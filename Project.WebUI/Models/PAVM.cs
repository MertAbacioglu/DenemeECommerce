using PagedList;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebUI.Models
{
    public class PAVM
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        public IPagedList<Product> PagedProducts { get; set; } //pagination islemleri icin tutulan property
    }
}