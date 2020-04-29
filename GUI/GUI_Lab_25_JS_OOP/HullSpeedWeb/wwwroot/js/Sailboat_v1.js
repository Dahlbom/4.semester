// Sailboat v1
export default function Sailboat()
{
	// private member variables
	var _name;
	var _length;

	// Properties setters and getters
	this.setName = function (value) {
		_name = value;
	}

	this.getName = function() {
		return _name;
	}

	this.setLength = function (value) {
		_length = value;
	}

	this.getLength = function () {
		return _length;
	}

	// Calculate the hull speed for the boat
	this.HullSpeed = function() {
		return 1.34 * Math.sqrt(_length);
	};
}

