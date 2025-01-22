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

        var list = new List<byte>();
        if (_buffer != null)
            list.AddRange(_buffer);

        var bytes = Encoding.GetEncoding(_codepage).GetBytes(value);
        list.AddRange(bytes);

        _buffer = [.. list];
    }

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
        Append(_command.AutoTest());
    }

    public void Font(string value, Fonts state)
    {
        Append(_command.FontMode.Font(value, state));
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
}
