using QRCoder;
using System;

class Program
{
    static void Main()
    {
        string qrText = "https://www.instagram.com/docesegredosorvetes/"; // The text or URL for the QR code

        // Create a QR code generator
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);

        // Generate SVG QR code
        SvgQRCode qrCode = new SvgQRCode(qrCodeData);
        string svgQRCode = qrCode.GetGraphic(20, "#D41367", "#FFFFFF00"); // Set background to transparent with "#FFFFFF00"

        // Output the SVG
        System.IO.File.WriteAllText("docesegredo.svg", svgQRCode);

        Console.WriteLine("QR code generated and saved as qrcode.svg");
    }
}