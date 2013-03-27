var DashboardController = function ($scope, $window, $location, checks) {

    $scope.$location = $location;
    
    $scope.hello = "Hello dashboard partial!";

    checks.get(function (data) {
        $scope.checksResult = data;
        console.log(data);
    });
};

var AboutController = function ($scope, $window, $location) {

    $scope.$location = $location;

    $scope.hello = "Hello about partial!";

};