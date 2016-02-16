angular.module("MDKApp").controller("LoginCtrl", ["$scope", "$rootScope", "$state", "apiService", function ($scope,$rootScope, $state, apiService) {
    $scope.msg = "My Login";

    $scope.login = function () {

        var loginInfo = {
            UserId: $scope.userId,
            Password: $scope.userPassword
        };

        $rootScope.loading=apiService.validateUser(loginInfo).then(function (data) {
 
            if (data.data.validateUserResult.SuccessCode === "VALID_USER") {
                $state.go("dashboard");
            }
            else {
                $scope.loginErrorMessage = data.data.validateUserResult.ErrorMessage;
                $scope.isLoginError = true;
            }

        }).catch(function (data) {
            console.log(data);
        });

        $scope.closeLoginUserValidationAlert = function () {
            $scope.isLoginError = false;
        };

    };
}]);