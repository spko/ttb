(function() {
    'use strict';

    function transform(_sourceValue) {
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

        impl.val = function () {
            return sourceValue;
        };

        return impl;
    };

    var run = function () {
        console.log(transform("Brown fox").uppercase().hyphenate().val());
        console.log(transform("White fox").hyphenate().uppercase().val());
    };

    run();

}());