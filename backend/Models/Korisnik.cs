using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Korisnik")]
    public class Korisnik
    {
        [Key]
        public int ID { get; set; }

        public DateTime VremeIDatum { get; set; }

        public string Pol {get;set;}

        public int Starost { get; set; }

        public string InstrumentILIPevanje {get;set;}

        public string InstrumentKojiSvira {get;set;}

        public string VremeProvedenoSviranjemInsturmenta {get;set;}

        public string Obrazovanje {get;set;}

        public List<RezultatiTesta> RezultatiTesta {get;set;}

    }
}
