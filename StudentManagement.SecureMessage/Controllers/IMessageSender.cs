using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.WindowsAzure.Storage;

namespace StudentManagement.SecureMessage.Controllers
{
    public interface IMessageSender
    {
        Task Send(string content);
    }

    public class AzureQueueMessageSender : IMessageSender
    {
        public AzureQueueMessageSender(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task Send(string content)
        {
            var connectionString = Configuration.GetValue<string>("AzureQueueConnectionString");
            await SendMessage(content, connectionString);
            
        }

        private static async Task SendMessage(string content, string ConnectionString)
        {
            var storageAccount = CloudStorageAccount.Parse(ConnectionString);
            storageAccount.CreateCloudQueueClient();
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference("youtube");
            var message = new Microsoft.WindowsAzure.Storage.Queue.CloudQueueMessage(content);
            await queue.AddMessageAsync(message);
        }
    }
}