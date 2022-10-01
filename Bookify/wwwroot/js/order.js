$(document).ready(function(){
    GetOrders();

    $(document).on('click','.page-link',function(){
        // get page number from pagination
        let pageNumber = $(this).data('page_number');


        // Get Orders From database and append it the orders page
        GetOrders(pageNumber);

        // Scroll to top of the page after the orders load
        setTimeout(() => {window.scrollTo(0,0)}, 150);
    });
    
    $(document).on("click","#viewOrder",function(){
        let order_id = $(this).data('order_id');
        GetOrderById(order_id);
    })
})

function GetOrders(pageNumber = 1, pageSize = 10)
{
    $.ajax({
        type: "GET",
        dataType : "json",
        contentType: "application/json; charset=utf-8",
        url: `https://localhost:44359/api/orders?pageNumber=${pageNumber}&pageSize=${pageSize}`,
        success: function(data){
            updatePagination(data,pageNumber);
            appendItems(data);
        }
    })
}

function GetOrderById(order_id){
    $.ajax({
        type: "POST",
        dataType : "json",
        data:{id: order_id},
        url: `https://localhost:44359/api/order`,
        success: function(data){
            addDataToOrderModal(data);
        }
    })
}

function appendItems(data){
    let orders = data.data;
    let table_body = $('#order_table_body');
    orders.length > 0 ?
        table_body.html(``) : 
        table_body.html(`<div class="empty-message"><h3>You haven't placed any order yet.</h3></div>`);
    
    $.each(orders,function(index,order){
        let date = moment(order.date).format("MMMM Do YYYY");
        let orderData = {
            order_id: order.id,
            reference: order.reference,
            date: date,
            status: order.status,
            total: order.total
        };
        table_body.append(`
            <tr>
                <td><p>#${orderData.reference}</p></td>
                <td><p>${orderData.date}</p></td>
                <td><p class="badge ${orderData.status}">${orderData.status}</p></td>
                <td><p>${orderData.total} EGP</p></td>
                <td><button id="viewOrder" data-order_id="${orderData.order_id}" class="btn btn-black btn-sm">View</button></td>
            </tr>
        `);
    });
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

function addDataToOrderModal(order){
    $("#orderFirstName").html(order.customerFirstName);
    $(".card-content").html(`
        <div class="card-body p-4">
            <div class="d-flex justify-content-between align-items-center mb-4">
              <p class="lead fw-normal mb-0" style="color: #a8729a;">Receipt</p>
            </div>
            <div class="card-items">
            
            </div>

            <div class="d-flex justify-content-between pt-2">
              <p class="fw-bold mb-0">Order Details</p>
            </div>

            <div class="d-flex justify-content-between pt-2">
              <p class="text-muted mb-0">Invoice Number : ${order.reference}</p>
              <p class="text-muted mb-0"><span class="fw-bold me-4">SubTotal: </span> ${order.subTotal.toFixed(2)} EGP</p>
            </div>

            <div class="d-flex justify-content-between">
              <p class="text-muted mb-0">Invoice Date : ${moment(order.date).format("MMMM Do YYYY")}</p>
              <p class="text-muted mb-0"><span class="fw-bold me-4">Tax(14%): </span> ${order.tax.toFixed(2)} EGP</p>
            </div>
            
            <div class="d-flex justify-content-between">
              <p class="text-muted mb-0">Order Status : <span class="badge ${order.status}">${order.status}</span></p>
            </div>

          </div>
        <div class="card-footer border-0 px-4 py-5"
                   style="background-color:#6351ce; border-bottom-left-radius: 10px; border-bottom-right-radius: 10px;">
                <h5 class="d-flex align-items-center justify-content-end text-white text-uppercase mb-0">Total
                  paid: <span class="h2 mb-0 ms-2">${order.total.toFixed(2)} EGP</span></h5>
              </div>
    `);
    
    // add order items
    $.each(order.books,function(index,book){
       $(".card-items").append(`
        <div class="card shadow-0 border mb-4">
              <div class="card-body">
                <div class="row">
                  <div class="col-md-2">
                    <img src="https://localhost:44359/img/${book.imagePath}"
                         class="img-fluid" alt="Book" style="height: 100px">
                  </div>
                  <div class="col-md-2 text-center d-flex justify-content-center align-items-center">
                    <p class="text-muted mb-0">${book.title}</p>
                  </div>
                  <div class="col-md-2 text-center d-flex justify-content-center align-items-center">
                    <p class="text-muted mb-0 small">${book.price} EGP</p>
                  </div>
                  <div class="col-md-2 text-center d-flex justify-content-center align-items-center">
                    <p class="text-muted mb-0 small">Qty: ${order.quantities[index]}</p>
                  </div>
                  <div class="col-md-2 text-center d-flex justify-content-center align-items-center">
                    <p class="text-muted mb-0 small">${book.price * order.quantities[index]} EGP</p>
                  </div>
                </div>
              </div>
            </div>
       `) 
    });
    $("#orderModal").modal('show');
}