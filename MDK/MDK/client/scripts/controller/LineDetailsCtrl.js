
angular.module("MDKApp").controller("LineDetailsCtrl", ["$scope", "$rootScope", "$state", "$stateParams", "apiService","Upload" ,function ($scope,$rootScope, $state, $stateParams, apiService,Upload) {

    var businessGUID = $stateParams.businessId;

    var init = function () {
        $rootScope.loading=apiService.getLineDetails(businessGUID).then(function (data) {

            if (data && data.data) {
                var lineData = data.data.getLineDetailsResult.personalInfo;

                $scope.firstName = lineData.FirstName;
                $scope.middleName = lineData.MiddleName;
                $scope.lastName = lineData.LastName;
                $scope.businessAddress = lineData.BusinessAddress;
                $scope.contactNo = lineData.ContactNo;
                $scope.alternateNumber = lineData.AlternateNumber;
                $scope.emailId = lineData.EmailID;
                $scope.dateOfBirth = lineData.DateOfBirth;
                $scope.businessName = lineData.BusinessName;
                $scope.businessType = lineData.BusinessType;
                $scope.businessGUID = lineData.BusinessGUID;
            }



        }).catch();
    };

    $scope.uploadFile = function () {

        var sai = Upload.upload({
            url: 'http://localhost:9595/WCF/BusinessServices/BusinessServices.svc/fileUpload',
            data: { file: $scope.file}

        }).then(function (resp) {
            console.log('Success ' + resp.config.data.file.name + 'uploaded. Response: ' + resp.data);
        }).catch();
    };

    init();
}]);