using System.Linq;

class HangmanGame
{
    static void Main(string[] args)
    {
        HangmanGame game = new HangmanGame();
        game.Play();
    }

    private string secretWord; // გამოსაცნობი სიტყვა 
    private char[] guessedWord; // გამოსაცნობი სიტყვის მდგომარეობა
    private int attemptsLeft; // მცდელობა 

    public HangmanGame()
    {
        secretWord = ChooseRandomWord(); //რენდომ სიტყვის მეთდი
        guessedWord = new string('_', secretWord.Length).ToCharArray(); // გამოსახვა ქვედა ტირეებით 

        // მცდელობის რაოდენობა იმდენია რამდენი უნიკალური ასოცაა სიტყვაში +3 მაგ.: თუ სიტყვა არის ბაია უნიკალური ასოებია ბ,ა,ი შესაბამისად მცდელობა იქნება 3+3=6 
        attemptsLeft = secretWord.Distinct().Count() + 3;
    }

    private string ChooseRandomWord()
    {
        // სიტყვები საიდანაც რენდომად აირჩევა გამოსაცნობი სიტყვა 
        string[] words = { "programming", "computer", "hangman", "developer", "software", "algorithm", "design", "technology" };
        Random random = new Random();

        // LINQ - ის დახმარებით ვირჩევთ რენდომ სიტყვას 
        return words.OrderBy(x => random.Next()).First(); // ურევს მასივს და ირჩევს პირველს
    }

    public void Play()
    {
        while (attemptsLeft > 0 && guessedWord.Contains('_'))
        {
            Console.WriteLine($"Current word: {new string(guessedWord)}");
            Console.Write("Enter a letter: ");
            char guess = Console.ReadLine()[0];

            //  LINQ - ით ვამოწმებთ არის თუ არა ასო სიტყვაში 
            if (secretWord.Any(c => c == guess))
            {
                guessedWord = secretWord
                    .Select((c, i) => c == guess ? c : guessedWord[i])
                    .ToArray();

                Console.WriteLine("Correct!");
                Console.WriteLine("Attempts Left - " + attemptsLeft);
            }
            else
            {
                // მცდელობები მცირდება მაშინ, თუ მომხმარებელმა ასო ვერ გამოიცნო (ე.ი. მცდელობები "სიცოცხლეებივით" არის) 
                attemptsLeft--;
                Console.WriteLine("Incorrect!");
                Console.WriteLine("Attempts Left - " + attemptsLeft);
            }
        }

        if (!guessedWord.Contains('_'))
        {
            Console.WriteLine($"Congratulations! You guessed the word: {secretWord}");
        }
        else
        {
            Console.WriteLine($"Game over. The word was: {secretWord}");
        }
    }
}