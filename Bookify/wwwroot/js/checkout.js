import {getBasketId, getCurrentBasket, deleteBasket} from "./cart.js";
const baseUrl = "https://localhost:44359/api";
const basket_id = getBasketId();
let isEmpty = false;

$(document).ready(function(){
    let subTotal;
    let tax;
    let total;
    [subTotal,tax,total] = calculatePrices(basket_id);
    if(isEmpty){
        Swal.fire({
            icon: "warning",
            text: "There is no item in cart"
        }).then(function(){
            window.location.href = "https://localhost:44359/Shop";
        })
    } else {
        $(".black-hover").hide();
    }
    showPricesOnCheckout(subTotal,tax,total);
    $(document).on('click','#checkout',function(){
        CreateOrder();
    });
})


function CreateOrder(){
    const user_id = $("#user_id").val();
    const first_name = $("#firstName").val();
    const last_name = $("#lastName").val();
    const email = $("#email").val();
    const mobile = $("#mobileNumber").val();
    const country = "EG";
    const address = $("#address").val();
    const postal_code = $("#postalCode").val();
    const errorsBox = $("#checkout-errors");
    const basket_id = getBasketId();
    let subTotal;
    let tax;
    let total;
    [subTotal,tax,total] = calculatePrices(basket_id);


    let order = {
        customerId: user_id,
        customerFirstName: first_name,
        customerLastName: last_name,
        customerEmail: email,
        customerPhone: mobile,
        customerCountry: country,
        customerAddress: address,
        customerPostalCode: postal_code,
        subTotal: subTotal,
        tax: tax,
        total: total,
        basketId: basket_id
    };
    // create order
    $.ajax({
        type: "post",
        url:baseUrl + "/order/create",
        data:{orderDto: order},
        dataSrc: "",
        success:function(response){
            purchase(response);
            errorsBox.hide();
        },
        error: function(error){
            const errors = error.responseJSON.errors;
            errorsBox.html(``);
            Object.values(errors).forEach(error => {
                let errorString = error.join();
                errorsBox.append(`<p>${errorString}</p>`);
                errorsBox.show();
                window.scrollTo(0,0);
            })
        }
    })
}

function purchase(order){
    $.ajax({
        type: 'post',
        url: baseUrl+ "/opay",
        data: JSON.stringify(order),
        contentType: 'application/json',
        success:function(response){
            var opayResponse = JSON.parse(response);
            if(opayResponse.message === "SUCCESSFUL"){
                setTimeout(()=>{
                    deleteBasket(basket_id);
                },1000)
                window.location.href = opayResponse.data.cashierUrl;
            }
            console.log(opayResponse);
        }
    });
}

function calculatePrices(basket_id){
    try{
        const basket = getCurrentBasket(basket_id);
        let subTotal = 0;
        basket.basketItems.map(b => {
            subTotal += (b.price * b.quantity);
        });
        const tax = parseFloat(subTotal)*.14;
        const total = parseFloat(subTotal) + tax;
        return [subTotal,tax,total];    
    } catch(e){
        isEmpty = true;
    }
    return [];
}

function showPricesOnCheckout(sub_total,tax,total){
    $("#sub_total").text(sub_total + " EGP");
    $("#tax").text(tax.toFixed(2) + " EGP");
    $("#total").text(total + " EGP");
    $("#pay-button").text(total + " EGP");
}