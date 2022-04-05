import { Circle } from "./Circle.js";

export class Slucaj{
    constructor(brojKrugova)
    {
        this.brojKrugova = brojKrugova;
        this.listaIntervala = [100,150,200,250,300];
        this.listaRandomIntervala = [];
        this.klasa="";
        this.timeout=0;
    }

    getRandomInt(min, max) 
    {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min) + min); //The maximum is exclusive and the minimum is inclusive
    }

    crtajStandard()
    {
        if (this.brojKrugova==6)
        this.klasa="circle";
        if (this.brojKrugova==8)
        this.klasa="circle2";
        if (this.brojKrugova==10)
        this.klasa="circle3";
        let i=0;
        while (i<this.brojKrugova)
        {
            let p= this.getRandomInt(0,5);
            this.listaRandomIntervala.push(this.listaIntervala[p]);
            i++;
        }
        setTimeout(async ()=>{console.log("zapocinjem crtanje");
        this.timeout=1000;
        await  this.listaRandomIntervala.forEach(el=>
            {
                this.timeout+=el;
                let dom=document.querySelector(".smallContainer");
                dom.innerHTML="";
                let c = new Circle(this.klasa);
                setTimeout(() =>{c.crtajKrug(dom);},this.timeout); 
            })
            return this.timeout;
        },1000);

    }

    crtajTest(istislucaj)
    {
        if (istislucaj)
        {
            setTimeout(async()=>{console.log("zapocinjem crtanje");
            this.listaRandomIntervala.forEach(el=>
                {
                    let lbl = document.querySelector('.lblNaslov');
                    lbl.innerHTML="Test";
                    this.timeout+=el;
                    let dom=document.querySelector(".smallContainer");
                    dom.innerHTML="";
                    let c = new Circle(this.klasa);
                    setTimeout(() =>{c.crtajKrug(dom);},this.timeout); 
                })
                return this.timeout;},1000);
        }
    }
}