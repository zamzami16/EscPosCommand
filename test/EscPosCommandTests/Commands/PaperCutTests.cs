using EscPosCommand.Commands;

#nullable disable

namespace EscPosCommand.Tests.Commands;

[TestFixture]
public class PaperCutTests
{
    private PaperCut _paperCut;

    [SetUp]
    public void Setup()
    {
        _paperCut = new PaperCut();
    }

    [Test]
    public void Full_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = new byte[] { 29, 86, 65, 0 };

        // Act
        byte[] result = _paperCut.Full();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Partial_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = new byte[] { 29, 86, 65, 1 };

        // Act
        byte[] result = _paperCut.Partial();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
