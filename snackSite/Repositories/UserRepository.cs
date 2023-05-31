using System.Data;
using System.Collections;
using Dapper;
using snackSite.Models;

namespace snackSite.Repositories
{
    public class UserRepository
    {
        private IDbConnection GetConnection()
        {
            return new DbUtils().GetDbConnection();
        }

        // add user after register
        public User Add(string username, string password)
        {
            using var connection = GetConnection();

            // TODO: create sql string to add user after register
            string sql = @"SQL STRING";

            var parameters = new { Name = username, Password = password };
            var user = connection.QuerySingle<User>(sql, parameters);
            return user;
        }

        public User Get(string email)
        {
            using var connection = GetConnection();

            // TODO: create sql string to get user by email
            string sql = @"SQL STRING";
            var parameters = new { email };

            var user = connection.QuerySingleOrDefault<User>(sql, parameters);
            return user;
        }
    }
}