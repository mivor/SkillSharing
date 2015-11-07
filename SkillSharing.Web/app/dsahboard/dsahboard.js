(function () {
    'use strict';

    angular
        .module('app.dsahboard')
        .controller('Dashboard', Dashboard);

    Dashboard.$inject = ['dataservice'];

    function Dashboard(dataservice) {
        var vm = this;
        vm.title = 'Dashboard';

        activate();

        function activate() {
//            dataservice.getPublisherMetrics().then(function (data) {
//                vm.metrics = data;
//            });
        }
    }
})();