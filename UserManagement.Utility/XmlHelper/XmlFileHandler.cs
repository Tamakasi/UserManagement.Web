using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Models.Models;

namespace UserManagement.Utility.XmlHelper
{
    public class XmlFileHandler
    {
        public static void WriteEntitiesToXMLFile(string fileName, List<User> entities)
        {
            if(string.IsNullOrEmpty(fileName))
            {
                //log and return with Result.Fail
                return;
            }

            if(entities == null) 
            {
                //log and return with Result.Fail
                return;
            }

            try
            {
                FileInfo file = new FileInfo(fileName + ".xml");

                using(StreamWriter sw = file.CreateText())
                {
                    var writer = new System.Xml.Serialization.XmlSerializer(typeof(List<User>));
                    writer.Serialize(sw, entities);
                }
            }
            catch(Exception ex)
            {
                //log
                return;
            }
            
        }
    }
}
