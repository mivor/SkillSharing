(function () {
    'use strict';

    angular
        .module('app.dashboard')
        .controller('Dashboard', Dashboard);

    Dashboard.$inject = ['$rootScope','dataservice'];

    function Dashboard($rootScope,dataservice) {
        var vm = this;
        vm.title = 'All Posts';
        vm.setAsDone = setAsDone;
        vm.setAsToDo = setAsToDo;
        vm.setAsHidden = setAsHidden;

        activate();

        function activate() {
            dataservice.getCurrentUser().then(function() {
                dataservice.getPublisherMetrics().then(function(data) {
                    vm.posts = data ? data : [];
                });
            });
        }

        function setAsDone(post) {
            post.IsDone = true;
            dataservice.updatePost(post).then(function () {
                $rootScope.$broadcast('updateToDo');
            });
        }

        function setAsToDo(post) {
            post.IsTodo = !post.IsTodo;
            dataservice.updatePost(post).then(function () {
                $rootScope.$broadcast('updateToDo');
            });
        }

        function setAsHidden(post) {
            post.IsHidden = true;
            dataservice.updatePost(post).then(function () {
                $rootScope.$broadcast('updateToDo');
            });
        }
    }
})();