//SaiRahem
var app = angular.module("MDKApp", ['ui.bootstrap', 'ui.router', 'cgBusy', 'ngFileUpload', 'directives.customvalidation.customValidationTypes']);


app.run(function ($rootScope, $location, $q) {
    var routeDeferred;

    $rootScope.$on('$stateChangeStart', function () {
        routeDeferred = $q.defer();
        $rootScope.loading = routeDeferred.promise;
    });
    $rootScope.$on('$stateChangeSuccess', function () {
        routeDeferred.resolve();
    });


    //$rootScope.$on('$routeChangeError', function () {
    //    routeDeferred.reject();
    //});
});