using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Pagination
{
    public class Pagination<T> where T : Base
    {
        public int CurrentPage { get; set; }
        public bool HasAnotherPage { get; set; }
        public int PageSize { get; set; }
        public List<T> Elements { get; set; }  = new List<T>();
    }
}
