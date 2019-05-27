/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('tedushop.orders', ['tedushop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('orders', {
                url: "/orders",
                parent: 'base',
                templateUrl: "/app/components/orders/orderlistView.html",
                controller: "orderListController"
            });
    }
})();