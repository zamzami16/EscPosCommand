using EscPosCommand.Commands;
using EscPosCommand.Enums;
using System.Text;

# nullable disable

namespace EscPosCommand.Tests.Commands;

[TestFixture]
public class BarCodeTests
{
    private BarCode _barCode;

    [SetUp]
    public void Setup()
    {
        _barCode = new BarCode();
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    [Test]
    public void Code128_ShouldReturnCorrectByteArray()
    {
        var code = "123456";
        var result = _barCode.Code128(code, Positions.BelowBarcode);

        Assert.That(result, Is.EqualTo(new byte[] { 29, 119, 2, 29, 104, 50, 29, 102, 1, 29, 72, 2, 29, 107, 73, 8, 123, 67, 49, 50, 51, 52, 53, 54, 10 }));
    }

    [Test]
    public void Code39_ShouldReturnCorrectByteArray()
    {
        var code = "123456";
        var result = _barCode.Code39(code, Positions.AbovBarcode);

        Assert.That(result, Is.EqualTo(new byte[] { 29, 119, 2, 29, 104, 50, 29, 102, 0, 29, 72, 1, 29, 107, 4, 49, 50, 51, 52, 53, 54, 0, 10 }));
    }

    [Test]
    public void Ean13_ShouldReturnCorrectByteArray()
    {
        var code = "1234567890128";
        var result = _barCode.Ean13(code, Positions.Both);

        Assert.That(result, Is.EqualTo(new byte[] { 29, 119, 2, 29, 104, 50, 29, 72, 3, 29, 107, 67, 12, 49, 50, 51, 52, 53, 54, 55, 56, 57, 48, 49, 50, 10 }));
    }

    [Test]
    public void Ean13_ShouldReturnEmptyArray_WhenCodeLengthIsNot13()
    {
        var code = "123456";
        var result = _barCode.Ean13(code, Positions.Both);

        Assert.That(result, Is.EqualTo(new byte[] { }));
    }
}
