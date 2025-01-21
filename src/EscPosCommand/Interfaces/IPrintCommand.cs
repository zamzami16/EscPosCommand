namespace EscPosCommand.Interfaces;

internal interface IPrintCommand
{
    IFontMode FontMode { get; set; }
    IFontWidth FontWidth { get; set; }
    IAlignment Alignment { get; set; }
    IPaperCut PaperCut { get; set; }
    IDrawer Drawer { get; set; }
    IQrCode QrCode { get; set; }
    IBarCode BarCode { get; set; }
    IImage Image { get; set; }
    ILineHeight LineHeight { get; set; }
    IInitializePrint InitializePrint { get; set; }
    byte[] Separator(int charLength, char speratorChar = '-');
    byte[] AutoTest();
}

