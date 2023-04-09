
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.DataLayer.Repository;
using MyCmsWebApi2.Dtos.CommentsDto;
using MyCmsWebApi2.Dtos.NewsGroupDto;
using MyCmsWebApi2.Dtos.NewsGroupDto.NewsGroupDto;
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


        public async Task<ActionResult<IEnumerable<ShowCommentsDto>>> GetAllCommentsAsync()
        {
           var result =  await _commentRepository.GetAllAsync();
            return Ok(result);
        }
        public async Task<ActionResult<ShowCommentsDto>> GetCommentsByIdAsync(int id)
        {
            var result = await _commentRepository.GetCommentByIdAsync(id);
            return Ok(result);
        }

    }
}
