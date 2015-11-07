(function () {
    'use strict';

    angular
        .module('app.channels')
        .controller('Channels', Channels);

    Channels.$inject = ['dataservice'];

    function Channels(dataservice) {
        var vm = this;
        vm.title = 'Channels';

        activate();

        function activate() {
            dataservice.getChannels().then(function (data) {
                vm.channels = data;
            });
        }
    }
})();