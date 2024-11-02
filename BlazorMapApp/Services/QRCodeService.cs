namespace BlazorMapApp.Services;

using System;
using System.Security.Cryptography;
using QRCoder;

public class QRCodeService
{
    private readonly string _secretKey = "TuCulito";

    public string GenerarHashMesa(int restaurantId, int mesaId)
    {
        var dataToHash = $"{restaurantId}-{mesaId}-{_secretKey}";
        using var sha256 = SHA256.Create();
        var hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(dataToHash));
        return Convert.ToBase64String(hashBytes).Replace("/", "_").Replace("+", "-").Substring(0, 10);
    }

    public byte[] GenerarCodigoQR(string contenido)
    {
        using var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(contenido, QRCodeGenerator.ECCLevel.Q);
        var qrCode = new PngByteQRCode(qrCodeData);
        return qrCode.GetGraphic(20);
    }
}
