using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app4
{
    public class Login
    {
        public Login() { }

        public static int ID { get; set; }
        public static string Password { get; set; }


        public static void StudentLogin()
        {
            Console.WriteLine("Enter your Login Details\n");

            Console.WriteLine("\nEnter StudentId");
            ID = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Password:");
            Password = Console.ReadLine();

            GetStudentDetailFromFile();

        }

        public static void GetStudentDetailFromFile()
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "StudentData.json");
            try
            {
                using (StreamReader stream = new StreamReader(path))
                {
                    string fileData = stream.ReadToEnd().TrimEnd(',');
                    fileData = string.Format("{0}{1}{2}", '[', fileData, ']');
                    List<StudentDetail> list = JsonConvert.DeserializeObject<List<StudentDetail>>(fileData);
                    var cnt = 0;

                    foreach(var item in list)
                    {
                        if(item.ID == ID && item.Password == Password)
                        {
                            Console.WriteLine("\n\nYour Data Is : \n");
                            Console.WriteLine(string.Format("ID : {0}\n", item.ID));
                            Console.WriteLine(string.Format("Name : {0}\n", item.Name));
                            Console.WriteLine(string.Format("Email : {0}\n", item.Email));
                            Console.WriteLine(string.Format("MobileNo : {0}\n\n\n\n", item.MobileNo));
                            cnt = 1;
                        }
                    }
                    if (cnt != 1)
                        Console.WriteLine("Your IDs Data doesn't Exits");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
    }
}
