'use strict';

/**
 * @ngdoc function
 * @name frontEndApp.controller:UserCtrl
 * @description
 * # UserCtrl
 * Controller of the frontEndApp
 */
angular.module('frontEndApp')
  .controller('UserCtrl', ['$log', 'UserService', '$window', function ($log, UserService, $window) {

      $log.log('entered UserCtrl');

      var self = this;

      self.user = {};
      self.timesheet = {};
      self.showSpinner = false;

      UserService.getUserDetails().then(function (data) {
          self.user = data;
      });

      self.saveUserInfo = function () {
          UserService.saveUserDetails(self.user).then(function (res) {
              self.showSpinner = false;
              $window.location.href('#/Home');
          });
          self.showSpinner = true;
      }

      // form helpers
      self.months = function () {
          return _.range(1, 12 + 1);
      };
      self.days = function () {
          return _.range(1, 31 + 1);
      };
      self.languages = ['English', 'Spanish', 'French'];
      self.transformChip = function (chip) {
          // If it is an object, it's already a known chip
          if (angular.isObject(chip)) {
              return chip;
          }
          // Otherwise, create a new one
          return { name: chip, type: 'new' }
      };
      function createFilterFor(query) {
          var lowercaseQuery = angular.lowercase(query);
          return function filterFn(language) {
              return language.toLowerCase().indexOf(lowercaseQuery) >= 0;
          };
      };
      self.querylanguageSearch = function (query) {
          return query ? self.languages.filter(createFilterFor(query)) : [];
      };


      $log.log('exiting UserCtrl');
  }]);
