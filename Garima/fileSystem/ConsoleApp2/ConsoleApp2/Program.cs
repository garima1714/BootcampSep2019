using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                String path = @"C:\Users\garima.sharma\Documents\File.txt";
                Console.Clear();
                Menu();
                Console.WriteLine("\n");
                Console.Write("\nSelect option (8 for exit): ");
                var selectedOptionString = Console.ReadLine();
                int.TryParse(selectedOptionString, out var selectedOption);

                Console.WriteLine("\n");

                if (selectedOption == 8)
                {
                    break;
                }

                switch (selectedOption)
                {
                    case 1:
                        ViewAllStudents(path);
                        break;
                    case 2:
                        FileStream x = new FileStream(path, FileMode.Append, FileAccess.Write);
                        StreamWriter xx = new StreamWriter(x);
                        String add = AddNewStudent();
                        xx.WriteLine(add);
                        xx.Close();
                        x.Close();
                        break;
                    case 3:
                        UpdateStudentDetails(path);
                        break;
                    case 4:
                        DeleteStudentDetails(path);
                        break;
                    case 5:
                        SearchStudentByName(path);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n User input is invalid.");
                        break;
                }

                Console.WriteLine("\nConsole any key to show MENU");
                Console.ReadLine();

            } while (true);
        }

        private static void Menu()
        {
            Console.WriteLine("Options:");
            Console.WriteLine("1. View all students");
            Console.WriteLine("2. Add new student");
            Console.WriteLine("3. Update student details");
            Console.WriteLine("4. Delete student details");
            Console.WriteLine("5. Search student by name");
        }

        private static void ViewAllStudents(String path)
        {
            String[] len = File.ReadAllLines(path);

            for(int i = 0; i < len.Length; i++)
            {
                Console.WriteLine(len[i]);
            }
        }

        private static String AddNewStudent()
        {
            String str = "";
            Console.WriteLine("Studentid");
            String id = Console.ReadLine();
            str = str + id + ",";
            Console.WriteLine("FirstName");
            String fname = Console.ReadLine();
            str = str + fname + ",";
            Console.WriteLine("LastName");
            String lname = Console.ReadLine();
            str = str + lname + ",";
            Console.WriteLine("City");
            String city = Console.ReadLine();
            str = str + city + ",";
            Console.WriteLine("State");
            String state = Console.ReadLine();
            str = str + state + ",";
            return str;
        }

        private static void UpdateStudentDetails(string path)
        {
            string[] line = File.ReadAllLines(path);
            string str = "";
            Console.WriteLine("Studentid");
            String id = Console.ReadLine();
            str = str + id + ",";
            Console.WriteLine("FirstName");
            String fname = Console.ReadLine();
            str = str + fname + ",";
            Console.WriteLine("LastName");
            String lname = Console.ReadLine();
            str = str + lname + ",";
            Console.WriteLine("City");
            String city = Console.ReadLine();
            str = str + city + ",";
            Console.WriteLine("State");
            String state = Console.ReadLine();
            str = str + state + ",";

            string str1 = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i].Contains(id))
                {
                    str1 += str;
                }
                else
                {
                    str += line[i] + Environment.NewLine;
                }
            }
            File.WriteAllText(path, str1);
            Console.WriteLine("Student details updated", id);

        }

        private static void DeleteStudentDetails(string path)
        {
            string[] line = File.ReadAllLines(path);
            Console.WriteLine("Enter id to delete:");
            string id = Console.ReadLine();

            string str = "";

            for( int i=0; i<line.Length; i++)
            {
                if(!line[i].Contains(id))
                {
                    str += line[i] + Environment.NewLine;
                }
            }
            File.WriteAllText(path, str);
            Console.WriteLine("Student details id {0} deleted", id);
        }

        private static void SearchStudentByName(string path)
        {
            string[] search = File.ReadAllLines(path);
            Console.WriteLine("Enter name");
            string find = Console.ReadLine();
            Boolean flag = false;
            for (int i=0;i < search.Length; i++)
            {
                if(search[i].Contains(find)==true)
                {
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                }
            }
            if(flag == true)
            {
                Console.Write("Record found");
            }
            else
            {
                Console.Write("No Record Found");
            }
        }
    }
}