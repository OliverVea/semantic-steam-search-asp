using Abstraction.Models;

namespace Presentation.Mappers;

public interface ISearchMapper
{
    SearchRequest Map(ViewModels.SearchRequest requestModel);
    ViewModels.SearchResult Map(SearchResult result);
}