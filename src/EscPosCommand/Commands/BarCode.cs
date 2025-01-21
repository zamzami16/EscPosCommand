using EscPosCommand.Enums;
using EscPosCommand.Extensions;
using EscPosCommand.Interfaces;

namespace EscPosCommand.Commands;

public class BarCode : IBarCode
{
    public byte[] Code128(string code, Positions printString = Positions.NotPrint)
    {
        return new byte[] { 29, 119, 2 } // Width
            .AddBytes([29, 104, 50]) // Height
            .AddBytes([29, 102, 1]) // font hri character
            .AddBytes([29, 72, printString.ToByte()]) // If print code informed
            .AddBytes([29, 107, 73]) // printCode
            .AddBytes([(byte)(code.Length + 2)])
            .AddBytes(['{'.ToByte(), 'C'.ToByte()])
            .AddBytes(code)
            .AddLF();
    }

    public byte[] Code39(string code, Positions printString = Positions.NotPrint)
    {
        return new byte[] { 29, 119, 2 } // Width
            .AddBytes([29, 104, 50]) // Height
            .AddBytes([29, 102, 0]) // font hri character
            .AddBytes([29, 72, printString.ToByte()]) // If print code informed
            .AddBytes([29, 107, 4])
            .AddBytes(code)
            .AddBytes([0])
            .AddLF();
    }

    public byte[] Ean13(string code, Positions printString = Positions.NotPrint)
    {
        if (code.Trim().Length != 13)
            return [];

        return new byte[] { 29, 119, 2 } // Width
            .AddBytes([29, 104, 50]) // Height
            .AddBytes([29, 72, printString.ToByte()]) // If print code informed
            .AddBytes([29, 107, 67, 12])
            .AddBytes(code.Substring(0, 12))
            .AddLF();
    }
}

