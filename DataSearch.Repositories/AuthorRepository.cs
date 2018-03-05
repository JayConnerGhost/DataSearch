using System.Data.SqlClient;
using DataSearch.Models;

namespace DataSearch.Repositories
{
    public class AuthorRepository:IAuthorRepository
    {
        private readonly SqlConnection _connection;

        public AuthorRepository(SqlConnection connection)
        {
            _connection = connection;
        }


        public IAuthor GetAuthor(string authorName)
        {
            var authorLastName=string.Empty;
            _connection.Open();
            var cmdText = "select * from authors where au_fname='" + authorName + "'";
            var reader = new SqlCommand(cmdText, _connection).ExecuteReader();

            if (reader.Read())
            {

                authorLastName = reader.GetFieldValue<string>(1);
            }
            
            _connection.Close();

            return new Author()
            {
                LastName = authorLastName,
            };

        }
    }
}