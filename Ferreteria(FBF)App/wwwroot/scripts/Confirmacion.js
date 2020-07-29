function ConfirmationPrumpt(titulo, mensaje, tipo) {
    return new Promise((resolve) => {

        Swal.fire({
            title: titulo,
            text: mensaje,
            icon: tipo,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, eliminar!',
            allowOutsideClick: false
        }).then((result) => {
            if (result.value) {
                resolve(true);
            } else {
                resolve(false);
            }
        });
    });
}

function result() {
    return confirm("Esta seguro que desea eliminar?");
}
