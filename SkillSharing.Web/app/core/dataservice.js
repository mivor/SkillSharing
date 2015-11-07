(function () {
    'use strict';

    angular
        .module('app.core')
        .constant('WebApi', 'http://localhost:59196/api/')
        .factory('dataservice', dataservice);

    dataservice.$inject = ['$http', 'WebApi'];

    function dataservice($http, WebApi) {
        return {
            getUser: getUser,
            getPosts: getPosts,
            getChannels: getChannels,
            getOrgStructure: getOrgStructure
        };

        function getUser() {
            return $http.get(WebApi + 'user')
                .then(getDataComplete);

            function getDataComplete(response) {
                return response.data;
            }
        }

        function getPosts(type, id) {
            var url = WebApi;
            switch (type) {
                case 'todo':
                    url += 'todo';
                    break;
                case 'channel':
                    url += 'channel\\' + id;
                    break;
                case 'orgstructure':
                    url += 'orgstructure\\' + id;
                    break;
            }

            return $http.get(url)
                .then(getDataComplete);

            function getDataComplete(response) {
                return response.data;
            }
        }

        function getChannels() {
            return $http.get(WebApi + 'channels')
                .then(getDataComplete);

            function getDataComplete(response) {
                return response.data;
            }
        }

        function getOrgStructure() {
            return $http.get(WebApi + 'orgstructures')
                .then(getDataComplete);

            function getDataComplete(response) {
                return response.data;
            }
        }
    }
})();