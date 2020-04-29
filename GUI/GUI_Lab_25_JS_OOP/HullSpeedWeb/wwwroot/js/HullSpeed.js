// Hullspeed.js
import Sailboat from '/js/Sailboat_v2.js';

// Adjust image to render within windows
function adjustImage() {
	document.getElementById("sailboat").height = window.innerHeight - 20;
}

adjustImage(); // Call when file loads

window.onresize = function() {
	adjustImage();
}

var ship = new Sailboat();

document.getElementById("calculateHullSpeed").addEventListener("click",
	function(event) {
		event.preventDefault();

		// For Sailboat_v1
		//ship.setName(document.getElementById("name").value);
		//ship.setLength(parseInt(document.getElementById("length").value));

		// For sailboat_v2 and v_2
		ship.name = document.getElementById("name").value;
		ship.length = document.getElementById("length").value;

		console.log(ship._length); // Should write "undefined" if _length is private

		document.getElementById("result").value = ship.hullSpeed().toFixed(1);

	});