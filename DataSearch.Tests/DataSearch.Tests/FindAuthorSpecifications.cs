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
}