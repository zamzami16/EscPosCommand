using EscPosCommand.Extensions;
using EscPosCommand.Interfaces;


namespace EscPosCommand.Commands;

public class PaperCut : IPaperCut
{
    public byte[] Full()
    {
        return [29, 'V'.ToByte(), 65, 0];
    }

    public byte[] Partial()
    {
        return [29, 'V'.ToByte(), 65, 1];
    }
}

