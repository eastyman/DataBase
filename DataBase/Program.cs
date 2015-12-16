using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            //получаем значение из ини файла
            string saveType = "";
            string path = "options.ini";
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                using (StreamReader sr = new StreamReader(path)) 
                {
                    saveType = sr.ReadToEnd(); 
                }                
            }
            else
            {
                Console.WriteLine("Файл настроек \"options.ini\" не найден! Программа завершает работу");
                return;
            }
            
            Driver driver = new Driver();
            switch (saveType)
            {
                case "BIN":
                    BINReader binRead = new BINReader();
                    BINWriter binWrite = new BINWriter();
                    driver.Reader = binRead;
                    driver.Writer = binWrite;
                    driver.FileName = "data.dat";
                    Console.WriteLine("Работаем с файлом BIN");
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadLine();
                    break;
                case "XML":
                    XMLReader xmlRead = new XMLReader();
                    XMLWriter xmlWrite = new XMLWriter();
                    driver.Reader = xmlRead;
                    driver.Writer = xmlWrite;
                    driver.FileName = "data.xml";
                    Console.WriteLine("Работаем с файлом XML");
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadLine();
                    break;
            }

            List<Employee> eList = new List<Employee>();
            driver.Read();
            if (driver.Data != null)
            {
                eList = driver.Data;
            }
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите \"help\" чтобы увидеть список доступных команд ! ");
                Console.Write("Введите команду: ");

                string[] commands = Console.ReadLine().Split(' ');

                if (commands[0].ToLower() == "exit" & commands.Length == 1)
                {
                    driver.Data = eList;
                    driver.Write();
                    return;
                }

                if (commands[0].ToLower() == "add" && commands.Length == 4)
                {
                    int age;
                    int count;
                    if (eList.Count > 0)
                    {
                        count = eList.Max(n => n.num);
                    }
                    else
                    {
                        count = 0;
                    }
                    
                    if (Int32.TryParse(commands[2], out age))
                    {                        
                        eList.Add(new Employee(count+1, commands[1], age, commands[3]));
                    }
                    else
                    {
                        Console.WriteLine("Неверно введен возраст");
                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadLine();
                    }
                }

                if (commands[0].ToLower() == "del" && commands.Length == 2)
                {
                    int num;
                    if (Int32.TryParse(commands[1], out num))
                    {
                       IEnumerable<int> res =
                       from t in eList
                       where t.num == num
                       orderby t
                       select eList.IndexOf(t);

                        foreach (int i in res)
                        {
                            eList.RemoveAt(i);
                        }
                    }
                    
                }
                if (commands[0].ToLower() == "view" && commands.Length == 2)
                {
                    int num;
                    if (Int32.TryParse(commands[1], out num))
                    {
                       var res =
                       from t in eList
                       where t.num == num
                       select new
                       {
                           num = t.num,
                           name = t.name,
                           age = t.age,
                           job = t.job
                       };

                        foreach (var emp in res)
                        {
                            Console.WriteLine("NUMBER: " + emp.num + " NAME: " + emp.name + " AGE: " + emp.age + " JOB: " + emp.job);
                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                            Console.ReadLine();
                        }             
                        
                    }
                    else
                    {
                        Console.WriteLine("Неверно введен номер сотрудника");
                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadLine();
                    }                    
                    
                }

                if (commands[0].ToLower() == "list")
                {
                    foreach (var emp in eList)
                    {
                        Console.WriteLine("NUMBER: " + emp.num+" NAME: "+emp.name+" AGE: "+emp.age);
                    }
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadLine();
                }
                if (commands[0].ToLower() == "help")
                {
                    Help();
                }
            }    
        }

        private static void Help()
        {
            Console.WriteLine("Доступные команды:");            
            Console.WriteLine("\tadd empName empAge empJob");
            Console.WriteLine("\tdel empNum");
            Console.WriteLine("\tview empNum");
            Console.WriteLine("\tlist");
            Console.WriteLine("\texit");  
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();
        }
    }
}
