using System;
using System.Text;
using MelonLoader.Logging;

namespace MelonLoader.Pastel;

public static class GradientExtensions
{
    // -------------------------
    // ColorARGB overloads
    // -------------------------

    public static string Gradient(this string text, ColorARGB start, ColorARGB end)
        => GradientInternal(text, start, end);

    public static string Gradient(this string text, ColorARGB first, ColorARGB second, ColorARGB third)
        => GradientInternal(text, first, second, third);

    public static string Gradient(this string text, ColorARGB first, ColorARGB second, ColorARGB third, ColorARGB fourth)
        => GradientInternal(text, first, second, third, fourth);

    // -------------------------
    // System.Drawing.Color overloads
    // -------------------------

    public static string Gradient(this string text, System.Drawing.Color start, System.Drawing.Color end)
        => text.Gradient(ToColorARGB(start), ToColorARGB(end));

    public static string Gradient(this string text, System.Drawing.Color first, System.Drawing.Color second, System.Drawing.Color third)
        => text.Gradient(ToColorARGB(first), ToColorARGB(second), ToColorARGB(third));

    public static string Gradient(this string text, System.Drawing.Color first, System.Drawing.Color second, System.Drawing.Color third, System.Drawing.Color fourth)
        => text.Gradient(ToColorARGB(first), ToColorARGB(second), ToColorARGB(third), ToColorARGB(fourth));

    // -------------------------
    // Hex string overloads
    // -------------------------

    public static string Gradient(this string text, string startHex, string endHex)
        => text.Gradient(ToColorARGB(startHex), ToColorARGB(endHex));

    public static string Gradient(this string text, string firstHex, string secondHex, string thirdHex)
        => text.Gradient(ToColorARGB(firstHex), ToColorARGB(secondHex), ToColorARGB(thirdHex));

    public static string Gradient(this string text, string firstHex, string secondHex, string thirdHex, string fourthHex)
        => text.Gradient(ToColorARGB(firstHex), ToColorARGB(secondHex), ToColorARGB(thirdHex), ToColorARGB(fourthHex));

    // -------------------------
    // Core implementation
    // -------------------------

    private static string GradientInternal(string text, params ColorARGB[] colors)
    {
        if (string.IsNullOrEmpty(text) || colors.Length == 0)
            return text;

        if (colors.Length == 1)
            return text.Pastel(colors[0]);

        StringBuilder builder = new(text.Length * 24);

        int lastChar = text.Length - 1;

        for (int i = 0; i < text.Length; i++)
        {
            float t = lastChar == 0 ? 0f : (float)i / lastChar;

            float scaled = t * (colors.Length - 1);

            int index = (int)Math.Floor(scaled);
            if (index >= colors.Length - 1)
                index = colors.Length - 2;

            float localT = scaled - index;

            ColorARGB color = Lerp(colors[index], colors[index + 1], localT);

            builder.Append(text[i].ToString().Pastel(color));
        }

        return builder.ToString();
    }

    private static ColorARGB Lerp(ColorARGB a, ColorARGB b, float t)
    {
        return ColorARGB.FromArgb(
            (byte)(a.A + (b.A - a.A) * t),
            (byte)(a.R + (b.R - a.R) * t),
            (byte)(a.G + (b.G - a.G) * t),
            (byte)(a.B + (b.B - a.B) * t));
    }

    // -------------------------
    // Converters
    // -------------------------

    private static ColorARGB ToColorARGB(System.Drawing.Color color)
    {
        return ColorARGB.FromArgb(color.A, color.R, color.G, color.B);
    }

    private static ColorARGB ToColorARGB(string hex)
    {
        if (string.IsNullOrWhiteSpace(hex))
            throw new ArgumentException("Hex color cannot be null or empty.", nameof(hex));

        hex = hex.TrimStart('#');

        // #RRGGBB
        if (hex.Length == 6)
        {
            return ColorARGB.FromArgb(
                Convert.ToByte(hex.Substring(0, 2), 16),
                Convert.ToByte(hex.Substring(2, 2), 16),
                Convert.ToByte(hex.Substring(4, 2), 16));
        }

        // #AARRGGBB
        if (hex.Length == 8)
        {
            return ColorARGB.FromArgb(
                Convert.ToByte(hex.Substring(0, 2), 16),
                Convert.ToByte(hex.Substring(2, 2), 16),
                Convert.ToByte(hex.Substring(4, 2), 16),
                Convert.ToByte(hex.Substring(6, 2), 16));
        }

        throw new ArgumentException(
            $"Invalid hex color '{hex}'. Use #RRGGBB or #AARRGGBB.",
            nameof(hex));
    }
}