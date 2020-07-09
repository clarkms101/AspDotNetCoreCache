using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspDotNetCoreCache.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AspDotNetCoreCache.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRepository _repository;
        public List<Book> Books { get; set; }
        public int BooksCount { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public void OnGet()
        {
            Books = _repository.GetBooks();
            BooksCount = _repository.GetBooksCount();
        }
    }
}
