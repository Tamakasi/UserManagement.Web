using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UserManagement.DataAccess.DataAccess;
using UserManagement.Models.Models;

namespace UserManagement.DataAccess.Data
{
    public class UserRepository : IUserRepository
    {
        UserFileHandler _handler;

        public UserRepository()
        {
            _handler = new UserFileHandler();
        }

        public List<User> GetUsers()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "UserData.txt");
            if (File.Exists(filePath))
                return _handler.GetUsersFromFile(filePath);
            else return new List<User>();
        }

        public User GetUserById(int id)
        {
            return this.GetUsers().FirstOrDefault(x => x.Id == id);
        }

        public void SaveUsers(List<User> users)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "UserData.txt");
            _handler.WriteUsersToFile(filePath, users);
        }
    }
}
