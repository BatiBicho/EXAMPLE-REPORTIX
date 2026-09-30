$(document).ready(function () {
    const $modal = $('#forgotPasswordModal');
    const $btnSend = $('#btnSendForgot');
    const $txtUserId = $('#txtForgotUserId');
    const $alert = $('#forgotAlert');
    const $success = $('#forgotSuccess');
    const $spinner = $('#btnForgotSpinner');

    // Limpiar campos y alertas al abrir la modal
    $modal.on('show.bs.modal', function () {
        $txtUserId.val('');
        $alert.addClass('d-none').text('');
        $success.addClass('d-none').text('');
        $btnSend.prop('disabled', false);
        $spinner.addClass('d-none');
    });

    // Poner el foco en el input al terminar de mostrar la modal
    $modal.on('shown.bs.modal', function () {
        $txtUserId.focus();
    });

    // Enviar al hacer clic en el botón
    $btnSend.on('click', function () {
        solicitarRestablecimiento();
    });

    // Enviar con Enter dentro del input
    $txtUserId.on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            solicitarRestablecimiento();
        }
    });

    function solicitarRestablecimiento() {
        const userId = $txtUserId.val().trim();
        const token = $('input[name="__RequestVerificationToken"]').val();

        $alert.addClass('d-none').text('');
        $success.addClass('d-none').text('');

        if (!userId) {
            mostrarError('Por favor ingresa tu ID de usuario.');
            $txtUserId.focus();
            return;
        }

        $btnSend.prop('disabled', true);
        $spinner.removeClass('d-none');

        $.ajax({
            url: '/Account/ForgotPassword',
            type: 'POST',
            contentType: 'application/json',
            headers: {
                'RequestVerificationToken': token
            },
            data: JSON.stringify({
                userId: userId
            }),
            success: function (response) {
                if (response.success) {
                    $success.removeClass('d-none').html(
                        '<i class="bi bi-check-circle-fill me-1"></i> ' +
                        (response.message || 'Se ha enviado un correo con las instrucciones para restablecer tu contraseña.')
                    );
                    $txtUserId.val('');
                    setTimeout(function () {
                        const modalEl = document.getElementById('forgotPasswordModal');
                        const modalInstance = bootstrap.Modal.getInstance(modalEl);
                        if (modalInstance) {
                            modalInstance.hide();
                        }
                    }, 3500);
                } else {
                    mostrarError(response.message || 'No se encontró el usuario especificado.');
                }
            },
            error: function () {
                mostrarError('Ocurrió un error al procesar la solicitud. Intenta de nuevo.');
            },
            complete: function () {
                $btnSend.prop('disabled', false);
                $spinner.addClass('d-none');
            }
        });
    }

    function mostrarError(msg) {
        $alert.removeClass('d-none').text(msg);
    }
});

