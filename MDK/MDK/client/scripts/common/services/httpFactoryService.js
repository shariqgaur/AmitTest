
 
    var service = angular.module('httpFactoryService', []);

    service.factory('HttpFactory', ['$http', '$rootScope', function ($http, $rootScope) {
        var HttpFactory;
        
        if(false)
        {   
         HttpFactory = {
            getDataByHttpPost: function (inputParams) {
                $rootScope.loading = true;
                return $http(inputParams).then(function (data) {
                    $rootScope.loading = false;
                    $rootScope.error = '';
                    if (data.data.errorCode == 401) {
                            $rootScope.error = data.data.message;
                    }

                    return data.data;

                }, function (error) {
                    $rootScope.loading = false;
                    if (error.status == 500) {
                        $rootScope.error = error.data.message;
                    }
                });
            },
            callHttpPostWithQ: function (config) {
                var deferred = $q.defer();
                $http(config).success(function (data) {
                    deferred.resolve(data);
                }).error(function () {
                    deferred.reject();
                    //error handling goes here.
                });
                return deferred.promise;
            }            
        };
    }
        
        else
        {
           HttpFactory = {
                getStubFile:function(fileName){
                    console.log('Service in service');
                  return $http({method: 'GET', url: fileName});
                }
         };  
            
        }
         return HttpFactory;
    }]);

 


