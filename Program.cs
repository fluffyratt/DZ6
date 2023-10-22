using System.Text.Json;
using ConsoleApp1;


try
{
    const string InputPath = "C:\\Users\\45ksu\\Desktop\\ООП\\ДЗ6\\input.json";

    const string OutputPath = "C:\\Users\\45ksu\\Desktop\\ООП\\ДЗ6\\output.json";

    FileStream fs = new FileStream(InputPath, FileMode.OpenOrCreate);

    var books = await JsonSerializer.DeserializeAsync<List<Book>>(fs);

    

    foreach (var book in books)
    {
      
        Console.WriteLine(JsonSerializer.Serialize(book));

    }

    fs.Close();

    var options = new JsonSerializerOptions
    {
        WriteIndented = true,
    };

    File.WriteAllText(OutputPath, JsonSerializer.Serialize(books, options));

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
