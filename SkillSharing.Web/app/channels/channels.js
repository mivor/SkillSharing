(function () {
    'use strict';

    angular
        .module('app.channels')
        .controller('Channels', Channels);

    Channels.$inject = ['$rootScope', 'dataservice'];

    function Channels($rootScope, dataservice) {
        var vm = this;
        vm.title = 'Channels';
        vm.subscribeChannel = subscribeChannel;

        activate();

        function activate() {
            dataservice.getChannels().then(function (data) {
                vm.channels = data;
            });
        }

        function subscribeChannel(channel) {
            channel.IsSubscribed = !channel.IsSubscribed;
            dataservice.subscribeChannel(channel).then(function () {
                $rootScope.$broadcast('updateChannels');
            });
        }
    }
})();