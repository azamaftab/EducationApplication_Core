using Education.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.Web.Models
{
    public class HomeViewModel
    {
        public Class Class { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }

    }
}
