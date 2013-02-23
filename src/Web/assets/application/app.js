angular.module('mongo', []).
  config(['$routeProvider', function ($routeProvider) {
      $routeProvider.
          when('/', { templateUrl: 'assets/application/views/home/index.html', controller: HomeIndexController }).
          when('/products', { templateUrl: 'assets/application/views/products/index.html', controller: ProductIndexController }).
          when('/products/new', { templateUrl: 'assets/application/views/products/new.html', controller: ProductNewController }).
          otherwise({ redirectTo: '/' });
  }]);