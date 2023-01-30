
    $("#loginForm").submit(function (e) {
        var pass = $('#password').val();
        var login = $('#login').val();
        e.preventDefault();
        $.ajax({
            url: '/Login/Login',
            method: "POST",
            data: {
                login: login,
                password: pass
            }
        }).done(function (data) {
            if (data.isSuccess) {
                document.getElementById("loginResponseModalBody").textContent = JSON.stringify(data.loginResponse, undefined, 2);
                $('#failureAlert').hide();
                $('#successAlert').show();
            }
            else {
                document.getElementById("loginResponseModalBody").textContent = JSON.stringify(data.errorResult, undefined, 2);
                $('#successAlert').hide();
                $('#failureAlert').show();
            }
            $('#loginResponseModal').modal('show');
        });
    });
