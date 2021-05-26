define(function (require) { 
	'use strict'; 

	const LangUtils = require('./LangUtils'); 

	const AjaxUtils = { 
		_gameState: null, 

		setGameState: function(gameState) { 
			AjaxUtils._gameState = gameState; 
		}, 

		getGameID: function() { 
			return AjaxUtils._gameState.getGameID(); 
		}, 


		callServer: function (actionURL, callback, callback, callbackContext) { 
			jQuery.ajax(makeAjaxOptionsWithNoData(actionURL, callback, callbackContext)); 
		}, 

		callServerWithData: function (actionURL, actionData, callback, callbackContext){ 
			jQuery.ajax(makeAjaxOptionsWithActionDate(actionURL, actionData, callback, callbackContext)); 
		} 
	}; 

	function myDataFilter(data) { 
		if (data[0] === '<') { 
			throw new Error('HTML content detected in Ajax response.' + ' Did you accidentally perform a redirect in your Spark Route?' + ' Sorry, that\'s a no-no.'); 
		} 
		else{ 
			return JSON.parse(data); 
		} 
	}

	function handleErrorResponse(xhr, textStatus, error) { 
		if(xhr.status === 404) { 
			throw new Error('This Ajax call has not been implemented.'); 
		} 
		else if (xhr.status === 500){ 
			throw new Error('This Ajax call threw an exception: ' + error); 
		} 
		else if(xhr.status === 0){ 
			throw new Error('The WebCheckers server is down.'); 
		} 
		else{ 
			throw new Error(`Unknown error (status=${xhr.status}) error: '${error}'`); 
		} 
	} 

	function makeAjaxOptionsWithNoData(actionURL, callback, callbackContext) { 
		return _makeAjaxOptions(actionURL, ajaxParams(), callback, callbackContext); 
	} 

	function makeAjaxOptionsWithActionData(actionURL, actionData, callback, callbackContext) { 
		return _makeAjaxOptions(actionURL, ajaxParams(actionData), callback, callbackContext); 
	}

	function ajaxParams(actionData) { 
		const params = {}; 
		if(LangUtils.exists(actionData)){ 
			params.actionData = convertActionData(actionData); 
		} 
		return params; 
	} 

	function convertActionData(actionData) { 
		return(typeof actionData === 'object') ? JSON.stringify(actionData) : actionData; 
	} 

	function _makeAjaxOptions(actionURL, parameters, callback, callbackContext) { 
		return { 
			method: 'POST', 
			url: actionURL, 

			contentType: 'application/x-www-form-urlencoded; charset=UTF-8', 	
			data: parameters, 

			beforeSend: function () { 
				console.debug(`POST ${actionURL} being sent.`); 
			}, 
			dataFilter: myDataFilter, 
			success: callback.bind(callbackContext), 
			error: handleErrorResponse, 
			complete: funtion(xhr, textStatus) { 
				console.debug(`POST ${actionURL} response complete with '${textStatus}' status.`); 
			} 
		}; 
	}
	
	return AjaxUtils; 

});  
