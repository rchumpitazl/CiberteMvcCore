
(function () {
    'use strict';
    angular
        .module('app')
        .controller('orderItemController', orderItemController);

    orderItemController.$inject = ['dataService','configService', '$state'];


    function orderItemController(dataService, configService, $state) {
        var url = configService.getApiUrl();
        var vm = this;
        vm.orderItem = {};
        vm.orderItemList = [];
        
        init();

        function init() {
            if (!configService.getLogin()) return $state.go('login');
            list();
        }
        function list() {
            dataService.getData(url + "/orderitem")
                .then(function (result) {
                    vm.orderItemList = result.data;
                },
                function (error) {
                    vm.orderItemList = [];
                }
            );
        }
    }
})();