'use strict';

var app = angular.module('vtex-hrm', ['vtex-hrm.services', '$strap.directives']).
  config(function ($routeProvider) {
      $routeProvider.
        when('/dashboard', { controller: DashboardController, templateUrl: 'app/partials/dashboard.html' }).
        when('/about', { controller: AboutController, templateUrl: 'app/partials/about.html' }).
        otherwise({ redirectTo: '/dashboard' });
  });