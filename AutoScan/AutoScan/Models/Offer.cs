using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration.Xml;

namespace AutoScan.Models
{
    public class Offer
    {
        public string id { get; set; }
        public string marca { get; set; }
        public string model { get; set; }
        public decimal price { get; set; }
        public string currency { get; set; }
        public string city { get; set; }
        public int engine_power { get; set; }
        public string full_name { get; set; }
        public string picture { get; set; }
    }

    public class Offers
    {
        public List<Offer> clientads { get; set; }
    }
}

//ad id ,marca, model,pret,currency, city,power, nume+prenume

//"id":"1",
//"marca":"Ford",
//"model":"Puma",
//"price":2.00,
//"currency":"leu",
//"city":"Oradea",
//"engine_power":268,
//"full_name":"alabalaportocala",