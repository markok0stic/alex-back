import { Korisnik } from "./Korisnik.js";
function Instrument()
{
	document.getElementById("instrument1").innerHTML="<br>Koji instrument svirate: <label> <input type='text' id='vrstainstrumenta' name='vrstainstrumenta'> </label></br>" + "</br> Koliko vremena dnevno provedete svirjuci taj instrument <label> <select id= 'vreme' name= 'vreme' size=3> <option value = 'Manje od 30 minuta'> Manje od 30 minuta </option> <option value = 'Manje od 120 minuta'> Manje od 120 minuta </option> <option value = 'Više od 30 minuta'> Više od 30 minuta </option> </select> </br>";
}
function Nestani()
{
  document.getElementById("instrument1").innerHTML="";
}
function submitDemographics() 
{
  var thisForm = document.getElementById("demograpghicForm");
  let rbs = thisForm.querySelectorAll("input[type=radio]:checked");
  let tbGod = thisForm.querySelector("input[type=number]");
  let inst = document.getElementById("instrument1");

  if (inst!=null && inst.innerHTML!="")
  {
    let tbInstrument = document.getElementById("vrstainstrumenta");
    let selVreme = document.getElementById("vreme");
    if (rbs.length != 3 || tbGod.value <23 || tbGod.value >33 || tbInstrument.value=="" || selVreme.options[selVreme.selectedIndex].value =="")
    confirm("Pažnja niste uneli neko polje ili ste to učinili to neispravno!");
    else
      {
        let listaVrednsti =[];
        rbs.forEach(el=>{
        listaVrednsti.push(el.value);
        })
        fetch ("https://localhost:5001/Korisnik/DodajKorisnika/"+ listaVrednsti[0]+"/"+tbGod.value+"/"+ listaVrednsti[1]+"/"+ tbInstrument.value+"/"+selVreme.options[selVreme.selectedIndex].value +"/" + listaVrednsti[2],
        {
          method:"Post"
        }).then((s)=>{
          if (s.ok)
          {
            s.json().then((data)=>{
              let k = new Korisnik(data);
              Korisnik.suba(k);
              window.location.href = "exp.html";
            }
            )
           
          }
           else
           {
             console.log("greska prilikom dodavanja na serveru");
           }         
        });
      }
  }
  else
  {
    if (rbs.length != 3 || tbGod.value <23 || tbGod.value >33)
    confirm("Pažnja niste uneli neko polje ili ste to učinili to neispravno!");
    else
      {
        let listaVrednsti =[];
        rbs.forEach(el=>{
        listaVrednsti.push(el.value);
        })
        fetch ("https://localhost:5001/Korisnik/DodajKorisnika/"+ listaVrednsti[0]+"/"+tbGod.value+"/"+ listaVrednsti[1]+"/"+ "nan"+"/"+ "nan" +"/" + listaVrednsti[2],
        {
          method:"Post"
        }).then((s)=>{
          if (s.ok)
          {
            s.json().then((data)=>{
              let k = new Korisnik(data);
              window.location.href = "exp.html";
            }
            )
           
          }
           else
           {
             console.log("greska prilikom dodavanja na serveru");
           }         
        });
      }
  }
  }
let rbt = document.getElementById("sviraminstrument");
rbt.onclick=(ev)=>{Instrument();}

let rbt1 = document.getElementById("solop");
rbt1.onclick=(ev)=>{Instrument();}

let rbt2 = document.getElementById("kamernop");
rbt2.onclick=(ev)=>{Instrument();}

let rb3 = document.getElementById("ne");
rb3.onclick=(ev)=>{Nestani();}

let btn = document.getElementById("exp_button");
btn.onclick=(ev)=>{submitDemographics();}