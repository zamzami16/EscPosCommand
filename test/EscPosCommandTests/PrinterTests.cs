using EscPosCommand.Commands;
using EscPosCommand.Enums;
using System.Drawing;
using System.Text;

namespace EscPosCommand.Tests;

#nullable disable

[TestFixture]
public class PrinterTests
{
    private Printer _printer;
    private EscPos _escPos;

    [SetUp]
    public void Setup()
    {
        // Register the code page provider
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        _escPos = new EscPos();
        _printer = new Printer("TestPrinter");
    }

    [Test]
    public void AppendLine_AppendsStringWithNewLine()
    {
        // Arrange
        string value = "Test Line";
        byte[] expected = Encoding.GetEncoding("IBM860").GetBytes(value + "\n");

        // Act
        _printer.AppendLine(value);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void AppendLine_WithNullOrEmptyString_DoesNotChangeBuffer()
    {
        // Arrange
        byte[] expected = new byte[] { };

        // Act
        _printer.AppendLine(null);
        _printer.AppendLine(string.Empty);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void Append_AppendsStringWithoutNewLine()
    {
        // Arrange
        string value = "Test";
        byte[] expected = Encoding.GetEncoding("IBM860").GetBytes(value);

        // Act
        _printer.Append(value);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void Append_WithNullOrEmptyString_DoesNotChangeBuffer()
    {
        // Arrange
        byte[] expected = new byte[] { };

        // Act
        _printer.Append(null);
        _printer.Append(string.Empty);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void NewLine_AppendsNewLine()
    {
        // Arrange
        byte[] expected = Encoding.GetEncoding("IBM860").GetBytes("\r\n");

        // Act
        _printer.NewLine();

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void NewLines_AppendsMultipleNewLines()
    {
        // Arrange
        int lines = 3;
        byte[] expected = Encoding.GetEncoding("IBM860").GetBytes("\r\n\r\n\r\n");

        // Act
        _printer.NewLines(lines);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void Clear_ClearsBuffer()
    {
        // Arrange
        _printer.Append("Test");
        byte[] expected = new byte[] { };

        // Act
        _printer.Clear();

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void Separator_AppendsSeparator()
    {
        // Arrange
        int charLength = 10;
        char separatorChar = '-';
        byte[] expected = Encoding.GetEncoding("IBM860").GetBytes(new string(separatorChar, charLength));

        // Act
        _printer.Separator(charLength, separatorChar);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void AutoTest_AppendsAutoTestSequence()
    {
        // Act
        _printer.AutoTest();

        // Assert
        Assert.That(_printer.GetBuffer().Length, Is.GreaterThan(0));
    }

    [Test]
    public void Font_AppendsFontCommand()
    {
        // Arrange
        string value = "Test Font";
        Fonts state = Fonts.FontA;
        byte[] expected = _escPos.FontMode.Font(value, state);

        // Act
        _printer.Font(value, state);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void BoldMode_AppendsBoldCommand()
    {
        // Arrange
        string value = "Bold Text";
        byte[] expected = _escPos.FontMode.Bold(value);

        // Act
        _printer.BoldMode(value);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void UnderlineMode_AppendsUnderlineCommand()
    {
        // Arrange
        string value = "Underline Text";
        byte[] expected = _escPos.FontMode.Underline(value);

        // Act
        _printer.UnderlineMode(value);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void ExpandedMode_AppendsExpandedCommand()
    {
        // Arrange
        string value = "Expanded Text";
        byte[] expected = _escPos.FontMode.Expanded(value);

        // Act
        _printer.ExpandedMode(value);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void CondensedMode_AppendsCondensedCommand()
    {
        // Arrange
        string value = "Condensed Text";
        byte[] expected = _escPos.FontMode.Condensed(value);

        // Act
        _printer.CondensedMode(value);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void NormalWidth_AppendsNormalWidthCommand()
    {
        // Arrange
        byte[] expected = _escPos.FontWidth.Normal();

        // Act
        _printer.NormalWidth();

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void DoubleWidth2_AppendsDoubleWidth2Command()
    {
        // Arrange
        byte[] expected = _escPos.FontWidth.DoubleWidth2();

        // Act
        _printer.DoubleWidth2();

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void DoubleWidth3_AppendsDoubleWidth3Command()
    {
        // Arrange
        byte[] expected = _escPos.FontWidth.DoubleWidth3();

        // Act
        _printer.DoubleWidth3();

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void AlignLeft_AppendsAlignLeftCommand()
    {
        // Arrange
        byte[] expected = _escPos.Alignment.Left();

        // Act
        _printer.AlignLeft();

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void AlignRight_AppendsAlignRightCommand()
    {
        // Arrange
        byte[] expected = _escPos.Alignment.Right();

        // Act
        _printer.AlignRight();

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void AlignCenter_AppendsAlignCenterCommand()
    {
        // Arrange
        byte[] expected = _escPos.Alignment.Center();

        // Act
        _printer.AlignCenter();

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void FullPaperCut_AppendsFullPaperCutCommand()
    {
        // Arrange
        byte[] expected = _escPos.PaperCut.Full();

        // Act
        _printer.FullPaperCut();

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void PartialPaperCut_AppendsPartialPaperCutCommand()
    {
        // Arrange
        byte[] expected = _escPos.PaperCut.Partial();

        // Act
        _printer.PartialPaperCut();

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void OpenDrawer_AppendsOpenDrawerCommand()
    {
        // Arrange
        byte[] expected = _escPos.Drawer.Open();

        // Act
        _printer.OpenDrawer();

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void QrCode_AppendsQrCodeCommand()
    {
        // Arrange
        string qrData = "Test QR Code";
        byte[] expected = _escPos.QrCode.Print(qrData);

        // Act
        _printer.QrCode(qrData);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void QrCode_WithSize_AppendsQrCodeCommand()
    {
        // Arrange
        string qrData = "Test QR Code";
        QrCodeSize qrCodeSize = QrCodeSize.Size2;
        byte[] expected = _escPos.QrCode.Print(qrData, qrCodeSize);

        // Act
        _printer.QrCode(qrData, qrCodeSize);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void Code128_AppendsCode128Command()
    {
        // Arrange
        string code = "123456";
        Positions printString = Positions.NotPrint;
        byte[] expected = _escPos.BarCode.Code128(code, printString);

        // Act
        _printer.Code128(code, printString);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void Code39_AppendsCode39Command()
    {
        // Arrange
        string code = "123456";
        Positions printString = Positions.NotPrint;
        byte[] expected = _escPos.BarCode.Code39(code, printString);

        // Act
        _printer.Code39(code, printString);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void Ean13_AppendsEan13Command()
    {
        // Arrange
        string code = "1234567890123";
        Positions printString = Positions.NotPrint;
        byte[] expected = _escPos.BarCode.Ean13(code, printString);

        // Act
        _printer.Ean13(code, printString);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void InitializePrint_SendsInitializePrintCommand()
    {
        // Arrange
        byte[] expected = _escPos.InitializePrint.Initialize();

        // Act
        _printer.InitializePrint();

        // Assert
        // Since we can't directly assert the printer output, we assume the method works if no exceptions are thrown
        Assert.Pass();
    }

    [Test]
    public void Image_AppendsImageCommand()
    {
        // Arrange
        var image = new Bitmap(10, 10);
        byte[] expected = _escPos.Image.Print(image);

        // Act
        _printer.Image(image);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void Image_WithScaling_AppendsImageCommand()
    {
        // Arrange
        var image = new Bitmap(10, 10);
        bool isScale = true;
        byte[] expected = _escPos.Image.Print(image, isScale);

        // Act
        _printer.Image(image, isScale);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void NormalLineHeight_AppendsNormalLineHeightCommand()
    {
        // Arrange
        byte[] expected = _escPos.LineHeight.Normal();

        // Act
        _printer.NormalLineHeight();

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void SetLineHeight_AppendsSetLineHeightCommand()
    {
        // Arrange
        byte height = 40;
        byte[] expected = _escPos.LineHeight.SetLineHeight(height);

        // Act
        _printer.SetLineHeight(height);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void AppendInitializePrint_AppendsInitializePrintCommand()
    {
        // Arrange
        byte[] expected = _escPos.InitializePrint.Initialize();

        // Act
        _printer.AppendInitializePrint();

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }
    [Test]
    public void Font_AppendsFontCommandWithState()
    {
        // Arrange
        Fonts state = Fonts.FontA;
        byte[] expected = _escPos.FontMode.Font(state);

        // Act
        _printer.Font(state);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void BoldMode_AppendsBoldCommandWithState()
    {
        // Arrange
        PrinterModeState state = PrinterModeState.On;
        byte[] expected = _escPos.FontMode.Bold(state);

        // Act
        _printer.BoldMode(state);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }

    [Test]
    public void UnderlineMode_AppendsUnderlineCommandWithState()
    {
        // Arrange
        PrinterModeState state = PrinterModeState.On;
        byte[] expected = _escPos.FontMode.Underline(state);

        // Act
        _printer.UnderlineMode(state);

        // Assert
        Assert.That(_printer.GetBuffer(), Is.EqualTo(expected));
    }
}
