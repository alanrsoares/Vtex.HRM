'use strict';
/* http://docs-next.angularjs.org/api/angular.module.ng.$compileProvider.directive */


angular.module('hrm.directives', []).
  directive('appVersion', ['version', function(version) {
    return function(scope, elm) {
      elm.text(version);
    };
  }]);
