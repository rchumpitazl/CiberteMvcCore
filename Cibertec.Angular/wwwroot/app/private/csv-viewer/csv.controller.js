
(function () {
    'use strict';
    angular
        .module('app')
        .controller('csvController', loginController);


    function loginController(configService, $state) {
        var vm = this;
        vm.orders = [];
        vm.processFile = processFile;

        var fileInput = document.getElementById('csvViewer');

        init();

        function init() {
            if (!configService.getLogin()) return $state.go('login');
            
        }

        function processFile() {
            vm.orders = [];

            readFile(function (result) {
                var list = [];
                var total_lines = result.length;
                var csvWorker = new Worker('/js/worker.js');
                var count = 0;
                csvWorker.addEventListener('message', function (message) {
                    list.push(message.data);
                    count++;
                    if (count >= total_lines) csvWorker.terminate();
                });

                for (var i = 0; i < total_lines; i++) {
                    csvWorker.postMessage(result[i]);
                }
                
            });
        }

        function readFile(callback) {

            var reader = new FileReader();
            reader.onload = function () {
               return callback(reader.result.split('\r\n'));
            }
            reader.readAsBinaryString(fileInput.files[0]);
            
        }

       

    }
})();