public class Chapter {
    public string _title;
    private string _content;

    // Kapitlets constructor.
    public Chapter(string title, string content) {
        _title = title;
        _content = content;
    }

    // Langomst skriv teksten ud.
    private void Write(string text) {
        foreach (char c in text) {
            Thread.Sleep(50);
            Console.Write(c);
        }
    }

    // Skriv titlen af kapitlet og derefter kapitlets indhold.
    public void Print() {
        Console.Clear();

        Console.WriteLine("Læser nu: " + _title + ".");

        Write(_content);

        Console.WriteLine("\nTryk ENTER for at vende tilbage.");

        // Vent med at fortsætte.
        Console.ReadKey();
    }
}