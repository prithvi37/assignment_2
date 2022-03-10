using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace app4
{
    public class SignUp
    {
        public SignUp()
        {
            StudentDetails = new List<StudentDetail>();
        }
        public static List<StudentDetail> StudentDetails { get; set; }

        public static void GetStudentData()
        {
            StudentDetail student = new StudentDetail();

            Console.WriteLine("Enter the following details to Sign Up");

            Console.WriteLine("Enter StudentId");
            student.ID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Student Name:");
            student.Name = Console.ReadLine();

            Console.WriteLine("Enter Email id");
            student.Email = Console.ReadLine();

            Console.WriteLine("Enter Mobile Number");
            student.MobileNo = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            student.Password = Console.ReadLine();

            StoreStudentData(student);
            ProcessStudentToFile(StudentDetails);
        }

        public static void StoreStudentData(StudentDetail student)
        {
            StudentDetails = new List<StudentDetail>();
            StudentDetails.Add(student);
        }

        public static void ProcessStudentToFile(List<StudentDetail> students)
        {
            string strserialize = JsonConvert.SerializeObject(students);
            strserialize = string.Format("{0}{1}", (strserialize.TrimStart('[').TrimEnd(']')), ',');

            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "StudentData.json");
            using (Stream stream = new FileStream(path, FileMode.Append))
            {
                stream.Seek(0, SeekOrigin.Current);
                stream.Write(Encoding.ASCII.GetBytes(Environment.NewLine));
                stream.Write(Encoding.ASCII.GetBytes(strserialize), 0, Encoding.ASCII.GetBytes(strserialize).Length);
            }
            Console.WriteLine("Your Path for JSON File is : " + path);
            Console.WriteLine("Your JSON Data is : " + strserialize);
            StudentDetails.Clear();
        }
    }

    public class StudentDetail
    {
        public StudentDetail() { }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
    }
}
