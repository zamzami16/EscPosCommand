using EscPosCommand.Enums;
using EscPosCommand.Extensions;
using EscPosCommand.Interfaces;

namespace EscPosCommand.Commands;

public class FontMode : IFontMode
{
    public byte[] Bold(string value)
    {
        return Bold(PrinterModeState.On)
            .AddBytes(value)
            .AddBytes(Bold(PrinterModeState.Off))
            .AddLF();
    }

    public byte[] Bold(PrinterModeState state)
    {
        return [27, 'E'.ToByte(), (byte)state];
    }

    public byte[] Underline(string value)
    {
        return Underline(PrinterModeState.On)
            .AddBytes(value)
            .AddBytes(Underline(PrinterModeState.Off))
            .AddLF();
    }

    public byte[] Underline(PrinterModeState state)
    {
        return state == PrinterModeState.On
            ? [27, '-'.ToByte(), 1]
            : [27, '-'.ToByte(), 0];
    }

    public byte[] Expanded(string value)
    {
        return Expanded(PrinterModeState.On)
            .AddBytes(value)
            .AddBytes(Expanded(PrinterModeState.Off))
            .AddLF();
    }

    public byte[] Expanded(PrinterModeState state)
    {
        return state == PrinterModeState.On
            ? [29, '!'.ToByte(), 16]
            : [29, '!'.ToByte(), 0];
    }

    public byte[] Condensed(string value)
    {
        return Condensed(PrinterModeState.On)
            .AddBytes(value)
            .AddBytes(Condensed(PrinterModeState.Off))
            .AddLF();
    }

    public byte[] Condensed(PrinterModeState state)
    {
        return state == PrinterModeState.On
            ? [27, '!'.ToByte(), 1]
            : [27, '!'.ToByte(), 0];
    }
    public byte[] Font(string value, Fonts state)
    {
        return Font(state)
       .AddBytes(value)
       .AddBytes(Font(Fonts.Normal))
       .AddLF();
    }

    public byte[] Font(Fonts state)
    {
        if (state is Fonts.Normal) // select font 1
        {
            return Condensed(PrinterModeState.Off);
        }

        return [27, 'M'.ToByte(), (byte)state];
    }
}

