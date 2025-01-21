using EscPosCommand.Extensions;
using EscPosCommand.Interfaces;

namespace EscPosCommand.Commands;

internal class Alignment : IAlignment
{
    public byte[] Left()
    {
        return [27, 'a'.ToByte(), 0];
    }

    public byte[] Right()
    {
        return [27, 'a'.ToByte(), 2];
    }

    public byte[] Center()
    {
        return [27, 'a'.ToByte(), 1];
    }
}
