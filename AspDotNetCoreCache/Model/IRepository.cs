using System.Collections.Generic;

namespace AspDotNetCoreCache.Model
{
    public interface IRepository
    {
        /// <summary>
        /// 模擬從DB取得資料
        /// </summary>
        /// <returns></returns>
        List<Book> GetBooks();

        int GetBooksCount();
    }
}