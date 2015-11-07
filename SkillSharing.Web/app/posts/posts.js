(function () {
    'use strict';

    angular
        .module('app.posts')
        .controller('Posts', Posts);

    Posts.$inject = ['$stateParams'];

    function Posts($stateParams) {
        var vm = this;
        vm.title = 'Posts';

        activate();

        function activate() {
            vm.type = $stateParams.type;
            vm.id = $stateParams.id;
            vm.posts = [{ name: 'Title', content: 'Lorem ipsum', date: '12.12.2012' }, { name: 'Title', content: 'Lorem ipsum', date: '12.12.2012' }, { name: 'Title', content: 'Lorem ipsum', date: '12.12.2012' }, { name: 'Title', content: 'Lorem ipsum', date: '12.12.2012' }, { name: 'Title', content: 'Lorem ipsum', date: '12.12.2012' }];
        }
    }
})();