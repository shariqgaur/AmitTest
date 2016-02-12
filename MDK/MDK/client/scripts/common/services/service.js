
angular.module("MDKApp")
    .service("apiService", ['$http', '$rootScope', function ($http, $rootScope) {

        var self = this;

        self.__get = function (url) {
            return $http.get(url);
        };

        self.__post = function (url, data, config) {
            return $http.post(url, data, config);
        };

        self.validateUser = function (data) {
            return self.__post("http://localhost:1062/AdminServices/AdminServices.svc/validateUser", "{data:data}");
        };


        return self;
    }]);
