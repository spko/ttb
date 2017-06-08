// I tried to create as much as possible a reusable song theme object, that could be used for any songs and with the shortest string generation logic.
// Which is basically located in Note.toString and Theme.toString methods
(function() {
    'use strict';

    function Note (note, rep) {
        this.note = note;
        this.repeat = rep;
    };

    function Theme (name, themeNotes) {
        this.themeName = name;
        this.notes = themeNotes;
    };

    Note.prototype.toString = function () {
        return this.note.repeat(this.repeat);
    };

    Theme.prototype.toString = function () {
        return this.themeName + ' theme: ' + this.notes.join('');
    };

    var run = function() {
        var notes = [new Note('NaN', 15), new Note('Batman', 1)];
        var theme = new Theme('Batman', notes);

        // I'm coercing Console.Log API to evaluate the result of my function as a string and not a object
        console.log('' + theme);
    };

    run();
}());