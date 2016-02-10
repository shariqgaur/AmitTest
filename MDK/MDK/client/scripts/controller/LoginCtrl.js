angular.module("MDKApp").controller("LoginCtrl",["$scope","$state",function ($scope,$state) {
    



    $scope.login = function () {
        //$scope.isLoginError = true;
        $state.go("dashboard");
    };
 }]);