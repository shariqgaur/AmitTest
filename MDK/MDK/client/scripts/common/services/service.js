
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

        //not in use now
        //self.uploadITACKN = function (file) {

        //    var fd = new FormData();
        //    fd.append('file', file);

        //    return self.__post(serverName + port + BusinessServices + "uploadITACKN", fd, {
        //        transformRequest: angular.identity,
        //        headers: { 'Content-Type': undefined }
        //    });
        //};

        self.getDocumentsToDownload = function (fileDetails) {
            return self.__post(serverName + port + BusinessServices + "getDocumentsToDownload", { "data": angular.toJson(fileDetails) });
        };


    }]);
