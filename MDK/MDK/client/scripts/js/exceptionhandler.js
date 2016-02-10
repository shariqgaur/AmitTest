angular.module("smbApp")
    .factory('$exceptionHandler', [function () {

        return function (exception, cause) {

            var data = {
                type: 'angular',
                url: window.location.hash,
                localtime: Date.now()
            };

            if (cause) {
                data.cause = cause;
                $('#errorCause').html(data.cause);

            }

            if (exception) {
                if (exception.message) {
                    data.message = exception.message;
                    $('#errorMessage').html(data.message);
                }
                if (exception.name) {
                    data.name = exception.name;
                    $('#errorName').html(data.name);
                }
                if (exception.stack) {
                    data.stack = exception.stack;
                    $('#errorStack').html(data.stack);
                }
            }

            //TODO: need to know how do application handle such errors. do we log into Google Analytics or on our server
            console.log(data);

        };
    }]);