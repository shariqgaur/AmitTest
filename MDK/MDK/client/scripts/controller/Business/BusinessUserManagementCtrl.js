angular.module("MDKApp").controller("BusinessUserManagementCtrl", ["$scope", "$rootScope", "$state", "apiService", function ($scope, $rootScope, $state, apiService) {

    /*
     * Year formatting in dropdown with html 
     *
    <select class="form-control" ng-options="item as yearDisplayFormat(item) for item in [2000,2001]" ng-model="selectedType"> 
    $scope.yearDisplayFormat = function (item) {
        var incremented = item + 1;
        return item + '-'+incremented;
    }
   */

    $scope.savePersonalInfo = function () {

        var personalInfo = {
            Pid: 1,
            FirstName: $scope.firstName,
            MiddleName: $scope.middleName,
            LastName: $scope.lastName,
            BusinessName: $scope.businessName,
            BusinessType: $scope.businessType,
            ContactNo: $scope.contactNumber,
            AlternateNumber: $scope.alternateNumber,
            EmailID: $scope.emailId,
            DateOfBirth: $scope.DateOfBirth,
            BusinessGUID: '',
            BusinessAddress: $scope.businessAddress
        };



        $rootScope.loading = apiService.savePersonalInfo(personalInfo).then(function (data) {

            if (data.data.createBusinessUserResult.SuccessCode === "RECORD_SAVED_SUCCESSFULLY") {

                $scope.isBusinessInfoSaved = true;
                $scope.personalRecordSavedMSG = data.data.createBusinessUserResult.SuccessMessage;
                $scope.businessID = data.data.createBusinessUserResult.tPersonalInfoData.BusinessGUID;
            }
            else {
                $scope.isBusinessInfoSaved = false;
                $scope.personalRecordSavedMSG = data.data.createBusinessUserResult.ErrorMessage;
            }

        }).catch();

    };

    $scope.saveBankInformation = function () {

        var bankInfo = {
            BusinessGUID: $scope.businessID,
            BankName: $scope.bankName,
            BankBranch: $scope.bankBranch,
            BankAccountNumber: $scope.bankAccountNumber,
            IFSCCode: $scope.bankIFSCCode,
            MICRCode: $scope.bankMICRCode
        }

        $rootScope.loading = apiService.saveBankInformation(bankInfo).then(function (data) {


            if (data.data.saveBankInformationResult.SuccessCode === "RECORD_SAVED_SUCCESSFULLY") {
                $scope.isBankInfoSaved = true;
                $scope.bankInfoSavedMSG = data.data.saveBankInformationResult.SuccessMessage;
            }
            else {
                $scope.isBankInfoSaved = false;
                $scope.bankInfoSavedMSG = data.data.saveBankInformationResult.ErrorMessage;
            }


        }).catch();

    };

    $scope.saveITInfo = function () {
       
        var ITInfo = {
            IncomeTax: '',
            PAN_NO: $scope.PAN,
            TAN_NO: $scope.TAN,
            VAT_NO: $scope.VAT,
            CST_NO: $scope.CST,
            PTRC_NO: $scope.PTRC,
            PTEC_NO: $scope.PTEC,
            SalesTax: '',
            BusinessGUID: $scope.businessID
        }

        $rootScope.loading = apiService.saveITInfo(ITInfo).then(function (data) {
            if (data.data.saveITInfoResult.SuccessCode === "RECORD_SAVED_SUCCESSFULLY") {
                $scope.isITInfoSaved = true;
                $scope.iTInfoSavedMSG = data.data.saveITInfoResult.SuccessMessage;
            }

        }).catch();



    };

    var temp = {
        ServiceTaxNo: $scope.serviceTaxNumber,
        ExciseNo: $scope.exciseNumber,
        PFESI_NO: $scope.PFESINumber,
        BusinessGUID: $scope.businessID
    };




}]);