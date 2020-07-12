using System;
using System.Collections.Generic;

namespace AspDotNetCoreCache.Model
{
    /// <summary>
    /// 模擬從DB取得資料
    /// </summary>
    public class Repository : IRepository
    {
        private readonly int _bookCount;
        private readonly List<string> _bookTags;

        public Repository()
        {
            // 取亂數決定回傳的資料量
            var ran= new Random();
            _bookCount = ran.Next(1, 51);
            _bookTags = new List<string>()
            {
                "C#",
                "Linq",
                "Asp.Net",
                "Sql Server"
            };
        }

        public List<Book> GetBooks()
        {
            var books = new List<Book>();
            for (var i = 1; i <= _bookCount; i++)
            {
                var ran= new Random();
                var tagIndex = ran.Next(0, 4);
                var book = new Book
                {
                    Id = i,
                    Name = $"測試{i}",
                    Tag = _bookTags[tagIndex]
                };
                books.Add(book);
            }
            return books;
        }

        public int GetBooksCount()
        {
            return _bookCount;
        }

        public List<string> GetBookTags()
        {
            return _bookTags;
        }
    }
}