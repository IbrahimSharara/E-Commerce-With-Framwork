using E_Commerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.WebUI.Models
{
    public class DataTableResponse
    {
        public int Draw { get; set; }
        public long RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public Category[] Data { get; set; }
        public string Error { get; set; }
    }
}