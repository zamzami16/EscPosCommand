using EscPosCommand.Extensions;
using EscPosCommand.Interfaces;

namespace EscPosCommand.Commands;

public class LineHeight : ILineHeight
{
    public byte[] Normal()
    {
        return [27, '3'.ToByte(), 30];
    }

    // Line Height may vary from 24 dots (3mm) to 8128 dots (1016mm)
    public byte[] SetLineHeight(byte height)
    {
        return [27, '3'.ToByte(), height];
    }
}
