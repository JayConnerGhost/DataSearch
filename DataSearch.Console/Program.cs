using System.Data.SqlClient;
using DataSearch.Models;
using DataSearch.Repositories;
using DataSearch.Services;
using Unity.Lifetime;
using Unity; 
    
namespace DataSearch.Console
{
    class Program
    {
        private static UnityContainer _container;

        static void Main(string[] args)
        {
            Construction();
            var authorFirstName =PromptForAuthorFirstName();
            var author = RetreiveAuthor(_container, authorFirstName);
            author.FirstName = authorFirstName;
            DisplayAuthorName(author);
        }

        private static void DisplayAuthorName(IAuthor author)
        {
           System.Console.WriteLine(author.LastName+ " "+ author.FirstName);
            System.Console.ReadKey();
        }

        private static IAuthor RetreiveAuthor(UnityContainer container, string authorFirstName)
        {
          return container.Resolve<IAuthorService>().GetAuthor(authorFirstName);
        }

        private static string PromptForAuthorFirstName()
        {
            System.Console.WriteLine("Please enter Author To Search for");
            return System.Console.ReadLine();
        }

        private static void Construction()
        {
            _container = new Unity.UnityContainer();
            var repository= new AuthorRepository(new SqlConnection("Server = localhost; Database = pubs; Trusted_Connection = True;"));
            _container.RegisterInstance<IAuthorRepository>(repository);
            _container.RegisterType<IAuthorService, AuthorService>(new PerThreadLifetimeManager());
        }
    }
}
