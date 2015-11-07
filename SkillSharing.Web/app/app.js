(function () {
    'use strict';

    angular
        .module('app', ['ui.router', 'app.core'])
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state("index", {
                url: "/",
                views: {
                    '': {
                        templateUrl: 'app/dashboard/dashboard.html',
                        controller: 'Dashboard',
                        controllerAs: 'vm'
                    }
                }
            })
            .state("posts", {
                url: "/posts?type&id",
                views: {
                    '': {
                        templateUrl: 'app/posts/posts.html',
                        controller: 'Posts',
                        controllerAs: 'vm'
                    }
                }
            })
            .state("channels", {
                url: "/channels",
                views: {
                    '': {
                        templateUrl: 'app/channels/channels.html',
                        controller: 'Channels',
                        controllerAs: 'vm'
                    }
                }
            });

        $urlRouterProvider.otherwise('/posts?type=todo');
    }
})();