
(function () {
    'use strict';
    angular
        .module('app')
        .controller('orderController', orderController);

    orderController.$inject = ['dataService','configService', '$state'];


    function orderController(dataService, configService, $state) {
        var url = configService.getApiUrl();
        var vm = this;
        vm.order = {};
        vm.orderList = [];
        
        init();

        function init() {
            if (!configService.getLogin()) return $state.go('login');
            list();
        }
        function list() {
            dataService.getData(url + "/order")
                .then(function (result) {
                    vm.orderList = result.data;
                },
                function (error) {
                    vm.orderList = [];
                }
            );
        }
    }
})();