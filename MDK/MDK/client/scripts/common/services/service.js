
angular.module("smbApp")
    .service("apiService", ['$http', '$rootScope', 'serviceURL', function($http, $rootScope, serviceURL){

      var self = this;
     
      self.__get = function(url){
        return $http.get(url);
      };

      self.__post = function(url, data,config){
        return $http.post(url, data,config);
      };

        self.InitiateSession = function (runParam) {

            var data = {
                "UserInfo": angular.copy($rootScope.UserInfo),
                "Fields": {"RUN_PARAM": runParam},
                "Log": [
                    {"USER_MACHINE_IP": ""}
                ]
            };
            return self.__post(serviceURL + "InitiateSession", data,{ async: false}).success(function (data){

//                $rootScope.UserInfo.CallId = angular.fromJson(data.ViewData.INITIATE_SESSION.CALL_INFO.CallId);
            })

        };

        self.PageRefresh = function(){
            var data = {
                "UserInfo" : angular.copy($rootScope.UserInfo),
                "Fields" : {
                },
                "Log": [{"USER_MACHINE_IP": ""}]
            };
            return self.__post(serviceURL + "PageRefresh",data, { async: false});

        };

        self.logoutDashboard = function(logOutAction){

            $rootScope.UserInfo.MDN = "";
            var data = {
                "UserInfo" : angular.copy($rootScope.UserInfo),
                "Fields" : {
                 "LOGOUT_ACTION" : $rootScope.logoutAction

                },
                "Log": [{"USER_MACHINE_IP": ""}]
            };
            //return self.__post(serviceURL + 'getAuthorizationInfo', data);
            return self.__post(serviceURL + 'logout', data);
        };




      self.validateBillingAccount = function(mdn, acctno, captchaResponse){

        $rootScope.UserInfo.MDN = mdn;
        var data = {
          "UserInfo" : angular.copy($rootScope.UserInfo),
          "Fields" : {
            "BAN" : acctno,
            "CAPTCHA_RESPONSE" : captchaResponse,
            "TRANSACTION_NAME" : "AdminLogin"
          },
            "Log": [{"USER_MACHINE_IP": ""}]
        };
        //return self.__post(serviceURL + 'getAuthorizationInfo', data);
          return self.__post(serviceURL + 'validateBillingAccount', data);
      };

      self.getValidatePasscode = function(passcode,mask, isPasscode){
        var data = {
          "UserInfo" : angular.copy($rootScope.UserInfo),
          "Fields" : {
            "TaxIdPasscode" : passcode,
            "MASK" : mask,
            "IsPasscode":isPasscode,
            "TRANSACTION_NAME" : "AdminPasscode"
          },
          "Log": [{"USER_MACHINE_IP": ""}]
        };
        return self.__post(serviceURL + 'AuthorizeSMBUser', data);
      };

      self.getAccountLineDetails = function(mask){
        var data = {
          "UserInfo" : angular.copy($rootScope.UserInfo),
          "Fields" : {
              "MASK" : mask,
              "TRANSACTION_NAME" : "DashBoard_ACCOUNT_LINE_DETAILS"
          },
            "Log": [{"USER_MACHINE_IP": ""}]
        };
        return self.__post(serviceURL + 'getAccountLineDetails', data);
      };

      self.getResources = function(locale){
        return self.__get('{get resource url to load resources by locale}');
      };
      
      self.getClaimDetails = function(){
        var data = {
          "UserInfo" : angular.copy($rootScope.UserInfo),
          "Fields" : {
          "TRANSACTION_NAME" : "DashBoard_GET_CLAIMS_COUNT"
          },
          "Log": [{"USER_MACHINE_IP": ""}]
        };
        return self.__post(serviceURL + "getClaimDetails", data);
      };

        self.getLineDetails = function(linemdn,firstName,lastName){
            var data = {
                "UserInfo" : angular.copy($rootScope.UserInfo),
                "Fields" : {
                    "Line_Mdn":linemdn,
                    "TRANSACTION_NAME" : "GetLineDetails",
                    "FIRST_NAME" : firstName,
                    "LAST_NAME" : lastName
                },
                "Log": [{"USER_MACHINE_IP": ""}]
            };
            return self.__post(serviceURL + "getLineDetails", data);
        };

        self.setCsCache = function(linemdn,Pass_MDN_In_Request){
            var data = {
                "UserInfo" : angular.copy($rootScope.UserInfo),
                "Fields" : {
                    "Line_Mdn":linemdn,
                    "Pass_MDN_In_Request": Pass_MDN_In_Request,
                    "TRANSACTION_NAME" : "SetCsCache"
                },
                "Log": [{"USER_MACHINE_IP": ""}]
            };
            return self.__post(serviceURL + "setCsCache", data);
        };

      return self;
  }]);
