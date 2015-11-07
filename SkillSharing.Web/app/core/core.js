(function () {
    'use strict';

    angular
        .module('app.core')
        .controller('Core', Core);

    Core.$inject = ['$state'];

    function Core($state) {
        var vm = this;
        vm.title = 'Core';

        activate();

        function activate() {

        }
    }
})();