(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('dataservice', dataservice);

    dataservice.$inject = ['$http'];

    function dataservice($http) {
        return {
            getData: getData
        };

        function getData() {
            return $http.get('/api/data')
                .then(getDataComplete);

            function getDataComplete(response) {
                return response.data.results;
            }
        }
    }
})();