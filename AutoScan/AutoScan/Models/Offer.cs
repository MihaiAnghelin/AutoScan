using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration.Xml;

namespace AutoScan.Models
{
    public class Offer
    {
        public string Id { get; set; }
        public string Marca { get; set; }
        public string Model { get; set; }
        public decimal Pret { get; set; }
        public string Currency { get; set; }
        public string City { get; set; }
        public int Power { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
    }
}

//ad id ,marca, model,pret,currency, city,power, nume+prenume