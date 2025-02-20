namespace NotificationService.Consumers;

using Shared.Requests;
using Shared.Responses;
using MassTransit;
using System.Threading.Tasks;

public class GetNotificationRequestConsumer : IConsumer<GetNotificationRequest>
{
    public Task Consume(ConsumeContext<GetNotificationRequest> context)
    {
        return context.RespondAsync(new GetNotificationResponse
        {
            Message = $"Notification details for OrderId: {context.Message.OrderId}"
        });
    }
}