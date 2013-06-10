'use strict';

angular.module('hrm.controllers', [])

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
    })
//#region Resource Controllers

//#region Analysis
    .controller('AnalysisDetailCtrl', function ($scope, $rootScope, $routeParams, $location, analysis, probes) {

        $scope.checkId = $routeParams.id;

        $scope.analysisId = $location.search()['analysisId'];

        if (!$scope.checkId) return false;

        probes.get(function (data) {
            $scope.probes = data.probes;
        });

        if ($scope.analysisId) {
            //analysis detail
            analysis.get({ checkId: $scope.checkId, analysisId: $scope.analysisId }, function (data) {
                $scope.analysisDetail = data;
            });
        } else {
            //analysis history
            analysis.get({ checkId: $scope.checkId }, function (data) {
                $scope.analysisHistory = data.analysis;

            });
        }

        return false;
    });
//#endregion Analysis

//#endregion