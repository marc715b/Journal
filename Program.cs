Book MyBook = new Book("Programmerings noter");

// Tilføj kapitler.
MyBook.AddChapter("Variabler", @"
  de seje
");

MyBook.AddChapter("Funktioner", @"
  de også seje
");

MyBook.AddChapter("Loops", @"
  de sejere
");

MyBook.AddChapter("Classes", @"
  de de sejeste
");

while (true) {
    Console.Clear();

    Chapter chapter = MyBook.PickChapter();
    chapter.Print();
}