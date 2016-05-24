angular.module('frontEndApp')
    .service('UserService', ['$log', '$q', '$http', function ($log, $q, $http) {
        $log.log('loaded UserService');

        var self = this;

        self.getUserDetails = function () {
            $log.log('getting user details');
            var deferred = $q.defer();

            $http.get('/api/volunteer')
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (msg, code) {
                    deferred.reject(msg);
                    $log.error('error in UserService.getUserDetails: ', msg, code);
                });

            return deferred.promise;
        };

        self.saveUserDetails = function(userObj) {
            $log.log('entered UserService.saveUserDetails');
            $log.log('userObj:', userObj);

            $http({
                method: 'PUT',
                url: '/api/volunteer/',
                data: userObj
            });
        };

    }]);