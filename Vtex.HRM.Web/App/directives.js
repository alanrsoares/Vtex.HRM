'use strict';

var hrmDirectives = angular.module('hrm.directives', [])
    .directive('appVersion', ['version', function (version) {
        return function (scope, elm) {
            elm.text(version);
        };
    }])
    .directive('showtab',
        function () {
            return {
                link: function (scope, element, attrs) {
                    element.click(function (e) {
                        e.preventDefault();
                        $(element).tab('show');
                    });
                }
            };
        })
    .directive('analysisDetail', function () {
        return {
            restrict: 'E',
            replace: true,
            templateUrl: '/app/directives/templates/analysisDetail.html',
            scope: {
                analysisDetail: "=",
                analysisId: "=",
                probes: "=",
                check: "="
            },
            link: function (scope, element, attributes) {

                scope.communicationLog = function (task) {

                    var communicationLogs = _.findWhere(task.result, { name: 'communication_log' });

                    if (communicationLogs) return communicationLogs.value[0];

                    return false;
                };

                scope.probe = function (task) {
                    return _.findWhere(scope.probes, { 'id': parseInt(task.analyzer_id) });
                };
            }
        };
    });