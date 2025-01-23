using EscPosCommand.Commands;
using EscPosCommand.Enums;
using EscPosCommand.Extensions;
using EscPosCommand.Helper;
using EscPosCommand.Interfaces;
using System.Runtime.CompilerServices;
using System.Text;

namespace EscPosCommand;

public class Printer(string printerName, string codepage = "IBM860") : IPrinter
{
    private byte[] _buffer = [];
    private readonly string _printerName = printerName;
    private readonly IPrintCommand _command = new EscPos();
    private readonly string _codepage = codepage;

    public void PrintDocument()
    {
        RawPrinterHelper.SendBytesToPrinter(_printerName, _buffer);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void AppendString(string value, bool useLf)
    {
        if (string.IsNullOrEmpty(value))
            return;

        if (useLf)
            value += "\n";

        var bytes = Encoding.GetEncoding(_codepage).GetBytes(value);
        if (_buffer != null && _buffer.Length > 0)
        {
            _buffer = _buffer.AddBytes(bytes);
        }
        else
        {
            _buffer = bytes;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Append(byte[] value)
    {
        _buffer = _buffer.AddBytes(value);
    }

    public void AppendLine(string value)
    {
        AppendString(value, true);
    }

    public void Append(string value)
    {
        AppendString(value, false);
    }

    public void NewLine()
    {
        AppendLine("\r");
    }

    public void NewLines(int lines)
    {
        for (int i = 1, loopTo = lines - 1; i <= loopTo; i++)
            NewLine();
    }

    public void Clear()
    {
        _buffer = [];
    }

    public void Separator(int charLength, char separatorChar = '-')
    {
        Append(_command.Separator(charLength, separatorChar));
    }

    public void AutoTest()
    {
        Clear();

        var lorem = " Lorem ipsum dolor";

        AppendInitializePrint();
        AppendLine("NORMAL - 48 COLUMNS");
        AppendLine("1...5...10...15...20...25...30...35...40...45.48");
        Separator(48);
        AppendLine("Text Normal");
        BoldMode("Bold Text");
        UnderlineMode("Underlined text");
        Separator(48);
        ExpandedMode(PrinterModeState.On);
        AppendLine("Expanded - 23 COLUMNS");
        AppendLine("1...5...10...15...20..23");
        ExpandedMode(PrinterModeState.Off);
        Separator(48);
        CondensedMode(PrinterModeState.On);
        AppendLine("Condensed - 64 COLUMNS");
        AppendLine("1...5...10...15...20...25...30...35...40...45...50...55...60..64");
        CondensedMode(PrinterModeState.Off);
        Separator(48);
        DoubleWidth2();
        AppendLine("Font Width 2");
        DoubleWidth3();
        AppendLine("Font Width 3");
        NormalWidth();
        AppendLine("Normal width");
        Separator(48);
        AlignRight();
        AppendLine("Right aligned text");
        AlignCenter();
        AppendLine("Center-aligned text");
        AlignLeft();
        AppendLine("Left aligned text");
        Separator(48);
        Font("Font A" + lorem, Fonts.FontA);
        Font("Font B" + lorem, Fonts.FontB);
        Font("Font C" + lorem, Fonts.FontC);
        Font("Font D" + lorem, Fonts.FontD);
        Font("Font E" + lorem, Fonts.FontE);
        Font("Font Special A" + lorem, Fonts.SpecialFontA);
        Font("Font Special B" + lorem, Fonts.SpecialFontB);
        Separator(48);
        AppendInitializePrint();
        SetLineHeight(24);
        AppendLine("This is first line with line height of 24 dots");
        SetLineHeight(30);
        AppendLine("This is second line with line height of 30 dots");
        SetLineHeight(40);
        AppendLine("This is third line with line height of 40 dots");
        DoubleWidth2();
        BoldMode("Font Width 2 With Bold");
        NormalWidth();
        NewLines(3);
        AppendLine("End of Test :)");
        Separator(48);
    }

    public void Font(string value, Fonts state)
    {
        Append(_command.FontMode.Font(value, state));
    }

    public void Font(Fonts state)
    {
        Append(_command.FontMode.Font(state));
    }

    public void BoldMode(string value)
    {
        Append(_command.FontMode.Bold(value));
    }

    public void BoldMode(PrinterModeState state)
    {
        Append(_command.FontMode.Bold(state));
    }

    public void UnderlineMode(string value)
    {
        Append(_command.FontMode.Underline(value));
    }

    public void UnderlineMode(PrinterModeState state)
    {
        Append(_command.FontMode.Underline(state));
    }

    public void ExpandedMode(string value)
    {
        Append(_command.FontMode.Expanded(value));
    }

    public void ExpandedMode(PrinterModeState state)
    {
        Append(_command.FontMode.Expanded(state));
    }

    public void CondensedMode(string value)
    {
        Append(_command.FontMode.Condensed(value));
    }

    public void CondensedMode(PrinterModeState state)
    {
        Append(_command.FontMode.Condensed(state));
    }

    public void NormalWidth()
    {
        Append(_command.FontWidth.Normal());
    }

    public void DoubleWidth2()
    {
        Append(_command.FontWidth.DoubleWidth2());
    }

    public void DoubleWidth3()
    {
        Append(_command.FontWidth.DoubleWidth3());
    }

    public void AlignLeft()
    {
        Append(_command.Alignment.Left());
    }

    public void AlignRight()
    {
        Append(_command.Alignment.Right());
    }

    public void AlignCenter()
    {
        Append(_command.Alignment.Center());
    }

    public void FullPaperCut()
    {
        Append(_command.PaperCut.Full());
    }

    public void PartialPaperCut()
    {
        Append(_command.PaperCut.Partial());
    }

    public void OpenDrawer()
    {
        Append(_command.Drawer.Open());
    }

    public void QrCode(string qrData)
    {
        Append(_command.QrCode.Print(qrData));
    }

    public void QrCode(string qrData, QrCodeSize qrCodeSize)
    {
        Append(_command.QrCode.Print(qrData, qrCodeSize));
    }

    public void Code128(string code, Positions printString = Positions.NotPrint)
    {
        Append(_command.BarCode.Code128(code, printString));
    }

    public void Code39(string code, Positions printString = Positions.NotPrint)
    {
        Append(_command.BarCode.Code39(code, printString));
    }

    public void Ean13(string code, Positions printString = Positions.NotPrint)
    {
        Append(_command.BarCode.Ean13(code, printString));
    }

    public void InitializePrint()
    {
        RawPrinterHelper.SendBytesToPrinter(_printerName, _command.InitializePrint.Initialize());
    }

    public void Image(Bitmap image)
    {
        Append(_command.Image.Print(image));
    }

    public void Image(Bitmap image, bool isScale)
    {
        Append(_command.Image.Print(image, isScale));
    }

    public void NormalLineHeight()
    {
        Append(_command.LineHeight.Normal());
    }

    public void SetLineHeight(byte height)
    {
        Append(_command.LineHeight.SetLineHeight(height));
    }

    public void AppendInitializePrint()
    {
        Append(_command.InitializePrint.Initialize());
    }
}
