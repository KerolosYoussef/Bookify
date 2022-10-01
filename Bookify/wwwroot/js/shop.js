$(document).ready(function(){
    GetBooks();
    // pagination
    $(document).on('click','.page-link',function(){
        // get page number from pagination
        let pageNumber = $(this).data('page_number');
        
        // Check if there a search
        let searchVal = $("#search").val();
        let search = searchVal === "" ? null : searchVal;
        
        // Get Books From database and append it the shop
        GetBooks(search,null,pageNumber);
        
        // Scroll to top of the page after the books load
        setTimeout(() => {window.scrollTo(0,0)}, 150);
    });
    
    // search bar
    $(document).on('click','#searchBtn',function(){
        let searchVal = $("#search").val();
        let search = searchVal === "" ? null : searchVal;
        GetBooks(search);
    })
    $("#search").keyup(function(event) {
        if (event.keyCode === 13) {
            $("#searchBtn").click();
        }
    });
    
    // Genre Filter
    $(document).on('click','.genre-link',function(){
       let genreId = $(this).data('id');
       GetBooks(null,genreId);
    });
    
    // Price Filter
    $(document).on('click','#submitPrice',function(){
        let min = $("#min").val();
        let max = $("#max").val();
        max = max !== "" ? max : 1000;
        min = min !== "" ? min : 0;
        if(max < min){
            Swal.fire({
                icon: 'error',
                text: 'Maximum price must be more than or equal minimum price!',
            });
        } else {
            let searchVal = $("#search").val();
            let search = searchVal === "" ? null : searchVal;
            GetBooks(search, null,1,9,min,max);    
        }
    });
    
    // Reset Filters
    $(document).on('click','#resetBtn', function(){
        $("#search").val("");
        GetBooks();
    });
})

function GetBooks(
    search = null,
    genre = null,
    pageNumber = 1,
    pageSize = 9,
    min = 0,
    max = 1000
)
{
    $.ajax({
        type: "GET",
        dataType : "json",
        contentType: "application/json; charset=utf-8",
        data:{search: search, genre: genre, min:min, max: max},
        url: `https://localhost:44359/api/book?pageNumber=${pageNumber}&pageSize=${pageSize}`,
        success: function(data){
            console.log(data);
            updateTotalNumberCount(data);
            updatePagination(data,pageNumber);
            appendItems(data);
        }
    })
}

function appendItems(data){
    let books = data.data;
    let content_items = $('.content-items');
    books.length > 0 ? content_items.html(``) : content_items.html(`<p class='text-muted ms-3'>No Items Found</p>`);
    $.each(books,function(index,book){
        let bookData = {
            Title: book.title,
            Price: book.price,
            ImagePath: book.imagePath
        };
        content_items.append(`
         <div class="col-lg-4 col-md-6 col-sm-6 mb-4">
            <div class="card h-100 shadow-sm">
              <div class="image position-relative" style="cursor: pointer;">
                  <img src="https://localhost:44359/img/${book.imagePath}" alt="${book.title}" class="img-fluid">
              <div class="d-flex align-items-center justify-content-center hover-overlay">
                  <a 
                      data-book='${JSON.stringify(bookData)}'
                      type="button"
                      class="add-to-cart btn btn-primary book-btn me-2"
                  >
                    <i class="fa fa-shopping-cart"></i>
                  </a>
                  <a type="button" class="btn btn-primary book-btn" href="https://localhost:44359/Book/${book.id}">View</a>
              </div>
              </div>
            
              <div class="card-body d-flex flex-column">
                  <a>
                      <h6 class="text-uppercase">${book.title}</h6>
                  </a>
                  <span class="mb-2">$${book.price}</span>
              </div>
            </div>
        </div> <!-- col end.// -->
        `)
    })
}

function updatePagination(data,currentPage= 1){
    let totalPages = data.totalPages;
    let paginationBody =  $(".pagination-body");
   paginationBody.html('');
    for(let i =1;i<=totalPages;i++){
        paginationBody.append(`
             <li class="page-item ${currentPage === i ? 'active' : ''}">
                <a class="page-link" data-page_number="${i}">${i}</a>
             </li>
        `);
    }
}

function updateTotalNumberCount(data) {
    $("#totalItems").text(data.count);
}
