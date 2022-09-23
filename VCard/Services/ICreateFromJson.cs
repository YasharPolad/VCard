namespace VCard.Services
{
    public interface ICreateFromJson
    {
        Task CreateVcardFromJson();
        Task<string> GetJsonAsync();
    }
}