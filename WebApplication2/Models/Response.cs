using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace WebApplication2.Models
{
    public class Response
    {
        public List<Hotel> Hotels { get; set; }
        public Status Status { get; set; }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
    }

    public enum Status
    {
        Success,
        Failure
    }
}