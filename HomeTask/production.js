// I would store connection IDs in a separate configuration file depending on the current targeted platform, let's name it config.js
// In that case, the content of this file would be something like this:

// config.js
var fs = require('fs'),
var configPath = './productionConfig.json';
var configuration = JSON.parse(fs.readFileSync(configPath, 'UTF-8'));
exports.dbConfig = configuration;

// #######################
// Here is our DB service class

var mysql = require('mysql');
var config = require('./config');

GLOBAL.con = mysql.createConnection({
    'hostName': config.dbConfig.host,
    'userName': config.dbConfig.user,
    'password': config.dbConfig.pwd,
    'database': config.dbConfig.database,
    "port": config.dbConfig.port
});

function insert(what, condition, errorCallback) {
    // Check input parameters before creating SQL connection
    if (!what && !condition) {
        return;
    }

    // Escape the user input with Escape function
    condition = 'WHERE 1=1 OR ' + con.escape(condition);

    // Open connection
    con.connect(function(error) {
        if (error) {
            console.error('Error during connection: ' + error.stack);
            return;
        }
        console.log('ConnectionID: ' + con.threadId);
    });

    // Or escape the user input with query integrated mechanism and replacement of ? placeholders
    var res = con.query('UPDATE users SET ? WHERE ?', [what, condition], function(error, results, fields) {
        // End the connection after execution of the query
        con.end();
        if (error || results) {
            if (error) {
                console.error('Error on query: ' + error);
                return;
            }
            
            return 'success';
        }
    });

    // The expression "!res" is always false because res object will always contain the Query object
    // However, since the query is asynchronous and if we want to apply a dedicated logic 
    // when an error occurs, the caller of this method should provide a callback function with corresponding logic
    // We can call this callback here or in the default callback above
    res.on('error', errorCallback);
};

var errorCallback = function (error) {
    // Custom logic here
};

insert("password = 'abc123'", 'id_of_user = 10', errorCallback);