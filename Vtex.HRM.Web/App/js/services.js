'use strict';

angular.module('vtex-hrm.services', ['ngResource'])
    .factory('checks', function ($resource) {
        return $resource('https://api.pingdom.com/api/2.0/checks/:checkId', {}, {
            query: {
                method: 'GET',
                params: { checkId: '' },
                isArray: true
            }
        });
    });