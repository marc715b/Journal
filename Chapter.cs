public class Chapter {
    public string _title;
    private string _path;

    // Kapitlets constructor.
    public Chapter(string path) {
        _path = path;
        _title = Path.GetFileNameWithoutExtension(_path);
    }

    // Langomst skriv teksten ud.
    private void Write(string text) {
        foreach (char c in text) {
            Thread.Sleep(50);
            Console.Write(c);
        }
    }

    // Læs filen fra disken.
    private string Read() 
        => File.ReadAllText(_path);

    // Skriv titlen af kapitlet og derefter kapitlets indhold.
    public void Print() {
        Console.Clear();
        Console.WriteLine("Læser nu: " + _title + ".");

        string content = Read();
        Write(content);

        // Vent med at fortsætte.
        Console.WriteLine("\nTryk ENTER for at vende tilbage.");
        Console.ReadKey();
    }
}