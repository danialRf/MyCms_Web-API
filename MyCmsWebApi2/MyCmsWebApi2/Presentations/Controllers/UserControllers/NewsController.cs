using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.Applications.Commands.Comments;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Infrastructure.Extensions;
using MyCmsWebApi2.Presentations.Controllers.AdminControllers;
using MyCmsWebApi2.Presentations.Dtos.CommentsDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.CommentsDto.User;
using MyCmsWebApi2.Presentations.Dtos.NewsDto.Admin;
using MyCmsWebApi2.Presentations.QueryFacade;

namespace MyCmsWebApi2.Presentations.Dtos.NewsDto.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _newsRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AdminNewsController> _logger;
        private readonly INewsGroupRepository _newsGroupRepository;
        private readonly INewsQueryFacade _newsQueryFacade;
        private readonly IMediator _mediator;
        public NewsController(INewsRepository newsRepository, IMapper mapper, ILogger<AdminNewsController> logger, ICommentRepository commentRepository, INewsGroupRepository newsGroupRepository, INewsQueryFacade newsQueryFacade, IMediator mediator)
        {
            _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _commentRepository = commentRepository;
            _newsGroupRepository = newsGroupRepository;
            _newsQueryFacade = newsQueryFacade;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserNewsDto>>> GetAllNewsAsync()
        {

            var news = await _newsQueryFacade.UserGetAllNews();
            var newsDto = _mapper.Map<List<UserNewsDto>>(news);
            return Ok(newsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserNewsByIdDto>> GetNewsById(int id)
        {
            var result = await _newsQueryFacade.UserGetNewsById(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }

        }
        [HttpGet("{id}/comments")]
        public async Task<ActionResult<List<Comment>>> GetCommentsByNewsId(int id)
        {
            return await _commentRepository.GetCommentsByNewsId(id);
        }

        [HttpGet("{id}/newsgroup")]
        public async Task<ActionResult<UserNewsDto>> GetNewsByGroupIdAsync(int id)
        {
            return Ok(await _newsQueryFacade.UserGetNewsByGroupId(id));

        }

        [HttpPost("{id}/comment")]
        [ProducesResponseType(typeof(SingleValue<Guid>), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostComment(int id,[FromBody] UserAddCommentDto commentDto)
        {
            if (await _newsRepository.IsExist(id) == false)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = _mapper.Map<AddCommentCommand>(commentDto);
            command.NewsId = id;
            var result = await _mediator.Send(command);

            _logger.LogInformation($"Create Comment with resultId = {result} ");
            return new ObjectResult(new SingleValue<int>(result)) { StatusCode = StatusCodes.Status201Created };

        }

        [HttpGet("top")]
        public async Task<ActionResult<IEnumerable<TopNewsDto>>> GetTopNewsAsync()
        {
            var news = await _newsQueryFacade.GetTopNews();
           
            return Ok(news);
        }
    }
}
