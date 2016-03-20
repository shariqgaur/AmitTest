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



    $scope.documentTypes = [
        { text: 'Income TAX', value: 'INCOMETAX' },
        { text: 'Sales TAX', value: 'SALESTAX' },
        { text: 'Service TAX', value: 'ServiceTAX' },
        { text: 'Excise TAX', value: 'ExciseTAX' }

    ];
         
    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);