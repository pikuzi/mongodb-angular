function ProductNewController($scope, $http) {
    $scope.model = {};

    $scope.create = function (form) {
        if (form.$valid) {
            $http.post("/api/product", $scope.model)
                .success(function (data, status, headers, config) {
                    
                });
        } else {
            
        }
    };
}