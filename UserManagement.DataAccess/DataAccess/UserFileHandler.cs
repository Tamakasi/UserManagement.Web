using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Models.Models;

namespace UserManagement.DataAccess.DataAccess
{
    public class UserFileHandler : IUserFileReader, IUserFileWriter
    {
        public List<User> GetUsersFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                return null;

            string? line;
            List<User> listOfPersons = new List<User>();

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        try
                        {
                            string[] words = line.Split(';');
                            listOfPersons.Add(new User(int.Parse(words[0]), words[1], words[2], words[3], words[4], DateTime.Parse(words[5]), words[6], words[7]));
                        }
                        catch
                        {
                            //Logging
                            continue;
                        }
                    }
                }
            }
            catch
            {
                //Logging
            }

            return listOfPersons;
        }

        public void WriteUsersToFile(string fileName, List<User> users)
        {
            try
            {
                if(File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (User user in users)
                    {
                        writer.WriteLine(user.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                //Logging
            }
        }
    }
}
