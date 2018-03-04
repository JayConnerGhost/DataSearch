using System;
using NSubstitute;
using Xunit;

namespace DataSearch.Tests
{
    public class FindAuthorSpecifications 
    {
        [Fact]
        public void Repository_is_called()
        {
            //arrange
            const string testAuthorName = "jesica";
            var repository = Substitute.For<IAuthorRepository>();
            
            //act
            var authorService = new AuthorService(repository);

            //assert
            authorService.GetAuthor(testAuthorName);
            repository.Received().GetAuthor(testAuthorName);
        }

        
    }

    public class AuthorService
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

    public class Author:IAuthor
    {
    }

    public interface IAuthor
    {
    }

    public interface IAuthorRepository
    {
        IAuthor GetAuthor(string AuthorName);
    }
}
