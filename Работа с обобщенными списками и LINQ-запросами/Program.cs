using System;

namespace MyApp 
{
        struct Users // структура для работы с обобщенным списком
        {
            public string surname; // фамилия
            public string name; // имя
            public string patronymic; // отчество
            public string telephone; // телефон
            public string password; // пароль
            public void show() 
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-20}", surname, name, patronymic, telephone, password);
            }
            public string concat() 
            {
                return surname + ";" + name + ";" + patronymic + ';' + telephone + ';' + password;
            }
        }
        internal class Program
        {
        static void getData(string path, List<Users> L) 
        {
            using (StreamReader sr = new StreamReader(path)) 
            {
                while(sr.EndOfStream!=true) 
                {
                    string[] ar = sr.ReadLine().Split(';'); 
                        L.Add(new Users()
                        {
                            surname = ar[0],
                            name = ar[1],
                            patronymic = ar[2],
                            telephone = ar[3],
                            password = ar[4]
                        }) ;
                }
            }
        }
        static void printData(List<Users> L) 
        {
        foreach (Users u in L)
            {
                u.show();
            }
        }
        static void inputData(string path, List<Users> L) 
        {
            using (StreamWriter sw = new StreamWriter(path, true)) 
            {
                foreach(Users u in L)
                {
                  sw.WriteLine(u.concat());
                }
            }
        }

        static void password()
        {

        }
                static void Main(string[] args)
                {

                List<Users> users = new List<Users>(); 
                     
                getData("users.csv", users);
                  
                    printData(users);
                   
                    Users us = new Users()
                    {
                        surname = "Иванов",
                        name = "Иван",
                        patronymic ="Иванович",
                        telephone = "8(908)234-57-57",
                        password = "12345"
                    };

           
                List<Users> userInput = new List<Users>(); 
                userInput.Add(us); 
                inputData("users.csv", userInput);
                // создание списка с людьми на И
                List<Users> peopleI = users.Where(x => x.surname.StartsWith("И")).ToList();



                List<Users> usersNEW = new List<Users>();
                userInput.Add(us);
                inputData("users.csv", userInput);
                // создание списка с людьми на Ф
                List<Users> peopleF = users.Where(x => x.surname.StartsWith("Ф")).ToList();


                // Операция объединения списков
                List<Users> L1 = users.Concat(userInput).ToList();



        }
    }
}

