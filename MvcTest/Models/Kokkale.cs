using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcTest.Models
{
    public class Kokkale
    {
        public int KokkaleId { get; set; }
        public int EatId { get; set; }
        public string Nimetus { get; set; }
        public DateTime Date { get; set; }
    }
}