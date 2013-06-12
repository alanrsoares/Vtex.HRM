'use strict';

hrm.controller('ChecksCtrl', ['$scope', '$rootScope', '$location', 'checks',
        function ($scope, $rootScope, $location, checks) {

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
                    $scope.paused = _.where($scope.all, { status: 'paused' });

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
                        position: 5
                    },
                    {
                        label: "Beta",
                        badgeStyle: "badge-warning",
                        alertStyle: "",
                        checks: [],
                        active: false,
                        position: 6
                    },
                    {
                        label: "Stores",
                        badgeStyle: "badge-info",
                        alertStyle: "",
                        checks: [],
                        active: false,
                        position: 7
                    },
                    {
                        label: "Paused",
                        badgeStyle: "",
                        alertStyle: "",
                        checks: [],
                        active: false,
                        position: 4
                    }
                ];
                //#endregion

                fetchAllChecks(true);

                window.setInterval(function () {

                    fetchAllChecks(true);

                }, intervalInSeconds * 1000);

            };

            //#endregion private

            //#region public
            $scope.isAutoRefresh = false;

            $scope.paneOptions = function (tab, isAutoRefresh) {

                if (arguments.length === 0) {
                    return paneOptions;
                } else {
                    paneOptions = {
                        filtered: tab.checks,
                        tabName: tab.label,
                        alertStyle: tab.alertStyle
                    };

                    activeTab = tab;

                    if (!isAutoRefresh) {
                        $location.search('tab', tab.label.toLowerCase());
                    }

                    $rootScope.pageTitle = "Checks - " + tab.label;
                }
                return paneOptions;
            };

            $scope.goToDetail = function (check) {
                $location.path("/resources/checks/" + check.id);
            };

            //#endregion

            init();
        }])
    .controller('ChecksDetailCtrl', ['$scope', '$rootScope', '$routeParams', 'checks', 'analysis', 'probes',
        function ($scope, $rootScope, $routeParams, checks, analysis, probes) {

            // get detailed check :id
            $scope.checkId = $routeParams.id;

            $scope.analysisResult = [];

            probes.get(function (data) {
                $scope.probes = data.probes;
            });

            checks.get({ checkId: $routeParams.id }, function (data) {

                $rootScope.pageTitle = data.check.name;

                $scope.check = data.check;

                // if check is down, then get analysis report
                if ($scope.check) {
                    analysis.get({ checkId: $scope.check.id }, function (analysisResult) {

                        if (analysisResult && analysisResult.analysis.length > 0) {

                            $scope.analysisResult = analysisResult.analysis;
                            
                            $scope.analysisId = $scope.analysisResult[0].id;
                            
                            analysis.get({ checkId: $scope.check.id, analysisId: $scope.analysisId }, function (analysisDetail) {
                                
                                $scope.analysisDetail = analysisDetail;
                                
                                var analysisTaskResult = $scope.analysisDetail.analysisresult.tasks[0].result;

                                var rawResponse = _.findWhere(analysisTaskResult, { name: "raw_response" });

                                $scope.taskRawResponse = rawResponse.value;

                                var communicationLog = _.findWhere(analysisTaskResult, { name: "communication_log" });

                                $scope.communicationLog = communicationLog.value[0];

                                $scope.responseHeaders = $scope.communicationLog.response_headers;

                            });
                        }
                    });
                }
            });
        }]);