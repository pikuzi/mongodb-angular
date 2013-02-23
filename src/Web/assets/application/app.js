angular.module('mongo', []).
  config(['$routeProvider', function ($routeProvider) {
      $routeProvider.
          when('/', { templateUrl: 'assets/application/views/home/index.html', controller: HomeController }).
          when('/products', { templateUrl: 'assets/application/views/products/product-list.html', controller: ProductListController }).
          //when('/products/:id', { templateUrl: 'partials/product-detail.html', controller: ProductDetailController }).
          otherwise({ redirectTo: '/' });
  }]);