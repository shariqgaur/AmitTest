angular.module("MDKApp").
constant('serverName', 'http://localhost:').
constant('port', '9595').
constant('AdminServices', '/WCF/AdminServices/AdminServices.svc/').
constant('BusinessServices', '/WCF/BusinessServices/BusinessServices.svc/');

angular.module('MDKApp').value('cgBusyDefaults', {
    message: 'Processing...',
    backdrop: true,
    templateUrl: 'views/loader.html',
    delay: 300,
    minDuration: 700
});