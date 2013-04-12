'use strict';

angular.module('hrm.services', ['ngResource'])
    .factory('checks', function ($resource) {
        return $resource('/api/checks/:checkId', {}, {
            query: {
                method: 'GET',
                params: { checkId: '' },
                isArray: true
            }
        });
    })
    .factory('CurrencyConverter', function ($resource) {
        return $resource('/api/CurrencyConverter/:amount/:from/:to', {}, {
            query: {
                method: 'GET',
                params: {},
                isArray: true
            }
        });
    });