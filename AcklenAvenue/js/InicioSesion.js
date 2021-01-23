$(document).ready(function () {
    //Mostrar el inicio de sesión.
    $('#IniciarSesion').show();
    $('#FormularioRegistro').hide();

    //Ocultar el inicio de sesión y mostrar formulario de registro.
    $("#CrearCuenta").click(function () {
        $('#IniciarSesion').hide();
        $('#FormularioRegistro').show();
        limpiar();
    });

    //Ocultar formulario y mostrar inicio de sesión.
    $("#btnRegresar").click(function () {
        $('#IniciarSesion').show();
        $('#FormularioRegistro').hide();
        limpiar();
    });

    //Registrar cuenta
    $("#btnRegistrar").click(function () {
        var respuesta = validar();
        if (respuesta != 'falso') {

            //Objeto Json
            var Datos = {
                Nombre: $('#MainContent_txtNombre').val(),
                Apellidos: $('#MainContent_txtApellidos').val(),
                Usuario: $('#MainContent_txtNuevoUsuario').val(),
                Contraseña: $('#MainContent_txtNuevaContraseña').val()
            };

            $.ajax({
                type: "POST",
                url: '/Index.aspx/Insertar',
                data: JSON.stringify(Datos),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    //Mostrar mensaje de éxito
                    if (data.d == 'Correcto') {
                        var dialog = new Messi(
                    '<strong>Se ha registrado con éxito</strong>',
                    {
                        title: '',
                        animate: { open: 'bounceInLeft', close: 'bounceOutRight' },
                        buttons: [{ id: 0, label: 'Close', val: 'X'}]
                    }
                    );
                        limpiar();
                    }
                    //Mostrar mensaje de error
                    else {
                        var dialog = new Messi(
                    '<strong>No fué posible hacer el registro</strong>',
                    {
                        title: '',
                        animate: { open: 'bounceInLeft', close: 'bounceOutRight' },
                        buttons: [{ id: 0, label: 'Close', val: 'X'}]
                    }
                    );
                        limpiar();
                    }

                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
    });

    //Limpiar campos
    function limpiar() {
        $('#MainContent_txtUsuario').val('');
        $('#MainContent_txtContraseña').val('');
        $('#MainContent_txtNombre').val('');
        $('#MainContent_txtApellidos').val('');
        $('#MainContent_txtNuevoUsuario').val('');
        $('#MainContent_txtNuevaContraseña').val('');
    }

    //Validar campos vacios
    function validar() {
        if ($('#MainContent_txtNombre').val() == "" || $('#MainContent_txtApellidos').val() == "" || $('#MainContent_txtNuevoUsuario').val() == "" || $('#MainContent_txtNuevaContraseña').val() == "") {
            return 'falso';
        }
    }

    //Iniciar sesión 
    $("#btnIiniciar").click(function () {
        var resp = validarSesion();

        if (resp != 'falso') {
            //Objeto Json
            var Sesion = {
                Usuario: $('#MainContent_txtUsuario').val(),
                Contraseña: $('#MainContent_txtContraseña').val()
            };

            $.ajax({
                type: "POST",
                url: '/Index.aspx/Sesion',
                data: JSON.stringify(Sesion),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == 'Correcto') {
                        //Mostrar pagina
                        window.location.href = "ejemploacklen.aspx";
                        limpiar();
                    }
                    //Mostrar mensaje de error
                    else {
                        var dialog = new Messi(
                    '<strong>Usuario o Contraseña incorrecto</strong>',
                    {
                        title: '',
                        animate: { open: 'bounceInLeft', close: 'bounceOutRight' },
                        buttons: [{ id: 0, label: 'Close', val: 'X'}]
                    }
                    );
                    }

                },
                failure: function (response) {
                    alert(response.d);
                }
            });

        }
    });

    //Validar campos vacios iniciar sesión
    function validarSesion() {
        if ($('#MainContent_txtUsuario').val() == "" || $('#MainContent_txtContraseña').val() == "") {
            return 'falso';
        }
    }

});