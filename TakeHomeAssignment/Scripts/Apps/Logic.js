var app = angular.module('ngmodule', []);

app.service('ngservice', function ($http) {

    this.getAllPersons = function () {
        var result = $http.get("/Persons");
        return result;
    };

    this.searchPersons = function (value) {
        var result;
        if (value.length == 0) {
            result = $http.get("/Persons");
            return result;
        }
        else {
            result = $http.get("/Persons" + "/" + value);
            return result
        }
    };
});


app.controller('ngcontroller', function ($scope, ngservice) {

    $scope.searchInput = "";
    $scope.Person = null;

    loadPersons();

    function loadPersons() {
        var promise = ngservice.getAllPersons();
        promise.then(function (response) {
            $scope.Persons = response.data;
            $scope.searchMessage = "Total : " + response.data.length;
        }, function (err) {
            $scope.searchMessage = "Failed : " + err.status;
        });
    };


    $scope.searchPersons = function () {
        lock();
        setTimeout(myfunction, 3000);
    };

    function myfunction() {
        if ($scope.searchInput.length == 0) {
            loadPersons();
            unlock();
        }
        else {
            var promise = ngservice.searchPersons($scope.searchInput);
            promise.then(function (response) {
                $scope.Persons = response.data;
                $scope.searchMessage = "Matched: " + response.data.length;
                unlock();
            }, function (err) {
                $scope.searchMessage = "Failed : " + err.status;
                unlock();
            });
        }
    };

    function lock() {
        $scope.searchMessage = "";
        $("#progress").css("display", "block");
        $scope.Persons = null;
    };

    function unlock() {
        $("#progress").css("display", "none");
    };
});


$(document).ready(function () {
    $('body').tooltip({
        selector: '.info',
        html: true
    });
});