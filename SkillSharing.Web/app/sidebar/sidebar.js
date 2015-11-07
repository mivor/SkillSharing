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
            dataservice.getCurrentUser().then(function (data) {
                vm.user = data;
                dataservice.getChannels().then(function (data) {
                    vm.channels = data;
                });
                dataservice.getOrgstructures().then(function (data) {
                    vm.orgstructures = data;
                });
            });
        }
    }
})();