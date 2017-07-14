
(function () {
    'use strict';
    angular
        .module('app')
        .controller('loginController', loginController);

    loginController.$inject = ['$http', 'authenticationService', 'configService', '$state'];


    function loginController($http, authenticationService, configService, $state) {
        var vm = this;
        vm.user = {};
        vm.title = 'Login';
        vm.login = login;
        vm.showError = false;
        vm.messageError = '';
        init();

        function init() {
            if (configService.getLogin()) {
                $state.go('home');
            } else {
                authenticationService.logout();
            }
        }
        function login() {
            authenticationService.login(vm.user).then(function (result) {
                vm.showError = false;
                $state.go("home");
            }, function (error) {
                vm.showError = true;
                vm.messageError = error.data;
            });
        }
    }
})();