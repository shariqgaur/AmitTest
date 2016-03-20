
angular.module("MDKApp").controller("DashboardCtrl", ["$scope","$rootScope", "$state", "apiService", function ($scope,$rootScope, $state, apiService) {


    var init = function () {
$rootScope.loading=apiService.getAllBusinessLines().then(getAllBusinessLinesSuccess).catch();
    };

    var getAllBusinessLinesSuccess = function (data) {
        console.log(data);

        if (data && data.data && data.data.getAllBusinessLinesResult && data.data.getAllBusinessLinesResult.allRecords) {
            
            $scope.businessLines = data.data.getAllBusinessLinesResult.allRecords;
            console.log($scope.businessLines);
        }

    };



    init();
}]);