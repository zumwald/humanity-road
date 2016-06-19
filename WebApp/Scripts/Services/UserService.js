angular.module('frontEndApp')
    .service('UserService', ['$log', '$q', '$http', function ($log, $q, $http) {
        $log.log('loaded UserService');

        var self = this;
        var volunteerEndpoint = '/api/volunteer';
        var timesheetEndpoint = '/api/timesheet';

        self.getUserDetails = function () {
            $log.log('getting user details');
            var deferred = $q.defer();

            $http.get(volunteerEndpoint).then(
                    function (data) {
                        deferred.resolve(data.data);
                    },
                    function (msg, code) {
                        deferred.reject(msg);
                        $log.error('error in UserService.getUserDetails: ', msg, code);
                    });

            return deferred.promise;
        };

        self.saveUserDetails = function (userObj) {
            $log.log('entered UserService.saveUserDetails');
            $log.log('userObj:', userObj);

            var deferred = $q.defer();

            $http({
                method: 'PUT',
                url: volunteerEndpoint,
                data: userObj
            }).then(function (data) {
                deferred.resolve(data);
            }, function (msg, code) {
                deferred.reject(msg);
                $log.error('error in UserService.saveUserDetails: ', msg, code);
            });

            return deferred.promise;
        };

        self.createTimesheet = function (o) {
            $log.log('entered UserService.createTimesheet');
            $log.log('timesheet object:', o);

            var deferred = $q.defer();

            $http({
                method: 'POST',
                url: timesheetEndpoint,
                data: o
            }).then(function (data) {
                $log.log('UserService.createTimesheet successful');
                deferred.resolve(data);
            }, function (msg, code) {
                $log.error('error in UserService.createTimesheet: ', msg, code);
                deferred.reject(msg);
            });

            return deferred.promise;
        };

        self.getTimesheets = function () {
            $log.log('entered UserService.getTimesheets');

            var deferred = $q.defer();

            $http.get(timesheetEndpoint)
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (msg, code) {
                    deferred.reject(msg);
                    $log.error('error in UserService.getTimesheets: ', msg, code);
                });

            return deferred.promise;
        };

    }]);