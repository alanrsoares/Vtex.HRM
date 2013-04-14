var baseController = (function () {

    function baseController() {

    }

    return baseController;
});

var MainCtrl = function($rootScope) {
    $rootScope.pageTitle = "Home";
};

var ResourcesRouteCtrl = function ($scope, $rootScope, $routeParams) {

    if ($routeParams.resource) {
        
        $rootScope.pageTitle = $routeParams.resource;

        $scope.templateUrl = $routeParams.id
                ? $scope.templateUrl = '/app/partials/resources/' + $routeParams.resource + 'Detail.html'
                : $scope.templateUrl = '/app/partials/resources/' + $routeParams.resource + '.html';
    }
};

var ResourcesCtrl = function($rootScope) {
    $rootScope.pageTitle = "Resources";
};

//#region Resource Controllers

//#region Checks
var ChecksCtrl = function ($scope, $rootScope, checks) {

    $scope.filtered = [];

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

        $scope.filtered = $scope.checks;
        $scope.tabName = "ALL";

    });
};

var ChecksDetailCtrl = function ($scope, $rootScope, $routeParams, checks) {

    // get detailed check :id
    $scope.checkId = $routeParams.id;
    
    checks.get({ checkId: $routeParams.id }, function (data) {
        $rootScope.pageTitle = data.check.name;
        $scope.check = data.check;
    });
};
//#endregion

//#endregion