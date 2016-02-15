
angular.module("MDKApp")
    .service("apiService", ['$http', '$rootScope', 'serverName', 'port', 'AdminServices', function ($http, $rootScope, serverName, port, AdminServices) {

        var self = this;

        self.__get = function (url) {
            return $http.get(url);
        };

        self.__post = function (url, data, config) {
            return $http.post(url, data, config);
        };

        self.validateUser = function (data) {

            console.log(serverName + port + AdminServices + "validateUser");
            var d = "last post ";
            return self.__post(serverName + port + AdminServices + "validateUser", { "data":angular.toJson(data) });
        };


        return self;
    }]);
