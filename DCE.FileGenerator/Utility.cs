using System.Text;

namespace DCE.FileGenerator;

internal class Utility
{
    private readonly Random _random = new Random();
    private readonly StringBuilder _stringBuilder = new StringBuilder();

    static readonly char[] Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ".ToCharArray();

    internal string GetRandomText(int size)
    {
        _stringBuilder.Clear();

        for (var i = 0; i < size; i++)
        {
            var character = Characters[_random.Next(0, Characters.Length)];
            _stringBuilder.Append(character);
        }

        return _stringBuilder.ToString();
    }
}
