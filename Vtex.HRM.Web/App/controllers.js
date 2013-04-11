
var HrmController = function($scope, $http, Checks) {};

var ResourcesController = function ($scope, $http, Checks) {

    Checks.get(function (data) {
        $scope.checks = data.checks;
    });
};