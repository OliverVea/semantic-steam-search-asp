using Abstraction.Models;

namespace Abstraction.Services;

public interface ISearchService
{
    SearchResult Search(SearchRequest request);
}