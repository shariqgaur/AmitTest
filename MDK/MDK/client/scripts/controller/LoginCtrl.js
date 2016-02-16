angular.module("MDKApp").controller("LoginCtrl", ["$scope", "$state", "apiService", function ($scope, $state, apiService) {
    $scope.msg = "My Login";

    $scope.login = function () {

        var loginInfo = {
            UserId: $scope.userId,
            Password: $scope.userPassword
        };

        apiService.validateUser(loginInfo).then(function (data) {
 
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