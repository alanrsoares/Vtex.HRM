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

        if (!$scope.isAutoRefresh && typeof tabFilter === "string" && tabFilter !== "") {

            var selectedTab = _.findWhere($scope.tabs, { label: tabFilter.toLowerCase().capitalize() });

            return (selectedTab && selectedTab.checks.length > 0)
                ? selectedTab
                : $scope.tabs[0];
        }

        var down = _.findWhere($scope.tabs, { label: 'Down' });
        var up = _.findWhere($scope.tabs, { label: 'Up' });

        return ($scope.down.length > 0) ? down : up;

    };

    var fetchAllChecks = function (isAutoRefresh) {

        // reset active tab
        activeTab = _.findWhere($scope.tabs, { active: true });
        if (activeTab) activeTab.active = false;

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

            var applications = _.union($scope.beta, $scope.stable);

            $scope.stores = _.difference($scope.all, applications);

            // set tabs collections
            angular.forEach($scope.tabs, function (tab) {
                tab.checks = $scope[tab.label.toLowerCase()];
            });

            // sets paneOptions initial state

            activeTab = getActiveTab();

            activeTab.active = true;

            $scope.paneOptions(activeTab, isAutoRefresh);

        });
    };

    var init = function () {

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
            },
            {
                label: "Stores",
                badgeStyle: "badge-info",
                alertStyle: "",
                checks: [],
                active: false,
                position: 6
            }
        ];
        //#endregion

        fetchAllChecks(true);

        window.setInterval(function () {

            fetchAllChecks(true);

        }, intervalInSeconds * 1000);

    };
    //#endregion

    //#region public
    $scope.isAutoRefresh = false;

    $scope.paneOptions = function (tab, isAutoRefresh) {

        if (arguments.length === 0) {
            return paneOptions;
        } else {
            paneOptions = {
                filtered: tab.checks,
                tabName: tab.label,
                alertStyle: tab.alertStyle,
            };

            activeTab = tab;

            if (!isAutoRefresh) {
                $location.search('tab', tab.label.toLowerCase());
            }

            $rootScope.pageTitle = "Checks - " + tab.label;
        }
    };

    $scope.detail = function (checkId) {
        console.log("#/resources/checks/" + checkId);
        window.location = "#/resources/checks/" + checkId;
    };

    //#endregion

    init();
};

var ChecksDetailCtrl = function ($scope, $rootScope, $routeParams, checks, analysis, probes) {

    // get detailed check :id
    $scope.checkId = $routeParams.id;

    $scope.analysisResult = [];

    probes.get(function (data) {
        $scope.probes = data.probes;
    });

    checks.get({ checkId: $routeParams.id }, function (data) {

        //$rootScope.pageTitle = data.check.name;

        $scope.check = data.check;

        $scope.statusIcon = "Content/images/status-" + $scope.check.status + ".png";

        // if check is down, then get analysis
        if ($scope.check) {
            analysis.get({ checkId: $scope.check.id }, function (analysisResult) {

                if (analysisResult && analysisResult.analysis.length > 0) {

                    $scope.analysisResult = analysisResult.analysis;

                    analysis.get({ checkId: $scope.check.id, analysisId: $scope.analysisResult[0].id }, function (analysisDetail) {
                        $scope.analysisDetail = analysisDetail;
                        var analysisTaskResult = $scope.analysisDetail.analysisresult.tasks[0].result;
                        $scope.taskRawResponse = _.findWhere(analysisTaskResult, { name: "raw_response" }).value;
                        $scope.communicationLog = _.findWhere(analysisTaskResult, { name: "communication_log" }).value[0];
                        $scope.responseHeaders = $scope.communicationLog.response_headers;
                    });
                }

            });
        }
    });

    $scope.taskCommunicationLog = function (task) {
        var result = _.findWhere(task.result, { name: 'communication_log' }).value[0];
        return result;
    };

};

//#endregion Checks

//#region Analysis

var AnalysisDetailCtrl = function ($scope, $rootScope, $routeParams, $location, analysis, probes) {

    $scope.checkId = $routeParams.id;
    $scope.analysisId = $location.search()['analysisId'];

    if (!$scope.checkId) return false;

    probes.get(function (data) {
        $scope.probes = data.probes;
    });

    if ($scope.analysisId) {
        //analysis detail

        analysis.get({ checkId: $scope.checkId, analysisId: $scope.analysisId }, function (data) {
            $scope.analysisDetail = data;
        });
    } else {
        //analysis history

        analysis.get({ checkId: $scope.checkId }, function (data) {
            $scope.analysisHistory = data.analysis;

        });
    }

    $scope.taskCommunicationLog = function (task) {
        var result = _.findWhere(task.result, { name: 'communication_log' }).value[0];
        return result;
    };

    return false;
};

//#endregion Analysis

//#endregion