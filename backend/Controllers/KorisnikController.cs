using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisnikController : ControllerBase
    {
        public IstrazivanjeContext  Context {get;set;}

        public KorisnikController(IstrazivanjeContext  context)
        {
           this.Context=context;
        }

        [HttpPost]
        [Route("KreirajKorisnika/{id}/{pol}/{starost}/{InstrumentILIPevanje}/{InstrumentKojiSvira}/{VremeProvedenoSviranjemInsturmenta}/{Obrazovanje}")]
        public async Task<ActionResult> KreirajKorisnika(string id,string pol,int starost,string InstrumentILIPevanje,string InstrumentKojiSvira,string VremeProvedenoSviranjemInsturmenta,string Obrazovanje)
        {
            Korisnik k = new Korisnik();
            k.IDgenerated=id;
            k.Pol=pol;
            k.Starost=starost;
            k.VremeIDatum=DateTime.Now;
            k.Obrazovanje=Obrazovanje;
            k.InstrumentILIPevanje=InstrumentILIPevanje;
            k.RezultatiTesta = new List<RezultatiTesta>();
            if (InstrumentILIPevanje == "Ne")
                {
                    k.InstrumentKojiSvira="/";
                    k.VremeProvedenoSviranjemInsturmenta="/";
                }
            else
            {
                k.InstrumentKojiSvira=InstrumentKojiSvira;
                    k.VremeProvedenoSviranjemInsturmenta=VremeProvedenoSviranjemInsturmenta;
            }
           try{
               Context.Korisnici.Add(k);
                await Context.SaveChangesAsync();
                return Ok(k.ID);
           }
           catch(Exception e)
           {
               return BadRequest(e.Message);
           }
        }

        [HttpPut]
        [Route("DodajRezultat/{id}/{resenje}/{odg}/{vremereakcije}")]
        public async Task<ActionResult> DodajRezultat(int id,string resenje,string odg,string vremereakcije)
        {
           try{
                var k = await Context.Korisnici.Include(k=>k.RezultatiTesta).Where(k=>k.ID ==id).FirstOrDefaultAsync();
                if (k==null)
                {
                    return BadRequest("Ne postoji takav korisnik");
                }
                List<string> resenja = resenje.Split("-x-").ToList();
                List<string> odgovori = odg.Split("-x-").ToList();
                List<int> vremenaReakcije = vremereakcije.Split("-x-").Where(x => int.TryParse(x, out _)).Select(int.Parse).ToList();
                
                for (int i=0;i<vremenaReakcije.Count;i++)
                {
                    var rez = new RezultatiTesta();
                    rez.Resenje=resenja[i];
                    rez.Odgovor=odgovori[i];
                    rez.VremeReakcije=vremenaReakcije[i];
                    k.RezultatiTesta.Add(rez);
                }

                Context.Korisnici.Update(k);
                await Context.SaveChangesAsync();
                return Ok(k.ID);
           }
           catch(Exception e)
           {
               return BadRequest(e.Message);
           }
        }
         [HttpGet]
        [Route("VratiKorisnike")]
        public async Task<ActionResult> VratiKorisnike()
        {
            var korisnici = await Context.Korisnici.Include(k=>k.RezultatiTesta).ToListAsync();
            return Ok(korisnici);
        }


        [HttpGet]
        [Route("VratiRezultateZaKorisnika/{id}")]
        public async Task<ActionResult> VratiRezultateZaKorisnika(int id)
        {
           try{
                var korisnik = Context.Korisnici.Include(k => k.RezultatiTesta).Where(k => k.ID == id);
                var k = await korisnik.FirstOrDefaultAsync();
                if (k==null)
                {
                    return BadRequest("Ne postoji takav korisnik");
                }
                return Ok(k.RezultatiTesta);
           }
           catch(Exception e)
           {
               return BadRequest(e.Message);
           }
        }
    }
}
