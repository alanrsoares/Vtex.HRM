
'use strict';

var hrm = angular.module('hrm', ['hrm.controllers', 'hrm.services', 'hrm.directives', 'hrm.filters', '$strap.directives'])
    .config(function ($routeProvider) {
        $routeProvider
            //.when('/', {
            //    controller: 'MainCtrl',
            //    templateUrl: 'app/partials/home.html',
            //})
            .when('/', {
                redirectTo: '/resources/checks'
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