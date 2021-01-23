$(document).ready(function () {
    //$('#MainContent_viewGrid').show();
    //$('#MainContent_viewCampos').hide();

    //Mostrar formulario del producto a registrar
    $("#btnAgregar").click(function () {
        $('#MainContent_viewGrid').hide();
        $('#MainContent_viewCampos').show();
    });
    

    //Registrar producto
    $("#btnGuardar").click(function () {
        var respuesta = validar();
        if (respuesta != 'falso') {

            //Objeto Json
            var Producto = {
                Nombre: $('#MainContent_txtNombre').val(),
                Precio: $('#MainContent_txtPrecio').val(),
                Existencia: $('#MainContent_txtExistencia').val()
            };

            $.ajax({
                type: "POST",
                url: '/EjemploAcklen.aspx/InsertarProducto',
                data: JSON.stringify(Producto),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    //Mostrar mensaje de éxito
                    if (data.d == 'Correcto') {
                        var dialog = new Messi(
                    '<strong>Producto registrado con éxito</strong>',
                    {
                        title: '',
                        animate: { open: 'bounceInLeft', close: 'bounceOutRight' },
                        buttons: [{ id: 0, label: 'Close', val: 'X'}]
                    }
                    );
                        limpiar();
                        //Mostrar grid
                        $('#MainContent_viewGrid').show();
                        $('#MainContent_viewCampos').hide();

                        window.location.href = "ejemploacklen.aspx"; 

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
        else {//Mensaje de validación
            var dialog = new Messi(
            '<strong>Es necesario llenar todos los campos</strong>',
            {
                title: '',
                animate: { open: 'bounceInLeft', close: 'bounceOutRight' },
                buttons: [{ id: 0, label: 'Close', val: 'X'}]
            }
            );
        }
    });

    //Validar campos vacios
    function validar() {
        if ($('#MainContent_txtNombre').val() == "" || $('#MainContent_txtPrecio').val() == "" || $('#MainContent_txtExistencia').val() == "") {
            return 'falso';
        }
    }

    //Limpiar campos
    function limpiar() {
        $('#MainContent_txtNombre').val('');
        $('#MainContent_txtPrecio').val('');
        $('#MainContent_txtExistencia').val('');
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


    //Mostrar formulario del producto a editar
    $("#MainContent_dgvProductos_btnEditar_2").click(function () {
        $('#MainContent_viewGrid').hide();
        $('#MainContent_viewCampos').show();
    });


});