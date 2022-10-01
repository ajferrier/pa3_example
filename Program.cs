//  PA 3
double gilAmount = 50;
bool keepGoing;
Console.Clear();
System.Console.WriteLine();
System.Console.WriteLine("Avaliable Gil: " + gilAmount + "\n");
System.Console.WriteLine("Welcome to Jeff's Jolly Jackpot Land! Enter one of the following options as an integer:\n1. Slot Machine \n2. Blackjack \n3. Exit");
string menuChoice = Console.ReadLine();
string[] slotWord = {"Elephant", "Computer", "Football", "Resume", "Capstone", "Crimson"};
//menu
while(menuChoice != "3" && (gilAmount <= 300 && gilAmount > 0))
{
    if (menuChoice == "1")
    {
        Console.Clear();
        DisplaySlotRules();
        double gameBetAmount = GetBetAmount(ref gilAmount);
        Console.Clear();
        Slot(ref gilAmount, slotWord, ref gameBetAmount);
        //KeepPlaying(ref keepGoing);
    }
    else if (menuChoice == "2")
    {
        Console.Clear();
        System.Console.WriteLine("Blackjack Game\n");
        gilAmount = gilAmount - 50;
    }
    else
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("Invalid Response!\n");
        Console.ForegroundColor = ConsoleColor.White;
    }

    if(gilAmount <= 300 && gilAmount > 0)
    {
        System.Console.WriteLine("Avaliable Gil: " + gilAmount + "\n");
        System.Console.WriteLine("Enter one of the following options as an integer: \n1. Slot Machine \n2. Blackjack \n3. Exit");
        menuChoice = Console.ReadLine();
    }
    
}
//Console.Clear();
if (gilAmount >= 300)
{
    System.Console.WriteLine("\nWinner! Winner! Go you!\n");
}
else if(gilAmount <= 0)
{
    System.Console.WriteLine("\nYou lose...\n");
}
System.Console.WriteLine("\n\nGoodbye!!\n\n");

//-------------------------------MAIN---------------------------------------------MAIN---------------------------------------------------------------------


static void Slot(ref double gilAmount, string[] slotWord, ref double gameBetAmount)
{
    Random randomNum1 = new Random();
    int num1 = randomNum1.Next(0,6);
    Random randomNum2 = new Random();
    int num2 = randomNum2.Next(0,6);
    Random randomNum3 = new Random();
    int num3 = randomNum3.Next(0,6);
    DisplaySlotOnScreen(num1, num2, num3, slotWord);
    SlotLogic(ref gilAmount, num1, num2, num3, ref gameBetAmount);
    
}

static void DisplaySlotOnScreen(int num1, int num2, int num3, string[] slotWord)
{
    //System.Console.WriteLine(num1 + " - " + num2 + " - " + num3);
    System.Console.WriteLine("__________________________________\n");
    Console.Write("  " + slotWord[num1] + " - " + slotWord[num2] + " - " + slotWord[num3]+ "\n");
    System.Console.WriteLine("__________________________________");
}

static void SlotLogic(ref double gilAmount, int num1, int num2, int num3, ref double gameBetAmount)
{
    if (num1 == num2 && num2 == num3)
    {
        gilAmount = gilAmount + (gameBetAmount*3);
        System.Console.WriteLine("\nAmount bet: " + gameBetAmount + " gil");
        System.Console.WriteLine("You just won triple your bet amount: " + gameBetAmount*3 + " gil\n");
        System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
        System.Console.WriteLine("[Hit any key to continue]");
        Console.ReadKey();
        Console.Clear();
    }
    else if (num1 == num2 || num2 == num3 || num3 == num1)
    {
        gilAmount = gilAmount + (gameBetAmount*2);
        System.Console.WriteLine("\nAmount bet: " + gameBetAmount + " gil");
        System.Console.WriteLine("You just won double your bet: " + gameBetAmount*2 + " gil\n");
        System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
        System.Console.WriteLine("[Hit any key to continue]");
        Console.ReadKey();
        Console.Clear();
    }
    else
    {
        gilAmount = gilAmount - gameBetAmount;
        System.Console.WriteLine("\n\nYou just bet & lost " + gameBetAmount + " gil...\n");
        System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
        System.Console.WriteLine("[Hit any key to continue]");
        Console.ReadKey();
        Console.Clear();
    }
}

static double GetBetAmount(ref double gilAmount)
{
    System.Console.WriteLine("Avaliable Gil: " + gilAmount);
    System.Console.WriteLine("How much would you like to bet?");
    double betAmount = double.Parse(Console.ReadLine());
    while(betAmount > gilAmount || betAmount <= 0)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("\nYou don't have enough gil or the amount enetred is negative\n\n");
        Console.ForegroundColor = ConsoleColor.White;
        System.Console.WriteLine("Enter valid bet, see amount below:");
        System.Console.WriteLine("\n\tAvaliable Gil: " + gilAmount + "\n");
        System.Console.WriteLine("How much would you like to bet?");
        betAmount = double.Parse(Console.ReadLine());
    }
    return betAmount;
}

static void DisplaySlotRules()
{
    System.Console.WriteLine("Welcome to Jeff's World-Famous Slots!");
    System.Console.WriteLine("You will be betting a valid amount of your gil on the wheels of fate...\n");
    System.Console.WriteLine("[Hit any key to continue]");
    Console.ReadKey();
    Console.Clear();
    System.Console.WriteLine("Next step, you'll be spinnin' them wheels away! The results will appear on your screen.\n\nRules\n---------------------------------------------------------");
    System.Console.WriteLine("No words match: you lose the gil you risked\n");
    System.Console.WriteLine("Two words match: you win double the gil you risked\n"); 
    System.Console.WriteLine("Three words match: you win triple the gil you risked\n");
    System.Console.WriteLine("As Jeff always says: 'Going once, going twice...'");
    System.Console.WriteLine("[Hit any key to advance to the game]");
    Console.ReadKey();
    Console.Clear();
}

static bool KeepPlaying()
{
    System.Console.WriteLine("Enter following integers: \n1. Play again\n2. Return to main menu");
    string keepPlay = Console.ReadLine();
    if (keepPlay == "1")
    {
        return true;
    }
    else
    {
        return false;
    }
}