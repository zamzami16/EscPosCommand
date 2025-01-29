using EscPosCommand.Commands;

#nullable disable

namespace EscPosCommand.Tests.Commands;

[TestFixture]
public class InitializePrintTests
{
    private InitializePrint _initializePrint;

    [SetUp]
    public void Setup()
    {
        _initializePrint = new InitializePrint();
    }

    [Test]
    public void Initialize_ReturnsCorrectByteArray()
    {
        // Arrange
        byte[] expected = [27, 64];

        // Act
        byte[] result = _initializePrint.Initialize();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
