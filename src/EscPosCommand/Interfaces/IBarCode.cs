using EscPosCommand.Enums;

namespace EscPosCommand.Interfaces;

interface IBarCode
{
    byte[] Code128(string code, Positions printString);
    byte[] Code39(string code, Positions printString);
    byte[] Ean13(string code, Positions printString);
}

