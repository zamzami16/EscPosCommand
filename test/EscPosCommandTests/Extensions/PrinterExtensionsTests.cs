using EscPosCommand.Enums;
using EscPosCommand.Extensions;
using System.Text;

#nullable disable

namespace EscPosCommand.Tests.Extensions
{
    [TestFixture]
    public class PrinterExtensionsTests
    {
        [SetUp]
        public void Setup()
        {
            // Register the code page provider
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        [Test]
        public void ToByte_Char_ReturnsCorrectByte()
        {
            char input = 'A';
            byte expected = 65;

            byte result = input.ToByte();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToByte_Enum_ReturnsCorrectByte()
        {
            Positions input = Positions.BelowBarcode;
            byte expected = 2;

            byte result = input.ToByte();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AddBytes_ByteArray_AddsBytesCorrectly()
        {
            byte[] initial = [1, 2, 3];
            byte[] toAdd = [4, 5, 6];
            byte[] expected = [1, 2, 3, 4, 5, 6];

            byte[] result = initial.AddBytes(toAdd);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AddBytes_ByteArray_NullOrEmpty_ReturnsOriginal()
        {
            byte[] initial = [1, 2, 3];
            byte[] toAdd = null;
            byte[] expected = [1, 2, 3];

            byte[] result = initial.AddBytes(toAdd);

            Assert.That(result, Is.EqualTo(expected));

            toAdd = ""u8.ToArray();
            result = initial.AddBytes(toAdd);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AddBytes_String_AddsBytesCorrectly()
        {
            byte[] initial = [1, 2, 3];
            string toAdd = "ABC";
            byte[] expected = [1, 2, 3, 65, 66, 67];

            byte[] result = initial.AddBytes(toAdd);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AddBytes_String_NullOrEmpty_ReturnsOriginal()
        {
            byte[] initial = [1, 2, 3];
            string toAdd = null;
            byte[] expected = [1, 2, 3];

            byte[] result = initial.AddBytes(toAdd);

            Assert.That(result, Is.EqualTo(expected));

            toAdd = "";
            result = initial.AddBytes(toAdd);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToBytes_String_ReturnsCorrectByteArray()
        {
            string input = "ABC";
            byte[] expected = "ABC"u8.ToArray();

            byte[] result = input.ToBytes();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToBytes_String_NullOrEmpty_ReturnsEmptyArray()
        {
            string input = null;
            byte[] expected = ""u8.ToArray();

            byte[] result = input.ToBytes();

            Assert.That(result, Is.EqualTo(expected));

            input = "";
            result = input.ToBytes();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AddLF_AddsLineFeedCorrectly()
        {
            byte[] initial = [1, 2, 3];
            byte[] expected = [1, 2, 3, 10];

            byte[] result = initial.AddLF();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AddCrLF_AddsCarriageReturnLineFeedCorrectly()
        {
            byte[] initial = [1, 2, 3];
            byte[] expected = [1, 2, 3, 13, 10];

            byte[] result = initial.AddCrLF();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void IsNullOrEmpty_String_ReturnsCorrectResult()
        {
            string input = "";
            bool result = input.IsNullOrEmpty();

            Assert.That(result, Is.True);

            input = "NotEmpty";
            result = input.IsNullOrEmpty();

            Assert.That(result, Is.False);
        }
    }
}
