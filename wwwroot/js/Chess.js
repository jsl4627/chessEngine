var state = false  
var currentPiece; 
var currentCell; 

var cells = document.getElementsByTagName("td"); 
for (var i = 0; i < cells.length; i++) { 
	cells[i].onClick = function(){ 
		getCell(this); 
	}; 
} 

function getCell(that) { 
	if(!state) { 
		state = true; 
		currentPiece = that.innerHTML; 
		currentCell = that; 
	} 
	else { 
		that.innerHTML = currentPiece; 
		currentCell.innerHTML = ""; 
		state = false; 
	} 
} 
