(function () {
    'use strict';

    angular
        .module('app.core')
        .controller('Core', Core);

    Core.$inject = ['$state','dataservice'];

    function Core($state, dataservice) {
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
                    vm.posts = data ? data : [];

                    var todo = 2;
                    if (vm.posts.length == 0) {
                        vm.progress = 0;
                    } else {
                        vm.progress = todo / vm.posts.length * 100;
                    }
                });
            });
        }

        function setAsDone(post) {
            post.IsDone = true;
            dataservice.updatePost(post);
        }
    }
})();