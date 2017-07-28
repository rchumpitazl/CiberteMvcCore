﻿
(function () {
    'use strict';
    angular
        .module('app')
        .controller('productController', productController);

    productController.$inject = ['dataService','configService', '$state'];


    function productController(dataService, configService, $state) {
        var url = configService.getApiUrl();
        var vm = this;

        // Propiedades
        vm.product = {};
        vm.productList = [];
        vm.modalButtonTitle = '';
        vm.readOnly = false;
        vm.isDelete = false;
        vm.modalTitle = '';
        vm.showCreate = false;


        vm.totalRecords = 0;
        vm.currentPage = 1;
        vm.maxSize = 10;
        vm.itemsPerPage = 25;

        //Funciones
        vm.getProduct = getProduct;
        vm.create = create;
        vm.edit = edit;
        vm.delete = productDelete;
        vm.pageChanged = pageChanged;
        //vm.closeModal = closeModal;

        init();

        function init() {
            if (!configService.getLogin()) return $state.go('login');
            configurePagination();
        }
        function configurePagination() {
            var widthScreen = (window.innerWidth > 0) ? window.innerWidth : screen.width;
            if (widthScreen < 20) vm.maxSize = 5;
            totalRecords();
        }
        function totalRecords() {
            dataService.getData(url + "/product/count")
                .then(function (result) {
                    vm.totalRecords = result.data;
                    getPageRecords(vm.currentPage);
                },
                function (error) {
                    vm.productList = [];
                }
                );
        }
        function pageChanged() {
            getPageRecords(vm.currentPage);
        }
        function getPageRecords(page) {
            dataService.getData(url + "/product/" + page + "/" + vm.itemsPerPage)
                .then(function (result) {
                    vm.productList = result.data;
                },
                function (error) {
                    vm.productList = [];
                }
                );
        }

        function getProduct(id) {
            vm.product = null;
            dataService.getData(url + '/product/' + id)
                .then(function (result) {
                    vm.product = result.data;
                },
                function (error) {
                    vm.product = null;
                }
            );
        }

        function createProduct() {
            if (!vm.product) return;
            dataService.postData(url + '/product', vm.product)
                .then(function (result) {
                    vm.product = {};
                    vm.currentPage = 1;
                    totalRecords();
                    closeModal();
                },
                function (error) {
                    vm.product = {};
                }
                );
        }

        function updateProduct() {
            if (!vm.product) return;
            dataService.putData(url + '/product', vm.product)
                .then(function (result) {
                    vm.product = {};
                    list();
                    closeModal();
                },
                function (error) {
                    vm.product = {};
                }
                );
        }
        function deleteProduct() {
            
            dataService.deleteData(url + '/product', vm.product.id)
                .then(function (result) {
                    list();
                    closeModal();
                },
                function (error) {
                   
                }
                );
        }
        function create() {
            vm.product = {};
            vm.modalTitle = 'New Product';
            vm.modalButtonTitle = 'Create';
            vm.readOnly = false;
            vm.modalFunction = createProduct;
            vm.isDelete = false;
        }
        function edit() {
            vm.showCreate = false;
            vm.modalTitle = 'Edit Product';
            vm.modalButtonTitle = 'Update';
            vm.readOnly = false;
            vm.modalFunction = updateProduct;
            vm.isDelete = false;
        }
        function detail() {
            vm.modalTitle = 'Created Product';
            vm.modalButtonTitle = '';
            vm.readOnly = true;
            vm.modalFunction = null;
            vm.isDelete = false;
        }
        function productDelete() {
            vm.showCreate = false;
            vm.modalTitle = 'Delete Product';
            vm.modalButtonTitle = 'Delete';
            vm.readOnly = false;
            vm.modalFunction = deleteProduct;
            vm.isDelete = true;
        }
        function closeModal() {
            angular.element('#modal-container').modal('hide');
        }
    }
})();