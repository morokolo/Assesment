using System;
using System.Collections.Generic;

namespace Oplay.Models.Response
{
    public class EmployeeResponse
    {
        public int personId { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public DateTime birthDate { get; set; }
    }
}
