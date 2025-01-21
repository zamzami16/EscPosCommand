using EscPosCommand.Extensions;
using EscPosCommand.Interfaces;

namespace EscPosCommand.Commands;

public class InitializePrint : IInitializePrint
{
    public byte[] Initialize()
    {
        return [27, '@'.ToByte()];
    }
}

