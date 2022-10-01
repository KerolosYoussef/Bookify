$(document).ready(function(){
    
    let basket_id = getBasketId();
    const basket = getCurrentBasket(basket_id) ?? createBasket(basket_id);
    getCartNumber(basket);
    if(window.location.href === "https://localhost:44359/Cart"){
        getBasketData(basket);
    }
    
    // increase cart item quantity by one
    $(document).on('click','.incrementItem',function(){
       let item = $(this).data('item');
       incrementItemQuantity(item);
    });

    // decrease cart item quantity by one
    $(document).on('click','.decrementItem',function(){
        let item = $(this).data('item');
        decrementItemQuantity(item);

    });

    // remove the item from the cart
    $(document).on('click','.removeItem',function(){
        let item = $(this).data('item');
        removeItemFromBasket(item);
    });
    
    // add item to cart with specific quantity (default = 1)
    $(document).on('click','.add-to-cart',function(){
        let book = $(this).data('book');
        if(isJson(book)){
            JSON.parse(book);
        }
        let quantityInput = parseInt($("#quantity").val());
        let quantity = isNaN(quantityInput) ? 1 : quantityInput;
        addItemToCart(book,basket_id,quantity);
    });
    
    $(document).on('click','#addPromo',function(){
        let promo_code = $(".promo_code");
        $(this).hide();
        promo_code.html(`
            <div class="row">
                <div class="col-lg-9" style="position: relative">
                  <input type="text" id="form3Examplea2" class="form-control" placeholder="Enter your code" />
                   <i id="closePromo" class="fas fa-times" style="position: absolute;left:-5px;top:7px;cursor: pointer"></i>                    
                </div>
                <button class="btn btn-outline-black col-lg-3">Submit</button>
            </div>
            <div class="clearfix"></div>
        `);
        promo_code.show();
    });
    $(document).on('click','#closePromo',function(){
        $(".promo_code").hide();
        $("#addPromo").show();
    })
});


// Function that take book object, basket_id and quantity as parameters and add the item to cart
function addItemToCart(book, basket_id,quantity = 1) {
    const itemToAdd = mapBookToBasketItem(book,basket_id,quantity);
    const basket = getCurrentBasket(basket_id) ?? createBasket(basket_id);
    basket.basketItems = addOrUpdateItem(basket.basketItems,itemToAdd, quantity);
    // update cart count number
    getCartNumber(basket);
    setBasket(basket);
    showAlert("success", 'Book added to cart successfully!');
}

// Function that take basket object as a parameter and save it to database
function setBasket(basket){
    $.ajax({
        type:"POST",
        url: "https://localhost:44359/api/basket",
        data:{basket: basket},
        success:function(response){
            
        },
        error: function(error){
            console.log(error);
        }
    });
}

// Function that take array of basket item object, item that we will add to basket and the quantity
// This function check if item already exists in the basket it will increase it by the quantity number
// Otherwise it will add the time with its quantity
function addOrUpdateItem(basketItems, itemToAdd, quantity) {
    const index = basketItems.findIndex(i => i.bookTitle === itemToAdd.bookTitle);
    if(index === -1){
        itemToAdd.quantity = quantity;
        basketItems.push(itemToAdd);
    } else {
        basketItems[index].quantity+=quantity;
    }
    return basketItems;
}

// Function that take basket id as a parameter and return the current basket of user
export function getCurrentBasket(basket_id){
    let basket = null;
    $.ajax({
        async: false,
        type:"get",
        url: "https://localhost:44359/api/basket",
        data:{id: basket_id},
    }).done(function(response){
        basket = response;
    });
    return basket;
}

// Function that map book object to basket item object
function mapBookToBasketItem(book,basket_id, quantity){
   return {
       basketId: basket_id,
       bookTitle: book.Title,
       price: book.Price,
       quantity: quantity,
       imagePath: book.ImagePath
   };
}

// Function that take basket id as a parameter and create a new basket and save this id in localstorage
function createBasket(basket_id){
    const basket = {
        id: basket_id,
        basketItems: []
    };
    localStorage.setItem('basket_id',basket.id);
    return basket;
}

// Function that check if basket_id exists in localstorage, if it's not then it will generate new basket_id
export function getBasketId(){
    let basket_id = localStorage.getItem("basket_id");
    if(basket_id === null){
        basket_id = uuidv4();
        localStorage.setItem("basket_id",basket_id);
    }
    return basket_id;
}

// Create Unique id 
function uuidv4() {
    return ([1e7]+-1e3+-4e3+-8e3+-1e11).replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}

// Function that return the length of the basket (given as a parameter)
function getCartNumber(basket){
    let basket_length = basket.basketItems !== null ? basket.basketItems.length : 0;
    $(".count").html(basket_length);
    return basket_length;
}

