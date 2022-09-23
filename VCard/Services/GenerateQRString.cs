using System.Diagnostics.Metrics;
using System;
using VCard.Models;
using static System.Net.WebRequestMethods;
using System.Text;

namespace QRCode.Services
{
    public class GenerateQRString : IGenerateQRString
    {
        public GenerateQRString()
        {
        }

        public string GenerateString(Vcard vcard)
        {
            string s = String.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("BEGIN:VCARD\nVERSION:4.0\n");
            stringBuilder.Append($"FN:{vcard.Firstname} {vcard.Surname}\n");
            stringBuilder.Append($"ADR;TYPE=home:{vcard.City};{vcard.Country};\n");
            stringBuilder.Append($"TEL:{vcard.Phone}\n");
            stringBuilder.Append($"EMAIL:{vcard.Email}\n");
            stringBuilder.Append($"END:VCARD");
            s = stringBuilder.ToString();
            Console.WriteLine(s);
            return s;
        }
    }
}
