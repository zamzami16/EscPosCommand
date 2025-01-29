using EscPosCommand.Commands;

#nullable disable

namespace EscPosCommand.Tests.Commands;

[TestFixture]
public class LineHeightTests
{
    private LineHeight _lineHeight;

    [SetUp]
    public void Setup()
    {
        _lineHeight = new LineHeight();
    }

    [Test]
    public void Normal_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = new byte[] { 27, 51, 30 };

        // Act
        byte[] result = _lineHeight.Normal();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void SetLineHeight_ReturnsCorrectByteArray()
    {
        // Arrange
        byte height = 40;
        byte[] expected = new byte[] { 27, 51, height };

        // Act
        byte[] result = _lineHeight.SetLineHeight(height);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
