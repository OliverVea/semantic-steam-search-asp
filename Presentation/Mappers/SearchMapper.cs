using Abstraction.Models;

namespace Presentation.Mappers;

public class SearchMapper : ISearchMapper
{
    public SearchRequest Map(ViewModels.SearchRequest requestModel)
    {
        return new SearchRequest
        {

        };
    }

    public ViewModels.SearchResult Map(SearchResult result)
    {
        return new ViewModels.SearchResult
        {
            
        };
    }
}