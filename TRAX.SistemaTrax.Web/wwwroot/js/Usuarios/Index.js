
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