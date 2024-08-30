using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Windows;

namespace project6
{
    public static class Data
    {
        static Data()
        {

        }
       
        public static List<Student> ToAdd(this List<Student> students,string name)
        {

            Student std = new Student();
            std.Name = name;
            students.Add(std);

            string folder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fullpath = System.IO.Path.Combine(folder, "Student", "Userdata.txt");
            if (!string.IsNullOrEmpty(name))
            {
                if (File.Exists(fullpath))
                {
                    string value = File.ReadAllText(fullpath);
                    List<Student> data = JsonConvert.DeserializeObject<List<Student>>(value);

                    if (value.Count() > 0)
                    {
                        students.AddRange(data);
                    }
                }
                string js = JsonConvert.SerializeObject(students);
                if (Directory.Exists(folder + "//Student"))
                {
                    File.WriteAllText(fullpath, js);
                }
                else
                {
                    Directory.CreateDirectory(folder + "//Student");
                    File.WriteAllText(fullpath, js);
                }
            }
            else
            {
                MessageBox.Show("Write the Name");
            }

            return students;
        }

        public static List<Student> List(this List<Student> students)
        {
            string folder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fullpath = System.IO.Path.Combine(folder, "Student", "Userdata.txt");
            if (File.Exists(fullpath))
            {
                string value = File.ReadAllText(fullpath);
                students = JsonConvert.DeserializeObject<List<Student>>(value);
            }
            return students;
        }
        public static List<Student> ToSearch(this List<Student> value, string name)
        {

            var search = from data in value
                         where data.Name.ToLower().Contains(name)
                         select data;
            List<Student> searchresult = new List<Student>();
            foreach (Student student in search)
            {
                searchresult.Add(student);
            }

            return searchresult;
        }
    }
    public class Student
    {
        public string Name { get; set; }
    }






}
