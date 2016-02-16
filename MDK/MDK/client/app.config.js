
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
          templateUrl:"views/lineDetails.html",
          controller: "LineDetailsCtrl"
      });

  $urlRouterProvider.otherwise("/lineDetails");

}]);


