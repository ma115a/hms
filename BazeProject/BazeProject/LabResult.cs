using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class LabResult
    {
        public string doc_name {  get; set; }
        public string tech_name { get; set; }
        public DateTime date { get; set; }
        public string result { get; set; }


        public LabResult(string doc_name, string tech_name, DateTime date, string result)
        {
            this.doc_name = doc_name;
            this.tech_name = tech_name;
            this.date = date;
            this.result = result;
        }
    }
}
