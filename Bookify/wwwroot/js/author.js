const baseUrl = "https://localhost:44359/api/";
$(document).ready(function(){
    if($("#authors-table").length){
        GetAuthorsDataTable();
    }

    $(document).on("click","#deleteBtn",function(){
        const id = $(this).data('id');
        DeleteAuthor(id);
    })
});


function GetAuthorsDataTable(){
    var authors_datatable = $("#authors-table").DataTable({
        ajax:{
            type: "GET",
            url:baseUrl + "admin/author",
            dataSrc: ""
        },
        columns:[
            {name: "id", render:function(data,type,full, meta){
                    return meta.row + 1;
                }},
            {data: 'name', render: function (data,type, row){
                return `${row.firstName} ${row.lastName}`;    
            }},
            {
                data: "action",
                render: function ( data, type, row ) {
                    let html = `<a href="/Admin/Author/Edit/${row.id}" class="btn btn-success btn-xs"><i class="fas fa-edit"></i> Edit</a>`;
                    html+=` <button id="deleteBtn" data-id="${row.id}" class="btn btn-danger btn-xs"><i class="fas fa-trash"></i> Delete</button>`;
                    return html;
                }
            }
        ]
    });
}
function DeleteAuthor(id)
{
    Swal.fire({
        icon: "info",
        title: 'Are you sure you want to delete this Author?',
        text: 'By deleting this author all its books will be deleted.',
        showCancelButton: true,
        confirmButtonText: 'Delete',
        showLoaderOnConfirm: true,
    }).then((result) => {
        if(result.isConfirmed){
            $.ajax({
                type: "DELETE",
                data:{authorId: id},
                url:baseUrl+`author?id=${id}`,
                success:function(response){
                    $('#authors-table').DataTable().ajax.reload();
                    Swal.fire({
                        icon: "success",
                        title: "Author Deleted Successfully",
                    })
                }
            })
        }
    })
}