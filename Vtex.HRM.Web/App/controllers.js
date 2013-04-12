var baseController = (function () {

    function baseController() {

    }

    return baseController;
});

var MainCtrl = function () { };

var ResourcesRouteCtrl = function ($scope, $routeParams) {

    if ($routeParams.resource) {

        $scope.templateUrl = $routeParams.id
                ? $scope.templateUrl = '/app/partials/resources/' + $routeParams.resource + 'Detail.html'
                : $scope.templateUrl = '/app/partials/resources/' + $routeParams.resource + '.html';
    }
};

var ResourcesCtrl = function () { };

//#region Resource Controllers

//#region Checks
var ChecksCtrl = function ($scope, $http, $window, $location, checks) {

    // get all checks
    checks.get(function (data) {
        $scope.checks = data.checks;
        $scope.up = _.where($scope.checks, { status: 'up' });
        $scope.down = _.where($scope.checks, { status: 'down' });
        $scope.beta = _.filter($scope.checks, function (check) {
            var pattern = /- Beta/;
            return pattern.test(check.name);
        });
        $scope.stable = _.filter($scope.checks, function (check) {
            var pattern = /- Stable/;
            return pattern.test(check.name);
        });
    });
};

var ChecksDetailCtrl = function ($scope, $http, $routeParams, checks) {

    // get detailed check :id
    checks.get({ checkId: $routeParams.id }, function (data) {
        $scope.check = data.check;
    });
};
//#endregion

//#endregion