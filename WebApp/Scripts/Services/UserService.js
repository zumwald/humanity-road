angular.module('frontEndApp')
    .service('UserService', ['$log', '$q', '$http', function ($log, $q, $http) {
        $log.log('loaded UserService');

        var self = this;

        self.getUserDetails = function () {
            $log.log('getting user details');
            var deferred = $q.defer();

            $http.get('/api/account')
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (msg, code) {
                    deferred.reject(msg);
                    $log.error('error in UserService.getUserDetails: ', msg, code);
                });

            return deferred.promise;
        };


    }]);