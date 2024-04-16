using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Models.Models;

namespace UserManagement.DataAccess.Data
{
    public class ApplicationDbContext
    {
        UserRepository _UserRepository;
        public List<User> Users { get; private set; }

        public ApplicationDbContext()
        { 
            _UserRepository = new UserRepository();
            Users = _UserRepository.GetUsers();

            if (Users.Count == 0)
                SeedData();
        }

        private void SeedData()
        {
            Users.Add(new User(1, "admin", "4dm1n", "Ad", "Min", DateTime.Now, "SkyNet", "SkyNet"));
            Users.Add(new User(2, "SuperUser", "Sup3rUs3r", "Super", "User", DateTime.Now, "Ether", "Ether"));
            Users.Add(new User(3, "user", "us3r", "Us", "Er", DateTime.Now, "Budapest", "Budapest"));
        }

        private void SaveChanges()
        {
            _UserRepository.SaveUsers(Users);
        }

        public void Add(User obj)
        {
            obj.Id = Users.Count + 1;
            if(Users.Find(x => x.Id == obj.Id) != null)
            {
                return;
            }

            Users.Add(obj);
            Commit();
        }

        public void Update(User obj)
        {
            int index = Users.FindIndex(u => u.Id == obj.Id);

            if(index != -1)
                Users[index] = obj;
            Commit();
        }

        public void Remove(User obj)
        {
            Users.Remove(obj);
            Commit();
        }

        public User Find(Func<User, bool> filter)
        {
            return Users.FirstOrDefault(filter);
        }

        public List<User> FindAll(Predicate<User> filter)
        {
            return Users.FindAll(filter);
        }

        private void Commit()
        {
            SaveChanges();
            Users = _UserRepository.GetUsers();
        }
    }
}
