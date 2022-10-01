const baseUrl = "https://localhost:44359/";
$(document).ready(function(){
    if($("#books-table").length){
        GetBooksDataTable();
    }

    $(document).on("click","#deleteBtn",function(){
        const id = $(this).data('id');
        DeleteBook(id);
    })
    
    $(document).on("change","#Image",function(event){
        let img = $("#output");
        img.show();
        img.attr("src",URL.createObjectURL(event.target.files[0]));
    })
    
    $('.quantity-right-plus').click(function(e){

        // Stop acting like a button
        e.preventDefault();
        // Get the field name
        var quantity = parseInt($('#quantity').val());

        // If is not undefined

        $('#quantity').val(quantity + 1);


        // Increment

    });

    $('.quantity-left-minus').click(function(e){
        // Stop acting like a button
        e.preventDefault();
        // Get the field name
        var quantity = parseInt($('#quantity').val());

        // If is not undefined

        // Increment
        if(quantity>0){
            $('#quantity').val(quantity - 1);
        }
    });
    $('.js-example-basic-multiple').select2();
});


function GetBooksDataTable(){
    var books_datatable = $("#books-table").DataTable({
        ajax:{
            type: "GET",
            url:"https://localhost:44359/api/admin/book",
            dataSrc: ""
        },
        columns:[
            {name: "id", render:function(data,type,full, meta){
                    return meta.row + 1;
            }},
            {data: "imagePath", render: function(data,type,row){
                let html =`<img src="${baseUrl}/img/${row.imagePath}" style="max-width: 50px;">`; 
                return html;
            }},
            {name: "title", data:"title"},
            {name: "price", data:"price"},
            {name: "numberOfCopies", data:"numberOfCopies"},
            {name: "bookSoldCopies", data:"bookSoldCopies"},
            {data: "genres", render:function(data,type,row) {
                let genres = [];
                let genre;
                genre = row.genres.map(g => {
                    return g.name;
                });
                genres.push(genre);
                return genres;    
            }},
            {
                data: "action",
                render: function ( data, type, row ) {
                    let html = `<a href="/Admin/Book/Edit/${row.id}" class="btn btn-success btn-xs"><i class="fas fa-edit"></i> Edit</a>`;
                    html+=` <button id="deleteBtn" data-id="${row.id}" class="btn btn-danger btn-xs"><i class="fas fa-trash"></i> Delete</button>`;
                    return html;
                }
            }
        ]
    });
}
function DeleteBook(id)
{
    Swal.fire({
        icon: "info",
        title: 'Are you sure you want to delete this book?',
        showCancelButton: true,
        confirmButtonText: 'Delete',
        showLoaderOnConfirm: true,
    }).then((result) => {
        if(result.isConfirmed){
            $.ajax({
                type: "delete",
                url:`https://localhost:44359/api/book?id=${id}`,
                success:function(response){
                    $('#books-table').DataTable().ajax.reload();
                    Swal.fire({
                        icon: "success",
                        title: "Book Deleted Successfully",
                    })
                }
            })
        }
    })
}