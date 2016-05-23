'use strict';

/**
 * @ngdoc function
 * @name frontEndApp.controller:UserCtrl
 * @description
 * # UserCtrl
 * Controller of the frontEndApp
 */
angular.module('frontEndApp')
  .controller('UserCtrl', ['$log', 'UserService', function ($log, UserService) {

      $log.log('entered UserCtrl');

      var self = this;

      self.user = {};

      UserService.getUserDetails().then(function (data) {
          self.user.primaryEmail = data.primaryEmail;
          self.user.firstName = data.firstName;
          self.user.lastName = data.lastName;
          self.user.id = data.id;
          self.user.imageUri = data.imageUri;
      });

      // form helpers
      self.months = function () {
          return _.range(1, 12 + 1);
      };
      self.days = function () {
          return _.range(1, 31 + 1);
      }

      $log.log('exiting UserCtrl');
  }]);
