using FullTextSearch.API.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Faker;
using System.ComponentModel.DataAnnotations;
using FullTextSearch.API.Models;

namespace FullTextSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookContext _context;
        private readonly ILogger<BooksController> _logger;

        public BooksController(BookContext context, ILogger<BooksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get([Required]string keyword, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(keyword) || string.IsNullOrEmpty(keyword))
            {
                return BadRequest("Keyword is empty");
            }
            keyword = keyword.Trim();

            var books = await _context.Book.AsNoTracking()
                //.Where(b => EF.Functions.Contains(b.Name, keyword) || EF.Functions.Contains(b.Description, keyword))
                .Where(b => EF.Functions.FreeText(b.Name, keyword) || EF.Functions.FreeText(b.Description, keyword))
                .ToListAsync(cancellationToken);
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMany([Required] int quantity, CancellationToken cancellationToken)
        {
            if (quantity <= 0)
            {
                return BadRequest();
            }

            var books = new List<Book>(quantity);
            for (int i = 0; i < quantity; i++)
            {
                books.Add(new Book
                {
                    Name = Faker.Company.Name(),
                    Description = Faker.Name.FullName()
                });
            }

            _context.AddRange(books);
            var affectedRows = await _context.SaveChangesAsync(cancellationToken);
            return Ok(affectedRows);
        }
    }
}
