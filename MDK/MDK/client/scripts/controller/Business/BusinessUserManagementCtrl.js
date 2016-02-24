﻿angular.module("MDKApp").controller("BusinessUserManagementCtrl", ["$scope", "$state", "apiService", function ($scope, $state, apiService) {

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
            Pid:1,
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

       
        console.log(angular.toJson(personalInfo));

        apiService.savePersonalInfo(personalInfo).then(function (data) {
            console.log('SPI');
           // console.log(data);
        }).catch();

    };








}]);