using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Xml.Linq;
using App3.ViewModels;
using KPI.Models;
using KPI.ViewModels;
using KPI.Views;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Essentials;

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
            if (recvmsg.Contains("root")) { loginpram = 3; PersonPage.isMeneger = true; }
            if (recvmsg.Contains("meneger")) { loginpram = 2; PersonPage.isMeneger = true; }
            if (recvmsg.Contains("worker")) { loginpram = 1; PersonPage.isMeneger = false; }
            if (recvmsg.Contains("eror")) { loginpram = 0; }
            return loginpram;
        }

        public bool AddPerson(string login, string password, string name, string surname, string patronymic, string email, string telephone, string position, string salary)
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

        public void Update(string uuid, string name, string surname, string patronymic, string email, string telephone, string salary)
        {
            string sendmsg = "update_by_uuid|&|" + uuid + "|&|" + name + "|&|" + surname + "|&|" + patronymic + "|&|" + email + "|&|" + telephone + "|&|" + salary;
            Writer.WriteLine(sendmsg);
            Writer.Flush();
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
                person.ueid = int.Parse(recvarr[2]);
                person.name = recvarr[3];
                person.surname = recvarr[4];
                person.patronymic = recvarr[5];
                person.email = recvarr[6];
                person.telephone = recvarr[7];
                person.salry = double.Parse(recvarr[8]);
                if (recvarr[9] != "")
                {
                    person.award = double.Parse(recvarr[9]);
                }
                else person.award = 0;
                persons.Add(person);
            }
            return persons;
        }

        public ObservableCollection<Persons> GetMenegerPersons()
        {
            string sendmsg = "select_meneger_persons|&|";
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
                person.ueid = int.Parse(recvarr[2]);
                person.name = recvarr[3];
                person.surname = recvarr[4];
                person.patronymic = recvarr[5];
                person.email = recvarr[6];
                person.telephone = recvarr[7];
                person.salry = double.Parse(recvarr[8]);
                if (recvarr[9] != "")
                {
                    person.award = double.Parse(recvarr[9]);
                }
                else person.award = 0;
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
            person.ueid = int.Parse(recvarr[2]);
            person.name = recvarr[3];
            person.surname = recvarr[4];
            person.patronymic = recvarr[5];
            person.salry = double.Parse(recvarr[6]);
            if (recvarr[7] != "")
            {
                person.award = double.Parse(recvarr[7]);
            }
            else person.award = 0;
            person.email = recvarr[8];
            person.telephone = recvarr[9];

            return person;
        }

        public void DelPerson(int uuid)
        {
            string sendmsg = "delete_person_by_uuid|&|" + uuid.ToString();
            Writer.WriteLine(sendmsg);
            Writer.Flush();
        }

        public void AddTask(int uuid, int upid, int ueid, string task_text, int count_to_do, string start_date, string end_date)
        {
            string sendmsg = "add_task|&|" + uuid + "|&|" + upid + "|&|" + ueid + "|&|" + task_text + "|&|" + count_to_do + "|&|" + 0 + "|&|" + start_date + "|&|" + end_date;
            Writer.WriteLine(sendmsg);
            Writer.Flush();
        }

        public ObservableCollection<PersonTask> GetTasks(int uuid)
        {
            string sendmsg = "select_task_by_uuid|&|" + uuid.ToString();
            Writer.WriteLine(sendmsg);
            Writer.Flush();

            ObservableCollection<PersonTask> tasks = new ObservableCollection<PersonTask>();
            string[] recvarr;
            string recvmsg = Reader.ReadLine();
            int count = int.Parse(recvmsg);
            for (int i = 0; i < count; i++)
            {
                recvmsg = Reader.ReadLine();
                recvarr = recvmsg.Split('&');

                PersonTask task = new PersonTask();
                task.utid = int.Parse(recvarr[0]);
                task.ueid = int.Parse(recvarr[1]);
                task.uuid = int.Parse(recvarr[2]);
                task.upid = int.Parse(recvarr[3]);
                task.task_Text = recvarr[4];
                task.count_to_do = int.Parse(recvarr[5]);
                task.task_start_date = DateTime.ParseExact(recvarr[6].ToString(), "dd.MM.yyyy", null);
                task.task_end_date = DateTime.ParseExact(recvarr[7].ToString(), "dd.MM.yyyy", null);
                task.count_of_complited = int.Parse(recvarr[8]);

                tasks.Add(task);
            }
            return tasks;
        }

        public void UpdateTask(int utid, int uuid, string compl)
        {
            string sendmsg = "update_task|&|" + utid + "|&|" + uuid + "|&|" + compl;
            Writer.WriteLine(sendmsg);
            Writer.Flush();
        }

        public List<double> KPI (int uuid, double salary)
        {
            double tmp1 = 0, tmp2 = 0;
            string[] recvarr;
            string recvmsg;
            string sendmsg = "kpi|&|" + uuid + "|&|" + salary;
            Writer.WriteLine(sendmsg);
            Writer.Flush();

            List<double> ret = new List<double>();
            recvmsg = Reader.ReadLine();
            recvarr = recvmsg.Split('&');

            if (recvarr[0].Length > 5)
            {
                tmp1 = double.Parse(recvarr[0].Remove(5)) / (double)100;
            }
            else
            {
                tmp1 = double.Parse(recvarr[0]) / (double)100;
            }

            if (recvarr[1].Length > 4)
            {
                tmp2 = double.Parse(recvarr[1].Remove(4)) / (double)100;
            }
            else
            {
                tmp2 = double.Parse(recvarr[1]) / (double)1000;
            }

            ret.Add(tmp1);
            ret.Add(tmp2);
            return ret;
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
