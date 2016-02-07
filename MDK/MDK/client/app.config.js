
angular.module('MDKApp').config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
  $stateProvider.
      state("login", {
        url: "/login",
        templateUrl: "views/login.html",
      });

  $urlRouterProvider.otherwise("/login");

}]);


