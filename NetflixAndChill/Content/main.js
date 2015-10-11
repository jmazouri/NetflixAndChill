$(document).foundation();

var replaceItemById = function (list, element) {
    var index = _.indexOf(list, _.find(list, { id: element.id }));

    list.splice(index, 1, element);

    return list;
};

_.mixin({ 'replaceItemById': replaceItemById });

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