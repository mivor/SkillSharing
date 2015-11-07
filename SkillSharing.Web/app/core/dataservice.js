﻿(function () {
    'use strict';

    angular
        .module('app.core')
        .constant('WebApi', 'http://localhost:59196/api/')
        .factory('dataservice', dataservice);

    dataservice.$inject = ['$http', 'WebApi'];

    function dataservice($http, WebApi) {
        return {
            getCurrentUser: getCurrentUser,
            getPosts: getPosts,
            getChannels: getChannels,
            getOrgstructures: getOrgstructures
        };

        function getCurrentUser() {
            return $http.get(WebApi + 'users/current')
                .then(getDataComplete);

            function getDataComplete(response) {
                return response.data;
            }
        }

        function getPosts(type, id) {
            var url = WebApi + 'posts\\';
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
            return $http.get(WebApi + 'channels/subscribed')
                .then(getDataComplete);

            function getDataComplete(response) {
                return response.data;
            }
        }

        function getOrgstructures() {
            return $http.get(WebApi + 'orgstructures')
                .then(getDataComplete);

            function getDataComplete(response) {
                return response.data;
            }
        }
    }
})();