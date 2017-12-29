using CoreApp.DbAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
