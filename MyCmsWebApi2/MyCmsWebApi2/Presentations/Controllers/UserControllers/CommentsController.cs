using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Presentations.Dtos.CommentsDto.Admin;

namespace MyCmsWebApi2.Presentations.Controllers.UserControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        public CommentsController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminCommentsDto>>> GetAllCommentsAsync()
        {
            var result = await _commentRepository.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<AdminCommentsDto>> GetCommentsByIdAsync(int id)
        {
            var result = await _commentRepository.GetCommentByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
