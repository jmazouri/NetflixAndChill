﻿$(document).foundation();

var mainModule = angular.module('ncApp', ["restangular"]);

mainModule.controller('MovieList', function ($scope, $timeout, Restangular)
{
    updateScope = function ()
    {
        //console.log("There was an update!");
        Restangular.all("movies").getList().then(function (response) {
            $(".connection-lost").addClass("hidden");
            $scope.movies = response;
        }, function ()
        {
            $(".connection-lost").removeClass("hidden");
            $("#maincontent").addClass("hidden");
        });

        /*
        var proper = [];

        _.each(Restangular.all("movies").getList(), function (item)
        {
            if (_.where($scope.movies, { id: item.id }))
            {
                
            }
        });
        */

        $timeout(updateScope, 1000);
    };

    updateScope();

});

mainModule.controller('CurrentMovie', function ($scope, $timeout, Restangular) {

    updateScope = function () {
        //console.log("There was an update!");
        $scope.currentMovie = Restangular.one("currentMovie").get().$object;
        $timeout(updateScope, 1000);
    };

    updateScope();

});