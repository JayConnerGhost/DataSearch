using DataSearch.Repositories;
using DataSearch.Services;
using FluentAssertions;
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

        [Fact]
        public void Can_find_author_by_firstName()
        {
            //assign
            const string testFirstName="Jessica";
            const string testLastName = "Jones";
            var repository = new TestAuthorRepository();
            var service=new AuthorService(repository);
            
            //act
            var author=service.GetAuthor(testFirstName);

            //assert
            author.FirstName.Should().Be(testFirstName);
            author.LastName.Should().Be(testLastName);
        }
        
    }
}