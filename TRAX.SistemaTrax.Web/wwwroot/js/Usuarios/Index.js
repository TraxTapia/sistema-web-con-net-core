
$(document).ready(function () {
    tableUser();
    //getAllAndUpdateTableProduct();
    var dataSet =
        [
            {
                Nombre: 'Julio cesar',
                Edad: '34'
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
            {
                data: "Nombre",
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
    //swal({
    //    title: "Correcto!",
    //    text: "Se creo el usuario correctamente.",
    //    icon: "success"
    //});
});
function getAllAndUpdateTableProduct() {
    //console.log('Entra a getAllAndUpdateTableProduct')

    //console.log('req Actualizar Tabla', request)
    $.ajax({
        beforeSend: function () {

        },
        url: 'Usuarios/ObtenerUsuarios',
        type: 'GET',
        success: function (data) {
            //console.log('res getAllAndUpdateTableProduct', data)
            if (data != undefined || data != null) {
                $('#divResult').html(data);

            }
        },
    })
}

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
    var objeto = {
        nombre: $('#txtnombre').val(),
        apellidoPaterno: $('#txtapellidoPaterno').val(),
        apellidoMaterno: $('#txtapellidoMaterno').val(),
        correo: $('#txtcorreo').val(),
        contrasena: $('#txtpassword').val(),
        idRol: $('#txtrol').val(),
    };
    cleanInputs();
  
    //ValidatorCapturaFichaTecnica.resetForm();

    //limpiarFormularioCampos();

    //limpiarSelectCatMonedaNuevo();
    //limpiarSelectTipoCopagoNew();
    //limpiarSelectTipoGastoNew();

    $.ajax({
        beforeSend: function () {
            closeModal();
            $.blockUI({
                theme: true,
                title: 'Creando Ficha Técnica Por Favor Espere...',
                message: '<div class="row"><div class="col-lg-10"><br/><p><img src="~/css/assets/img/revertloading.gif" style="width: 35px;" /></p><p> Espere un momento por favor...</p><br /></div></div>',
                baseZ: 10000
            });
        },

        url: 'Usuarios/AgregarUsuarios',
        type: 'POST',
        data: objeto,
        success: function (data) {
            $.unblockUI();
            if (data.success === 200) {
               
                tableUser();
                swal({
                    title: "Exito!",
                    text: "Se creo el usuario correctamente",
                    icon: "success"
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
function tableUser() {

    $.ajax({
        beforeSend: function () {

        },
        url: 'Usuarios/ObtenerUsuarios',
        type: 'GET',
        success: function (data) {
            //console.log('res getAllAndUpdateTableProduct', data)
            if (data != null) {

                $('#tblUsers').DataTable({
                    data: data.data,
                    dom: 'Blfrtip',
                    buttons: ['csv', 'excel', 'pdf'],
                    destroy: true,
                    lengthMenu: [10, 15, 20],
                    language: {
                        "decimal": "",
                        "emptyTable": "No hay información",
                        "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                        "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                        "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                        "infoPostFix": "",
                        "thousands": ",",
                        "lengthMenu": "Mostrar _MENU_ Entradas",
                        "loadingRecords": "Cargando...",
                        "processing": "Procesando...",
                        "search": "Buscar en resultado:",
                        "zeroRecords": "Sin resultados encontrados",
                        "paginate": {
                            "first": "Primero",
                            "last": "Ultimo",
                            "next": "Siguiente",
                            "previous": "Anterior"
                        }
                    },
                    "columns":
                        [
                            {
                                "data": "Id"
                            }, {
                                "data": "NombreCompleto"
                            }, {
                                "data": "Correo"
                            }, {
                                "data": "DescripcionRol"
                            }
                            ,
                            {
                                "data": "Activo",
                                render: function (data, type, row) {
                                    if (data==true) {
                                        return '<span class="badge badge-success">Activo </span>'
                                        

                                    } else {
                                        return '<span class="badge badge-danger">Inactivo</span>'

                                    }
                                },

                            }
                        ]
                })
            }
        },
    })

    //$('#tblUsers').DataTable({
    //    'ajax': {
    //        'url': 'Usuarios/ObtenerUsuarios',
    //        'type': 'GET',
    //        'datatype': 'json',
    //        "dataSrc": "data",
    //    },
    //})

}
function cleanInputs() {
    $('#frmNuevoUsuario').find('input').val('');
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