angular.module("MDKApp").controller("LoginCtrl", ["$scope", "$state", "apiService", function ($scope, $state, apiService) {
    $scope.msg = "My Login";

    $scope.login = function () {
        alert('sai');
        //$state.go('dashboard');
        apiService.validateUser().then(function () {
            alert('success');
        }).catch(function () {
            alert('error');
        });
    };
}]);