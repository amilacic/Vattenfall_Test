
(function () {

    'use strict';
    Date.prototype.ddmmyyyy = function () {
        var yyyy = this.getFullYear().toString();
        var mm = (this.getMonth() + 1).toString(); // getMonth() is zero-based
        var dd = this.getDate().toString();
        return (dd[1] ? dd : "0" + dd[0]) + '.' + (mm[1] ? mm : "0" + mm[0]) + '.' + yyyy; // padding
    };
    Date.prototype.ddmmyyyyhhmm = function () {
        var yyyy = this.getFullYear().toString();
        var mm = (this.getMonth() + 1).toString(); // getMonth() is zero-based
        var dd = this.getDate().toString();
        var HH = this.getHours().toString();
        var MM = this.getMinutes().toString();
        var SS = this.getSeconds().toString();
        return (dd[1] ? dd : "0" + dd[0]) + '.' + (mm[1] ? mm : "0" + mm[0]) + '.' + yyyy + " " + (HH[1] ? HH : "0" + HH[0]) + ":" + (MM[1] ? MM : "0" + MM[0]) + ":" + (SS[1] ? SS : "0" + SS[0]); // padding
    };

    var fooApp = angular.module('fooApp', ['ngRoute']);

    fooApp.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

        // when foo list
        $routeProvider.when('/', {
            templateUrl: '/Foo/ListFoos',
            controller: 'fooMainCTRL',
        });

        // when editing foo
        $routeProvider.when('/ManageFoo/:Id', {
            templateUrl: '/Foo/ManageFoo',
            controller: 'fooManagementCTRL',
        });

        // when create new foo
        $routeProvider.when('/ManageFoo', {
            templateUrl: '/Foo/ManageFoo',
            controller: 'fooManagementCTRL',
        });

        // default option
        $routeProvider.otherwise({
            redirectTo: '/'
        });
    }]);

    fooApp.controller('fooMainCTRL', ['$scope', '$rootScope', '$http', '$compile', '$parse', function ($scope, $rootScope, $http, $compile, $parse) {
        $scope.PageTitle = "Foo List";
        $scope.FooList = [];

        // small hack when not using angular framework / ie. if using regular ajax insted of $http, not gonna use it in this example but its my must have hack for angular.
        $scope.refresh = function () {
            if (!$scope.$$phase || !$rootScope.$root.$$phase) {
                $scope.$apply();
            }
        };

        // converter for C# datetime to JS, then to string
        $scope.convertCSDate = function (d) {
            var date = new Date(parseInt(d.substr(6)));

            return date.ddmmyyyy();
        };

        $scope.GetFooList = function () {
            // get list of foo elements 
            $http({
                url: '/Foo/GetFooData',
                method: 'post',
                
                }).success(function (data) {
                    $scope.FooList = data.FooList;
                });
        };

        $scope.DeleteFoo = function (foo) {
            // we pass the object foo over doom to this function to delete the selected foo element from db
            $http({
                url: '/Foo/DeleteFooData',
                method: 'post',
                data: { model: foo },
                }).success(function (data) {
                    var index = $scope.FooList.indexOf(data);
                    $scope.FooList.splice(index, 1);
                });
        };

    }]);

    fooApp.controller('fooManagementCTRL', ['$scope', '$rootScope', '$http', '$compile', '$parse', '$location', '$routeParams', function ($scope, $rootScope, $http, $compile, $parse, $location, $routeParams) {
        $scope.Foo = {};
        $scope.PageTitle = $scope.Foo.Id == null ? "Create new Foo" : "Edit Foo";
        

        // small hack when not using angular framework / ie. if using regular ajax insted of $http, not gonna use it in this example but its my must have hack for angular.
        $scope.refresh = function () {
            if (!$scope.$$phase || !$rootScope.$root.$$phase) {
                $scope.$apply();
            }
        };

        $scope.GetFoo = function () {
            // get foo element if in db, if the id is not null
            var ID = $routeParams.Id;
            if (ID != null) {
                $http({
                    url: '/Foo/GetFooDataById',
                    method: 'post',
                    data: {Id: ID}
                }).success(function (data) {
                    $scope.Foo = data.Foo;
                });
            }
        };

        $scope.SaveFoo = function () {
            // since im re-using this form for both edit and save new, im doign a small check for ID
            var link = $scope.Foo.Id == null ? '/Foo/SaveFooData' : '/Foo/EditFooData';

            $http({
                url: link,
                method: 'post',
                data: { model: $scope.Foo },
            }).success(function (data) {
                    $location.path("/");
            });

        };

        // on load of functions finished check if there is ID in link to load the Foo
        $scope.GetFoo();
    }]);


})();