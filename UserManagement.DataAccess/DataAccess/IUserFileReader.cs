using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Models.Models;

namespace UserManagement.DataAccess.DataAccess
{
    public interface IUserFileReader
    {
        public List<User> GetUsersFromFile(string fileName);
    }
}
