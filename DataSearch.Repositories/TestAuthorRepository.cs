using System.Collections.Generic;
using DataSearch.Models;

namespace DataSearch.Repositories
{
    public class TestAuthorRepository:IAuthorRepository
    {
        private readonly List<IAuthor> _data;
        public TestAuthorRepository()
        {
            
            _data = new List<IAuthor>()
            {
                new Author()
                {
                    FirstName="Jessica",
                    LastName="Jones"
                }
            };
        }

        public IAuthor GetAuthor(string authorName)
        {
            return _data.Find(x=>x.FirstName == authorName);
        }
    }
}