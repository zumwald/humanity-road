'use strict';

/**
 * @ngdoc function
 * @name frontEndApp.controller:UserCtrl
 * @description
 * # UserCtrl
 * Controller of the frontEndApp
 */
angular.module('frontEndApp')
  .controller('UserCtrl', ['$log', 'UserService', '$window', '$mdSidenav', '$location', '$cookies', function ($log, UserService, $window, $mdSidenav, $location, $cookies) {

      $log.log('entered UserCtrl');

      var desiredRoute = $cookies.get('clientStartRoute');
      if (desiredRoute) {
          if (desiredRoute !== $location.url()) {
              $location.url(desiredRoute);
          }
      }

      var self = this;
      self.user = {};
      self.timesheet = {};
      self.showSpinner = true;

      // function declarations
      self.saveUserInfo = function () {
          UserService.saveUserDetails(self.user).then(function (res) {
              self.showSpinner = false;
              $window.location.href = '#/Home';
          });
          self.showSpinner = true;
      }

      self.toggleNav = function() {
          $mdSidenav('left').toggle();
      }

      self.hrefHandle = function(href) {
          $mdSidenav('left').close();
          $window.location.href = href;
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
          return chip;
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

      self.saveTimesheet = function () {
          UserService.createTimesheet(self.timesheet).then(function () {
              self.getTimesheetHistory();
              self.timesheet = null;
              self.timesheet = {};
          });
      }

      self.getTimesheetHistory = function () {
          UserService.getTimesheets().then(function (data) {
              $log.log('got timesheet list:', data);
              self.timesheetList = data;
          });
      };

      // run once for initialization
      UserService.getUserDetails().then(function (data) {
          self.user = data;
          self.showSpinner = false;
      });
      self.getTimesheetHistory();

      $log.log('exiting UserCtrl');
  }]);
