angular.module('mongo', []).
  config(['$routeProvider', function ($routeProvider) {
      $routeProvider.
          when('/products', { templateUrl: 'scripts/application/views/products/product-list.html', controller: ProductListController }).
          //when('/products/:id', { templateUrl: 'partials/product-detail.html', controller: ProductDetailController }).
          otherwise({ redirectTo: '/products' });
  }]);