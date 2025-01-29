using EscPosCommand.Commands;

#nullable disable

namespace EscPosCommand.Tests.Commands;

[TestFixture]
public class FontWidthTests
{
    private FontWidth _fontWidth;

    [SetUp]
    public void Setup()
    {
        _fontWidth = new FontWidth();
    }

    [Test]
    public void Normal_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = new byte[] { 27, 33, 0 };

        // Act
        byte[] result = _fontWidth.Normal();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void DoubleWidth2_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = new byte[] { 29, 33, 16 };

        // Act
        byte[] result = _fontWidth.DoubleWidth2();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void DoubleWidth3_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = new byte[] { 29, 33, 32 };

        // Act
        byte[] result = _fontWidth.DoubleWidth3();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
