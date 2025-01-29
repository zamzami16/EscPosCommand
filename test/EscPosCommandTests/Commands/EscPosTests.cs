using EscPosCommand.Commands;

#nullable disable

namespace EscPosCommand.Tests.Commands;

[TestFixture]
public class EscPosTests
{
    private EscPos _escPos;

    [SetUp]
    public void Setup()
    {
        _escPos = new EscPos();
    }

    [Test]
    public void AutoTest_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = new byte[] { 29, 40, 65, 2, 0, 0, 2 };

        // Act
        byte[] result = _escPos.AutoTest();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Separator_ReturnsCorrectByteArray()
    {
        // Arrange
        int charLength = 10;
        char separatorChar = '-';
        byte[] expected = new byte[] { 45, 45, 45, 45, 45, 45, 45, 45, 45, 45 };

        // Act
        byte[] result = _escPos.Separator(charLength, separatorChar);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Separator_WithDifferentChar_ReturnsCorrectByteArray()
    {
        // Arrange
        int charLength = 5;
        char separatorChar = '*';
        byte[] expected = new byte[] { 42, 42, 42, 42, 42 };

        // Act
        byte[] result = _escPos.Separator(charLength, separatorChar);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Constructor_InitializesAllProperties()
    {
        // Act
        var escPos = new EscPos();

        // Assert
        Assert.That(escPos.FontMode, Is.Not.Null);
        Assert.That(escPos.FontWidth, Is.Not.Null);
        Assert.That(escPos.Alignment, Is.Not.Null);
        Assert.That(escPos.PaperCut, Is.Not.Null);
        Assert.That(escPos.Drawer, Is.Not.Null);
        Assert.That(escPos.QrCode, Is.Not.Null);
        Assert.That(escPos.BarCode, Is.Not.Null);
        Assert.That(escPos.Image, Is.Not.Null);
        Assert.That(escPos.LineHeight, Is.Not.Null);
        Assert.That(escPos.InitializePrint, Is.Not.Null);
    }
}
