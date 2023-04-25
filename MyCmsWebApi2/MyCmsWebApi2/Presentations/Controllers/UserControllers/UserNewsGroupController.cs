using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Presentations.Dtos.NewsDto;
using MyCmsWebApi2.Presentations.Dtos.NewsGroupDto.Users;
using MyCmsWebApi2.Presentations.QueryFacade;

namespace MyCmsWebApi2.Presentations.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserNewsGroupController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UserNewsGroupController> _logger;
        private readonly INewsGroupQueryFacade _newsGroupQueryFacade;
      
        public UserNewsGroupController(IMapper mapper, ILogger<UserNewsGroupController> logger, INewsGroupQueryFacade newsGroupQueryFacade)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _newsGroupQueryFacade = newsGroupQueryFacade;
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserNewsGroupDto>>> GetAllNewsGroup()
        {
            var newsGroup = await _newsGroupQueryFacade.UserGetAllNewsGroup();    
            if (newsGroup == null)
            {
                _logger.LogInformation($"There is not newsGroup");
                return NotFound();
            }
            return Ok(_mapper.Map<List<UserNewsGroupDto>>(newsGroup));
        }
        

    }
}
