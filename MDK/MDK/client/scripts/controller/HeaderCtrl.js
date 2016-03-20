angular.module("MDKApp").controller("HeaderCtrl", ["$scope", "$rootScope", "$state", "apiService", function ($scope,$rootScope, $state, apiService) {
   
    $scope.logout = function () {
        $rootScope.isUserLoggedIn = false;
        $rootScope.loggedInUserName = "";
        $state.go('logout');
    };
}]);