using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using App3.ViewModels;
using KPI.Models;
using KPI.ViewModels;

namespace KPI.Classes
{

    public class Connection
    {

        StreamReader Reader = null;
        StreamWriter Writer = null;
        string host = "127.0.0.1";
        int port = 8888;

        public static Connection connection;
        public static Connection SetConnection(Connection con) => connection = con;
        public static Connection GetConnection() => connection;

        public void Connect()
        {

            TcpClient client = new TcpClient();
            try
            {
                client.Connect(host, port); //подключение клиента
                Reader = new StreamReader(client.GetStream());
                Writer = new StreamWriter(client.GetStream());
                if (Writer is null || Reader is null) return;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }

        }

        public int Login(string login, string password) 
        {
            string sendmsg = "login|&|" + login + "|&|" + password;
            Writer.WriteLine(sendmsg);
            Writer.Flush();
            int loginpram = 0;
            string recvmsg = Reader.ReadLine();
            string[] recvarr = recvmsg.Split('&');
            try
            {
                App.logineduserid = recvarr[1];
            }
            catch { }
            if (recvmsg.Contains("root")) { loginpram = 3; }
            if (recvmsg.Contains("meneger")) { loginpram = 2; }
            if (recvmsg.Contains("worker")) { loginpram = 1; }
            if (recvmsg.Contains("eror")) { loginpram = 0; }
            return loginpram;
        }

        public bool AddWorker(string login, string password, string name, string surname, string patronymic, string email, string telephone, string position, string salary)
        {
            string sendmsg = "add_worker|&|" + login + "|&|" + password + "|&|" + name + "|&|" + surname + "|&|" + patronymic + "|&|" + email + "|&|" + telephone + "|&|" + position + "|&|" + salary;
            Writer.WriteLine(sendmsg);
            Writer.Flush(); 
            
            bool AddSuccessfully = false;
            string recvmsg = Reader.ReadLine();
            if (recvmsg.Contains("true")) { AddSuccessfully = true; }
            if (recvmsg.Contains("false")) { AddSuccessfully = false; }
            return AddSuccessfully;
        }
        
        public ObservableCollection<Persons> GetWorkerPersons()
        {
            string sendmsg = "select_worker_persons|&|";
            Writer.WriteLine(sendmsg);
            Writer.Flush();

            ObservableCollection<Persons> persons = new ObservableCollection<Persons>();
            string[] recvarr;
            string recvmsg = Reader.ReadLine();
            int count = int.Parse(recvmsg);
            for (int i = 0; i < count; i++)
            {
                recvmsg = Reader.ReadLine();
                recvarr = recvmsg.Split('&');
                Persons person = new Persons();
                person.upid = int.Parse(recvarr[0]);
                person.uuid = int.Parse(recvarr[1]);
                person.name = recvarr[2];
                person.surname = recvarr[3];
                person.patronymic = recvarr[4];
                person.email = recvarr[5];
                person.telephone = recvarr[6];
                persons.Add(person);
            }
            return persons;
        }

        public object GetPerson(int uuid) 
        {
            Persons person = new Persons();

            string sendmsg = "select_person_by_uuid|&|" + uuid.ToString();
            Writer.WriteLine(sendmsg);
            Writer.Flush();

            string recvmsg = Reader.ReadLine();
            string[] recvarr = recvmsg.Split('&');

            person.upid = int.Parse(recvarr[0]);
            person.uuid = int.Parse(recvarr[1]);
            person.name = recvarr[2];
            person.surname = recvarr[3];
            person.patronymic = recvarr[4];
            person.email = recvarr[5];
            person.telephone = recvarr[6];

            return person;
        }

        public void DelPerson(int uuid)
        {
            string sendmsg = "delete_person_by_uuid|&|" + uuid.ToString();
            Writer.WriteLine(sendmsg);
            Writer.Flush();
        }

        public ObservableCollection<Task> GetTasks()
        {
            ObservableCollection<Task> tasks = new ObservableCollection<Task>();
            return tasks;
        }

        public void Disconnect()
        {
            string sendmsg = "exit|&|";
            Writer.WriteLine(sendmsg);
            Writer.Flush();

            Writer?.Close();
            Reader?.Close();
        }
    }
}
