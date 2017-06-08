(function() {
    'use strict';

    var multiply = function(factor) {
        var that = {
            result: 1
        };

        that.multiplyAction = function(factor) {
            if (isNaN(factor) || factor == null) {
                console.error("Not a number");
            } else {
                that.result *= factor;
            }

            return that.multiplyAction;
        };

        that.multiplyAction.valueOf = function() {
            return that.result;
        };

        return that.multiplyAction(factor);
    };

    var run = function() {
        // I'm coercing Console.Log API to evaluate the result of my function as a string and not a object
        console.log('' + multiply(2)(5)(4));
        console.log('' + multiply(3)(6)(8));
    };

    run();
})();