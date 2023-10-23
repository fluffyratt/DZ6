using System.Text.Encodings.Web;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using ConsoleApp1;
using System;


try
{
    const string InputPath = "C:\\Users\\45ksu\\Desktop\\ООП\\ДЗ6\\ConsoleApp1\\input.json";

    const string OutputPath = "C:\\Users\\45ksu\\Desktop\\ООП\\ДЗ6\\ConsoleApp1\\output.json";

    FileStream fs = new FileStream(InputPath, FileMode.OpenOrCreate);

    var books = await JsonSerializer.DeserializeAsync<List<Book>>(fs); 




    foreach (var book in books)
    {

        Console.WriteLine($"Title: {book.Title}");
        Console.WriteLine($"Publishing House: {book.PublishingHouse.Name}");
        Console.WriteLine($"Adress: {book.PublishingHouse.Adress}");
        Console.WriteLine();

    }

    fs.Close();


    var options = new JsonSerializerOptions
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
        WriteIndented = true
    
    };

    File.WriteAllText(OutputPath, JsonSerializer.Serialize(books, options));

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
