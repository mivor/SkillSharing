(function () {
    'use strict';

    angular
        .module('app.dashboard')
        .controller('Dashboard', Dashboard);

    Dashboard.$inject = ['dataservice'];

    function Dashboard(dataservice) {
        var vm = this;
        vm.title = 'All Posts';
        vm.setAsDone = setAsDone;
        vm.setAsToDo = setAsToDo;
        vm.setAsHidden = setAsHidden;

        activate();

        function activate() {
            dataservice.getPublisherMetrics().then(function (data) {
                vm.posts = data ? data : [];
            });
        }

        function setAsDone(post) {
            post.IsDone = true;
            dataservice.updatePost(post);
        }

        function setAsToDo(post) {
            post.IsTodo = true;
            dataservice.updatePost(post);
        }

        function setAsHidden(post) {
            post.IsHidden = true;
            dataservice.updatePost(post);
        }
    }
})();