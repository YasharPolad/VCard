using VCard.Models;

namespace QRCode.Services
{
    public interface IGenerateQRString
    {
        string GenerateString(Vcard vcard);
    }
}