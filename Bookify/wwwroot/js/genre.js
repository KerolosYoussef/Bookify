const baseUrl = "https://localhost:44359/api/";
$(document).ready(function(){
    if($("#genres-table").length){
        GetGenresDataTable();
    }

    $(document).on("click","#deleteBtn",function(){
        const id = $(this).data('id');
        DeleteGenre(id);
    })
});


function GetGenresDataTable(){
    var genres_datatable = $("#genres-table").DataTable({
        ajax:{
            type: "GET",
            url:baseUrl + "admin/genre",
            dataSrc: ""
        },
        columns:[
            {name: "id", render:function(data,type,full, meta){
                    return meta.row + 1;
                }},
            {name: 'name', data: 'name'},
            {
                data: "action",
                render: function ( data, type, row ) {
                    let html = `<a href="/Admin/Genre/Edit/${row.id}" class="btn btn-success btn-xs"><i class="fas fa-edit"></i> Edit</a>`;
                    html+=` <button id="deleteBtn" data-id="${row.id}" class="btn btn-danger btn-xs"><i class="fas fa-trash"></i> Delete</button>`;
                    return html;
                }
            }
        ]
    });
}
function DeleteGenre(id)
{
    Swal.fire({
        icon: "info",
        title: 'Are you sure you want to delete this genre?',
        showCancelButton: true,
        confirmButtonText: 'Delete',
        showLoaderOnConfirm: true,
    }).then((result) => {
        if(result.isConfirmed){
            $.ajax({
                type: "DELETE",
                data:{genreId: id},
                url:baseUrl+`genre?id=${id}`,
                success:function(response){
                    $('#genres-table').DataTable().ajax.reload();
                    Swal.fire({
                        icon: "success",
                        title: "Genre Deleted Successfully",
                    })
                }
            })
        }
    })
}