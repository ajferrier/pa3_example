//  PA 3

double gilAmount = 50;
bool keepGoing;
Console.Clear();
System.Console.WriteLine();
System.Console.WriteLine("Avaliable Gil: " + gilAmount + "\n");
System.Console.WriteLine("Welcome to Jeff's Jolly Jackpot Land! Enter one of the following options as an integer:\n1. Slot Machine \n2. Blackjack \n3. Roulette \n4. Exit");
string menuChoice = Console.ReadLine();
string[] slotWord = {"Elephant", "Computer", "Football", "Resume", "Capstone", "Crimson"};
int[] blackjackCard = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
int[] rouletteWheel = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36};
// int playerInitialHand = 0;
// int dealerInitialHand = 0;

//menu
while(menuChoice != "4" && (gilAmount <= 300 && gilAmount > 0))
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
        DisplayBlackjackRules();
        double gameBetAmount = GetBetAmount(ref gilAmount);
        Console.Clear();
        BlackJack(ref gilAmount, blackjackCard, ref gameBetAmount);
    }
    else if (menuChoice == "3")
    {
        Console.Clear();
        DisplayRouletteRules();
        double gameBetAmount = GetBetAmount(ref gilAmount);
        Console.Clear();
        Roulette(ref gilAmount, rouletteWheel, ref gameBetAmount);
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
        System.Console.WriteLine("Enter one of the following options as an integer: \n1. Slot Machine \n2. Blackjack \n3. Roulette Wheel \n4. Exit");
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

static void Roulette(ref double gilAmount, int[] rouletteWheel, ref double gameBetAmount)
{
    Random randomNum1 = new Random();
    int num1 = randomNum1.Next(1,36);
    Spin(ref gilAmount, num1, rouletteWheel, ref gameBetAmount);
}

static void BlackJack(ref double gilAmount, int[] blackjackCard, ref double gameBetAmount)
{
    Random randomNum1 = new Random();
    int num1 = randomNum1.Next(0,10);
    Random randomNum2 = new Random();
    int num2 = randomNum2.Next(0,10);
    Random randomNum3 = new Random();
    int num3 = randomNum3.Next(0,10);
    Random randomNum4 = new Random();
    int num4 = randomNum4.Next(0,10);
    Deal(ref gilAmount, num1, num2, num3, num4, blackjackCard, ref gameBetAmount);
}

static void Spin(ref double gilAmount, int num1, int[] rouletteWheel, ref double gameBetAmount)
{
    int spinValue = rouletteWheel[num1];
    //Console.WriteLine(spinValue);
    Console.WriteLine("The wheel is spinning...\n\nPlease pick either 'red' or 'black' ");
    string rouletteChoice = Console.ReadLine().ToLower();
    if (rouletteChoice == "red")
    {
        if (spinValue >= 1 && spinValue <= 10)
        {
            if (spinValue % 2 == 0)
            {
                Console.Clear();
                Console.WriteLine("Sorry, " + spinValue + " is black!");
                gilAmount = gilAmount - gameBetAmount;
                System.Console.WriteLine("\n\nYou just bet & lost " + gameBetAmount + " gil...\n");
                System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
                System.Console.WriteLine("[Hit any key to continue]");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You win! " + spinValue + " is red!");
                gilAmount = gilAmount + (gameBetAmount*2);
                System.Console.WriteLine("\nAmount bet: " + gameBetAmount + " gil");
                System.Console.WriteLine("You just won double your bet amount: " + gameBetAmount*2 + " gil\n");
                System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
                System.Console.WriteLine("[Hit any key to continue]");
                Console.ReadKey();
                Console.Clear();
            }
        }
        else if (spinValue <= 18)
        {
            if (spinValue % 2 == 0)
            {
                Console.Clear();
                Console.WriteLine("You win! " + spinValue + " is red!");
                gilAmount = gilAmount + (gameBetAmount*2);
                System.Console.WriteLine("\nAmount bet: " + gameBetAmount + " gil");
                System.Console.WriteLine("You just won double your bet amount: " + gameBetAmount*2 + " gil\n");
                System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
                System.Console.WriteLine("[Hit any key to continue]");
                Console.ReadKey();
                Console.Clear();
                
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Sorry, " + spinValue + " is black!");
                gilAmount = gilAmount - gameBetAmount;
                System.Console.WriteLine("\n\nYou just bet & lost " + gameBetAmount + " gil...\n");
                System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
                System.Console.WriteLine("[Hit any key to continue]");
                Console.ReadKey();
                Console.Clear();
            }
        }
        else if (spinValue <= 28)
        {
            if (spinValue % 2 == 0)
            {
                Console.Clear();
                Console.WriteLine("Sorry, " + spinValue + " is black!");
                gilAmount = gilAmount - gameBetAmount;
                System.Console.WriteLine("\n\nYou just bet & lost " + gameBetAmount + " gil...\n");
                System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
                System.Console.WriteLine("[Hit any key to continue]");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You win! " + spinValue + " is red!");
                gilAmount = gilAmount + (gameBetAmount*2);
                System.Console.WriteLine("\nAmount bet: " + gameBetAmount + " gil");
                System.Console.WriteLine("You just won double your bet amount: " + gameBetAmount*2 + " gil\n");
                System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
                System.Console.WriteLine("[Hit any key to continue]");
                Console.ReadKey();
                Console.Clear();
            }
        }
        else
        {
            if (spinValue % 2 == 0)
            {
                Console.Clear();
                Console.WriteLine("You win! " + spinValue + "is red!");
                gilAmount = gilAmount + (gameBetAmount*2);
                System.Console.WriteLine("\nAmount bet: " + gameBetAmount + " gil");
                System.Console.WriteLine("You just won double your bet amount: " + gameBetAmount*2 + " gil\n");
                System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
                System.Console.WriteLine("[Hit any key to continue]");
                Console.ReadKey();
                Console.Clear();
                
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Sorry, " + spinValue + "is black!");
                gilAmount = gilAmount - gameBetAmount;
                System.Console.WriteLine("\n\nYou just bet & lost " + gameBetAmount + " gil...\n");
                System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
                System.Console.WriteLine("[Hit any key to continue]");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    else if (rouletteChoice == "black")
    {
        if (spinValue >= 1 && spinValue <= 10)
        {
            if (spinValue % 2 == 0)
            {
                Console.Clear();
                Console.WriteLine("You win! " + spinValue + " is black!");
                gilAmount = gilAmount + (gameBetAmount*2);
                System.Console.WriteLine("\nAmount bet: " + gameBetAmount + " gil");
                System.Console.WriteLine("You just won double your bet amount: " + gameBetAmount*2 + " gil\n");
                System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
                System.Console.WriteLine("[Hit any key to continue]");
                Console.ReadKey();
                Console.Clear();
                
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Sorry, " + spinValue + " is red!");
                gilAmount = gilAmount - gameBetAmount;
                System.Console.WriteLine("\n\nYou just bet & lost " + gameBetAmount + " gil...\n");
                System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
                System.Console.WriteLine("[Hit any key to continue]");
                Console.ReadKey();
                Console.Clear();
            }
        }
        else if (spinValue <= 18)
        {
            if (spinValue % 2 == 0)
            {
                Console.Clear();
                Console.WriteLine("Sorry, " + spinValue + " is red!");
                gilAmount = gilAmount - gameBetAmount;
                System.Console.WriteLine("\n\nYou just bet & lost " + gameBetAmount + " gil...\n");
                System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
                System.Console.WriteLine("[Hit any key to continue]");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You win! " + spinValue + " is black!");
                gilAmount = gilAmount + (gameBetAmount*2);
                System.Console.WriteLine("\nAmount bet: " + gameBetAmount + " gil");
                System.Console.WriteLine("You just won double your bet amount: " + gameBetAmount*2 + " gil\n");
                System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
                System.Console.WriteLine("[Hit any key to continue]");
                Console.ReadKey();
                Console.Clear();
            }
        }
        else if (spinValue <= 28)
        {
            if (spinValue % 2 == 0)
            {
                Console.Clear();
                Console.WriteLine("You win! " + spinValue + " is black!");
                gilAmount = gilAmount + (gameBetAmount*2);
                System.Console.WriteLine("\nAmount bet: " + gameBetAmount + " gil");
                System.Console.WriteLine("You just won double your bet amount: " + gameBetAmount*2 + " gil\n");
                System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
                System.Console.WriteLine("[Hit any key to continue]");
                Console.ReadKey();
                Console.Clear();
                
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Sorry, " + spinValue + " is red!");
                gilAmount = gilAmount - gameBetAmount;
                System.Console.WriteLine("\n\nYou just bet & lost " + gameBetAmount + " gil...\n");
                System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
                System.Console.WriteLine("[Hit any key to continue]");
                Console.ReadKey();
                Console.Clear();
            }
        }
        else
        {
            if (spinValue % 2 == 0)
            {
                Console.Clear();
                Console.WriteLine("Sorry, " + spinValue + " is red!");
                gilAmount = gilAmount - gameBetAmount;
                System.Console.WriteLine("\n\nYou just bet & lost " + gameBetAmount + " gil...\n");
                System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
                System.Console.WriteLine("[Hit any key to continue]");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You win! " + spinValue + " is black!");
                gilAmount = gilAmount + (gameBetAmount*2);
                System.Console.WriteLine("\nAmount bet: " + gameBetAmount + " gil");
                System.Console.WriteLine("You just won double your bet amount: " + gameBetAmount*2 + " gil\n");
                System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
                System.Console.WriteLine("[Hit any key to continue]");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("\nYou selection is not on the wheel!");
        Spin(ref gilAmount, num1, rouletteWheel, ref gameBetAmount);
    }

}

static void Deal(ref double gilAmount, int num1, int num2, int num3, int num4, int[] blackjackCard, ref double gameBetAmount)
{
    int dealerCard1 = blackjackCard[num1];
    int dealerCard2 = blackjackCard[num2];
    int playerCard1 = blackjackCard[num3];
    int playerCard2 = blackjackCard[num4];

    if (dealerCard1 == 0 && dealerCard2 == 0)
    {
        dealerCard1 = 11;
        dealerCard2 = 1;
    }
    else if (dealerCard1 == 0)
    {
        dealerCard1 = 11;
    }
    else if (dealerCard2 == 0)
    {
        dealerCard2 = 11;
    }

    int dealerInitialHand = dealerCard1 + dealerCard2;

    System.Console.WriteLine("__________________________________\n");
    Console.Write("You drew: " + playerCard1 + " and " + playerCard2 + "\nThe dealer drew: " + dealerCard1 + " and " + dealerCard2);
    System.Console.WriteLine("\n__________________________________");
    if (playerCard2 == 0 && playerCard1 == 0)
    {
        Console.Clear();
        playerCard1 = 11;
        playerCard2 = 1;
        int playerInitialHand = playerCard1 + playerCard2;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("You drew double aces!\nYour hand total is: " + playerInitialHand);
        Console.ForegroundColor = ConsoleColor.Green;        
        Console.WriteLine("\nThe dealer hand total is: " + dealerInitialHand);
        Console.ForegroundColor = ConsoleColor.White;

    }
    else if (playerCard1 == 0)
    {
        Console.WriteLine("You drew an ace!\nYou can choose if you would like it to be an 11 or 1\n");
        Console.WriteLine("Please enter '11' or '1'\n");
        string choice = Console.ReadLine();
        if (choice == "11")
        {
            playerCard1 = 11;
            int playerInitialHand = playerCard1 + playerCard2;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Your hand total is: " + playerInitialHand);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe dealer hand total is: " + dealerInitialHand);
            Console.ForegroundColor = ConsoleColor.White;

        }
        else if (choice == "1")
        {
            playerCard1 = 1;
            int playerInitialHand = playerCard1 + playerCard2;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Your hand total is: " + playerInitialHand);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe dealer hand total is: " + dealerInitialHand);
            Console.ForegroundColor = ConsoleColor.White;

        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Invalid Response!\n");
            Console.ForegroundColor = ConsoleColor.White;
            Deal(ref gilAmount, num1, num2, num3, num4, blackjackCard, ref gameBetAmount);
        }
        
    }
    else if (playerCard2 == 0)
    {
        Console.WriteLine("You drew an ace!\nYou can choose if you would like it to be an 11 or 1\n");
        Console.WriteLine("Please enter '11' or '1'\n");
        string choice = Console.ReadLine();
        if (choice == "11")
        {
            playerCard2 = 11;
            int playerInitialHand = playerCard1 + playerCard2;            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Your hand total is: " + playerInitialHand);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe dealer hand total is: " + dealerInitialHand);
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (choice == "1")
        {
            playerCard2 = 1;
            int playerInitialHand = playerCard1 + playerCard2;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Your hand total is: " + playerInitialHand);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe dealer hand total is: " + dealerInitialHand);
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Invalid Response!\n");
            Console.ForegroundColor = ConsoleColor.White;
            Deal(ref gilAmount, num1, num2, num3, num4, blackjackCard, ref gameBetAmount);
        } 
    }
    else 
    {
        int playerInitialHand = playerCard1 + playerCard2;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nYour hand total is: " + playerInitialHand);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nThe dealer hand total is: " + dealerInitialHand);
        Console.ForegroundColor = ConsoleColor.White;
    }


    int playerUpdatedHand = playerCard1 + playerCard2;
    int dealerUpdatedHand = dealerCard1 + dealerCard2;
    

    Console.WriteLine("\nWould you like to hit or stay?");
    string hitStay = Console.ReadLine().ToLower();
    while (hitStay == "hit")
    {
        Random randomNum1 = new Random();
        int playerHit = randomNum1.Next(0,10);
        int playerCard = blackjackCard[playerHit];
        if (playerCard == 0 && playerUpdatedHand + 11 > 21)
        {
            playerCard = 1;
        }
        else
        {
            playerCard = 11;
        }
        playerUpdatedHand = playerUpdatedHand + playerCard;

        Random randomNum2 = new Random();
        int dealerHit = randomNum2.Next(0,10);
        int dealerCard = blackjackCard[dealerHit];
        if (dealerCard == 0 && dealerUpdatedHand + 11 > 21)
        {
            dealerCard = 1;
        }
        else
        {
            dealerCard = 11;
        }
        dealerUpdatedHand = dealerUpdatedHand + dealerCard;

        if (playerUpdatedHand == 21)
        {
            Console.Clear();
            Console.WriteLine("Blackjack!! You win!");
            gilAmount = gilAmount + (gameBetAmount*2);
            System.Console.WriteLine("\nAmount bet: " + gameBetAmount + " gil");
            System.Console.WriteLine("You just won double your bet amount: " + gameBetAmount*2 + " gil\n");
            System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
            System.Console.WriteLine("[Hit any key to continue]");
            Console.ReadKey();
            Console.Clear();
            break;
        }
        else if (playerUpdatedHand > 21)
        {
            Console.Clear();
            Console.WriteLine("You drew a " + playerCard);
            Console.WriteLine("Oops... you busted with a total of " + playerUpdatedHand);
            gilAmount = gilAmount - gameBetAmount;
            System.Console.WriteLine("\n\nYou just bet & lost " + gameBetAmount + " gil...\n");
            System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
            System.Console.WriteLine("[Hit any key to continue]");
            Console.ReadKey();
            Console.Clear();
            break;
        }
        else if (dealerUpdatedHand > 21)
        {
            Console.Clear();
            Console.WriteLine("You drew a " + playerCard + " for a total of " + playerUpdatedHand);
            Console.WriteLine("They say the house never loses...\nThey were wrong! The dealer busted with " + dealerUpdatedHand);
            gilAmount = gilAmount + (gameBetAmount*2);
            System.Console.WriteLine("\nAmount bet: " + gameBetAmount + " gil");
            System.Console.WriteLine("You just won double your bet amount: " + gameBetAmount*2 + " gil\n");
            System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
            System.Console.WriteLine("[Hit any key to continue]");
            Console.ReadKey();
            Console.Clear();
            break;
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Your new hand total is: " + playerUpdatedHand);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe dealer hand total is: " + dealerUpdatedHand);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nWould you like to hit or stay?");
            hitStay = Console.ReadLine().ToLower();
        }
        
    }
    if (hitStay == "stay")
    {
        while (dealerUpdatedHand < 17)
        {
            Random randomNum2 = new Random();
            int dealerHit = randomNum2.Next(0,10);
            int dealerCard = blackjackCard[dealerHit];
            if (dealerCard == 0 && dealerUpdatedHand + 11 > 21)
            {
                dealerCard = 1;
            }
            else
            {
                dealerCard = 11;
            }
            dealerUpdatedHand = dealerUpdatedHand + dealerCard;
        }
        
        if (playerUpdatedHand > dealerUpdatedHand)
        {
            Console.Clear();
            Console.WriteLine("You stayed for a total of " + playerUpdatedHand);
            Console.WriteLine("They say the house never loses...\nThey were wrong! The dealer busted with " + dealerUpdatedHand);
            gilAmount = gilAmount + (gameBetAmount*2);
            System.Console.WriteLine("\nAmount bet: " + gameBetAmount + " gil");
            System.Console.WriteLine("You just won double your bet amount: " + gameBetAmount*2 + " gil\n");
            System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
            System.Console.WriteLine("[Hit any key to continue]");
            Console.ReadKey();
            Console.Clear();
        }
        else if (playerUpdatedHand == dealerUpdatedHand)
        {
            Console.Clear();
            Console.WriteLine("You and the dealer tied! \nBut the house always wins, better luck next time!");
            gilAmount = gilAmount - gameBetAmount;
            System.Console.WriteLine("\n\nYou just bet & lost " + gameBetAmount + " gil...\n");
            System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
            System.Console.WriteLine("[Hit any key to continue]");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("The dealer hit and now has " + dealerUpdatedHand);
            Console.WriteLine("Well, there is always next time.  The dealer won. \nBetter luck next time around!");
            gilAmount = gilAmount - gameBetAmount;
            System.Console.WriteLine("\n\nYou just bet & lost " + gameBetAmount + " gil...\n");
            System.Console.WriteLine("Updated Gil Total: " + gilAmount + "\n");
            System.Console.WriteLine("[Hit any key to continue]");
            Console.ReadKey();
            Console.Clear();
        }
    }   
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

static void DisplayRouletteRules()
{
    System.Console.WriteLine("Welcome to Jeff's World-Famous Roulette Wheel!");
    System.Console.WriteLine("You will be betting a valid amount of your gil on our wheel...\n");
    System.Console.WriteLine("[Hit any key to continue]");
    Console.ReadKey();
    Console.Clear();
    System.Console.WriteLine("------------------- Rules -------------------");
    System.Console.WriteLine("\nYou will pick either 'red' or 'black'\n");
    System.Console.WriteLine("Next, it is simple, just wait for the wheel to decide you fate\n"); 
    System.Console.WriteLine("The wheel will stop on a number between 1 and 36, you have a 50% chance of winning!\n");
    System.Console.WriteLine("If you guess correctly, you will double your money, if you are wrong... you lose what you bet.\nGood Luck!!!");
    System.Console.WriteLine("\n\n[Hit any key to advance to the game]");
    Console.ReadKey();
    Console.Clear();
}

static void DisplayBlackjackRules()
{
    System.Console.WriteLine("Welcome to Jeff's World-Famous Blackjack!");
    System.Console.WriteLine("You will be betting a valid amount of your gil on the table...\n");
    System.Console.WriteLine("[Hit any key to continue]");
    Console.ReadKey();
    Console.Clear();
    System.Console.WriteLine("--------------- Rules ----------------\n");
    System.Console.WriteLine("Today you'll be playing against only the dealer, you will both recieve two cards to start the hand.\n");
    System.Console.WriteLine("Once you see your total you can choose to hit or stay\n");
    System.Console.WriteLine("You can continue to make this choice, but don't go over 21!\n"); 
    System.Console.WriteLine("Going over 21 will result in a bust and you will lose your wagered gil.\n");
    System.Console.WriteLine("If you tie with the dealer you will lose, unless you have blackjack (21)!");
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