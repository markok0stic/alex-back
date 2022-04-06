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
        [Route("DodajKorisnika/{pol}/{starost}/{InstrumentILIPevanje}/{InstrumentKojiSvira}/{VremeProvedenoSviranjemInsturmenta}/{Obrazovanje}")]
        public async Task<ActionResult> NapraviKorisnika(string pol,int starost,string InstrumentILIPevanje,string InstrumentKojiSvira,string VremeProvedenoSviranjemInsturmenta,string Obrazovanje)
        {
            Korisnik k = new Korisnik();
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
                return Ok("Uspesno dodat korisnik!");
           }
           catch(Exception e)
           {
               return BadRequest(e.Message);
           }
        }

        [HttpPut]
        [Route("DodajRezultat/{id}/{resenje}/{odg}/{vremereakcije}")]
        public async Task<ActionResult> DodajRezultat(int id,string resenje,string odg,int vremereakcije)
        {
           try{
                var k = await Context.Korisnici.Include(k=>k.RezultatiTesta).Where(k=>k.ID ==id).FirstOrDefaultAsync();
                if (k==null)
                {
                    return BadRequest("Ne postoji takav korisnik");
                }
                RezultatiTesta rez = new RezultatiTesta();
                rez.Odgovor=odg;
                rez.Resenje=resenje;
                rez.VremeReakcije=vremereakcije;
                k.RezultatiTesta.Add(rez);
                Context.Korisnici.Update(k);
                await Context.SaveChangesAsync();
                return Ok(k.RezultatiTesta);
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
            var korisnici = await Context.Korisnici.ToListAsync();
            return Ok(korisnici);
        }


        [HttpGet]
        [Route("VratiRezultateZaKorisnika/{id}")]
        public async Task<ActionResult> VratiRezultateZaKorisnika(int id)
        {
           try{
                var k = await Context.Korisnici.Include(k=>k.RezultatiTesta).Where(k=>k.ID ==id).FirstOrDefaultAsync();
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
