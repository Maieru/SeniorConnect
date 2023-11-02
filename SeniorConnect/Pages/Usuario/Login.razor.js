export class Login {
    static exibeTelaAnimada() {
        console.log("estou sendo chamado :)");

        $('#loginWindow').animate({ 'width': '100%' }, 500)
            .delay(30)
            .animate({ 'height': '350px' }, 500);
        $('.page-header, .input-group, .btn')
            .delay(850)
            .animate({ 'opacity': '100' }, 7000);
    }
};

window.Login = Login;