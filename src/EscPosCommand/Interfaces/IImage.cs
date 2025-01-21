namespace EscPosCommand.Interfaces;

internal interface IImage
{
    byte[] Print(Bitmap image);

    byte[] Print(Bitmap image, bool isScale);
}
