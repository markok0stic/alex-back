import { Slucaj } from "./Slucaj.js";
import { Korisnik } from "./Korisnik.js";
let mainContainer = document.createElement('div');
mainContainer.className="mainContainer";
document.body.appendChild(mainContainer);

let lblNaslov = document.createElement('label');
lblNaslov.className="lblNaslov";
lblNaslov.innerHTML="PRITISNI DUGME START DA ZAPOČNES EXPERIMENT"
mainContainer.appendChild(lblNaslov);

let btnStart = document.createElement('button');
btnStart.className="btnStart";
btnStart.innerHTML="Start"
btnStart.onclick = (ev) => startExperiment(mainContainer);
mainContainer.appendChild(btnStart);

let smallContainer = document.createElement('div');
smallContainer.className="smallContainer";
mainContainer.appendChild(smallContainer);

let lblOdg = document.createElement('label');
lblOdg.className="lblOdg";
mainContainer.appendChild(lblOdg);

let listaOdgovora =[];
let listaVremenaReakcije=[];
let listaResenja =[];
function openFullscreen() 
{
	if (document.documentElement.requestFullscreen) 
		document.documentElement.requestFullscreen();
	else if (document.documentElement.webkitRequestFullscreen) 
		document.documentElement.webkitRequestFullscreen();
	else if (document.documentElement.msRequestFullscreen) 
		document.documentElement.msRequestFullscreen();
}   


async function startExperiment(host)
{
    alert(Korisnik.id);
    btnStart.style="display:none";
    listaOdgovora =[];
    listaResenja=[];
    listaVremenaReakcije=[];

    await openFullscreen();
    
    let j =[0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1]; 

    await shuffle(j);
    for ( let i =0;i<2;i++)
    await crtaj(6,j[i]);

    await shuffle(j);
    for ( let i =0;i<2;i++)
    await crtaj(8,j[i]);
    
    await shuffle(j);
    for ( let i =0;i<2;i++)
    await crtaj(10,j[i]);

    await popuniBazu();
}

function crtaj(broj,pom)
{
    return new Promise (async (resolve)=>
    {
        let s = new Slucaj(broj);
        await s.crtajStandard();
        await s.crtajTest(pom).then(()=>
        {
            listaOdgovora.push(Slucaj.Odgovor);
            listaResenja.push(s.resenje);
            listaVremenaReakcije.push(Slucaj.vremeReakcije);
        });
        resolve();
    });
}

function shuffle(array) {
    return new Promise ( (resolve) => {
        for (let i = array.length - 1; i > 0; i--) 
        {
             let j = Math.floor(Math.random() * (i + 1)); // random index from 0 to i
             [array[i], array[j]] = [array[j], array[i]];
         } 
             resolve();  
     });
}

function popuniBazu()
{
   let odgovori ="";

   for (let i=0;i<listaOdgovora.length;i++)
   {
       odgovori = odgovori.concat(listaOdgovora[i],"a");
   }
   console.log(odgovori);

   let resenja ="";

   for (let i=0;i<listaResenja.length;i++)
   {
    resenja = resenja.concat(listaResenja[i],"a");
   }
   console.log(resenja);

   let vremeReakcije ="";

   for (let i=0;i<listaVremenaReakcije.length;i++)
   {
    vremeReakcije = vremeReakcije.concat(listaVremenaReakcije[i],"a");
   }
   console.log(vremeReakcije);


}
