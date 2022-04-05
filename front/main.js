import { Slucaj } from "./Slucaj.js";
let timeout=0;
let mainContainer = document.createElement('div');
mainContainer.className="mainContainer";
document.body.appendChild(mainContainer);

let lblNaslov = document.createElement('label');
lblNaslov.className="lblNaslov";
lblNaslov.innerHTML="PRITISNI DUGME START DA ZAPOCNES EXPERIMENT"
mainContainer.appendChild(lblNaslov);

let btnStart = document.createElement('button');
btnStart.className="btnStart";
btnStart.innerHTML="Start"
btnStart.onclick = (ev) => startExperiment(mainContainer);
mainContainer.appendChild(btnStart);

let smallContainer = document.createElement('div');
smallContainer.className="smallContainer";
mainContainer.appendChild(smallContainer);


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
    await openFullscreen()
            let s = new Slucaj(10);
            let l =  await s.crtajStandard(s);
            timeout+=l;
            console.log(l,timeout);
            setTimeout(s.crtajTest(1),timeout);
            console.log(s);
            
}
