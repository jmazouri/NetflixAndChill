$(document).foundation();

var mainModule = angular.module('ncApp', ["restangular", 'autocomplete']);

mainModule.controller('MovieList', function ($scope, $timeout, Restangular)
{
    $scope.updateMovieSearch = function (typed)
    {
        Restangular.several("search", typed).getList().then(function (response)
        {
            $scope.movieTitles = _.uniq(_.pluck(response, 'Title'));
        });
    };

    $scope.updateScope = function ()
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

        $timeout($scope.updateScope, 30000);
    };

    $scope.updateScope();

});

mainModule.directive('backImg', function() {
    return function(scope, element, attrs) {
        var url = attrs.backImg;
        element.css({
            'background-image': 'url(' + url + ')',
            'background-size': 'cover'
        });
    };
});

mainModule.controller('CurrentMovie', function ($scope, $timeout, Restangular) {

    updateScope = function () {
        //console.log("There was an update!");
        $scope.currentMovie = Restangular.one("currentMovie").get().$object;
        $timeout(updateScope, 1000);
    };

    updateScope();

});