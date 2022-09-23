using VCard.Models;

namespace VCard.Services
{
    public interface ICreateQRImage
    {
        Task<string> generateImage(Vcard card);
    }
}