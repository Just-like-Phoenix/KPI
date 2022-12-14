using System;
using System.Collections.Generic;
using System.Text;

namespace KPI.Models
{
    public class Persons
    {
        public int uuid { get; set; }
        public int upid { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }
        public double salry { get; set; }
        public double award { get; set; }
    }
}
