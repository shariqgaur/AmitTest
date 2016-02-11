angular.module("smbApp")
    .service('httpinterceptor', ['$httpProvider', function ($httpProvider) {

        $httpProvider.interceptors.push(function ($q, $state) {
            return {
                'responseError': function (rejection) {
                    //If session is invalid - user needs to be redirected to login page
                    if (rejection.status === '401') {
                        return $state.go('login');
                    }

                    //Provide global handler to log exception over here
                    //TODO: need to know how do application handle such errors. do we log into Google Analytics or on our server
                    console.log(rejection);
                    return $q.reject(rejection);
                }
            };
        });
    }]);