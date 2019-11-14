using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTest.Models
{
    public class Eats
    {
        public int Id { get; set; }
        public string Nimetus { get; set; }
        public string Hind { get; set; }
    }
}