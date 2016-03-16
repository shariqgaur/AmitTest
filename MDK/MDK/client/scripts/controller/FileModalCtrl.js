angular.module("MDKApp").controller("FileModalCtrl", ["$uibModalInstance", "$scope", "$rootScope", "apiService", "fileList",
    function ($uibModalInstance, $scope, $rootScope, apiService, fileList) {
    
        $scope.fileList = fileList.FileList;
        $scope.year = fileList.SelectedYear;
        $scope.businessGUID = fileList.BusinessGUID;

    $scope.ok = function () {
      
    };

    $scope.downloadFile = function (businessGUID, selectedYear, fileName) {
        var partialPath = businessGUID + '\\' + selectedYear + '\\' + fileName;

        $rootScope.loading = apiService.downloadFile(partialPath).then(function (data) {
            
        }).catch();
         
    };


   

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);