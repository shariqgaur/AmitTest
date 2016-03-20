angular.module("MDKApp").controller("BusinessUserManagementCtrl", ["$scope", "$rootScope", "$state", "apiService", function ($scope, $rootScope, $state, apiService) {

    /*
     * Year formatting in dropdown with html 
     *
    <select class="form-control" ng-options="item as yearDisplayFormat(item) for item in [2000,2001]" ng-model="selectedType"> 
    $scope.yearDisplayFormat = function (item) {
        var incremented = item + 1;
        return item + '-'+incremented;
    }

    //Indian pan card validation
    ^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$
   */

    $scope.businessTypes = [
        { text: 'Propriotorship', value: 'PROP' },
        { text: 'Partnership', value: 'PARTNER' },
        { text: 'LLP', value: 'LLP' },
        { text: 'PVT LTD', value: 'PLTD' },
        { text: 'LTD', value: 'LTD' }


    ];


    $scope.ownersList = [];

    function OwnerModel(firstName, middleName, lastName) {
        this.firstName = firstName;
        this.middleName = middleName;
        this.lastName = lastName;
    };



    $scope.businessTypeChange = function () {


        $scope.ownersList = [];
        if (!$scope.selectedBusinessType) {
            $scope.ownersList = [];

        }
        else if ($scope.selectedBusinessType == 'PROP') {

            $scope.ownersList.push(new OwnerModel('', '', ''));
        }

        else {

            $scope.ownersList.push(new OwnerModel('', '', ''));
            $scope.ownersList.push(new OwnerModel('', '', ''));
        }

        if ($scope.selectedBusinessType === 'PARTNER' || $scope.selectedBusinessType === 'LLP') {
            $scope.addMoreOwnerText = '+ Add more partners';
        }

        else if ($scope.selectedBusinessType === 'PLTD' || $scope.selectedBusinessType === 'LTD') {
            $scope.addMoreOwnerText = '+ Add more directors';
        }

    };

    $scope.addMorePartner = function () {
        $scope.ownersList.push(new OwnerModel('', '', ''));
    };


    $scope.savePersonalInfo = function () {

        var personalInfo = {
            Pid: 1,
            FirstName: $scope.firstName,
            MiddleName: $scope.middleName,
            LastName: $scope.lastName,
            BusinessName: $scope.businessName,
            BusinessType: $scope.selectedBusinessType,
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



    $scope.saveOtherInfo = function () {

        var otherInfo = {
            ServiceTaxNumber: $scope.serviceTaxNumber,
            ExciseNumber: $scope.exciseNumber,
            PFESI_NO: $scope.PFESINumber,
            BusinessGUID: $scope.businessID
        };

        $rootScope.loading = apiService.saveOtherInfo(otherInfo).then(function (data) {

            if (data.data.saveOtherInfoResult.SuccessCode === "RECORD_SAVED_SUCCESSFULLY") {
                $scope.isOtherInfoSaved = true;
                $scope.otherInfoSavedMSG = data.data.saveOtherInfoResult.SuccessMessage;
            }

        }).catch();
    };

    $('#ifscInfo').tooltip({ container: 'body' });
    $('#micrInfo').tooltip({ container: 'body' });
    $('#businessPANInfo').tooltip({ container: 'body' });
}]);
