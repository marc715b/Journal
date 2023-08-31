Book MyBook = new Book("Programmerings noter");

// Eksempel kapitler.
MyBook.AddChapter("Variabler", "de seje");
MyBook.AddChapter("Funktioner", "de også seje");
MyBook.AddChapter("Loops", "de sejere");

while (true) {
    Console.Clear();

    Chapter chapter = MyBook.PickChapter();
    chapter.Print();
}