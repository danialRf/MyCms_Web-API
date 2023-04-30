using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.Applications.Commands.CommentsCommand;
using MyCmsWebApi2.Applications.Notifications;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Infrastructure.Extensions;
using MyCmsWebApi2.Persistences.QueryFacade;
using MyCmsWebApi2.Persistences.Repositories;
using MyCmsWebApi2.Presentations.Dtos.CommentsDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.NewsDto;
using MyCmsWebApi2.Presentations.Dtos.NewsDto.Admin;
using MyCmsWebApi2.Presentations.QueryFacade;

namespace MyCmsWebApi2.Presentations.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/admin/[controller]")]

    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<CommentsController> _logger;
        private readonly ICommentQueryFacade _commentQueryFacade;

        public CommentsController(ICommentRepository commentRepository, IMapper mapper, IMediator mediator, ILogger<CommentsController> logger, ICommentQueryFacade commentQueryFacade)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
            _commentQueryFacade = commentQueryFacade;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminCommentsDto>>> GetAllComments()
        {

            var comment = await _commentQueryFacade.AdminGetAllComments();
            if (comment == null)
            {
                _logger.LogInformation($"There is not news");
                return NotFound();
            }
            var commentDto = _mapper.Map<List<AdminCommentsDto>>(comment);

            return Ok(commentDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminCommentsDto>> GetCommentById(int id)
        {
            var result = await _commentQueryFacade.AdminGetCommentById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
      

        [HttpPost]
        [ProducesResponseType(typeof(SingleValue<int>), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostComment([FromBody] AdminAddCommentsDto commentDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = _mapper.Map<AddCommentCommand>(commentDto);

            var result = await _mediator.Send(command);

            _logger.LogInformation($"Create Comment with resultId = {result} ");
            return new ObjectResult(new SingleValue<int>(result)) { StatusCode = StatusCodes.Status201Created };

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {

            if (await _commentRepository.IsExist(id) == false)
                return NotFound();

            await _commentRepository.Delete(id);

            _logger.LogInformation($"The Comment whit ID {id} was Deleted");
            return Accepted();

        }

    }
}
