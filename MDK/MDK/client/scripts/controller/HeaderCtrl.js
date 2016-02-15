angular.module("MDKApp").controller("HeaderCtrl", ["$scope", "$state", "apiService", function ($scope, $state, apiService) {
   
    $scope.logout = function () {
        $state.go('login');
    };
}]);