

(function () {
    'use strict';
    angular
        .module('app')
        .directive('supplierCard', supplierCard);

    function supplierCard() {
        return {
            restrict: 'E',
            transclude: true,
            scope: {
                id: '@',
                companyName: '@',
                contactName: '@',
                city: '@',
                country: '@',
                phone: '@'
            },
            templateUrl: 'app/private/supplier/directives/supplier-card/supplier-card.html',
            controller: directiveController
        };
    }
    function directiveController() {

    }
})();