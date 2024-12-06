namespace FinalProjectStageFirst

{
    internal class GuessTheNumber
    {
        class GuessTheNumber 
        { 
     static void Main(string[] args)
     {
         Console.WriteLine("Welcome to 'Guess the Number'!");
         Console.WriteLine("I have selected a number between 1 and 100. Try to guess it!");


                 Random random = new Random();
                 int numberToGuess = random.Next(1, 101);
                 int attempts = 0;
                 bool guessedCorrectly = false;

                 while (!guessedCorrectly)
                 {

                     Console.Write("\nEnter your guess: ");
                     string input = Console.ReadLine();


                     if (!int.TryParse(input, out int playerGuess) || playerGuess < 1 || playerGuess > 100)
                     {
                         Console.WriteLine("Invalid input! Please enter a number between 1 and 100.");
                         continue;
                     }


                     attempts++;


                     if (playerGuess == numberToGuess)
                     {
                         Console.WriteLine($"Congratulations! You guessed the correct number {numberToGuess} in {attempts} attempts.");
                         guessedCorrectly = true;
                     }
                     else if (playerGuess < numberToGuess)
                     {
                         Console.WriteLine("Too low! Try again.");
                     }
                     else
                     {
                         Console.WriteLine("Too high! Try again.");
                     }
                 }

                 Console.WriteLine("Thanks for playing! Press any key to exit.");
                 Console.ReadKey();
             }
         }
    }
}
   
