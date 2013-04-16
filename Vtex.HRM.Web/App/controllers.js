var baseController = (function () {

    function baseController() {

    }

    return baseController;
});

var MainCtrl = function ($rootScope) {
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

var ResourcesCtrl = function ($rootScope) {
    $rootScope.pageTitle = "Resources";
};

//#region Resource Controllers

//#region Checks
var ChecksCtrl = function ($scope, $rootScope, $location, checks) {

    var activeTab = null;

    var paneOptions = {};

    $scope.paneOptions = function (tab) {
        if (arguments.length === 0) {
            return paneOptions;
        } else {
            paneOptions = {
                filtered: tab.checks,
                tabName: tab.label,
                alertStyle: tab.alertStyle,
            };
            activeTab = tab;
            $location.search('tab', tab.label.toLowerCase());
            $rootScope.pageTitle = "Checks - " + tab.label;
        }
    };

    $scope.fetchAllChecks = function () {
        
        // get all checks
        
        //#region Tabs
        $scope.tabs = {
            all: {
                label: "All",
                badgeStyle: "",
                alertStyle: "alert-info",
                checks: [],
                active: false
            },
            up: {
                label: "Up",
                badgeStyle: "badge-success",
                alertStyle: "alert-success",
                checks: [],
                active: false
            },
            down: {
                label: "Down",
                badgeStyle: "badge-important",
                alertStyle: "alert-error",
                checks: [],
                active: false
            },
            stable: {
                label: "Stable",
                badgeStyle: "badge-info",
                alertStyle: "alert-info",
                checks: [],
                active: false
            },
            beta: {
                label: "Beta",
                badgeStyle: "badge-warning",
                alertStyle: "",
                checks: [],
                active: false
            }
        };
        
        //#endregion
        checks.get(function (data) {

            $scope.all = data.checks;
            $scope.up = _.where($scope.all, { status: 'up' });
            $scope.down = _.where($scope.all, { status: 'down' });
            $scope.beta = _.filter($scope.all, function (check) {
                var pattern = /- Beta/;
                return pattern.test(check.name);
            });
            $scope.stable = _.filter($scope.all, function (check) {
                var pattern = /- Stable/;
                return pattern.test(check.name);
            });

            // set tabs collections
            angular.forEach($scope.tabs, function(tab) {
                tab.checks = $scope[tab.label.toLowerCase()];
            });

            // sets paneOptions initial state
            var tabFilter = $location.search()['tab'];

            if (tabFilter && $scope.tabs[tabFilter.toLowerCase()]) {
                activeTab = $scope.tabs[tabFilter];
            } else {
                activeTab = ($scope.down.length > 0)
                    ? $scope.tabs.down
                    : $scope.tabs.all;
            }
            activeTab.active = true;
            $scope.paneOptions(activeTab);

        });
    };

    var init = function () {

        $scope.order = "id";

        $scope.fetchAllChecks();

        window.setInterval(function () {

            $scope.fetchAllChecks();

        }, 60 * 1000);
    };

    init();
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