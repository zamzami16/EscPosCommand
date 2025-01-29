using EscPosCommand.Commands;
using EscPosCommand.Enums;
using System.Text;

#nullable disable

namespace EscPosCommand.Tests.Commands;

[TestFixture]
public class QrCodeTests
{
    private QrCode _qrCode;

    [SetUp]
    public void Setup()
    {
        _qrCode = new QrCode();
    }

    [Test]
    public void Print_WithDefaultSize_ReturnsCorrectByteArray()
    {
        // Arrange
        string qrData = "Test QR Code";
        var length = qrData.Length + 3;
        var b = (byte)(length % 256);
        var b2 = (byte)(length / 256);

        var expected = new List<byte>();
        expected.AddRange(new byte[] { 29, 40, 107, 4, 0, 49, 65, 50, 0 }); // Model QR
        expected.AddRange(new byte[] { 29, 40, 107, 3, 0, 49, 67, 3 }); // Size
        expected.AddRange(new byte[] { 29, 40, 107, 3, 0, 49, 69, 48 }); // Error QR
        expected.AddRange(new byte[] { 29, 40, 107, b, b2, 49, 80, 48 }); // Store QR
        expected.AddRange(Encoding.UTF8.GetBytes(qrData)); // QR Data
        expected.AddRange(new byte[] { 29, 40, 107, 3, 0, 49, 81, 48 }); // Print QR

        // Act
        byte[] result = _qrCode.Print(qrData);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToArray()));
    }

    [Test]
    public void Print_WithSpecificSize_ReturnsCorrectByteArray()
    {
        // Arrange
        string qrData = "Test QR Code";
        QrCodeSize qrCodeSize = QrCodeSize.Size2;
        var length = qrData.Length + 3;
        var b = (byte)(length % 256);
        var b2 = (byte)(length / 256);

        var expected = new List<byte>();
        expected.AddRange(new byte[] { 29, 40, 107, 4, 0, 49, 65, 50, 0 }); // Model QR
        expected.AddRange(new byte[] { 29, 40, 107, 3, 0, 49, 67, 5 }); // Size
        expected.AddRange(new byte[] { 29, 40, 107, 3, 0, 49, 69, 48 }); // Error QR
        expected.AddRange(new byte[] { 29, 40, 107, b, b2, 49, 80, 48 }); // Store QR
        expected.AddRange(Encoding.UTF8.GetBytes(qrData)); // QR Data
        expected.AddRange(new byte[] { 29, 40, 107, 3, 0, 49, 81, 48 }); // Print QR

        // Act
        byte[] result = _qrCode.Print(qrData, qrCodeSize);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToArray()));
    }
}
