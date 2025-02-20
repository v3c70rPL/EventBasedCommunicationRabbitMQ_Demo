namespace NotificationService.Consumers;

using Shared.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

public class OrderCreatedConsumer : IConsumer<OrderCreated>
{
    private readonly ILogger<OrderCreatedConsumer> _logger;

    public OrderCreatedConsumer(ILogger<OrderCreatedConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<OrderCreated> context)
    {
        _logger.LogInformation($"Received OrderCreated event for OrderId: {context.Message.OrderId}");
        return Task.CompletedTask;
    }
}