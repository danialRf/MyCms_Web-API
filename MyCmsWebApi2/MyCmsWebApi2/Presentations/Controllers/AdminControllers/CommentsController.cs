using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Entities;

namespace MyCmsWebApi2.Presentations.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/admin/[controller]")]

    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentsController(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteCommentsById(int id)
        {
            if (await _commentRepository.CommentExist(id) == false)
                return NotFound();

            await _commentRepository.DeleteCommentByIdAsync(id);
            return Accepted();

        }
    }
}