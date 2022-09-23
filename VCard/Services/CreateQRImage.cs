using Newtonsoft.Json;
using QRCode.Services;
using System.Text;
using VCard.Models;

namespace VCard.Services
{
    public class CreateQRImage : ICreateQRImage
    {
        private IHttpClientFactory _clientFactory { get; set; }
        private readonly IGenerateQRString _generateQRString;
        public CreateQRImage(IHttpClientFactory clientFactory, IGenerateQRString generateQRString)
        {
            _clientFactory = clientFactory;
            _generateQRString = generateQRString;
        }

        public async Task<string> generateImage(Vcard card)
        {
            var body = new
            {
                frame_name = "no-frame",
                qr_code_text = _generateQRString.GenerateString(card),
                image_format = "SVG",
                qr_code_logo = "scan-me-square"
            };

            HttpClient httpClient = _clientFactory.CreateClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://api.qr-code-generator.com/v1/create?access-token=MrdBpyznJaBA3c5C98YZdr5FQu7Nnl8I17KVAvcdNMraBiKtQqbLWI6_daew1QbE");
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

            return await responseMessage.Content.ReadAsStringAsync();


        }

    }
}
