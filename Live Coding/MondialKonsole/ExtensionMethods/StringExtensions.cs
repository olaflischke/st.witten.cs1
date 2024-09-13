namespace MondialKonsole.ExtensionMethods;

public static class StringExtensions
{
    public static bool IsNumeric(this string text)
    {
        //double zahl;

        if (Double.TryParse(text, out _))
            return true;

        return false;
    }

    // Nur zu Demo-Zwecken
    public static void AddIfNew<T>(this List<T> list, T element)
    {
        if (!list.Contains(element))
        {
            list.Add(element);
        }
    }
}