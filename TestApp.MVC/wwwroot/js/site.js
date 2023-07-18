$(function () {
    debugger;
    var url = window.location;

    $('.sidebar a').filter(function () {
        return this.href == url;
    }).addClass('active');

});

function AreYouSureDelete(id, ajaxPath) {
    Swal.fire({
        title: 'Silmek İstediğinizden Eminmisiniz?',       
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sil',
        cancelButtonText: 'Vazgeç',
        reverseButtons: true,
    }).then((result) => {

        if (result.isConfirmed) {           
            var url = ajaxPath + "/" + id;
            $.ajax({
                type: "GET",
                url: url,
                data: id,
                success: function (data) {
                    debugger;
                    window.location.reload();
                },
                error: function (data) {
                    debugger;
                    Swal.fire('Beklenmedik Bir Hata Oluştu', '', 'error')
                }
            });
        }        
    })
}