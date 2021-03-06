﻿
angular.module("MDKApp").controller("LineDetailsCtrl", ["$uibModal", "$scope", "$rootScope", "$state", "$stateParams", "apiService", "Upload", function ($uibModal, $scope, $rootScope, $state, $stateParams, apiService, Upload) {

    var businessGUID = $stateParams.businessId;
 
    $scope.businessYears = [2011, 2012, 2013, 2014, 2015, 2016];

    $scope.documentTypes = [
        { text: 'Income TAX', value: 'INCOMETAX' },
        { text: 'Sales TAX', value: 'SALESTAX' },
        { text: 'Service TAX', value: 'ServiceTAX' },
        { text: 'Excise TAX', value: 'ExciseTAX' }

    ];


    $scope.subDocuementForIncomeTax = [
        { text: 'IT ACK', value: 'IncomeTax' },
        { text: 'Excel workbook', value: 'SALESTAX' },
        { text: 'Audit Report', value: 'ServiceTAX' },
        { text: '26AS', value: 'ExciseTAX' },
        { text: 'Challans', value: 'Challans' }

    ];

    $scope.subDocumentsForSalesTax = [
        { text: 'VAT Returns', value: 'IncomeTax' },
        { text: 'CST Returns', value: 'SALESTAX' },
        { text: 'PTRC Returns', value: 'ServiceTAX' },
        { text: 'PTEC Challan', value: 'ExciseTAX' },
        { text: 'Annexure J1/J2', value: 'Challans' },
        { text: '704 ACK', value: 'Challans' },
        { text: 'Excel workbook', value: 'Challans' },
        { text: 'Challans', value: 'Challans' }

    ];


    $scope.periods = [
            { text: 'Monthly', value: 'MONTHLY' },
            { text: 'Quarterly', value: 'QUA' },
            { text: 'Half Yearly', value: 'HYear' },
            { text: 'Yearly', value: 'YEARLY' }
    ];


    $scope.subcategories = [];

    $scope.$watch('selectedDocumentType', function (newVal, oldvalue) {

        if (newVal == 'INCOMETAX') {
            $scope.subcategories = $scope.subDocuementForIncomeTax;
        }
        else if (newVal == 'SALESTAX') {
            $scope.subcategories = $scope.subDocumentsForSalesTax;
        }
    });


    $scope.docThumbnail = "../client/images/defaultDoc.png";

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

        $scope.getBankDetails();
        $scope.getITDetails();
        $scope.getOtherDetails();
    };

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

    $scope.getDocumentsToDownload = function () {

        var fileDetails = {
            BusinessGUID: businessGUID,
            SelectedYear: $scope.selectedDownloadYear,

        }

        $rootScope.loading = apiService.getDocumentsToDownload(fileDetails).then(function (data) {
            if (data && data.data && data.data.getDocumentsToDownloadResult.SuccessCode === "FILE_LIST_RETRIEVED") {
                $scope.fetchedFileList = angular.fromJson(data.data.getDocumentsToDownloadResult.fileModel);
                console.log($scope.fetchedFileList);
                $scope.openFileListModel();
            }
        }).catch();
    };

    $scope.openFileListModel = function () {

        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: '../client/views/fileModal.html',
            controller: 'FileModalCtrl',
            resolve: {
                fileList: function () {
                    return {
                        BusinessGUID: businessGUID,
                        SelectedYear: $scope.formatYear($scope.selectedDownloadYear),
                        FileList: $scope.fetchedFileList
                    }
                }

            }
        });

    };

    $scope.getBankDetails = function () {

        $rootScope.loading = apiService.getBankDetails(businessGUID).then(function (data) {
            if (data && data.data) {
                var bankDataFetched = data.data.getBankDetailsResult.bankModel;

                $scope.bankName = bankDataFetched.BankName;
                $scope.branch = bankDataFetched.BankBranch;
                $scope.bankAccountNumber = bankDataFetched.BankAccountNumber;
                $scope.bankIFSCCode = bankDataFetched.IFSCCode;
                $scope.bankMICRCode = bankDataFetched.MICRCode;

            }


        }).catch();
    };

    $scope.getITDetails = function () {

        $rootScope.loading = apiService.getITDetails(businessGUID).then(function (data) {

            if (data && data.data) {
                var fetchedITDetails = data.data.getITDetailsResult.itInfoModel;
                $scope.PAN = fetchedITDetails.PAN_NO;
                $scope.TAN = fetchedITDetails.TAN_NO;
                $scope.VAT = fetchedITDetails.VAT_NO;
                $scope.CST = fetchedITDetails.CST_NO;
                $scope.PTRCNumber = fetchedITDetails.PTRC_NO;
                $scope.PTECNumber = fetchedITDetails.PTEC_NO;
            }

        }).catch();

    };

    $scope.getOtherDetails = function () {

        $rootScope.loading = apiService.getOtherDetails(businessGUID).then(function (data) {

            if (data && data.data) {
                var fetchedOtherinfo = data.data.getOtherDetailsResult.otherInfoModel;

                $scope.exciseNumber = fetchedOtherinfo.ExciseNumber;
                $scope.pFESI_NO = fetchedOtherinfo.PFESI_NO;
                $scope.serviceTaxNumber = fetchedOtherinfo.ServiceTaxNumber;


            }
        }).catch();
    };

    init();
}]);
