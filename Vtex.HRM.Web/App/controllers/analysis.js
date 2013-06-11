'use strict';

hrm.controller('AnalysisDetailCtrl', ['$scope', '$rootScope', '$routeParams', '$location', 'analysis', 'probes',
        function ($scope, $rootScope, $routeParams, $location, analysis, probes) {

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
        }]);
