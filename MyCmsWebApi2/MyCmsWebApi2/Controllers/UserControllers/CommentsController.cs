
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.DataLayer.Repository;
using MyCmsWebApi2.Dtos.CommentsDto.Admin;
using Serilog;
using Serilog.Core;

namespace MyCmsWebApi2.Controllers.UserControllers
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
        public async Task<ActionResult<IEnumerable<AdminShowCommentsDto>>> GetAllCommentsAsync()
        {
            var result = await _commentRepository.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<AdminShowCommentsDto>> GetCommentsByIdAsync(int id)
        {
            var result = await _commentRepository.GetCommentByIdAsync(id);
            return Ok(result);
        }

    }
}
