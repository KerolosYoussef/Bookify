$(document).ready(function(){
    GetUsersDataTable(); 
    
    $(document).on("click","#deleteBtn",function(){
        const id = $(this).data('id');
        DeleteUser(id);
    })
});

function GetUsersDataTable(){
    var users_table = $("#users-table").DataTable({
        ajax:{
            type: "GET",
            url:"https://localhost:44359/api/user",
            dataSrc:"",
        },
        columns:[
            {name: "id", render:function(data,type,full, meta){
                return meta.row + 1;    
            }},
            {name: "displayName", data:"displayName"},
            {name: "email", data:"email"},
            {name: "roles", render:function(data,type,row){
                if(row.roles.length === 0 || row.roles.includes("Customer")){
                    return "Customer";
                }
                return row.roles;   
            }},
            {
                data: "action",
                render: function ( data, type, row ) {
                    let html = `<a href="/User/Edit/${row.id}" class="btn btn-success btn-xs"><i class="fas fa-edit"></i> Edit</a>`;
                    html+=` <button id="deleteBtn" data-id="${row.id}" class="btn btn-danger btn-xs"><i class="fas fa-trash"></i> Delete</button>`;
                    return html;
                }
            }
        ]
    });
}

function DeleteUser(id)
{
    Swal.fire({
        icon: "info",
        title: 'Are you sure you want to delete this user?',
        showCancelButton: true,
        confirmButtonText: 'Delete',
        showLoaderOnConfirm: true,
    }).then((result) => {
        if(result.isConfirmed){
            $.ajax({
                type: "delete",
                url:`https://localhost:44359/api/user?id=${id}`,
                success:function(response){
                    $('#users-table').DataTable().ajax.reload();
                    Swal.fire({
                        icon: "success",
                        title: "User Deleted Successfully",
                    })
                }
            })
        }
    })    
}