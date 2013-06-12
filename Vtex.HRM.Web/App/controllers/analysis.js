'use strict';

hrm.controller('AnalysisDetailCtrl', ['$scope', '$rootScope', '$routeParams', '$location', 'analysis', 'probes', 'checks',
        function ($scope, $rootScope, $routeParams, $location, analysis, probes, checks) {

            $scope.analysisId = $location.search().analysisId;

            var checkId = $routeParams.id;

            checks.get({ 'checkId': checkId }, function (data) {
                $scope.check = data.check;
            });

            probes.get(function (data) {
                $scope.probes = data.probes;
            });

            if ($scope.analysisId) {
                //analysis detail
                analysis.get({ 'checkId': checkId, analysisId: $scope.analysisId }, function (data) {
                    $scope.analysisDetail = data;
                });
            } else {
                //analysis history
                analysis.get({ 'checkId': checkId }, function (data) {
                    $scope.analysisHistory = data.analysis;

                });
            }

            $scope.goToDetail = function (a) {
                $location.path("/resources/analysis/" + checkId + "/")
                         .search('analysisId', a.id);
            };

            return false;
        }]);
