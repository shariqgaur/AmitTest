angular.module("smbApp")
	   .service('windowsexception', ['$window', function ($window) {
	   	
	   		$window.onerror = function(message, url, line, col, error) {
            var stopPropagation = true;
            var data = {
                type: 'javascript',
                url: window.location.hash,
                localtime: Date.now()
            };
            if (message) {
                data.message = message;
            }
            if (url) {
                data.fileName = url;
            }
            if (line) {
                data.lineNumber = line;
            }
            if (col) {
                data.columnNumber = col;
            }
            if (error) {
                if (error.name) {
                    data.name = error.name;
                }
                if (error.stack) {
                    data.stack = error.stack;
                }
            }
            
            //TODO: need to know how do application handle such errors. do we log into Google Analytics or on our server
            console.log(data);
            return stopPropagation;
        };

	   }]);