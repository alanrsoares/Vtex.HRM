'use strict';

hrm.controller('MainCtrl', ['$rootScope',
        function ($rootScope) {
            $rootScope.pageTitle = "Home";
        }])
    .controller('ResourcesRouteCtrl', ['$scope', '$rootScope', '$routeParams',
        function ($scope, $rootScope, $routeParams) {

            if ($routeParams.resource) {

                $rootScope.pageTitle = $routeParams.resource;

                $scope.templateUrl = $routeParams.id
                    ? $scope.templateUrl = '/app/partials/resources/' + $routeParams.resource + 'Detail.html'
                    : $scope.templateUrl = '/app/partials/resources/' + $routeParams.resource + '.html';
            }
        }])
    .controller('ResourcesCtrl', ['$rootScope',
        function ($rootScope) {
            $rootScope.pageTitle = "Resources";
        }]);