using QRCoder;
using System.Drawing;

namespace qr.service
{
    public class QrService
    {
        public QRCodeGenerator QrGenerator { get; set; }

        public QrService()
        {
            QrGenerator = new QRCodeGenerator();
        }

        public Bitmap EncodeToBitmap(string valueToEnocde)
        {
            return GetBitmap(valueToEnocde);
        }

        public Bitmap GetBitmap(string codevalue)
        {
            QRCodeData qrCodeData = QrGenerator.CreateQrCode(codevalue, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }
    }
}
