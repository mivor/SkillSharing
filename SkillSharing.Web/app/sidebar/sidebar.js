(function () {
    'use strict';

    angular
        .module('app.sidebar')
        .controller('Sidebar', Sidebar);

    Sidebar.$inject = ['dataservice'];

    function Sidebar(dataservice) {
        var vm = this;
        vm.title = 'Sidebar';

        activate();

        function activate() {
            dataservice.getChannels.then(function (data) {
                vm.channels = data;
            });
            dataservice.getOrgStructure.then(function (data) {
                vm.orgStructures = data;
            });
        }
    }
})();