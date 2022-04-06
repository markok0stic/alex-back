using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("RezultatiTesta")]
    public class RezultatiTesta
    {
        [Key]
        public int ID { get; set; }

        public string Resenje {get;set;}
        public string Odgovor {get;set;}
        public int VremeReakcije {get;set;}

    }
}
