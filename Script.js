var index = 1;

function Slider() {
	document.getElementById('slide-'+index).style.display = 'none';
	if (index<3) {
		document.getElementById('slide-'+(index+1)).style.display = 'block';
		index++;
	}
	else{
		index=1;
		document.getElementById('slide-'+index).style.display = 'block';		
	}
}

setInterval(Slider,1000);