using System;
using System.Collections.Generic;

namespace AspDotNetCoreCache.Model
{
    public class Repository : IRepository
    {
        private readonly int _bookCount;

        public Repository()
        {
            // 取亂數決定回傳的資料量
            var ran= new Random();
            _bookCount = ran.Next(1, 51);
        }

        /// <summary>
        /// 模擬從DB取得資料
        /// </summary>
        /// <returns></returns>
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
                    Tag = GetBookTags()[tagIndex]
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
            return new List<string>()
            {
                "C#",
                "Linq",
                "Asp.Net",
                "Sql Server"
            };
        }
    }
}