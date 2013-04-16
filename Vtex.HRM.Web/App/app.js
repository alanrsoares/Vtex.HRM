
'use strict';

var app = angular.module('hrm', ['hrm.services', 'hrm.directives', 'hrm.filters', '$strap.directives']).
config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            controller: 'MainCtrl',
            templateUrl: 'app/partials/home.html',
        })
        .when('/resources', {
            controller: 'ResourcesCtrl',
            templateUrl: 'app/partials/resources.html',
        })
        .when('/resources/:resource', {
            controller: 'ResourcesRouteCtrl',
            templateUrl: 'app/partials/resources/urlRouter.html',
        })
        .when('/resources/:resource/:id', {
            controller: 'ResourcesRouteCtrl',
            templateUrl: 'app/partials/resources/urlRouter.html',
        });
});

String.prototype.capitalize = function () {
    return this.charAt(0).toUpperCase() + this.slice(1);
}