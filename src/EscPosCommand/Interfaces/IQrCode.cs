using EscPosCommand.Enums;

namespace EscPosCommand.Interfaces;

internal interface IQrCode
{
    byte[] Print(string qrData);

    byte[] Print(string qrData, QrCodeSize qrCodeSize);
}

