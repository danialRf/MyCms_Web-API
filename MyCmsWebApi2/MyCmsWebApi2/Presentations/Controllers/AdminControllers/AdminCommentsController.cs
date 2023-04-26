using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.Applications.Commands.Comments;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Enums;
using MyCmsWebApi2.Infrastructure.Extensions;
using MyCmsWebApi2.Presentations.Dtos.CommentsDto.Admin;
using MyCmsWebApi2.Presentations.QueryFacade;

namespace MyCmsWebApi2.Presentations.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/admin/[controller]")]

    public class AdminCommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<AdminCommentsController> _logger;
        private readonly ICommentQueryFacade _commentQueryFacade;
        private readonly INewsRepository _newsRepository;

        public AdminCommentsController(ICommentRepository commentRepository, IMapper mapper, IMediator mediator, ILogger<AdminCommentsController> logger, ICommentQueryFacade commentQueryFacade, INewsRepository newsRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
            _commentQueryFacade = commentQueryFacade;
            _newsRepository = newsRepository;
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

        [HttpGet("Unverified")]
        public async Task<ActionResult<IEnumerable<AdminCommentsDto>>> GetAllUnverifiedComments()
        {

            var comment = await _commentQueryFacade.AdminGetAllUnverifiedComments();
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


        [HttpPost("{id}/comment")]
        [ProducesResponseType(typeof(SingleValue<Guid>), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostComment(int id, [FromBody] AdminAddCommentsDto commentDto)
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
            command.CommentStatus = CommentStatus.Accepted;
            command.NewsId = id;
            var result = await _mediator.Send(command);

            _logger.LogInformation($"Create Comment with resultId = {result} ");
            return new ObjectResult(new SingleValue<int>(result)) { StatusCode = StatusCodes.Status201Created };

        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> ChangeCommentStatus(int id, [FromBody] AdminChangeCommentStatusDto newStatus)
        {
            var comment = await _commentRepository.GetById(id);
            if (comment == null)
            {
                _logger.LogInformation($"Comment with ID {id} not found");
                return NotFound();
            }

            comment.CommentStatus = newStatus.CommentStatus;
            await _commentRepository.Update(comment);

            _logger.LogInformation($"Comment status updated for comment with ID {id} to {newStatus}");
            return NoContent();
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
