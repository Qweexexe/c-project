using System;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Do you want to play alone or with friends?  alone/friends");
        string userAnswer = GetUserQuestion();
        switch (userAnswer)
        {
            case "alone":
                string wordsType = GetUserWordType();
                string generatedWord = GetWords(wordsType);
                Game(5, generatedWord, new string('*', generatedWord.Length));
                break;
            case "friends":
                string userWord = GenerateWord();
                Game(5, userWord, new string('*', userWord.Length));
                break;
            default:
                Console.WriteLine("Invalid input. Please enter 'alone' or 'friends'.");
                break;
        }
    }

    public static string GetUserWordType()
    {
        Console.WriteLine("What type of word do you wish ?");
        string[] types = { "fruits", "videogames", "countries", "currency" };
        foreach (string wordType in types)
        {
            Console.WriteLine("--------->{0}<--------", wordType);
        }
        string anwser = Console.ReadLine();
        return anwser;
    }

    public static string GetWords(string typeOfWords)
    {
        switch (typeOfWords)
        {
            case "fruits":
                string[] fruits = GetListOfWords("fruits");
                int maxFruitLength = GetMaxLength(fruits);
                return fruits[GetRandomNumber(maxFruitLength) - 1];
            case "videogames":
                string[] videogames = GetListOfWords("videogames");
                int maxGamesLength = GetMaxLength(videogames);
                return videogames[GetRandomNumber(maxGamesLength) - 1];
            case "countries":
                string[] countries = GetListOfWords("countries");
                int maxCountryLength = GetMaxLength(countries);
                return countries[GetRandomNumber(maxCountryLength) - 1];
            case "currency":
                string[] currency = GetListOfWords("currency");
                int maxCurrencyLength = GetMaxLength(currency);
                return currency[GetRandomNumber(maxCurrencyLength) - 1];
            default:
                Console.WriteLine("Sorry, but I don't understand your message, let's start with fruits");
                string[] defaultFruits = { "apple", "pineapple", "meloun", "watermeloun", "cherry", "strawberry" };
                int maxDefaultFruitsLength = GetMaxLength(defaultFruits);
                return defaultFruits[GetRandomNumber(maxDefaultFruitsLength) - 1];
        }
    }

    public static void Game(int lifes, string word, string hiddenWord)
    {
        if (lifes > 0)
        {
            Console.Clear();
            GetLifes(lifes);
            Console.WriteLine("WORD ---> {0} <--- WORD", hiddenWord);
            GuessWord(word, hiddenWord, lifes);
        }
        else
        {
            Console.WriteLine("Nice try, but you've done, the word was ===>{0}<===", word);
        }
    }

    //With friends
    public static string GenerateWord()
    {
        Console.WriteLine("Nobody can't see the word you're writing here");
        string word = Console.ReadLine();
        return word;
    }

    public static void ControlledWord(string word, string hiddenWord, string userInput, int lifes)
    {
        int localLifes = lifes;
        char[] splittedWord = hiddenWord.ToCharArray();
        char[] splittedUser = userInput.ToCharArray();
        bool correctGuess = false;

        if (word == userInput)
        {
            Console.WriteLine("Good, the word was ==> {0} <==", word);
        }
        else
        {
            for (int i = 0; i < splittedWord.Length; i++)
            {
                char letter = splittedWord[i];
                for (int j = 0; j < splittedUser.Length; j++)
                {
                    char userLetter = splittedUser[j];
                    if (letter == '*' && char.ToLower(userLetter) == char.ToLower(word.ToCharArray()[j]))
                    {
                        splittedWord[j] = word.ToCharArray()[j];
                        correctGuess = true;
                        continue;
                    }
                }
            }

            if (!correctGuess)
            {
                localLifes--;
                Console.WriteLine("Incorrect guess! Lives remaining: {0}", localLifes);
            }

            Game(localLifes, word, string.Join("", splittedWord));
        }
    }

    public static string[] GetListOfWords(string param)
    {
        string[] fruits = { "apple", "pineapple", "melon", "watermelon", "cherry", "strawberry" };
        string countries = { "Ukraine", "Czech", "Germany", "Austria", "Poland", "Turkey", "Cyprus", "France", "Italy" };
        string[] videgames = { "minecraft", "rainbowsix", "dota", "cyberpunk", "metro", "gta", "battlefield" };
        string[] currency =  { "cryptocurrency", "currency", "dollar", "euro" };
        switch (param)
        {
            case "fruits":
                return fruits;
            case "countries":
                return countries;
            case "videogames":
                return videgames;
            case "currency":
                return currency;
            default:
                return null;
        }
    }


    public static string GetUserQuestion()
    {
        string answer = Console.ReadLine();
        return answer;
    }


    public static string GetUserWord()
    {
        string userWord = Console.ReadLine();
        return userWord;
    }


    public static void GuessWord(string word, string hiddenWord, int lifes)
    {
        Console.WriteLine("Hmm... What is it ?");
        string userWord = Console.ReadLine();
        ControlledWord(word, hiddenWord, userWord, lifes);
    }


    public static void GetLifes(int lifes)
    {
        Console.WriteLine("<<---------------------------------------------->>");
        Console.WriteLine("You have {0} lifes", lifes);
        Console.WriteLine("<<---------------------------------------------->>");
    }

    public static int GetRandomNumber(int ends)
    {
        Random random = new Random();
        return random.Next(1, ends);
    }

    public static int GetMaxLength(string[] array)
    {
        return array.Length;
    }
}
