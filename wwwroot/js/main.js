/** 
* This file contains the launch code for the Game view. 
*/
(function () { 
	// not strict to get the Game state object from the HTML response 
	//'use strict'; 

	// This 'this' variable here holds the  rowser's window object 
	const gameData = this.gameData; 
	
	define(function (require) { 
		'use strict'; 

		// Imports 
		const GameState = require('./model/GameState'); 
		const GameView = require('./GameView'); 
		const AjaxUtils = require('./util/AjaxUtils'); 

		// Perform startup after the DOM has been built 
		$(document).ready(function () { 
			// Configure global exception handler 
			window.addEventListener('error', function (error) { 
				alert(error.message); 
				console.log(error); 
			}); 

			// Create Game State object 
			const gameState = new GameState(gameData); 
			// create a global variable for debugging purposes 
			window._gameState = gameState; 

			// Initialize AjaxUtils 
			AjaxUtils.setGameState(gameState); 

			// Create the Game View component 
			const view = new GameView(gameState); 
			// create a global variable for debugging purposes 
			window._gameView = view; 

			// Create unload handler 
			window.addEventListener('beforeunload', function (event) { 
				if(!view.canDeactivate()) { 
					// Cancel the event as stated by the standard. 
					event.preventDefault(); 
					return event.returnValue = 'You are in the middle of a turn. Leaving this page might leave the game in a corrupted state.';
				} 
			}); 
	
			// Launch the Game View. 
			// Startup uses the viewMode to determine the View's behavior state model. 
			view.startup(); 
		}); 
	}); 
})(); 

 
