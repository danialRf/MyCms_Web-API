using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Persistences.QueryFacade;
using MyCmsWebApi2.Presentations.Dtos.NewsDto;
using MyCmsWebApi2.Presentations.Dtos.NewsGroupDto.Admin;
using MyCmsWebApi2.Presentations.QueryFacade;

namespace MyCmsWebApi2.Presentations.Controllers.AdminControllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]

    public class AdminNewsGroupController : ControllerBase
    {
        private readonly INewsGroupRepository _newsGroupRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AdminNewsGroupController> _logger;
        private readonly INewsGroupQueryFacade _newsGroupQueryFacade;
        private readonly INewsQueryFacade _newsQueryFacade;


        public AdminNewsGroupController(INewsGroupRepository newsGroupRepository, IMapper mapper, ILogger<AdminNewsGroupController> logger, INewsQueryFacade newsQueryFacade, INewsGroupQueryFacade newsGroupqueryFacade)
        {
            _newsGroupRepository = newsGroupRepository ?? throw new ArgumentNullException(nameof(newsGroupRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
           
            _newsQueryFacade = newsQueryFacade;
            _newsGroupQueryFacade = newsGroupqueryFacade;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminNewsGroupDto>>> GetAllNewsGroupAsync()
        {
            var newsGroup = await _newsGroupQueryFacade.AdminGetAllNewsGroup();
            var result = _mapper.Map<List<AdminNewsGroupDto>>(newsGroup);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AdminNewsGroupDto>> GetNewsGroupById(int id)
        {
            //if (await _newsGroupRepository.IsExist(id) == false)
            //{
            //    return NotFound();
            //}


            //var result = await _newsGroupRepository.GetById(id);

            //return Ok(_mapper.Map<AdminNewsGroupDto>(result));

            return Ok(await _newsGroupQueryFacade.AdminGetNewsGroupById(id));

        }

        [HttpGet("NewsByGoupId/{id}")]
        public async Task<ActionResult<AdminNewsDto>> GetNewsByGroupIdAsync(int id)
        {
            return Ok(await _newsQueryFacade.AdminGetNewsByGroupId(id));

        }




        [HttpPost]
        public async Task<ActionResult<AdminNewsGroupDto>> PostNewsGroupAsync([FromBody] AdminAddNewsGroupDto newsGroupDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newsGroup = _mapper.Map<NewsGroup>(newsGroupDto);
            var result = await _newsGroupRepository.Create(newsGroup);

            _logger.LogInformation($"Create NewsGroup whit id {newsGroup.Id} ");
            return CreatedAtAction(nameof(GetNewsGroupById), new { id = newsGroup.Id }, newsGroup);
        }

        [HttpPut]
        public async Task<ActionResult> PutPageGroupAsync([FromForm] AdminEditNewsGroupDto newsGroupDto)
        {
            if (await _newsGroupRepository.IsExist(newsGroupDto.Id) == false)
            {
                _logger.LogInformation($"GroupTitle '{newsGroupDto.GroupTitle}' Not Found.");
                return NotFound();
            }


            if (newsGroupDto == null)
                return BadRequest();

            var newsGroup = _mapper.Map<NewsGroup>(newsGroupDto);
            var result = _newsGroupRepository.Update(newsGroup);

            _logger.LogInformation($"NewsGroup whit id {newsGroupDto.Id} was edited");
            return NoContent();

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNewsGroupAsync(int id)
        {
            if (await _newsGroupRepository.IsExist(id) == false)
            {
                return NotFound();
            }


            await _newsGroupRepository.Delete(id);

            _logger.LogInformation($"The NewsGroup whit ID {id} was Deleted");
            return Accepted();

        }

    }
}
