
angular.module("MDKApp").controller("LineDetailsCtrl", ["$scope", "$rootScope", "$state", "$stateParams", "apiService", "Upload", function ($scope, $rootScope, $state, $stateParams, apiService, Upload) {

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

    $scope.documentTypes = [
        { text: 'IT Acknowledgement', value: 'ITAcknowledgement' },
        { text: '26 AS', value: '26AS' },
        { text: 'TAX Challan', value: 'TAXChallan' },
        { text: 'Audit Report', value: 'AuditReport' },
        { text: 'Workbook', value: 'Workbook' },
        { text: 'Other', value: 'other' },

    ];

    $scope.upperButtons = [
         
          { text: 'Workbook' },
          { text: 'Audit Report' },
          { text: 'TAX Challan' },
          { text: '26 AS' },
          { text: 'IT Acknowledgement' }
    ];

    $scope.fileChanged = function () {
        // console.log($scope.modelDocument);
    };


    $scope.showACKNSection = function (index) {
        $scope.selectedDownloadDoc = index;

        $scope.isShowACKNSection = true;
    };

    $scope.hideACKNSection = function () {
        $scope.selectedDownloadDoc = 999;
        $scope.isShowACKNSection = false;
    }

    $scope.ACKNFileUpload = function () {
        $rootScope.loading = apiService.uploadITACKN($scope.ACKNFile).then(function (data) {
        }).catch();
    };

    $scope.formatYear = function (year) {
        var nextYear = year + 1;
        return year + "-" + nextYear;
    };


    $scope.docThumbnail = "../client/images/defaultDoc.png";



    $scope.uploadDocument = function () {
        $rootScope.loading = Upload.upload({
            url: 'http://localhost:9595/WCF/BusinessServices/BusinessServices.svc/uploadDocuments',
            data: { file: $scope.modelDocument },
            headers: {
                businessId: businessGUID,
                selectedYear: $scope.selectedYear,
                selectedDocType: $scope.selectedDocumentType
            }
        }).then(function (resp) {
            console.log('Success ');// + resp.config.data.file.name + 'uploaded. Response: ' + resp.data);
        }, function (resp) {
            console.log('Error status: ' + resp.status);
        }, function (evt) {
            var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
            console.log('progress: ' + progressPercentage + '% ');//+ evt.config.data.file.name);
        });

    };



    init();
}]);
