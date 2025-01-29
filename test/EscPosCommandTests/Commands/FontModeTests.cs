using EscPosCommand.Commands;
using EscPosCommand.Enums;
using System.Text;

namespace EscPosCommand.Tests.Commands;

[TestFixture]
public class FontModeTests
{
    private FontMode _fontMode;

    [SetUp]
    public void Setup()
    {
        // Register the code page provider
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        _fontMode = new FontMode();
    }

    [Test]
    public void Bold_String_ReturnsCorrectByteArray()
    {
        // Arrange
        string value = "Test";
        byte[] expected = new byte[] { 27, 69, 1, 84, 101, 115, 116, 27, 69, 0, 10 };

        // Act
        byte[] result = _fontMode.Bold(value);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Bold_StateOn_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = new byte[] { 27, 69, 1 };

        // Act
        byte[] result = _fontMode.Bold(PrinterModeState.On);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Bold_StateOff_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = new byte[] { 27, 69, 0 };

        // Act
        byte[] result = _fontMode.Bold(PrinterModeState.Off);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Underline_String_ReturnsCorrectByteArray()
    {
        // Arrange
        string value = "Test";
        byte[] expected = new byte[] { 27, 45, 1, 84, 101, 115, 116, 27, 45, 0, 10 };

        // Act
        byte[] result = _fontMode.Underline(value);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Underline_StateOn_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = new byte[] { 27, 45, 1 };

        // Act
        byte[] result = _fontMode.Underline(PrinterModeState.On);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Underline_StateOff_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = new byte[] { 27, 45, 0 };

        // Act
        byte[] result = _fontMode.Underline(PrinterModeState.Off);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Expanded_String_ReturnsCorrectByteArray()
    {
        // Arrange
        string value = "Test";
        byte[] expected = new byte[] { 29, 33, 16, 84, 101, 115, 116, 29, 33, 0, 10 };

        // Act
        byte[] result = _fontMode.Expanded(value);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Expanded_StateOn_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = new byte[] { 29, 33, 16 };

        // Act
        byte[] result = _fontMode.Expanded(PrinterModeState.On);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Expanded_StateOff_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = new byte[] { 29, 33, 0 };

        // Act
        byte[] result = _fontMode.Expanded(PrinterModeState.Off);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Condensed_String_ReturnsCorrectByteArray()
    {
        // Arrange
        string value = "Test";
        byte[] expected = new byte[] { 27, 33, 1, 84, 101, 115, 116, 27, 33, 0, 10 };

        // Act
        byte[] result = _fontMode.Condensed(value);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Condensed_StateOn_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = new byte[] { 27, 33, 1 };

        // Act
        byte[] result = _fontMode.Condensed(PrinterModeState.On);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Condensed_StateOff_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = new byte[] { 27, 33, 0 };

        // Act
        byte[] result = _fontMode.Condensed(PrinterModeState.Off);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Font_String_ReturnsCorrectByteArray()
    {
        // Arrange
        string value = "Test";
        byte[] expected = new byte[] { 27, 77, 1, 84, 101, 115, 116, 27, 33, 0, 10 };

        // Act
        byte[] result = _fontMode.Font(value, Fonts.FontB);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Font_StateNormal_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = new byte[] { 27, 33, 0 };

        // Act
        byte[] result = _fontMode.Font(Fonts.Normal);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Font_StateOther_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = new byte[] { 27, 77, 1 };

        // Act
        byte[] result = _fontMode.Font(Fonts.FontB);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
