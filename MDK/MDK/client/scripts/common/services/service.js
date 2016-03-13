
angular.module("MDKApp")
    .service("apiService", ['$http', '$rootScope', 'serverName', 'port', 'AdminServices', 'BusinessServices', function ($http, $rootScope, serverName, port, AdminServices, BusinessServices) {

        var self = this;

        self.__get = function (url) {
            return $http.get(url);
        };

        self.__post = function (url, data, config) {
            return $http.post(url, data, config);
        };

        self.validateUser = function (data) {
            return self.__post(serverName + port + AdminServices + "validateUser", { "data": angular.toJson(data) });
        };

        self.getAllBusinessLines = function () {
            return self.__post(serverName + port + BusinessServices + "getAllBusinessLines", { "data": "" });

        }

        self.savePersonalInfo = function (data) {
            return self.__post(serverName + port + BusinessServices + "createBusinessUser", { "data": angular.toJson(data) });
        };

        self.getLineDetails = function (data) {
            return self.__post(serverName + port + BusinessServices + "getLineDetails", { "data": angular.toJson(data) });
        };

        self.getDocumentsToDownload = function (fileDetails) {
            return self.__post(serverName + port + BusinessServices + "getDocumentsToDownload", { "data": angular.toJson(fileDetails) });
        };

        self.saveBankInformation = function (data) {
            return self.__post(serverName + port + BusinessServices + "saveBankInformation", { "data": angular.toJson(data) });
        };

        self.saveITInfo = function (data) {
            return self.__post(serverName + port + BusinessServices + "saveITInfo", { "data": angular.toJson(data) });
        };

        self.saveOtherInfo = function (data) {
            return self.__post(serverName + port + BusinessServices + "saveOtherInfo", { "data": angular.toJson(data) });
        };
        
        self.getBankDetails = function (data) {
            return self.__post(serverName + port + BusinessServices + "getBankDetails", { "businessGUID": data });
        };

        self.getITDetails = function (data) {
            return self.__post(serverName + port + BusinessServices + "getITDetails", { "businessGUID": data });
        };

        self.getOtherDetails = function (data) {
            return self.__post(serverName + port + BusinessServices + "getOtherDetails", { "businessGUID": data });
        };




    }]);
