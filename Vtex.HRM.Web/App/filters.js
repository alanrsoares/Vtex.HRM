'use strict';
/* http://docs-next.angularjs.org/api/angular.module.ng.$filter */

angular.module('hrm.filters', [])
    .filter('interpolate', ['version', function (version) {
        return function (text) {
            return String(text).replace(/\%VERSION\%/mg, version);
        };
    }])
    .filter('unixDate', function () {
        return function (input) {
            return moment.unix(input).format('DD/MM/YYYY HH:mm:ss');
        };
    });
