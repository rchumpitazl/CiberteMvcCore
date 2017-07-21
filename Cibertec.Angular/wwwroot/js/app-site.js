(function () {
    'use strict';
    angular.module('app',
        [   'ui.router',
            'LocalStorageModule',
            'ui.bootstrap'
        ]);
})();
(function () {
    'use strict';
    angular.module('app').config(routeConfig);

    routeConfig.$inject = ['$stateProvider', '$urlRouterProvider'];

    function routeConfig($stateProvider, $urlRouterProvider) {
        $stateProvider.
            state("home",
            {
                url: "/home",
                templateUrl: "app/home.html"
            })
            .state("login", {
                url: "/login",
                templateUrl: "app/public/login/index.html"
            })
            .state("product", {
                url: "/product",
                templateUrl: "app/private/product/index.html"
            })
            .state("customer", {
                url: "/customer",
                templateUrl: "app/private/customer/index.html"
            })
            .state("supplier", {
                url: "/supplier",
                templateUrl: "app/private/supplier/index.html"
            })
            .state("order", {
                url: "/order",
                templateUrl: "app/private/order/index.html"
            })
            .state("orderitem", {
                url: "/orderitem",
                templateUrl: "app/private/orderitem/index.html"
            })
            .state("otherwise", {
                url: "*path",
                templateUrl: "app/home.html"
            })
    }
})();
(function () {
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
        } else {
            $state.go('login');
        }
    }
})();
(function () {
    'use strict';
    angular.module('app').
        controller('applicationController', applicationController);

    applicationController.$inject = ['$scope', 'configService', 'authenticationService', 'localStorageService'];

    function applicationController($scope, configService, authenticationService, localStorageService ) {
        var vm = this;
        vm.validate = validate;
        vm.logout = logout;

        $scope.init = function (url) {
            configService.setApiUrl(url);
        }
        function validate() {
            return configService.getLogin();
        }
        function logout() {
            authenticationService.logout();
        }
    }
})();