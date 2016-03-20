
angular.module("MDKApp").controller("LogoutCtrl", ["$scope", "$rootScope", "$state", "$q", "apiService", function ($scope, $rootScope, $state, $q, apiService) {

    var userManagementLoaded = $q.defer();


    setTimeout(function () {
        $rootScope.loading.then(function () {
            userManagementLoaded.resolve();
        }, function () {
            userManagementLoaded.reject();
        });
    }, 0);

}]);