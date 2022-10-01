using System.Collections;
using System.Text;
using System.Text.Json.Nodes;
using AspNetCoreHero.ToastNotification.Abstractions;
using Bookify.Dtos;
using Bookify.Helpers;
using Bookify.Interfaces;
using Bookify.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using static System.Int32;

namespace Bookify.Controllers.Api;

[Authorize]
public class OpayController: BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotyfService _notyf;
    private readonly OrderTransaction _orderTransaction;
    public OpayController(IUnitOfWork unitOfWork, INotyfService notyf)
    {
        _unitOfWork = unitOfWork;
        _notyf = notyf;
        _orderTransaction = new OrderTransaction(_unitOfWork);
    }

    [Route("~/api/opay")]
    [HttpPost]
    public async Task<IActionResult> Purchase([FromBody] Order order)
    {
        // Get OPAY Keys
        var opayPublicKey = Environment.GetEnvironmentVariable("OPAY_PUBLIC_KEY");
        var merchantId = Environment.GetEnvironmentVariable("MERCHANT_ID");
        // Encrypt Order id to send it with the success query 
        var encryptedOrderId = OrderCrypt.Encrypt(order.Id.ToString());
        // Generate the reference number of the order
        var referenceNumber = order.Id + '-' + HelperFunctions.GenerateRandomString();
        var orderToBeUpdated = _unitOfWork.OrderRepository.GetById(order.Id);
        orderToBeUpdated.Reference = referenceNumber;
        var client = new HttpClient();
        var amount = new Dictionary<object, object>
        {
            {"total", Math.Round(order.Total) * 100},
            {"currency", "EGP"}
        };
        var userInfo = new Dictionary<object, object>()
        {
            {"userEmail", order.CustomerEmail},
            {"userId", order.CustomerId},
            {"userMobile", order.CustomerPhone},
            {"username", order.CustomerFirstName}
        };
        var productList = new Dictionary<object,object>()
        {
            {"productId", "productId"},
            {"name", "name"},
            {"description", "description"},
            {"price", Math.Round(order.Total)},
            {"quantity", 1}
        };
        var formData = new Dictionary<object,object>
        {
            {"country", "EG"},
            {"reference", referenceNumber},
            {"amount", amount},
            {"returnUrl","https://localhost:44359/api/opay/success?token="+encryptedOrderId},
            {"callbackUrl", ""},
            {"cancelUrl", "https://localhost:44359/api/opay/cancel?token="+encryptedOrderId},
            {"expireAt", 300},
            {"userInfo", userInfo},
            {"product", productList},
            {"payMethod", "BankCard"},
        };
        
        var uri = "https://sandboxapi.opaycheckout.com/api/v1/international/cashier/create";
        var jsonInString = JsonConvert.SerializeObject(formData);
        client.DefaultRequestHeaders.Add("Authorization", "Bearer "+opayPublicKey);
        client.DefaultRequestHeaders.Add("MerchantId",merchantId);
        var response = await client.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json")); 
        var content = await response.Content.ReadAsStringAsync();
        // save reference number to order
        _unitOfWork.OrderRepository.Update(orderToBeUpdated);
        _unitOfWork.Complete();
        return Ok(content);
    }
    
    [Route("~/api/opay/success")]
    public IActionResult Success(string token)
    {
        var orderId = Parse(OrderCrypt.Decrypt(token));
        var order = _unitOfWork.OrderRepository.GetById(orderId);
        order.Status = "Success";
        _unitOfWork.OrderRepository.Update(order);
        _unitOfWork.Complete();
        _orderTransaction.DecreaseQuantityFromOrderedBooks(order);
        _notyf.Success("Order "+orderId+" created successfully");
        return RedirectToAction("Index","Shop");
    }
    
    [Route("~/api/opay/cancel")]
    public IActionResult Cancel(string token)
    {
        var orderId = Parse(OrderCrypt.Decrypt(token));
        var order = _unitOfWork.OrderRepository.GetById(orderId);
        order.Status = "Cancelled";
        _unitOfWork.Complete();
        _notyf.Error("Payment failed");
        return RedirectToAction("Index","Shop");
    }
}