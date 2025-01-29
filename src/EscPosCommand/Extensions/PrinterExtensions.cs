
using System.Text;

namespace EscPosCommand.Extensions;

internal static class PrinterExtensions
{
    public static byte ToByte(this char c)
    {
        return (byte)c;
    }

    public static byte ToByte(this Enum c)
    {
        return (byte)Convert.ToInt16(c);
    }

    public static byte[] AddBytes(this byte[] bytes, byte[] addBytes)
    {
        if (addBytes == null || addBytes.Length == 0)
            return bytes;

        var result = new byte[bytes.Length + addBytes.Length];
        Buffer.BlockCopy(bytes, 0, result, 0, bytes.Length);
        Buffer.BlockCopy(addBytes, 0, result, bytes.Length, addBytes.Length);
        return result;
    }

    public static byte[] AddBytes(this byte[] bytes, string value)
    {
        if (string.IsNullOrEmpty(value))
            return bytes;

        return bytes.AddBytes(Encoding.GetEncoding(850).GetBytes(value));
    }

    public static byte[] ToBytes(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return [];
        }

        return [.. Encoding.GetEncoding(850).GetBytes(value)];
    }

    public static byte[] AddLF(this byte[] bytes)
    {
        return bytes.AddBytes("\n");
    }

    public static byte[] AddCrLF(this byte[] bytes)
    {
        return bytes.AddBytes("\r\n");
    }

    public static bool IsNullOrEmpty(this string value)
    {
        return string.IsNullOrEmpty(value);
    }
}

