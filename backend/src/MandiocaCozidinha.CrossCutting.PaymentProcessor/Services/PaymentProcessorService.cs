using MandiocaCozidinha.CrossCutting.PaymentProcessor.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MandiocaCozidinha.CrossCutting.PaymentProcessor.Services
{
    public interface IPaymentProcessorService
    {
        Task<PaymentProcessorResponse> SendPaymentAsync(PaymentProcessorRequest request, string clientName = "default");
    }

    public class PaymentProcessorService : IPaymentProcessorService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PaymentProcessorService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<PaymentProcessorResponse> SendPaymentAsync(PaymentProcessorRequest request, string clientName = "default")
        {
            ArgumentNullException.ThrowIfNull(request);
            ArgumentNullException.ThrowIfNull(clientName);

            var httpClient = _httpClientFactory.CreateClient(clientName);
            var response = await httpClient.PostAsync("/payments", new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PaymentProcessorResponse>() ?? throw new InvalidOperationException("Failed to deserialize the payment request.");
        }
    }

    public static class ProcessorPaymentServiceDependencyInjection
    {
        public static void AddProcessorPaymentServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("default", client =>
            {
                client.BaseAddress = new Uri(configuration["Services:PaymentProcessor:Default"] ?? throw new ArgumentNullException("The default URI for the Payment Processor service is not configured."));
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("X-Rinha-Token", configuration["Services:PaymentProcessor:Token"] ?? throw new ArgumentNullException("The token for the Payment Processor service is not configured."));
            });

            services.AddHttpClient("fallback", client =>
            {
                client.BaseAddress = new Uri(configuration["Services:PaymentProcessor:Fallback"] ?? throw new ArgumentNullException("The default URI for the Payment Processor service is not configured."));
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("X-Rinha-Token", configuration["Services:PaymentProcessor:Token"] ?? throw new ArgumentNullException("The token for the Payment Processor service is not configured."));
            });

            services.AddTransient<IPaymentProcessorService, PaymentProcessorService>();
        }
    }
}
