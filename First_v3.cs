// Класс RGBAPixel
public class RGBAPixel : IEquatable<RGBAPixel>
{
    private byte _red, _green, _blue;
    private double _alpha; // По альфу каналу ->0,0...1,0

    public byte Red { get => _red; private set => _red = ClampByte(value); } // Радиус 0 - 255
    public byte Green { get => _green; private set => _green = ClampByte(value); } // Радиус 0 - 255
    public byte Blue { get => _blue; private set => _blue = ClampByte(value); } // Радиус 0 - 255
    public double Alpha { get => _alpha; private set => _alpha = ClampAlpha(value); } // Радиус 0,0 - 1,0

    public RGBAPixel(byte red, byte green, byte blue, double alpha)
    {
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }
    
    private static byte ClampByte(int value) => (byte)Math.Clamp(value, 0, 255);
    private static double ClampAlpha(double value) => Math.Clamp(value, 0, 1);

    // Перегрузки операций
    public static RGBAPixel operator +(RGBAPixel a, RGBAPixel b) =>
        new(ClampByte(a.Red + b.Red), ClampByte(a.Green + b.Green), ClampByte(a.Blue + b.Blue), ClampAlpha(a.Alpha + b.Alpha));
    public static RGBAPixel operator -(RGBAPixel a, RGBAPixel b) =>
        new(ClampByte(a.Red - b.Red), ClampByte(a.Green - b.Green), ClampByte(a.Blue - b.Blue), ClampAlpha(a.Alpha - b.Alpha));
    public static RGBAPixel operator *(RGBAPixel a, double scalar) =>
        new(ClampByte((int)(a.Red * scalar)), ClampByte((int)(a.Green * scalar)), ClampByte((int)(a.Blue * scalar)), ClampAlpha(a.Alpha * scalar));
    public static RGBAPixel operator *(double scalar, RGBAPixel a) => a * scalar;
    public static RGBAPixel operator *(RGBAPixel a, RGBAPixel b) =>
        new(ClampByte(a.Red * b.Red / 255), ClampByte(a.Green * b.Green / 255), ClampByte(a.Blue * b.Blue / 255), a.Alpha * b.Alpha);
    public static RGBAPixel operator /(RGBAPixel a, double scalar) =>
        scalar == 0 ? throw new DivideByZeroException() : a * (1.0 / scalar);

    public static bool operator ==(RGBAPixel a, RGBAPixel b) => a?.Equals(b) ?? b is null;
    public static bool operator !=(RGBAPixel a, RGBAPixel b) => !(a == b);

    public override string ToString() => $"RGBa({Red}, {Green}, {Blue}, {Alpha:F2})";
    public string ToHex() => $"#{Red:X2}{Green:X2}{Blue:X2}{(int)(Alpha * 255):X2}";

    // is
    public bool Equals(RGBAPixel other) => other != null && Red == other.Red && Green == other.Green && Blue == other.Blue && Alpha == other.Alpha; 
    public override bool Equals(object obj) => Equals(obj as RGBAPixel);
    public override int GetHashCode() => HashCode.Combine(Red, Green, Blue, Alpha);
}