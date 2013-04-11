
'use strict';

var app = angular.module('hrm', ['hrm.services']).
config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            controller: HrmController,
            templateUrl: 'app/partials/home.html'
        })
        .when('/resources', {
            controller: ResourcesController,
            templateUrl: 'app/partials/resources.html'
        })
        .when('/resources/:resource', {
            controller: ResourcesController,
            templateUrl: 'app/partials/resources/checks.html'
        });
});