public class Book {
    private string _title;
    private List<Chapter> _chapters;

    // Bogens constructor.
    public Book(string title) {
        _title = title;

        _chapters = new List<Chapter>();
        AddChapters();
    }

    private void PrintHeader() {
        Console.WriteLine(
            "Velkommen til " + _title + "! Naviger kapitlerne vha. piletasterne.\n" +
            "Tryk ENTER ved det kapitel du vil læse. Tryk Q for at bryde ud af programmet.\n"
        );
    }

    private void AddChapters() {
        // hardcoded lol
        foreach (string file in Directory.GetFiles(@"C:\dev\Journal\chapters")) {
            _chapters.Add(new Chapter(file));
        }
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