(function () {
    'use strict';

    angular
        .module('app.posts')
        .controller('Posts', Posts);

    Posts.$inject = ['$rootScope', '$stateParams', 'dataservice'];

    function Posts($rootScope, $stateParams, dataservice) {
        var vm = this;
        vm.setAsDone = setAsDone;
        vm.setAsToDo = setAsToDo;
        vm.setAsHidden = setAsHidden;
        vm.createPost = createPost;

        activate();

        function activate() {
            vm.title = $stateParams.title;
            vm.type = $stateParams.type;
            vm.id = $stateParams.id;
            dataservice.getPosts(vm.type, vm.id).then(function (data) {
                vm.posts = data ? data : [];
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
            dataservice.updatePost(post);
        }

        function createPost(post) {
            post.ChannelId = vm.id;
            dataservice.createPost(post).then(function (data) {
                vm.posts.push(data);
            });
        }
    }
})();