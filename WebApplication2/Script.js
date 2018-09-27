function Slider() {
	let cell = document.getElementsByClassName('size-4-cell');
	cellContent = Array.from(cell);
	cellContent.forEach(function(eles){
		let children = Array.from(eles.children);
		let showed = false;
		children.forEach(function(curr){
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
}

setInterval(Slider,2000);