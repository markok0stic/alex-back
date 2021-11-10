//******IMT Routines ********


function shuffle(array) {
for (let i = array.length - 1; i > 0; i--) {
  let j = Math.floor(Math.random() * (i + 1)); // random index from 0 to i
  [array[i], array[j]] = [array[j], array[i]];
}
}

function linspace(a,b,n) {
  if(typeof n === "undefined") n = Math.max(Math.round(b-a)+1,1);
  if(n<2) { return n===1?[a]:[]; }
  var i,ret = Array(n);
  n--;
  for(i=n;i>=0;i--) { ret[i] = (i*b+(n-i)*a)/n; }
  return ret;
}

function randomInts(dataSetSize, minValue, maxValue) {
return new Array(dataSetSize).fill(0).map(function(n) {
  return Math.floor(Math.random() * (maxValue - minValue) + minValue);
});
}

function distance (pointA, pointB) {

var a = pointA[0] - pointB[0];
var b = pointA[1] - pointB[1];
return Math.trunc(Math.sqrt( a*a + b*b ));

}

function cancelAllAnimationFrames(){
 var id = window.requestAnimationFrame(function(){});
 while(id--){
   window.cancelAnimationFrame(id);
 }
}

function pad (myNum, size) {
var s = String(myNum);
while (s.length < (size || 2)) {s = "0" + s;}
return s;
}

function getParameterByName(name, url) {
  if (!url) url = window.location.href;
  name = name.replace(/[\[\]]/g, '\\$&');
  var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
      results = regex.exec(url);
  if (!results) return null;
  if (!results[2]) return '';
  return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

function getUrlParameter(name) {
    name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
    var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
    var results = regex.exec(location.search);
    return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
};


/* View in fullscreen */
	var elem = document.documentElement;
	function openFullscreen() {
  if (elem.requestFullscreen) {
    elem.requestFullscreen();
  } else if (elem.webkitRequestFullscreen) { /* Safari */
    elem.webkitRequestFullscreen();
  } else if (elem.msRequestFullscreen) { /* IE11 */
    elem.msRequestFullscreen();
  }
}

/* Close fullscreen */
function closeFullscreen() {
  if (document.exitFullscreen) {
    document.exitFullscreen();
  } else if (document.mozCancelFullScreen) { /* Firefox */
    document.mozCancelFullScreen();
  } else if (document.webkitExitFullscreen) { /* Chrome, Safari and Opera */
    document.webkitExitFullscreen();
  } else if (document.msExitFullscreen) { /* IE/Edge */
    document.msExitFullscreen();
  }
}

// For storing data locally
function downloadData(file, text) {

  //creating an invisible element
  var element = document.createElement('a');
  element.setAttribute('href', 'data:text/plain;charset=utf-8, '
  + encodeURIComponent(text));
  element.setAttribute('download', file);

  //the above code is equivalent to
  // <a href="path of file" download="file name">

  document.body.appendChild(element);

  //onClick property
  element.click();

  document.body.removeChild(element);
}

function Instrument()
{
	document.getElementById("instrument1").innerHTML="<br>Koji instrument svirate: <label> <input type='text' id='vrstainstrumenta' name='vrstainstrumenta'> </label></br>" + "</br> Koliko vremena dnevno provedete svirjuci taj instrument <label> <select id= 'vreme' name= 'vreme' size=3> <option value = 'Manje od 30 minuta'> Manje od 30 minuta </option> <option value = 'Manje od 120 minuta'> Manje od 120 minuta </option> <option value = 'Više od 30 minuta'> Više od 30 minuta </option> </select> </br>";
	
}
function Nestani(id)
{
	document.getElementById(id).innerHTML="";
}