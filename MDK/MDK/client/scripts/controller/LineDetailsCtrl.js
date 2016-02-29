
angular.module("MDKApp").controller("LineDetailsCtrl", ["$scope", "$rootScope", "$state", "$stateParams", "apiService", function ($scope, $rootScope, $state, $stateParams, apiService) {

    var businessGUID = $stateParams.businessId;

    var init = function () {
        $rootScope.loading = apiService.getLineDetails(businessGUID).then(function (data) {

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


    $scope.showACKNSection = function () {
        $scope.isShowACKNSection = true;
        
    };

    $scope.hideACKNSection = function () {
        $scope.isShowACKNSection = false;
    }


    $scope.ACKNFileUpload = function () {

     $rootScope.loading=apiService.uploadITACKN($scope.ACKNFile).then(function (data) {

        }).catch();

    };

    init();
}]);

/*
*This is working service to upload file as multipart form data.
*This service uploaded all king of files to the server.
*/

//angular.module("MDKApp").service('fileUpload', ['$http', function ($http) {
//    this.uploadFileToUrl = function (file, uploadUrl) {
//        var fd = new FormData();
//        fd.append('file', file);
//        $http.post(uploadUrl, fd, {
//            transformRequest: angular.identity,
//            headers: { 'Content-Type': undefined }
//        })
//        .success(function () {
//        })
//        .error(function () {
//        });
//    }
//}]);

