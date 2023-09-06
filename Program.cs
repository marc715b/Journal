Book MyBook = new Book("Programmerings noter");

while (true) {
    Console.Clear();

    Chapter chapter = MyBook.PickChapter();
    chapter.Print();
}