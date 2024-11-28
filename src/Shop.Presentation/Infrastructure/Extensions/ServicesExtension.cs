

namespace Shop.Presentation.Infrastructure.Extensions;

public static class ServicesExtension
{
    /// <summary>
    /// Register services
    /// </summary>
    /// <param name="services"></param>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        services.AddControllers();
    }

    /// <summary>
    /// Register database
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void RegisterDatabase(this IServiceCollection services,
        IConfiguration configuration)
        => services.AddDbContext<ApplicationDbContext>(current =>
        {
            current.UseSqlServer(configuration["DatabaseSettings:ConnectionString"]);
        });


    /// <summary>
    /// Register api versioning
    /// </summary>
    /// <param name="services"></param>
    public static void RegisterApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);

            options.ReportApiVersions = true;

            options.AssumeDefaultVersionWhenUnspecified = true;

            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version"));
        });
    }

    /// <summary>
    /// Register dependencies
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void RegisterDependencyInjectionAndOptions(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddSingleton<ITokenHandler, Shop.Application.Common.SecurityHelper.TokenHandler>();

        services.AddValidatorsFromAssembly(typeof(IAssembly).Assembly);

        services.AddMediatR(current =>
        {
            current.RegisterServicesFromAssembly(typeof(IAssembly).Assembly);

            current.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
    }

    /// <summary>
    /// Register auth
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void RegisterAuthentication(this IServiceCollection services,
         IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters =
                new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(configuration["JwtSetting:SecretKey"]!))
                };
        });
    }

    /// <summary>
    /// Add rate limit
    /// </summary>
    /// <param name="services"></param>
    public static void RegisterRateLimit(this IServiceCollection services)

    {
        services.AddMemoryCache();

        services.Configure<IpRateLimitOptions>(options =>
        {
            options.EnableEndpointRateLimiting = true;
            options.StackBlockedRequests = false;
            options.HttpStatusCode = 429;
            options.RealIpHeader = "X-Real-IP";
            options.ClientIdHeader = "X-ClientId";
            options.GeneralRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint = "*",
                    Period = "10s",
                    Limit = 2,
                }
            };
        });

        services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
        services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
        services.AddInMemoryRateLimiting();
    }
}