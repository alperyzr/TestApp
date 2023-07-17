function AreYouSureDelete(id, ajaxPath,) {
    debugger;
    Swal.fire({
        title: 'Silmek İstediğinizden Eminmisiniz?',       
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sil',
        cancelButtonText: 'VAzgeç',
        reverseButtons: true,
    }).then((result) => {

        if (result.isConfirmed) {
            debugger;
            $.ajax({
                type: "DELETE",
                url: ajaxPath,
                data: id,
                success: function (data) {
                    debugger;
                    Swal.fire('Saved!', '', 'success')
                },
                error: function (data) {
                    debugger;
                    Swal.fire('Saved!', '', 'success')
                }
            });
        }
        else if (result.dismiss === Swal.DismissReason.cancel)
        {
            debugger;
            swalWithBootstrapButtons.fire(
                'Cancelled',
                'Your imaginary file is safe :)',
                'error'
            )
        }
       
    })
}