
describe('loginController', function()
{
    var controller, service;

    beforeEach(module('app'));


    beforeEach(inject(function($controller, _authenticationService_,$q){
        service = _authenticationService_;

        spyOn(service, "login").and.callFake(function(user){
            var deferred = $q.defer();
            deferred.resolve('Response');
            return deferred.promise;
        });

        controller = $controller('loginController' ,
        {
            _authenticationService_: service
        });

        describe('Login Test', function() {

            it('Login', inject(function()
            {
                controller.login({});
                expect(controller.showError).toEqual(false);
            }));
        });

    })
    );

});