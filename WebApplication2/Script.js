//var index = 1;

function Slider() {
	let cell = document.getElementsByClassName('size-4-cell');
	cellContent = Array.from(cell);
	cellContent.forEach(function(eles){
		let children = Array.from(eles.children);
		let showed = false;
		children.forEach(function(curr){
			//console.log('curr', curr);
			if(curr.classList.contains('slide-show')){
				curr.classList.add('slide-close');
				curr.classList.remove('slide-show');
			}
			else if(curr.classList.contains('slide-close')){
				curr.classList.add('slide-closed');
				curr.classList.remove('slide-close');
				let moveToLast = curr.cloneNode(true);
				curr.remove();
				eles.appendChild(moveToLast);
			}
			else if(!showed){
				curr.classList.remove('slide-closed');
				curr.classList.add('slide-show');
				showed = true;
			}
		});
	});
	// document.getElementById('slide-'+index).style.display = 'none';
	// if (index<3) {
	// 	document.getElementById('slide-'+(index+1)).style.display = 'block';
	// 	index++;
	// }
	// else{
	// 	index=1;
	// 	document.getElementById('slide-'+index).style.display = 'block';		
	// }
	// if(el.classList.contains('slide-show')){
	// 	el.classList.add('slide-close');
	// 	el.classList.remove('slide-show');
	// }
	// else{
	// 	el.classList.remove('slide-close');
	// 	el.classList.add('slide-show');
	// }
}

setInterval(Slider,2000);