// Function that has basket as a parameter and show the items of the cart in the cart page
function getBasketData(basket) {
    let basket_length = getCartNumber(basket);
    let cart_number = $(".cart-number");
    cart_number.html(basket_length);
    let basket_items = basket.basketItems;
    if(basket_length > 0){
        $(".cart-item").html("");
    }
    $.each(basket_items,function(index,item){
       $(".cart-item").append(`
           <div class="row mb-4 d-flex justify-content-between align-items-center item-${item.id}">
            <div class="col-md-2 col-lg-2 col-xl-2">
              <img
                src="https://localhost:44359/img/${item.imagePath}"
                class="img-fluid rounded-3" alt="Cotton T-shirt">
            </div>
            <div class="col-md-3 col-lg-3 col-xl-3">
              <h6 class="text-black mb-0">${item.bookTitle}</h6>
            </div>
            <div class="col-md-3 col-lg-3 col-xl-2 d-flex">
              <button class="btn btn-link px-2 decrementItem" data-item='${JSON.stringify(item)}'>
                <i class="fas fa-minus"></i>
              </button>

              <p class="mt-3 p-2" id="quantity-${item.id}">${item.quantity}</p>
              <button class="btn btn-link px-2 incrementItem" data-item='${JSON.stringify(item)}'>
                <i class="fas fa-plus"></i>
              </button>
            </div>
            <div class="col-md-3 col-lg-2 col-xl-2 offset-lg-1">
              <h6 class="mb-0">${item.price} EGP</h6>
            </div>
            <div class="col-md-1 col-lg-1 col-xl-1 text-end">
              <a class="text-muted removeItem" data-item='${JSON.stringify(item)}'><i class="fas fa-times"></i></a>
            </div>
          </div>

          <hr class="my-4">
       `); 
    });
    updateBasketTotal(basket);
}

// Function that take the basket as a parameter and calculate total price of the basket items
function updateBasketTotal(basket){
    let price = 0;
    const basketItems = basket.basketItems;
    $.each(basketItems,function(index,item){
        price+=(item.price*item.quantity); 
    });
    let tax = +(price*.14).toFixed(2);
    let total = (price + tax);
    $(".price").text(price);
    $(".tax").text(tax);
    $(".total").text(total)
    return total;
}

function incrementItemQuantity(item){
    let basket_id = getBasketId();
    const basket = getCurrentBasket(basket_id);
    const basketItemIndex = basket.basketItems.findIndex(i => i.bookTitle === item.bookTitle);
    basket.basketItems[basketItemIndex].quantity += 1;
    updateBasketTotal(basket);
    updateItemQuantity(basket.basketItems[basketItemIndex].quantity, item.id);
    setBasket(basket);
    showAlert("success", 'Book quantity increased successfully!')
}

function decrementItemQuantity(item){
    let basket_id = getBasketId();
    const basket = getCurrentBasket(basket_id);
    const basketItemIndex = basket.basketItems.findIndex(i => i.bookTitle === item.bookTitle)
    if(basket.basketItems[basketItemIndex].quantity > 1){
        basket.basketItems[basketItemIndex].quantity -=1;
        updateItemQuantity(basket.basketItems[basketItemIndex].quantity, item.id);
        updateBasketTotal(basket);
        setBasket(basket);
    } else {
        removeItemFromBasket(item);
    }
    showAlert("success", 'Book quantity decreased successfully!')
}

function removeItemFromBasket(item) {
    let basket_id = getBasketId();
    const basket = getCurrentBasket(basket_id);
    if(basket.basketItems.some(x => x.bookTitle === item.bookTitle)){
        basket.basketItems = basket.basketItems.filter(i => i.id !== item.id);
        updateItemQuantity(0, item.id);
        if(basket.basketItems.length > 0){
            setBasket(basket);
            updateBasketTotal(basket);
        } else {
            deleteBasket(basket_id);
        }
    }
    getCartNumber(basket);
    showAlert("success", 'Item removed successfully!')
}

export function deleteBasket(basket_id) {
    $.ajax({
        url: "https://localhost:44359/api/basket",
        data:{id: basket_id},
        success:function(){
            localStorage.removeItem('basket_id');
        }
    }).done(function(data){
        showAlert("success","Basket Emptied Successfully!");
    });
    // updateBasketTotal(basket);
}

function updateItemQuantity(quantity,id){
    if(quantity === 0)
        $(`.item-${id}`).remove();
    else
        $(`#quantity-${id}`).html(quantity);
}

function showAlert(icon,message){
    Swal.fire({
        icon: icon,
        text: message,
    });
}

// function that take string and check if it's json object or not (return bool)
function isJson(str) {
    try {
        JSON.parse(str);
    } catch (e) {
        return false;
    }
    return true;
}
