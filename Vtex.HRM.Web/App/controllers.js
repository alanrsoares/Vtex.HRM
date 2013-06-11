'use strict';

var hrmControllers = angular.module('hrm.controllers', [])
    .controller("MainCtrl", function ($rootScope) {
        $rootScope.pageTitle = "Home";
    })
    .controller("ResourcesRouteCtrl", function ($scope, $rootScope, $routeParams) {

        if ($routeParams.resource) {

            $rootScope.pageTitle = $routeParams.resource;

            $scope.templateUrl = $routeParams.id
                ? $scope.templateUrl = '/app/partials/resources/' + $routeParams.resource + 'Detail.html'
                : $scope.templateUrl = '/app/partials/resources/' + $routeParams.resource + '.html';
        }

    })
    .controller("ResourcesCtrl", function ($rootScope) {
        $rootScope.pageTitle = "Resources";
    });
//#region Resource Controllers



//#endregion