﻿(function () {
    'use strict';
    angular.module('app').config(setup).
        run(run);

        setup.$inject = ['$compileProvider'];

    function setup($compileProvider) {
        $compileProvider.debugInfoEnabled(false);
    }
     

    run.$inject = ['$http', '$state', 'localStorageService', 'configService' ];

    function run($http, $state, localStorageService, configService) {

        var user = localStorageService.get('userToken');
        if (user && user.token) {
            $http.defaults.headers.common.Authorization = 'Bearer ' +
            localStorageService.get('userToken').token;
            configService.setLogin(true);
            startSignalR();
        } else {
            $state.go('login');
        }
    }

    function startSignalR() {
        $.connection.hub.logging = true;
        var notificationHubProxy = $.connection.notificationHub;
        notificationHubProxy.client.updateProduct = function (id) {
            console.log(id);
        }
        $.connection.hub.start().done(function () {
            console.log("Hub Started - success");
        }).fail(function (error) {
            console.log(error);
        });
    }
})();