using DataSearch.Models;
using DataSearch.Repositories;

namespace DataSearch.Services
{
    public class AuthorService:IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public IAuthor GetAuthor(string authorName)
        {
           return _repository.GetAuthor(authorName);
        }
    }
}
