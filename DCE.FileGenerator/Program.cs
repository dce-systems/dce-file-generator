using DCE.FileGenerator;
using System.Globalization;

Console.WriteLine("---------------------------------");
Console.WriteLine("File generator - DCE-Systems");
Console.WriteLine("---------------------------------");

var fileName = "";

Console.WriteLine("Provide the filename for text file (or press ENTER if you want to use default name: 'input.txt')");
fileName = Console.ReadLine();
if (string.IsNullOrWhiteSpace(fileName))
{
    fileName = "input.txt";
}

Console.WriteLine("Provide the file size (in gigabytes) e.g.: 2");

double size;
while (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out size) && size > 0)
{
    Console.WriteLine("Number should be greater than 0!");
}
var fileSize = size * 1024 * 1024 * 1024;

var randomInt = new Random();
var utility = new Utility();

long totalBytes = 0;
using (var writer = new StreamWriter(new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None, 8192)))
{
    while (totalBytes < fileSize)
    {
        var text = utility.GetRandomText(randomInt.Next(5, 30));
        var number = randomInt.Next(100000);
        var rowText = string.Concat(number, ". ", text);

        writer.WriteLine(rowText);

        totalBytes += rowText.Length + 2;
    }
}

Console.WriteLine($"Done!");

Console.ReadKey();