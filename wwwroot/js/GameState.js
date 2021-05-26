/** 
* This module exports the GameState class constructor. 
* 
* This Value Object holds a snapshot of the state of the chess game. 
* Information about who the players are, the current player and whose 
* turn is it. 
*/ 
define(function (require) { 
	'use strict'; 
	// imports 
	const BrowserUtils = require('../util/BrowserUtils'); 
	
	/** 
	* Constructor function. 
	*/ 
	function GameState(gameData){ 
		// public (internal) methods 

		/** 
		* Get the name of the BLACK player in this game. 
		*/ 
		this.getBlackPlayer = function getBlackPlayer() { 
			return gameData.blackPlayer; 
		}; 	

		/** 
		* Get the name of the WHITE Player in this game. 
		*/ 
		this.getWhitePlayer = function getWhitePlayer() { 
			return gameData.whitePlayer; 
		}; 

		this.isBlacksTurn = function isBlacksTurn() { 
			return gameData.activeColor === 'BLACK'; 
		}; 

		/** 
		* Query whether current user is the BLACK player. 
		*
		* @return {boolean} true if the current user is the BLACK player
		*/ 
		this.isPlayerBlack = function isPlayerBlack() { 
			return gameData.blackPlayer === gameData.currentUser; 
		}; 

		/** 
		* Query whether current user is the WHITE player. 
		* 
		* @return {boolean} true if the current user is the WHITE player
		*/ 
		this.isPlayerWhite = function isPlayerWhite() { 
			return gameData.whitePlayer === gameData.currentUser; 
		}; 
	} 

	// 
	// Public (external) methods 
	// 

	/** 
	* Queries whether it's the current player's turn. 
	*/ 
	GameState.prototype.isMyTurn = function isMyTurn() { 
		return (this.isPlayerBlack() && this.isBlacksTurn()) || (this.isPlayerWhite() && !this.isWhitesTurn()); 
	}; 

	// export class constructor 
	return GameState;  

}); 
