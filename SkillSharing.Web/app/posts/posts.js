(function () {
    'use strict';

    angular
        .module('app.posts')
        .controller('Posts', Posts);

    Posts.$inject = ['$stateParams','dataservice'];

    function Posts($stateParams, dataservice) {
        var vm = this;
        vm.title = 'Posts';

        activate();

        function activate() {
            vm.type = $stateParams.type;
            vm.id = $stateParams.id;
            dataservice.getPosts(vm.type, vm.id).then(function (data) {
                //vm.posts = [{ name: 'Title', content: 'Lorem ipsum', date: '12.12.2012' }, { name: 'Title', content: 'Lorem ipsum', date: '12.12.2012' }, { name: 'Title', content: 'Lorem ipsum', date: '12.12.2012' }, { name: 'Title', content: 'Lorem ipsum', date: '12.12.2012' }, { name: 'Title', content: 'Lorem ipsum', date: '12.12.2012' }];
                vm.posts = data;
            });
        }
    }
})();