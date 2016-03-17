angular.module("MDKApp").controller("FileModalCtrl", ["$uibModalInstance", "$scope", "$rootScope", "apiService", "fileList",
    function ($uibModalInstance, $scope, $rootScope, apiService, fileList) {
    
        $scope.fileList = fileList.FileList;
        $scope.year = fileList.SelectedYear;
        $scope.businessGUID = fileList.BusinessGUID;

    $scope.ok = function () {
      
    };

    $scope.f = function () {
        alert('sairahem');
    };

    $scope.downloadFile = function (businessGUID, selectedYear, fileName) {
        alert('sai');

        //var partialPath = businessGUID + '\\' + selectedYear + '\\' + fileName;
    
        //$rootScope.loading = apiService.downloadFile(partialPath).then(function (data) {
         

        //}).catch();
         
    };

    $scope.test = function (businessGUID, selectedYear, fileName) {
        alert('DOWNLOADING..');

        var partialPath = businessGUID + '\\' + selectedYear + '\\' + fileName;
        $rootScope.loading = apiService.downloadFile(partialPath).then(function (data) {

            var blob = new Blob([data], {
                 
            });
         
            navigator.msSaveBlob(blob, 'S.pdf');

        }).catch();

    };
   

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);