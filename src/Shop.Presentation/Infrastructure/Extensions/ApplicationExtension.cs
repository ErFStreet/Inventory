namespace Shop.Presentation.Infrastructure.Extensions;

public static class ApplicationExtension
{
    /// <summary>
    /// Register application
    /// </summary>
    /// <param name="app"></param>
    public static void RegisterApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();

            app.UseSwaggerUI();
        }

        app.UseIpRateLimiting();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }

    /// <summary>
    /// Register data
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static void RegisterData(this WebApplication app)
    {
        try
        {
            using var scope = app.Services.CreateScope();

            using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var roleDbSet = dbContext.Set<Role>();

            if (roleDbSet.Any())
                return;

            var role = new Role("Admin");

            roleDbSet.Add(role);

            var saveRole =
                dbContext.SaveChanges();

            if (saveRole == 0) return;

            var userDbSet = dbContext.Set<User>();

            var user = new User(firstName: "Erfan",
                lastName: "Edalati",
                email: "erfannstreet@gmail.com",
                phone: "09305172457",
                password: "Jsj#29AKJAahn",
                roleId: role.Id);


            userDbSet.Add(user);

            dbContext.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }
}