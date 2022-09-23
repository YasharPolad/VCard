using Newtonsoft.Json.Linq;
using VCard.DAL;
using VCard.Models;
using VCard.Repositories;
using static System.Net.WebRequestMethods;

namespace VCard.Services
{
    public class CreateFromJson : ICreateFromJson
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _url = "https://randomuser.me/api?results=3";
        private IGenericRepository<Vcard> _vcardRepository;
        private readonly VCardDbContext _dbContext;
        private readonly ICreateQRImage _createQRImage;

        public CreateFromJson(IHttpClientFactory httpClientFactory, VCardDbContext dbContext, ICreateQRImage createQRImage)
        {                                                         //bes men sabah contexti deyishsem nece olacaq?
            //_vcardRepository = vcardRepository;
            _httpClientFactory = httpClientFactory;
            _dbContext = dbContext;
            _createQRImage = createQRImage;
        }

        public async Task<string> GetJsonAsync()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response;
            while (true)
            {
                response = await httpClient.GetAsync(_url);
                if (response.IsSuccessStatusCode) break;
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public async Task CreateVcardFromJson()
        {
            var content = JObject.Parse(await GetJsonAsync());
            //Console.WriteLine(content["results"][0]);

            foreach (var item in content["results"])
            {
                Vcard vcard = new Vcard
                {
                    Firstname = (string)item["name"]["first"],
                    Surname = (string)item["name"]["last"],
                    Email = (string)item["email"],
                    Phone = (string)item["phone"],
                    Country = (string)item["location"]["country"],
                    City = (string)item["location"]["city"]
                };

                vcard.QRImageString = await _createQRImage.generateImage(vcard);

                _vcardRepository = new GenericRepository<Vcard>(_dbContext); //this is problematic
                await _vcardRepository.Add(vcard);
            }
        }
    }
}
