
$(document).ready(function () {
    var dataSet =
        [
            {
                Nombre: 'Julio cesar',
                Edad:'34'
            },
            {
                Nombre: 'Rodolfo Hernandez',
                Edad: '34'
            },
            {
                Nombre: 'Rodolfo Hernandez',
                Edad: '17'
            }
            
        ]
    $('#example').DataTable({
        data: dataSet,
        columns: [
            {   data:"Nombre",
                title: "Name"
            },
            {
                data: "Edad",
                render: function (data, type, row) {
                    if (data > 18) {
                        return '<span class="badge badge-danger">' + data + ' el usuario es mayor de edad</span>'

                    } else {
                        return '<span class="badge badge-success">$' + data + 'el usuario es menor de edad </span>'

                    }
                },
                title: "Edad",
                'autoWith': true
            }
        ]

    });

});


function alerta() {
    swal({
        type: 'warning',
        title: 'Aviso...',
        text: 'Las fecha final de consulta no puede ser mayor a la fecha del año actual.\nEn caso de requerir información de facturas de años anteriores contacte a alianzas@mediaccess.com.mx',
        allowEscapeKey: true,
        allowEnterKey: true,
        focusCancel: true,
        focusConfirm: true,
        //timer: 4000
    });
}
function OpenModalNuevo(button) {
    if (button != undefined) {
        $('#frmNuevoUsuario').find('input').val('');
        $('#ModalNuevoRegistro').modal('show');
    }
};
function validarEmail(elemento) {

    var texto = document.getElementById(elemento.id).value;
    var regex = /^[-\w.%+]{1,64}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/i;

    if (!regex.test(texto)) {
        document.getElementById("resultado").innerHTML = 'Correo invalido';
    } else {
        document.getElementById("resultado").innerHTML = "";
    }

}

$('#frmNuevoUsuario').on('submit', function (e) {
    e.preventDefault();
   
        //if (!isAuthenticate()) {
        //    showExpiredSession();
        //    //return;
        //} else
      


        var objeto = {
            nombre: $('#txtnombre').val(),
            apellidoPaterno: $('#txtapellidoPaterno').val(),
            apellidoMaterno: $('#txtapellidoMaterno').val(),
            correo: $('#txtcorreo').val(),
            contrasena: $('#txtpassword').val(),
            idRol: $('#txtrol').val(),
        };
        //ValidatorCapturaFichaTecnica.resetForm();

        //limpiarFormularioCampos();

        //limpiarSelectCatMonedaNuevo();
        //limpiarSelectTipoCopagoNew();
        //limpiarSelectTipoGastoNew();

        $.ajax({
            //beforeSend: function () {
            //    //closeModalNuevo();
            //    $.blockUI({
            //        theme: true,
            //        title: 'Creando Ficha Técnica Por Favor Espere...',
            //        message: '<div class="row"><div class="col-lg-10"><br /><p><img src="/SASE/Content/assets/img/loading.gif" style="width: 35px;" /></p><p> Espere un momento por favor...</p><br /></div></div>',
            //        baseZ: 10000
            //    });
            //},

            url: 'Usuarios/AgregarUsuarios',
            type: 'POST',
            data: objeto,
            success: function (data) {

                //console.log("res ==>", data)
                $.unblockUI();
                if (data.success === 200) {
                    closeModal();
                    swal({
                        type: 'warning',
                        title: 'Aviso...',
                        text: 'Las fecha final de consulta no puede ser mayor a la fecha del año actual.\nEn caso de requerir información de facturas de años anteriores contacte a alianzas@mediaccess.com.mx',
                        allowEscapeKey: true,
                        allowEnterKey: true,
                        focusCancel: true,
                        focusConfirm: true,
                        //timer: 4000
                    });

                }
            },
            error: function (jqXHR, status, error) {
                $.unblockUI();
                swal({
                    title: "¡Error!",
                    text: 'Surgio un error inesperado. \n' + jqXHR.status + ' ' + jqXHR.statusText,
                    icon: "warning",
                });
            }
        });    
});
function closeModal() {
    $('#ModalNuevoRegistro').modal('toggle');
}
//function validateCampos() {
//    let nombre = document.getElementById("#txtnombre").value;
//    if (nombre === '') {
//        document.getElementById("validateNombre").innerHTML = 'Ingresa un nombre';
//    }
//    else {
//        document.getElementById("validateNombre").innerHTML = "";
//    }
//}