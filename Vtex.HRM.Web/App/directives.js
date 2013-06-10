'use strict';

/* http://docs-next.angularjs.org/api/angular.module.ng.$compileProvider.directive */


angular.module('hrm.directives', [])
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
                probes: "="
            }
        };
    });


