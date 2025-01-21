using EscPosCommand.Extensions;
using EscPosCommand.Interfaces;

namespace EscPosCommand.Commands;

public class FontWidth : IFontWidth
{
    public byte[] Normal()
    {
        return [27, '!'.ToByte(), 0];
    }

    public byte[] DoubleWidth2()
    {
        return [29, '!'.ToByte(), 16];
    }

    public byte[] DoubleWidth3()
    {
        return [29, '!'.ToByte(), 32];
    }
}

