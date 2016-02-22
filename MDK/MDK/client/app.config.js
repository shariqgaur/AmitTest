
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
            url: "/lineDetails",
            templateUrl: "views/lineDetails.html",
            controller: "LineDetailsCtrl"
        }).state("addUser", {
            url: "/addUser",
            templateUrl: "views/userManagement.html",
            controller: function () { }

        });

    $urlRouterProvider.otherwise("/addUser");

}]);


