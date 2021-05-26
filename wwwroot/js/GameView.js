/** 
* This module exports the GameView class constructor. 
* 
* This component manages the Client-side behavior of the Game view. 
*/ 
define(function (require) { 
	'use strict'; 
	
	// imports 
	const BoardController = require('./BoardController'); 
	const GameState = require('./model/GameState'); 
	
	// MVP imports 
	const PlayController = require('./modes/play/PlayController'); 
	
	// Project Enhancement imports 
	const ReplayController = require('./modes/replay/ReplayController'); 
	const SpactatorController = require('./modes/spectator/Spe3ctatorController'); 
	
	// 
	// Constructor 
	// 

	/** 
	* Constructor function 
	*/
	function GameView(gameState) { 
		// private data 
		this._gameState = gameState; 
		this._boardController = new BoardController(this._gameState); 
	} 

	// 
	// Public (external) methods 
	// 

	GameView.prototype.startup = function startup() { 
		// initialize the Info fieldset with the player's names 
		this.setBlackPlayersName(this._gameState.getBlackPlayer()); 
		this.setWhitePlayersName(this._gameState.getWhitePlayer()); 
		this.setTurnFlasher(); 
	};	

	GameView.prototype.setHelperText = function setHelperText(helpTextHTML) { 
		jQuery("#help_text").html(helpTextHTML); 
	}; 
	
	GameView.prototype.canDeactivate = function canDeactivate() { 
		return this._modeController.canDeactivate(); 
	}; 

	// export class constructor 
	return GameView; 
}; 

	
