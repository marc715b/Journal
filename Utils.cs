public static class Utils {
    // Langomst skriv teksten ud.
    public static void Write(string text) {
        foreach (char c in text) {
            Thread.Sleep(50);
            Console.Write(c);
        }
    }

    // Skriv teksten en specifisk farve.
    public static void WriteColor(string text, ConsoleColor color) {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}