
angular.module("MDKApp").controller("DashboardCtrl", ["$scope", "$state", "apiService", function ($scope, $state, apiService) {


    var init = function () {
        apiService.getAllBusinessLines().then(getAllBusinessLinesSuccess).catch();
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