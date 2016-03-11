angular.module("MDKApp").
constant('serverName', 'http://10.50.210.175:').
constant('port', '1545').
constant('AdminServices', '/WCF/AdminServices/AdminServices.svc/').
constant('BusinessServices', '/WCF/BusinessServices/BusinessServices.svc/');

angular.module('MDKApp').value('cgBusyDefaults', {
    message: 'sai...',
    backdrop: true,
    templateUrl: 'views/loader.html',
    delay: 300,
    minDuration: 700
});