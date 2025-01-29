using System.Drawing;
using Image = EscPosCommand.Commands.Image;

#nullable disable

namespace EscPosCommand.Tests.Commands;

[TestFixture]
public class ImageTests
{
    private Image _image;

    [SetUp]
    public void Setup()
    {
        _image = new Image();
    }

    [Test]
    public void GetBitmapData_ReturnsCorrectBitmapData()
    {
        // Arrange
        var bmp = new Bitmap(10, 10);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.Clear(Color.White);
            g.FillRectangle(Brushes.Black, 0, 0, 5, 5);
        }

        // Act
        var result = Image.GetBitmapData(bmp);

        // Assert
        Assert.That(result.Width, Is.EqualTo(10));
        Assert.That(result.Height, Is.EqualTo(10));
        Assert.That(result.Dots.Length, Is.EqualTo(100));
    }

    [Test]
    public void GetBitmapData_WithScaling_ReturnsCorrectBitmapData()
    {
        // Arrange
        var bmp = new Bitmap(10, 10);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.Clear(Color.White);
            g.FillRectangle(Brushes.Black, 0, 0, 5, 5);
        }

        // Act
        var result = Image.GetBitmapData(bmp, true);

        // Assert
        Assert.That(result.Width, Is.EqualTo(576));
        Assert.That(result.Height, Is.EqualTo(576));
        Assert.That(result.Dots.Length, Is.EqualTo(576 * 576));
    }

    [Test]
    public void Print_ReturnsCorrectByteArray()
    {
        // Arrange
        var bmp = new Bitmap(10, 10);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.Clear(Color.White);
            g.FillRectangle(Brushes.Black, 0, 0, 5, 5);
        }

        // Act
        byte[] result = _image.Print(bmp);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Length, Is.GreaterThan(0));
    }

    [Test]
    public void Print_WithScaling_ReturnsCorrectByteArray()
    {
        // Arrange
        var bmp = new Bitmap(10, 10);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.Clear(Color.White);
            g.FillRectangle(Brushes.Black, 0, 0, 5, 5);
        }

        // Act
        byte[] result = _image.Print(bmp, true);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Length, Is.GreaterThan(0));
    }
}
