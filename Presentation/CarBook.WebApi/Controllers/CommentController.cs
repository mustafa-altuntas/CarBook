using CarBook.Aplication.Features.RepositoryPattern;
using CarBook.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;

        public CommentController(IGenericRepository<Comment> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _repository.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment([Bind("Name", "CreatedDate", "BlogID")] Comment comment)
        {
             _repository.Create(comment);
            return Ok("Yorum başarıyla eklendi.");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
             _repository.Update(comment);
            return Ok("Yorum başarıyla güncellendi.");
        }

        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            _repository.Remove(id);
            return Ok("Yorum başarıyla silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _repository.GetById(id);
            return Ok(value);
        }


        [HttpGet("CommentListByBlog")]
        public IActionResult CommentListByBlog(int id)
        {
            var value = _repository.GetCommentsByBlogId(id);
            return Ok(value);
        }

    }
}
