using System;
using System.Collections.Generic;
using System.Text;

namespace KPI.Models
{
    public class PersonTask
    {
        public int utid { get; set; }
        public int ueid { get; set; }
        public int uuid { get; set; }
        public int upid { get; set; }
        public string task_Text { get; set; }
        public int count_to_do { get; set; }
        public int count_of_complited { get; set; }
        public DateTime task_start_date { get; set; }
        public DateTime task_end_date { get; set; }
    }
}
