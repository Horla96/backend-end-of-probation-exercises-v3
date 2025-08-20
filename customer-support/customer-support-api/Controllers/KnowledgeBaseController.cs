using customer_support_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace customer_support_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeBaseController : ControllerBase
    {
        private static readonly List<KnowledgeBaseArticle> _articles = new();


        [HttpPost]
        public IActionResult Add(KnowledgeBaseArticle article)
        {
            _articles.Add(article);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_articles);

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string query)
        {
            var results = _articles.Where(s => s.Title.Contains(query, StringComparison.OrdinalIgnoreCase) || s.Content.Contains(query, StringComparison.OrdinalIgnoreCase));

            return Ok(results);
        }


    }
}
