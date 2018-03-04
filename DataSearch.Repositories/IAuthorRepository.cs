using DataSearch.Models;

namespace DataSearch.Repositories
{
    public interface IAuthorRepository
    {
        IAuthor GetAuthor(string AuthorName);
    }
}