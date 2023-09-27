using System.Text;

public class Book {
    private string _title;
    private List<Chapter> _chapters;
    private Encryption _encryption;

    // Bogens constructor.
    public Book(string title) {
        _title = title;

        _encryption = new Encryption();

        _chapters = new List<Chapter>();
        AddChapters();
    }

    private void PrintHeader() {
        Utils.WriteColor(
            $"Velkommen til {_title}! Naviger kapitlerne vha. piletasterne.\n" +
            "Tryk ENTER ved det kapitel som du vil læse.\n" +
            "Tryk N for at tilføje et nyt kapitel.\n" +
            "Tryk Q for at bryde ud af programmet.",
            ConsoleColor.Green
        );
    }

    private void AddChapter(Chapter chapter) 
        => _chapters.Add(chapter);

    private void AddChapters() {
        // hardcoded lol
        foreach (string file in Directory.GetFiles(@"C:\dev\Journal\chapters", "*.txt")) {
           AddChapter(new Chapter(file));
        }
    }

    public Chapter CreateChapter() {
        Console.Clear();
        Utils.WriteColor(
            "Du tilføjer nu et nyt kapitel. Skriv først navnet af kapitlet,\n" +
            "og derefter indholdet af kapitlet. Skriv :q når du er færdig.\n" +
            "Dette er ikke et tekstredigeringsprogram. Hvis du laver fejl, øv bøv.",
            ConsoleColor.Green
        );

        string title = Utils.Prompt("Title: ");

        // det her er det klammeste jeg nogensinde har skrevet
        StringBuilder content = new StringBuilder();
        
        string line;
        while ((line = Console.ReadLine()) != ":q")
            content.Append(line);

        // hardcoded igen
        Chapter newChapter = new Chapter(@"C:\dev\Journal\chapters\" + title + ".txt");
        newChapter.Write(ref _encryption, content.ToString());

        return newChapter;
    }

    public void Run() {
        Chapter chapter = PickChapter();
        chapter.Print(ref _encryption);
    }

    public Chapter PickChapter() {
        int ChapterIdx = 1;

        while (true) {
            PrintHeader();

            // Print de tilgængelige kapitler.
            for (int i = 1; i < _chapters.Count + 1; ++i) {
                string prefix = ChapterIdx == i ? " > " : "   ";

                Chapter chapter = _chapters[i - 1];

                Console.WriteLine("{0}[{1}] {2}" , prefix, i, chapter._title);
            }

            // Håndter tasterne.
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key) {
                // Bryd helt ud af programmet.
                case ConsoleKey.Q:
                    Environment.Exit(0); // dirty; who cares?
                    break;

                // Bryd ud af loopet og returner det valgte kapitel.
                case ConsoleKey.Enter:
                    return _chapters[ChapterIdx - 1];

                case ConsoleKey.N:
                    AddChapter(CreateChapter());
                    break;

                // Hvis vi kommer under 1, spring op igen til den øverste.
                case ConsoleKey.UpArrow:
                    ChapterIdx = (ChapterIdx > 1) ? --ChapterIdx : _chapters.Count;
                    break;

                // Hvis vi kommer over mængden af kapitler, spring ned til den nederste.
                case ConsoleKey.DownArrow:
                    ChapterIdx = (ChapterIdx < _chapters.Count) ? ++ChapterIdx : 1;
                    break;
            }

            Console.Clear();
        }
    }
}