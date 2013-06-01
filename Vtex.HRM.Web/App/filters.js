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
    })
    .filter('capitalizeFirst', function () {
        return function (input) {
            var loweCaseString = input.toLowerCase();
            return loweCaseString.substring(0, 1).toUpperCase() + loweCaseString.substring(1);
        };
    })
    .filter('jsonFormatter', function () {
        return function (input) {
            try {
                var result = jsonlint.parse(input);

                if (result) {
                    return JSON.stringify(result, null, 4);
                }

                return input;

            } catch (e) {
                return input;
            }
        };
    });
