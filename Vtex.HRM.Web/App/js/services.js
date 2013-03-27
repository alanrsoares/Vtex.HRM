'use strict';

angular.module('vtex-hrm.services', ['ngResource'])
    .factory('checks', function ($resource) {
        return $resource('https://"alertawebstore@vtex.com.br:vtexonline1"@api.pingdom.com/api/2.0/checks/:checkId', {}, {
            query: {
                method: 'GET',
                params: { checkId: '' },
                headers: {
                    "app-key": "8gofngoojyhtc16t4q0b1sflrt2czq4b",
                },
                isArray: true
            }
        });
    });