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

    // Lav en "prompt" før vi spørger om brugerens input.
    public static string Prompt(string text) {
        Console.Write(text);
        return Console.ReadLine();
    }
}