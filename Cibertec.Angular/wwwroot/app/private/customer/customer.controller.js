
(function () {
    'use strict';
    angular
        .module('app')
        .controller('customerController', customerController);

    customerController.$inject = ['dataService','configService', '$state'];


    function customerController(dataService, configService, $state) {
        var url = configService.getApiUrl();
        var vm = this;
        vm.customer = {};
        vm.customerList = [];
        
        init();

        function init() {
            if (!configService.getLogin()) return $state.go('login');
            list();
        }
        function list() {
            dataService.getData(url + "/customer")
                .then(function (result) {
                    vm.customerList = result.data;
                },
                function (error) {
                    vm.customerList = [];
                }
            );
        }
    }
})();