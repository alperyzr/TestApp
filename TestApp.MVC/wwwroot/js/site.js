﻿//Sidebar active
$(function () {   
    var url = window.location;

    $('.sidebar a').filter(function () {
        return this.href == url;
    }).addClass('active');

});


//Check Cookie
function getCookie(name) {
    var dc = document.cookie;
    var prefix = name + "=";
    var begin = dc.indexOf("; " + prefix);
    if (begin == -1) {
        begin = dc.indexOf(prefix);
        if (begin != 0) return null;
    }
    else {
        begin += 2;
        var end = document.cookie.indexOf(";", begin);
        if (end == -1) {
            end = dc.length;
        }
    }

    return decodeURI(dc.substring(begin + prefix.length, end));
}
$(function () {
    var myCookie = getCookie("UserKey");

    if (myCookie == null) {
        window.location.href = '/Login';
    }


});

//Silme İşlemi
function AreYouSureDelete(id, ajaxPath) {
    debugger;
    Swal.fire({
        title: 'Silmek İstediğinizden Eminmisiniz?',       
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sil',
        cancelButtonText: 'Vazgeç',
        reverseButtons: true,
    }).then((result) => {

        if (result.isConfirmed) {
            debugger;
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



function onDetailClick(e) {
    debugger;
    e.preventDefault();
    var grid = $("#Grid").data("kendoGrid");
    var dataItem = grid.dataItem($(e.target).closest("tr"));
    var itemId = dataItem.Id;
    alert(itemId);

};

function onEditClick(e) {
    debugger;
    e.preventDefault();
    var grid = $("#Grid").data("kendoGrid");
    var dataItem = grid.dataItem($(e.target).closest("tr"));
    var itemId = dataItem.Id;
    alert(itemId);

};

function onDeleteClick(e) {
    debugger;
    e.preventDefault();
    if (confirm("Bu öğeyi silmek istediğinizden emin misiniz?")) {
        var grid = $("#Grid").data("kendoGrid");
        var dataItem = grid.dataItem($(e.target).closest("tr"));
        var itemId = dataItem.Id;
        alert(itemId);

        
    }
}