'use strict';

angular.module('hrm.services', ['ngResource'])
    .factory('checks', ['$resource', function ($resource) {
        return $resource('/api/checks/:checkId/', { checkId: "@checkId" }, {});
    }])
    .factory("analysis", ['$resource', function ($resource) {
        return $resource("/api/analysis/:checkId/", { checkId: "@checkId" },
            {
                update: { method: "PUT" }
            }
        );
    }])
    .factory("probes", ['$resource', function ($resource) {
        return $resource("/api/probes/");
    }]);