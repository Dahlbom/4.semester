// Sailboat-v2.js
export default function Sailboat() {
    // Private member variables
    var _name;
    var _length;

    // Properties (setters and getters)
    Object.defineProperty(this, "name", {
        get: function () { return _name; },
        set: function (n) { _name = n; }
    });

    Object.defineProperty(this, "length", {
        get: function () { return _length; },
        set: function (n) { _length = n; }
    });

    // Member functions

    // Calculate the hull speed for the boat.
    this.hullSpeed = function () {
        return 1.34 * Math.sqrt(this.length);
    };
}