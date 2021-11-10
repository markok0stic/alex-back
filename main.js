 	   let data = "";
	   var divii = document.getElementById('div-container');
	   var up = document.getElementById('h1'); 
	   var down = document.getElementById('down'); 
	   const BtnAdd = document.querySelector("btn-add");
	   const DivContainer = document.getElementById("div-container");
	   let randomCorrect = [100,150,200,250,300];
	   var p=getRandomInt(0, 5);
	   let randomInterval= [];
	   var elem = document.documentElement;
	   var startTime;
	   var endTIme;
	   let temporaryTimeout=[];
	   function showStuff(id) 
	   	{
	       document.getElementById(id).style.display = "none";
	   	}

	   function openFullscreen() 
	   	{
			if (elem.requestFullscreen) 
			elem.requestFullscreen();
			else if (elem.webkitRequestFullscreen) 
			elem.webkitRequestFullscreen();
			else if (elem.msRequestFullscreen) 
			elem.msRequestFullscreen();
		}   

		
	 	async function waitingKeypress() 
	   {
		return new Promise((resolve) => 
					{
						setTimeout(()=> {
						console.log('waiting keypress..');
						startTime = performance.now();
						document.addEventListener("keyup", onkeyPressed);
						clearArray(temporaryTimeout);
						function onkeyPressed (e)
						{
							if (e.key == 'a' || e.key == 'A') 
											{
												document.removeEventListener('keyup', onkeyPressed);    
												data+="-Ispitanik:A(Postoji razlika)!";
												endTime = performance.now();
												resolve();
											}
							if (e.key == 'l' || e.key == 'L') 
											{
												document.removeEventListener('keyup', onkeyPressed);    
												data+="-Ispitanik:L(Nema razlike)!";
												endTime = performance.now();
												resolve();
											}  
						}		 
					},temporaryTimeout[0]);
				} 
				);
	   }
		function AddNewCircle(classname) 
	   	{
			const newDiv = document.createElement("div");
			console.log("added");
			newDiv.classList.add(classname);
			DivContainer.appendChild(newDiv);
	   	}
	   
	   function GenerateCirclesCase(count,funci,classname)
	 	{
	       	return new Promise (async (resolve) =>
			   	{	
					document.getElementById('h1').innerHTML = ("STANDARD");
					divii.innerHTML='';
					down.innerHTML = '<div id="div-container"><\/div>';
					document.getElementById('h2').innerHTML='';
					var counter1=0;
					var timeout=500;
					while(counter1<count)
						{
							counter1=counter1+1;
							p=getRandomInt(0, 5);
							timeout = timeout + randomCorrect[p];
							setTimeout(()=>{funci(classname);},timeout);;
							randomInterval.push(randomCorrect[p]);
						}
						console.log("started generating circles");
						setTimeout(() => {console.log('GENERATED STANDARD CASE');resolve();},timeout+1000);
	       		}
		   );
	   	}

	   function GenerateCirclesStandardorTest(count,test,funci,classname)
	   {   
		return new Promise (async (resolve) =>{
	       up.innerHTML = "TEST";
	       divii.innerHTML='';
	       down.innerHTML = '<div id="div-container"><\/div>';
	       document.getElementById('h2').innerHTML="</br></br></br></br></br></br></br></br></br></br></br></br></br></br></br></br></br></br>STISNI <b>A<\/b> UKOLIKO POSTOJI RAZLIKA ILI <b>L<\/b> UKOLIKO NE POSTOJI";
	       var counter1=0;
		   var timeout=0;
	       if (test==0) // same as standard
	           {
				var z=0;
				timeout = 500;
	           while(counter1<count)
	               {	
					   timeout +=randomInterval[z];
					   temporaryTimeout.push(timeout);
	                   counter1=counter1+1;
	                   setTimeout(()=>{funci(classname);},timeout);
	                   z=z+1;
	               }
	           data+="Nema razlike!";
			   await clearArray(randomInterval);
	           }   
	       else //test case
	       {
	           timeout= 500;
			   var randomNumofPairTestCircles = getRandomInt(4, 1);// num of diff timeout circles
			   var t=1;
			   let temp= [];// indexes of pairs that have diff timeout than standards
			   while (t <= randomNumofPairTestCircles)
			   {
					var randomPair= getRandomInt(count,1);
					t++;
					temp.push(randomPair);
				}
			  	temp.sort(function(a, b){return a - b}); //sort
			   t=0;
			   var i=0;
	           while (i < count)
			   		if ( i == temp[t] )
	               {
					   let s=0;
					   uslovZaUlazak=1;
					   p=getRandomInt(0, 5);
	                   timeout = timeout + randomCorrect[p];
					   temporaryTimeout[s++]=timeout;
					   console.log("UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSLLLLLLLLLLLLLLLLLLLLLOOOOOOO")
					   setTimeout(()=>{funci(classname);},timeout);
					   t++;
					   i++;
				   }
				   else
				   {
					timeout +=randomInterval[i];
					temporaryTimeout.push(timeout);
	                setTimeout(()=>{funci(classname);},timeout);
					i++;
				   }
				   data+="Postoji razlika!";
				}
			console.log("started generating circles");
	   		setTimeout(() => {console.log("'GENERATED TEST CASE'");},timeout+500);
			await waitingKeypress();
			await lasting(endTime - startTime);
			await clearArray(randomInterval);
			setTimeout(() => {console.log("GENERATING NEW CASE");resolve();},timeout);       
	  		 });
		}

		function clearArray(call)
		{
			return new Promise ((resolve) => {call.length = 0;resolve();})
		}

		function lasting(time) 
		{
			return new Promise ((resolve)=> {
			document.getElementById('h2').innerHTML="</br></br></br></br></br></br></br></br></br></br></br></br></br></br></br></br></br></br>OVO JE TRAJALO <b>" + Math.floor(time) + "</b> ms. SLEDEĆI SLUČAJ SE UČITAVA! MOLIMO SAČEKAJTE!"; 
			data+="-Vreme reakcije: "+ Math.floor(time)+ " ms||";
			resolve();
		})	;
		}

	   function getRandomInt(min, max) 
	   {
	   min = Math.ceil(min);
	   max = Math.floor(max);
	   return Math.floor(Math.random() * (max - min) + min); //The maximum is exclusive and the minimum is inclusive
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
	   
	   async function Launch() 
	   {   
			let j =[0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1];
			openFullscreen();
			showStuff("btn_add");
			//start
			await shuffle(j); // shuffing order of test cases
		  	for (let i=0;i<3;i++)
		  	{
		   		await doWork(6,AddNewCircle,j[i],"circle");
			}
		  	await shuffle(j);// shuffing order of test cases
			for (let i=0;i<3;i++)
			{
				await doWork(8,AddNewCircle,j[i],"circle2");
			}
			await shuffle(j);// shuffing order of test cases
			for (let i=0;i<3;i++)
			{
				await doWork(10,AddNewCircle,j[i],"circle3");
			}
	   }
	   
	   async function doWork(count, func , testornot,classname)
	   {
	       await GenerateCirclesCase(count,func,classname);
	       await GenerateCirclesStandardorTest(count, testornot , func,classname);
	   }	