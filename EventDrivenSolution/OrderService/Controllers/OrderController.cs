namespace OrderService.Controllers;

using Shared.Events;
using Shared.Requests;
using Shared.Responses;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IRequestClient<GetNotificationRequest> _requestClient;

    public OrderController(IPublishEndpoint publishEndpoint, IRequestClient<GetNotificationRequest> requestClient)
    {
        _publishEndpoint = publishEndpoint;
        _requestClient = requestClient;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder()
    {
        await _publishEndpoint.Publish(new OrderCreated { OrderId = Guid.NewGuid() });
        return Ok("Order created");
    }

    [HttpGet("{orderId}/notification")]
    public async Task<IActionResult> GetNotification(Guid orderId)
    {
        var response = await _requestClient.GetResponse<GetNotificationResponse>(new GetNotificationRequest { OrderId = orderId });
        return Ok(response.Message);
    }
}