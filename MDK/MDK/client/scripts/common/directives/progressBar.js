angular.module("MDKApp").directive('inProgressModal', ['$rootScope', function ($rootScope) {

    return {
        restrict: "A",
        replace: false,
        link: function ($scope, element) {

            $rootScope.$watch('loading', function (newValue) {
                if (newValue) {
                    element.find('.modal').modal({ backdrop: "static", keyboard: false });
                    angular.element(document.getElementById("device")).find('.modal').modal({ backdrop: "static", keyboard: false });
                } else {
                    element.find('.modal').modal('hide');
                }
            })
        }
    }

}]);

