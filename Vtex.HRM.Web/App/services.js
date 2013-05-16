'use strict';

angular.module('hrm.services', ['ngResource'])
    .factory('checks', function ($resource) {
        return $resource('/api/checks/:checkId/', { checkId: "@checkId" }, {});
    })
    .factory("analysis", function ($resource) {
        return $resource("/api/analysis/:checkId/", { checkId: "@checkId" },
            {
                update: { method: "PUT" }
            }
        );
    })
    .factory("probes", function ($resource) {
        return $resource("/api/probes/");
    });