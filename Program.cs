using QRCoder;
using System;

class Program
{
    static void Main(string[] args)
    {
        string qrText = string.Empty; // The text or URL for the QR code
        string fileName = string.Empty;
        string colorQrCode = string.Empty;
        
        var previousColor = Console.ForegroundColor;
        
        if (args != null && args.Length == 3)
        {
            qrText = args[0];
            fileName = args[1];
            colorQrCode = args[2];
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please provide text, file name and color.");
            Console.WriteLine("Usage: dotnet run <text> <file_name> <color>");
            Console.ForegroundColor = previousColor;
            return;
        }
        
        try
        {
            // Create a QR code generator
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);

            // Generate SVG QR code
            SvgQRCode qrCode = new SvgQRCode(qrCodeData);
            string svgQRCode =
                qrCode.GetGraphic(20, colorQrCode, "#FFFFFF00"); // Set background to transparent with "#FFFFFF00"

            // Output the SVG
            Directory.CreateDirectory("qrCodes");
            File.WriteAllText(string.Format("qrCodes/{0}.svg",fileName), svgQRCode);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("QR code generated and saved as {0}.svg",fileName));
            Console.ForegroundColor = previousColor;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}