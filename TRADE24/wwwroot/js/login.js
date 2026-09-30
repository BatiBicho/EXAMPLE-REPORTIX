$(document).ready(function () {
    $('#btnLogin').on('click', function () {
        realizarLogin();
    });

    // Permitir enviar con Enter
    $('#txtUsuario, #txtPassword').on('keypress', function (e) {
        if (e.which === 13) realizarLogin();
    });

    function realizarLogin() {
        const usuario = $('#txtUsuario').val().trim();
        const password = $('#txtPassword').val().trim();
        const token = $('input[name="__RequestVerificationToken"]').val();

        $('#loginAlert').addClass('d-none').text('');

        if (!usuario || !password) {
            mostrarError('Debes ingresar usuario y contraseña.');
            return;
        }

        $('#btnLogin').prop('disabled', true);
        $('#btnSpinner').removeClass('d-none');

        $.ajax({
            url: '/Account/Login',
            type: 'POST',
            contentType: 'application/json',
            headers: {
                'RequestVerificationToken': token
            },
            data: JSON.stringify({
                usuario: usuario,
                password: password
            }),
            success: function (response) {
                if (response.success) {
                    window.location.href = response.redirectUrl;
                } else {
                    mostrarError(response.message);
                }
            },
            error: function (xhr) {
                mostrarError('Ocurrió un error al iniciar sesión. Intenta de nuevo.');
            },
            complete: function () {
                $('#btnLogin').prop('disabled', false);
                $('#btnSpinner').addClass('d-none');
            }
        });
    }

    function mostrarError(msg) {
        $('#loginAlert').removeClass('d-none').text(msg);
    }
});