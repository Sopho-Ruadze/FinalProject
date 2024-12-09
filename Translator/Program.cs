using System.Linq;

public class Translation
{
    public string FromLanguage { get; set; }
    public string ToLanguage { get; set; }
    public string SourceWord { get; set; }
    public string TranslatedWord { get; set; }
}

public class TranslationManager
{
    private List<Translation> _translations = new List<Translation>();

    // ფაილიდან წაკითხვა 
    public void LoadTranslations(string filePath)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 4)
                {
                    Translation translation = new Translation
                    {
                        FromLanguage = parts[0],
                        ToLanguage = parts[1],
                        SourceWord = parts[2],
                        TranslatedWord = parts[3]
                    };

                    _translations.Add(translation);
                }
            }
        }
    }

    //სიტყვის თარგმნა ლინქის გამოყენებით 
    public string Translate(string fromLang, string toLang, string sourceWord)
    {
        var translation = _translations
            .FirstOrDefault(t => t.FromLanguage.Equals(fromLang, StringComparison.OrdinalIgnoreCase) &&
                                 t.ToLanguage.Equals(toLang, StringComparison.OrdinalIgnoreCase) &&
                                 t.SourceWord.Equals(sourceWord, StringComparison.OrdinalIgnoreCase));

        return translation != null ? translation.TranslatedWord : "Translation not found.";
    }

    // ფრაზის თარგმანა (სიტყვა სიტყვით ) 
    public string TranslatePhrase(string fromLang, string toLang, string phrase)
    {
        string[] words = phrase.Split(' ');
        string translatedPhrase = string.Join(" ", words.Select(word => Translate(fromLang, toLang, word)));

        return translatedPhrase;
    }

    // თარგმანის დამატება
    public void AddTranslation(string filePath, string fromLang, string toLang, string sourceWord, string translatedWord)
    {
        var existingTranslation = _translations
            .FirstOrDefault(t => t.FromLanguage.Equals(fromLang, StringComparison.OrdinalIgnoreCase) &&
                                 t.ToLanguage.Equals(toLang, StringComparison.OrdinalIgnoreCase) &&
                                 t.SourceWord.Equals(sourceWord, StringComparison.OrdinalIgnoreCase)); //მოწმდება შემოყვანილი სიტყვა უკვე ხომ არ არსებობს

        if (existingTranslation != null)
        {
            Console.WriteLine("This translation already exists.");
            return;
        }

        // ლისთში ახალი ნათარგმნის დამატება
        Translation newTranslation = new Translation
        {
            FromLanguage = fromLang,
            ToLanguage = toLang,
            SourceWord = sourceWord,
            TranslatedWord = translatedWord
        };

        _translations.Add(newTranslation);

        // ფაილის შენახვა LINQ-ის დახმარებით
        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine($"{fromLang},{toLang},{sourceWord},{translatedWord}");
        }

        Console.WriteLine("Translation added successfully!");
    }
}
class Program
{
    static void Main(string[] args)
    {
        TranslationManager manager = new TranslationManager();
        string filePath = "dictionary.txt"; // ფაილის ლოკაცია 

        manager.LoadTranslations(filePath);

        while (true)
        {
            Console.WriteLine("\n1. Translate Word");
            Console.WriteLine("2. Translate Phrase");
            Console.WriteLine("3. Add Translation");
            Console.WriteLine("4. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // სიტყვის თარგმნა
                    Console.Write("Enter source language: ");
                    string fromLang = Console.ReadLine();
                    Console.Write("Enter target language: ");
                    string toLang = Console.ReadLine();
                    Console.Write("Enter word to translate: ");
                    string word = Console.ReadLine();
                    string result = manager.Translate(fromLang, toLang, word);
                    Console.WriteLine($"Translation: {result}");
                    break;

                case "2":
                    // ფრაზის თარგმნა
                    Console.Write("Enter source language: ");
                    fromLang = Console.ReadLine();
                    Console.Write("Enter target language: ");
                    toLang = Console.ReadLine();
                    Console.Write("Enter phrase to translate: ");
                    string phrase = Console.ReadLine();
                    string translatedPhrase = manager.TranslatePhrase(fromLang, toLang, phrase);
                    Console.WriteLine($"Translation: {translatedPhrase}");
                    break;

                case "3":
                    // თარგმანის დამატება ფაილში
                    Console.Write("Enter source language: ");
                    fromLang = Console.ReadLine();
                    Console.Write("Enter target language: ");
                    toLang = Console.ReadLine();
                    Console.Write("Enter the word or phrase to add: ");
                    string sourceWord = Console.ReadLine();
                    Console.Write("Enter the translated word: ");
                    string translatedWord = Console.ReadLine();

                    manager.AddTranslation(filePath, fromLang, toLang, sourceWord, translatedWord);
                    break;

                case "4":
                    // დასრულება/გამოსვლა პროგრამიდან
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    // რაღაც ვერაა რიგზე :D
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }
        }
    }
}

