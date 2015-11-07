(function () {
    'use strict';

    angular
        .module('app.posts')
        .controller('Posts', Posts);

    Posts.$inject = ['$stateParams','dataservice'];

    function Posts($stateParams, dataservice) {
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

        function createPost(post) {
            post.ChannelId = vm.id;
            dataservice.createPost(post).then(function (data) {
                vm.posts.push(data);
            });
        }
    }
})();