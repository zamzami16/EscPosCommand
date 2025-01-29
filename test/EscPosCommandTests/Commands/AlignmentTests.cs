using EscPosCommand.Commands;

#nullable disable

namespace EscPosCommand.Tests.Commands;

[TestFixture]
public class AlignmentTests
{
    private Alignment _alignment;

    [SetUp]
    public void Setup()
    {
        _alignment = new Alignment();
    }

    [Test]
    public void Left_ShouldReturnCorrectByteArray()
    {
        // Arrange
        var expected = new byte[] { 27, (byte)'a', 0 };

        // Act
        var result = _alignment.Left();

        // Assert
        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void Right_ShouldReturnCorrectByteArray()
    {
        // Arrange
        var expected = new byte[] { 27, (byte)'a', 2 };

        // Act
        var result = _alignment.Right();

        // Assert
        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void Center_ShouldReturnCorrectByteArray()
    {
        // Arrange
        var expected = new byte[] { 27, (byte)'a', 1 };

        // Act
        var result = _alignment.Center();

        // Assert
        Assert.That(expected, Is.EqualTo(result));
    }
}
