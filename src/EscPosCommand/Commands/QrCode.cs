using EscPosCommand.Enums;
using EscPosCommand.Extensions;
using EscPosCommand.Interfaces;
using System.Text;

namespace EscPosCommand.Commands;

public class QrCode : IQrCode
{
    private static byte[] Size(QrCodeSize size)
    {
        return new byte[] { 29, 40, 107, 3, 0, 49, 67 }
            .AddBytes([(size + 3).ToByte()]);
    }

    private IEnumerable<byte> ModelQr()
    {
        return [29, 40, 107, 4, 0, 49, 65, 50, 0];
    }

    private IEnumerable<byte> ErrorQr()
    {
        return [29, 40, 107, 3, 0, 49, 69, 48];
    }

    private static IEnumerable<byte> StoreQr(string qrData)
    {
        var length = qrData.Length + 3;
        var b = (byte)(length % 256);
        var b2 = (byte)(length / 256);

        return new byte[] { 29, 40, 107 }
            .AddBytes([b])
            .AddBytes([b2])
            .AddBytes([49, 80, 48]);
    }

    private IEnumerable<byte> PrintQr()
    {
        return [29, 40, 107, 3, 0, 49, 81, 48];
    }

    public byte[] Print(string qrData)
    {
        return Print(qrData, QrCodeSize.Size0);
    }

    public byte[] Print(string qrData, QrCodeSize qrCodeSize)
    {
        var list = new List<byte>();
        list.AddRange(ModelQr());
        list.AddRange(Size(qrCodeSize));
        list.AddRange(ErrorQr());
        list.AddRange(StoreQr(qrData));
        list.AddRange(Encoding.UTF8.GetBytes(qrData));
        list.AddRange(PrintQr());
        return [.. list];
    }
}

