using EscPosCommand.Extensions;
using EscPosCommand.Interfaces;

namespace EscPosCommand.Commands;

internal class EscPos : IPrintCommand
{
    public IFontMode FontMode { get; set; }

    public IFontWidth FontWidth { get; set; }

    public IAlignment Alignment { get; set; }

    public IPaperCut PaperCut { get; set; }

    public IDrawer Drawer { get; set; }

    public IQrCode QrCode { get; set; }

    public IBarCode BarCode { get; set; }

    public IInitializePrint InitializePrint { get; set; }

    public IImage Image { get; set; }

    public ILineHeight LineHeight { get; set; }

    public EscPos()
    {
        FontMode = new FontMode();
        FontWidth = new FontWidth();
        Alignment = new Alignment();
        PaperCut = new PaperCut();
        Drawer = new Drawer();
        QrCode = new QrCode();
        BarCode = new BarCode();
        Image = new Image();
        LineHeight = new LineHeight();
        InitializePrint = new InitializePrint();
    }

    public byte[] AutoTest()
    {
        return [29, 40, 65, 2, 0, 0, 2];
    }

    public byte[] Separator(int charLength, char speratorChar = '-')
    {
        return new string(speratorChar, charLength).ToBytes();
    }
}

