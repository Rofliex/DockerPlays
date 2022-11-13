// See https://aka.ms/new-console-template for more information
//Environment.SetEnvironmentVariable("LOG_FOLDER","/Logs");
var baseDirectory = Environment.GetEnvironmentVariable("LOG_FOLDER");
if (string.IsNullOrEmpty(baseDirectory))
{
    Console.WriteLine("Env variable LOG_FOLDER is null or empty.");
    return;
}

foreach (var filePath in Directory.GetFiles(baseDirectory))
{
    Console.WriteLine("File: " + filePath + "\n");
    using StreamReader fs = new StreamReader(filePath);
    while (!fs.EndOfStream)
    {
        Console.WriteLine(fs.ReadLine());
    }
}


