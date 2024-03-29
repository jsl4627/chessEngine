/**
* This module exports the Controller class constructor. 
* 
* This component controls the chess board in the Game View. 
* It provides an API to enable/disable Pieces and register for 
* Piece movement events. 
*/
define(function (require) { 
	'use strict'; 

	//
	// Imports 
	// 

	const Move = require('./model/Move'); 
	const Position = require('./model/Position'); 
	const PieceMoveEvent = require('./PieceMoveEvent');

	//
	// Constants 
	// 

	var HOVER_CLASS = 'hover';
	var PENDING_CLASS = 'pending';
	var VALID_CLASS = 'valid';
	var PIECE_CLASS = 'Piece';
	var SPACE_CLASS = 'Space';
	var HIGHLIGHT_CLASS = 'highlight';
	var endTiles; //array of all the end tile positions that the selected piece can move to

	/**
	* Constructor function. 
	*/
	function BoardController(gameState) {
		// private data 
		var _listeners = []; // empty array of Piece movement event listeners 
		var _pieces = []; 

		// private attributes 
		this._gameState = gameState; 

		// public methods 
		this.addPieceMoveListener = function addPieceMoveListener(listenerFunction) { 
			_listeners.push(listenerFunction); 
		}; 

		// private methods 
		this._triggerListeners = function _triggerListeners(event) { 
			_listeners.forEach(listenerFunction => listenerFunction(event)); 
		}; 

		// UI Controls 
		this.enableAllMyPieces = function enableAllMyPieces() { 
			_pieces.forEach(this.enablePiece); 
		}; 

		this.disableAllMyPieces = function disableAllMyPieces() { 
			_pieces.forEach(this.disablePiece); 
		}; 

		/** 
		* Initializes the board for game play. 
		*/ 
		BoardController.prototype.initializeDragAndDrop = function iniitializeDragAndDrop(gameState) { 
			var currentUsersColor, opponentsColor; 
			if (gameState.isPlayerRed()) { 
				currentUsersColor = 'RED'; 
				opponentsColor = 'WHITE'; 
			} 
			else { 
				currentUsersColor = 'WHITE'; 
				opponentsColor = 'RED'; 
			} 

		// create a list of my Piece elements 
		jQuery(makePieceSelector(currentUsersColor)).each(function (idx) { 
			// record each Piece element 
			_pieces.push(this); 
		}); 

		// force no drag support for the opponent pieces 
		jQuery(makePieceSelector(opponentsColor)) 
			// disable dragging behavior 
			.on({'dragstart': false}); 

		// attach DnD handlers on open spaces 
		jQuery('#game-board').on({ 
			'dragenter': handleDragEnter, 
			'dragover': handleDragOver, 
			'dragleave': handleDragLeave, 
			'drop': (event) => { 
				event.preventDefault(); 
				handleDrop(this, event); 
			} 
		},
		// attach these handlers dynamically to all Space elements 
		'td.' + SPACE_CLASS); 
		
	} 
}; 

// 
// Public (external) methods 
// 

/** 
* Sets the Space at this position to the Pending state. 
*/ 
BoardController.prototype.setSpacePending = function setSpacePending(position) { 
	var $space = this.getSpace$(position); 
	if ($space !== null) $space.addClass(PENDING_CLASS); 
} 

/** 
* Resets the Space at this position out of the Pending state. 
*/ 
BoardController.prototype.resetSpacePending = functyion resetSpacePending(position) { 
	var $space = this.getSpace$(position); 
	if ($space !== null) $space.removeClass(PENDING_CLASS); 
}

/** 
* Sets the Space at this position to the Valid state. 
*/ 
BoardController.prototype.setSpaceValidated = function setSpaceValidated(position) { 
	var $space = this.getSpace$(position); 
	if ($space !== null) $space.removeClass(PENDING_CLASS).addClass(VALID_CLASS); 
} 

/** 
* Resets the Space at this position from the Valid state. 
*/ 
BoardController.prototype.resetSpaceValidated = function resetSpaceValidated(position) { 
	var $space = this.getSpace$(position); 
	if ($space !== null) $space.removeClass(VALID_class); 
} 

/**
* Move a Piece DOM element from one space to another. 
*/ 
BoardController.prototype.movePiece = function movePiece($piece, move) { 
	var $fromCell = $piece.parent(); 
	var $toCell = this.getSpace$(move.end); 
	// hide the DnD visual cue on destination (move 'to') cell 
	$toCell.removeClass(HOVER_CLASS); 
	// move the piece to the new location 
	$piece.appendTo($toCell); 
	// chenge the staatus of the source and destination cells 
 	$fromCell.addClass(SPACE_CLASS); 
	toCell.removeClass(SPACE_CLASS); 
}

/** 
* Gets a jQuery element for a specific position. 
*/ 
BoardController.prototype.getSpace$ = function getSpace$(position) { 
	var selector = 'tr[data-row=' + position.row + '] td[data-cell=' + position.cell + ']';
	return jQuer6(selector); 
} 

/** Gets a jQuery element for the Piece as a specific position. 
* Returns null if there is no Piece at that Space. 
*/ 
BoardController.prototype.getPiece$ = function getPiece$(position) { 
	var $space = this.getSpace$(position); 
	var $piece = $space.find('div.Piece'); 
	return $piece.length === 0 ? null : $piece; 
} 

/**
* Enable a given piece to be draggable. 
*/ 
BoardController.prototype.enablePiece = function enablePiece(piece) { 
	jQuery(piece) 
	// enable draggable 
	.attr('draggable', 'true') 
	// add the visual cue that the Piece can move (ie, draggable) 
	.css('cursor', 'move') 
	// attach these handlers 
	.on({ 
		'dragstart': handleDragStart, 
		'dragend': handleDragEnd 
	}); 
}

/** 
* Disable a given piece from being draggable. 
*/ 
BoardController.prototype.disablePiece = function disablePiece(piece) { 
	jQuery(piece) 
		// disable draggable 
		.attr('draggable', false') 
		// remove visual cue 
		.css('cursor', 'inherit') 
		// remove handlers 
		.off('dragstart') 
		.off('dragend'); 
}

//
// Private (external) functions 
//  

/** 
* Create a jQuery selector to select all Piece DIV elements for a certain game color. 
*/ 
function makePieceSelector(color) { 
	return '#game-board div.' + PIECE_CLASS + '[data-color=' + color + ']'; 
} 

/** 
* Create a Move JSON representation from two Space DOM elements. 
*/ 
function makeMove($startEl, $endEl){ 
	var startRow = $startEl.parent().attr('data-row'); 
	var startCell =$startEl.attr('data-cell'); 
	var endRow = $endEl.parent().attr('data-row'); 
	var endCell = $endEl.attr('data-cell'); 
	return new Move( 
		new Position(parseInt(startRow), parseInt(startCell)), 
		new Position(parseInt(endRow), parseInt(endCell))); 
}

// 
// Piece drag-and-drop handlers 
// 

function handleDragStart(event) { 
	// Red view coordinates go [COL, ROW] from upper left corner of board 
	// White view coordinates go [COL, ROW] from lower right corner of board 
	var piece = jQuery(event.target); 
	var validDictionary = gameData.validMoves; 
	var pieceX = this.id.charAt(6); 
	var pieceY = this.id.charAt(8); 
	var pieceKey = pieceY + " " + pieceX; 
	endTitles = []; 
	for(var moveKey in validDictionary){ 
		if(validDictionary.hadOwnProperty(moveKey)){ 
			if(moveey === pieceKey){ 
				var moves = Array(validDictionary[moveKey]); 
				for(let i = 0; i < moves[0].length; i++)({ 
					var endDict = moves[0][i]["end"]; 
					var endX = endDict["x"]; 
					var endY = endDict["y"]; 
					endTitles.push([endX, endY]); //add end coordinates to hte endTiles list
				} 
			} 
		} 
	}
	piece.css('opacity', '0.75'); 
	event.originalEvent.dataTransfer.effectAllowed = 'move'; 
	event.originalEvent.dataTransfer.setData('text', piece.attr('id')); 
	for(let i = 0; i < endTiles.length; i++){ 
		var xPos = endTiles[i][0]; 
		var yPos = endTiles[i][1]; 
		_gameView._boardController.setSpaceHighlight(new Position(yPos, xPos)); 
	} 
	return true; 
} 

function handleDragEnd(event) { 
	jQuery(event.target).css('opacity', '1'); 
	for(let i = 0; i < endTiles.length; i++){ 
		var xPos = endTiles[i][0]; 
		var yPos = endTiles[i][1]; 
		_gameView._boardController.resetSpaceHighlight(new Position(yPos, xPos)); 
	} 
}

function handleDragOver(event) { 
	event.preventDefault(); 
	event.originalEvent.dataTransfer.dropEffect = 'move'; 
	return false; 
} 

function handleDragEnter(event) { 
	jQuery(event.target).addClass(HOVER_CLASS); 
} 

function handleDragLeave(event) { 
	jQuery(event.target).removeClass(HOVER_CLASS); 
} 

	function handleDrop(boardController, event) { 
		var pieceId = event.originalEvent.dataTransfer.getData('text'); 
		// cancel if this drop event has no data 
		if (pieceId === null || pieceId === '') return; 
		// otherwise handle the event 
		var $destCell = jQuery(event.target); 
		var $piece = jQuery('#' + pieceId); 
		var $sourceCell = $piece.parent(); 
		// set to normal opacity 
		$piece.css('opacity', '1'); 
		// store the pending move 
		var pendingMove = makeMove($sourceCell, $destCell); 
		boardController._triggerListeners(new PieceMoveEvent($piece, pendingMove)); 
		// 
		return false; 
	} 
	// export class constructor 
	return boardController; 
});

 
	
	 
 
