using EscPosCommand.Commands;

namespace EscPosCommand.Tests.Commands;

[TestFixture]
public class DrawerTests
{
    [Test]
    public void Open_ReturnsCorrectByteArray()
    {
        // Arrange
        var drawer = new Drawer();
        byte[] expected = new byte[] { 27, 112, 0, 60, 120 };

        // Act
        byte[] result = drawer.Open();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
