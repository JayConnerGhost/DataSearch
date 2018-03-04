using DataSearch.Models;

namespace DataSearch.Services
{
    public interface IAuthorService
    {
        IAuthor GetAuthor(string authorName);
    }
}