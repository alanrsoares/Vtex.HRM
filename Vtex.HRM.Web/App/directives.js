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
    })
    .directive('backToTop', ['$window', function ($window) {
        return {
            restrict: 'E',
            replace: false,
            template: "<a class='btn btn-info pull-right btn-back-to-top'>" +
                      "<b>{{text}}</b> <i class='icon-chevron-up icon-white'></i>" +
                      "</a>",
            scope: {
                text: "@",
                show: "&"
            },
            link: function (scope, element, attributes) {

                element.on('click', function () {
                    window.scrollTo();
                });
                
                //var body = angular.element('body');

                //$(document).ready(function () {
                //    console.log(this);
                //    var bodyScrollHeight = body.get(0).scrollHeight;
                //    var buttonPosition = $(element).offset().top;
                    
                //    console.log(bodyScrollHeight);
                //    console.log(buttonPosition);

                //    if (buttonPosition > bodyScrollHeight) {
                //        $(element).show();
                //    } else {
                //        $(element).hide();
                //    }
                //});

            }
        };
    }]);
