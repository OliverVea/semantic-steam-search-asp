using Abstraction.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Mappers;

namespace Presentation.Controllers;

[ApiController]
public class SearchController : ControllerBase
{
    private readonly ISearchService _service;
    private readonly ISearchMapper _mapper;

    public SearchController(ISearchMapper mapper, ISearchService service)
    {
        _mapper = mapper;
        _service = service;
    }
    
    /// <summary>
    /// Used for searching steam games.
    /// </summary>
    /// <param name="requestModel">Contains the parameters of the search request.</param>
    /// <returns></returns>
    [HttpPost("search")]
    public ActionResult<ViewModels.SearchResult> Search(ViewModels.SearchRequest requestModel)
    {
        var request = _mapper.Map(requestModel);
        var response = _service.Search(request);
        return _mapper.Map(response);
    }
}