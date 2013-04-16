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
    //#region private
    var activeTab = null;

    var paneOptions = {};

    var intervalInSeconds = 60;
    
    var getActiveTab = function () {

        var tabFilter = $location.search()['tab'];

        if (typeof tabFilter === "string" && tabFilter !== "") {

            var selectedTab = _.find($scope.tabs, function (tab) {
                return tab.label.toLowerCase() === tabFilter.toLowerCase();
            });

            return (selectedTab) ? selectedTab : $scope.tabs[0];

        }

        var down = _.findWhere($scope.tabs, { label: 'Down' });
        var all = _.findWhere($scope.tabs, { label: 'All' });

        return ($scope.down.length > 0) ? down : all;

    };

    var init = function () {

        $scope.order = "id";
        
        //#region Tabs
        $scope.tabs = [
            {
                label: "All",
                badgeStyle: "",
                alertStyle: "alert-info",
                checks: [],
                active: false,
                position: 1
            },
            {
                label: "Up",
                badgeStyle: "badge-success",
                alertStyle: "alert-success",
                checks: [],
                active: false,
                position: 2
            },
            {
                label: "Down",
                badgeStyle: "badge-important",
                alertStyle: "alert-error",
                checks: [],
                active: false,
                position: 3
            },
            {
                label: "Stable",
                badgeStyle: "badge-info",
                alertStyle: "alert-info",
                checks: [],
                active: false,
                position: 4
            },
            {
                label: "Beta",
                badgeStyle: "badge-warning",
                alertStyle: "",
                checks: [],
                active: false,
                position: 5
            }
        ];
        //#endregion

        $scope.fetchAllChecks();

        window.setInterval(function () {

            $scope.fetchAllChecks();

        }, intervalInSeconds * 1000);

    };
    //#endregion

    //#region public
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
            angular.forEach($scope.tabs, function (tab) {
                tab.checks = $scope[tab.label.toLowerCase()];
            });

            // sets paneOptions initial state

            activeTab = getActiveTab();

            activeTab.active = true;

            $scope.paneOptions(activeTab);

        });
    };
    //#endregion

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