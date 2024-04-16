using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Models.Models;

namespace UserManagement.DataAccess.Data
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        public User GetUserById(int id);
    }
}
