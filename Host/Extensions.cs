using System.Text.Json.Serialization;
using Presentation;

namespace Host;

public static class Extensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        
        services.AddSwaggerGen(options =>
        {
            options.UseAllOfToExtendReferenceSchemas();
            var libFiles = Directory.EnumerateFiles(AppContext.BaseDirectory, "*.xml");
            foreach (var libFile in libFiles) options.IncludeXmlComments(libFile);
        });

        services.AddPresentationMappers();
    }

    public static void ConfigureApplication(this WebApplication app)
    {
        app.Logger.LogInformation("App is in development: {Development}", app.Environment.IsDevelopment());

        app = app.Environment.IsDevelopment() switch
        {
            true => (WebApplication)app.UseDeveloperExceptionPage(),
            false => app.ConfigureForProduction()
        };

        app.ConfigureSwagger();

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    private static WebApplication ConfigureForProduction(this WebApplication app)
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();

        return app;
    }

    private static void ConfigureSwagger(this WebApplication app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Semantic Search Search API");
        });
    }
}