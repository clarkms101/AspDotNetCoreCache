using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspDotNetCoreCache.Cache;
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
        private readonly RepositoryCache _repositoryCache;
        public List<Book> Books { get; set; }
        public int BooksCount { get; set; }
        public string BookTags { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IRepository repository, RepositoryCache repositoryCache)
        {
            _logger = logger;
            _repository = repository;
            _repositoryCache = repositoryCache;
        }

        public void OnGet()
        {
            Books = _repository.GetBooks();
            BooksCount = _repositoryCache.GetBooksCount();
            BookTags = _repositoryCache.GetBookTags();
        }
    }
}
