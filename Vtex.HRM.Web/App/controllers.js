
var MainCtrl = function ($scope, $http) { };

var ResourcesRouteCtrl = function ($scope, $routeParams) {

    if (typeof $routeParams.resource !== "undefined") {

        if (typeof $routeParams.id !== "undefined") {
            //is detail
            $scope.templateUrl = '/app/partials/resources/' + $routeParams.resource + 'Detail.html';
        }
        else {
            $scope.templateUrl = '/app/partials/resources/' + $routeParams.resource + '.html';
        }
    }
};

var ResourcesCtrl = function ($scope, $http, checks) { };

var ChecksCtrl = function ($scope, $http, checks) {
    checks.get(function (data) {
        $scope.checks = data.checks;
    });
};

var ChecksDetailCtrl = function ($scope, $http, $routeParams, checks) {
    checks.get({ checkId: $routeParams.id }, function (data) {
        $scope.check = data.check;
    });
};