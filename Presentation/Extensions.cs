using Microsoft.Extensions.DependencyInjection;
using Presentation.Mappers;

namespace Presentation;

public static class Extensions
{
    public static void AddPresentationMappers(this IServiceCollection services)
    {
        services.AddSingleton<ISearchMapper, SearchMapper>();
    }
}