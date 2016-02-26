
angular.module('MDKApp').config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    $stateProvider.
        state("login", {
            url: "/login",
            templateUrl: "views/login.html",
            controller: "LoginCtrl"
        }).state("dashboard", {
            url: "/dashboard",
            templateUrl: "views/dashboard.html",
            controller: "DashboardCtrl"
        }).state("lineDetails", {
            url: "/lineDetails/{businessId}",
            templateUrl: "views/lineDetails.html",
            controller: "LineDetailsCtrl"
        }).state("userManagement", {
            url: "/userManagement",
            templateUrl: "views/userManagement.html",
            controller: "UserManagementCtrl"

        }).state("businessUserManagement", {
            url: "/businessUserManagement",
            templateUrl: "views/Business/businessUserManagement.html",
            controller: "BusinessUserManagementCtrl"
        });

    $urlRouterProvider.otherwise("/businessUserManagement");

}]);


