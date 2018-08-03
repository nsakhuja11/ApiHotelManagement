using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoomsAvailalbe { get; set; }
        public string Address { get; set; }
        public int PINCode { get; set; }
    }
}