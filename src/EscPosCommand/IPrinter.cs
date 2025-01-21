using EscPosCommand.Enums;

namespace EscPosCommand;

public interface IPrinter
{
    void PrintDocument();
    void AppendLine(string value);
    void Append(string value);
    void NewLine();
    void NewLines(int lines);
    void Clear();
    void Separator(int charLength, char separatorChar = '-');
    void AutoTest();
    void Font(string value, Fonts state);
    void BoldMode(string value);
    void BoldMode(PrinterModeState state);
    void UnderlineMode(string value);
    void UnderlineMode(PrinterModeState state);
    void ExpandedMode(string value);
    void ExpandedMode(PrinterModeState state);
    void CondensedMode(string value);
    void CondensedMode(PrinterModeState state);
    void NormalWidth();
    void DoubleWidth2();
    void DoubleWidth3();
    void NormalLineHeight();
    void SetLineHeight(byte height);
    void AlignLeft();
    void AlignRight();
    void AlignCenter();
    void FullPaperCut();
    void PartialPaperCut();
    void OpenDrawer();
    void Image(Bitmap image);
    void Image(Bitmap image, bool isScale);
    void QrCode(string qrData);
    void QrCode(string qrData, QrCodeSize qrCodeSize);
    void Code128(string code, Positions positions);
    void Code39(string code, Positions positions);
    void Ean13(string code, Positions positions);
    void InitializePrint();
}
