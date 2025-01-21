using EscPosCommand.Interfaces;

namespace EscPosCommand.Commands;

public class Drawer : IDrawer
{
    public byte[] Open()
    {
        return [27, 112, 0, 60, 120];
    }
}

