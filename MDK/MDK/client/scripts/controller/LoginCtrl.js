angular.module("MDKApp").controller("LoginCtrl", ["$scope","$state", function ($scope,$state) {
    $scope.msg = "My Login";

    $scope.login = function () {
        alert('sai');
        $state.go('dashboard');
    };
}]);