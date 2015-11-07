(function () {
    'use strict';

    angular
        .module('app.core')
        .controller('Core', Core);

    Core.$inject = ['$scope','$state','dataservice'];

    function Core($scope, $state, dataservice) {
        var vm = this;
        vm.title = 'Core';
        vm.setAsDone = setAsDone;

        activate();

        function activate() {
            dataservice.getCurrentUser().then(function (data) {
                vm.user = data;
                dataservice.getSubscribedChannels().then(function (data) {
                    vm.channels = data;
                });
                dataservice.getOrgstructures().then(function (data) {
                    vm.orgstructures = data;
                });
                dataservice.getPosts('todo').then(function (data) {
                    vm.posts = [];
                    angular.forEach(data, function(post) {
                        if (!post.IsDone) {
                            vm.posts.push(post);
                        }
                    });

                    var allPosts = data.length;
                    if (allPosts == 0) {
                        vm.progress = 0;
                    } else {
                        var todoPosts = allPosts - vm.posts.length;
                        vm.progress = todoPosts / allPosts * 100;
                    }
                });
            });
        }

        function setAsDone(post) {
            post.IsDone = true;
            dataservice.updatePost(post).then(function() {
                dataservice.getPosts('todo').then(function (data) {
                    vm.posts = [];
                    angular.forEach(data, function (post) {
                        if (!post.IsDone) {
                            vm.posts.push(post);
                        }
                    });

                    var allPosts = data.length;
                    if (allPosts == 0) {
                        vm.progress = 0;
                    } else {
                        var todoPosts = allPosts - vm.posts.length;
                        vm.progress = todoPosts / allPosts * 100;
                    }
                });
            });
        }

        $scope.$on('updateToDo', function () {
            dataservice.getPosts('todo').then(function (data) {
                vm.posts = [];
                angular.forEach(data, function(post) {
                    if (!post.IsDone) {
                        vm.posts.push(post);
                    }
                });

                var allPosts = data.length;
                if (allPosts == 0) {
                    vm.progress = 0;
                } else {
                    var todoPosts = allPosts - vm.posts.length;
                    vm.progress = todoPosts / allPosts * 100;
                }
            });
        });

        $scope.$on('updateChannels', function () {
            dataservice.getSubscribedChannels().then(function (data) {
                vm.channels = data;
            });
        });
    }
})();