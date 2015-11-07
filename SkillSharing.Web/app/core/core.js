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
                    vm.posts = []
                    angular.forEach(data, function (post) {
                        if (!post.IsDone) {
                            vm.posts.push(post);
                        }
                    })
                });
            });
        }

        function setAsDone(post) {
            post.IsDone = !post.IsTodo;
            dataservice.updatePost(post);
        }

        $scope.$on('updateToDo', function () {
            dataservice.getPosts('todo').then(function (data) {
                vm.posts = []
                angular.forEach(data, function (post) {
                    if (!post.IsDone) {
                        vm.posts.push(post);
                    }
                })
            });
        });

        $scope.$on('updateChannels', function () {
            dataservice.getSubscribedChannels().then(function (data) {
                vm.channels = data;
            });
        });
    }
})();