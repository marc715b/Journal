public class Chapter {
    public string _title;
    private string _path;

    // Kapitlets constructor.
    public Chapter(string path) {
        _path = path;
        _title = Path.GetFileNameWithoutExtension(_path);
    }

    // Læs filen fra disken.
    private string Read(ref Encryption encryption) 
        => encryption.Decrypt(File.ReadAllText(_path));

    // Skriv til filen på disken.
    public void Write(ref Encryption encryption, string text)
        => File.WriteAllText(_path, encryption.Encrypt(text));

    // Skriv titlen af kapitlet og derefter kapitlets indhold.
    public void Print(ref Encryption encryption) {
        Console.Clear();
        Utils.WriteColor($"Læser nu: {_title}.", ConsoleColor.Green);

        string content = Read(ref encryption);
        Utils.Write(content);

        // Vent med at fortsætte.
        Utils.WriteColor("\nTryk ENTER for at vende tilbage.", ConsoleColor.Green);
        Console.ReadKey();
    }
}