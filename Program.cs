Book MyBook = new Book("Programmerings noter");

// Tilføj kapitler.
MyBook.AddChapter("Variabler", Chapters.Variabler);
MyBook.AddChapter("Loops", Chapters.Loops);
MyBook.AddChapter("Funktioner", Chapters.Funktioner);
MyBook.AddChapter("Classes", Chapters.Classes);

while (true) {
    Console.Clear();

    Chapter chapter = MyBook.PickChapter();
    chapter.Print();
}