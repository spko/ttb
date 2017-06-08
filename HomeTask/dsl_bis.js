(function() {
    'use strict';

    function transform (_sourceValue) {
        var sourceValue = _sourceValue;

        function impl() {
        };

        impl.uppercase = function () {
            sourceValue = sourceValue.toUpperCase();

            return impl;
        };

        impl.hyphenate = function () {
            sourceValue = sourceValue.replace(' ', '-');

            return impl;
        };

        impl.valueOf = function() {
            return sourceValue;
        };

        return impl;
    };

    var run = function () {
        // I'm coercing Console.Log API to evaluate the result of my function as a string and not a object 
        console.log('' + transform("Brown fox").uppercase().hyphenate());
        console.log('' + transform("White fox").hyphenate().uppercase());
    };

    run();

}());