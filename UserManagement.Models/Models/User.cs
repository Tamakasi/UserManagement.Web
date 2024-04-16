using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Models.Models
{
    public class User
    {
        //Azonosító, Felh.név, Jelszó, Vezetéknév, Keresztnév, Szül. idő, Szül. hely, Lakhely (város)
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string PlaceOfResidence { get; set; }

        public User() { }

        public User(int id, string userName, string password, string firstName, string lastName, DateTime dateOfBirth, string placeOfBirth, string placeOfResidence)
        {
            Id = id;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PlaceOfBirth = placeOfBirth;
            PlaceOfResidence = placeOfResidence;
        }

        public override string ToString()
        {
            return String.Concat(Id,";",UserName,";",Password,";",FirstName,";",LastName,";",DateOfBirth.ToString("yyyy-MM-dd"), ";",PlaceOfBirth,";",PlaceOfResidence);
        }
    }
}
