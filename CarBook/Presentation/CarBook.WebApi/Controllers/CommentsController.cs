using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentsRepository;

        public CommentsController(IGenericRepository<Comment> commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentsRepository.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _commentsRepository.Create(comment);
            return Ok("Yorum başarıyla eklendi!");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentsRepository.Update(comment);
            return Ok("Yorum başarıyla güncellendi!");
        }

        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var values = _commentsRepository.GetById(id);
            _commentsRepository.Remove(values);
            return Ok("Yorum başarıyla silindi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value =_commentsRepository.GetById(id);
            return Ok(value);
        }
    }
}
