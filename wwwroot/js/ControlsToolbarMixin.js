define(function (require) { 
	'use strict'; 
	
	var DISABLED = 'disabled'; 
	
	function ControlsToolbarMixin() { 
		var _buttonMap = {}; 
		var $toolbar = $('div.toolbar'); 

		this.addButton = function addButton(id, label, enabled, tooltip, actionMethod) { 
			var $button = $('<button/>', { 
				type: 'button', 
				id: id, 
				text: label, 
				title: tooltip 
			}); 

			$button.on('click', makeViewEventHandler(actionMethod.bind(this))); 
			$toolbar.append($button); 
			_buttonMap[id] = $button; 
			if(!enabled) this.disableButton(id); 
		}; 

		this.disableButton = function disableButton(id) { 
			getButton(id).attr('disabled', 'disabled'); 
		};

		this.enableButton = function enableButton(id) { 
			getButton(id).removeAttr(DISABLED); 
		}; 

		this.hideButton = function hideButton(id) { 
			getButton(id).hide(); 
		}; 


		this.showButton = function showButton(id) { 
			getButton(id).show(); 
		}; 

		function makeViewEventHandler(actionMethod) { 
			return function (event) { 
				if($(this).is("[disabled]")){ 
					event.preventDefault(); 
					return; 
				} 
				actionMethod(event); 
			} 
		}

		function getButton(id) { 
			if(id === null || id === undefined) { 
				throw new Error("no button id"); 
			} 
			var $button = _buttonMap[id]; 
			if($button === null || $button === undefined) { 
				throw new Error("Unknown button: " + id); 
			} 
			return $button; 
		}
	}; 

	return ControlsToolbarMixin; 
});   
		
