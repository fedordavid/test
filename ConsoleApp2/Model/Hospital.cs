ausing System;
using System.Security.Cryptography;

namespace ConsoleApp2.Model
{
    public class Hospital
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        
        public string Address { get; set; }
        public string Gift { get; set; }
    }
}