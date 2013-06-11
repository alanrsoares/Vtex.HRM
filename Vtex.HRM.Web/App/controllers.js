'use strict';

var hrmControllers = angular.module('hrm.controllers', []);

var MainCtrl = ['$rootScope', function ($rootScope) {
    $rootScope.pageTitle = "Home";
}];

var ResourcesRouteCtrl = ['$scope', '$rootScope', '$routeParams', function ($scope, $rootScope, $routeParams) {

    if ($routeParams.resource) {

        $rootScope.pageTitle = $routeParams.resource;

        $scope.templateUrl = $routeParams.id
            ? $scope.templateUrl = '/app/partials/resources/' + $routeParams.resource + 'Detail.html'
            : $scope.templateUrl = '/app/partials/resources/' + $routeParams.resource + '.html';
    }
}];

var ResourcesCtrl = ['$rootScope', function ($rootScope) {
    $rootScope.pageTitle = "Resources";
}];
