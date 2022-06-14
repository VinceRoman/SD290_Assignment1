using System.Text;

//Question 1
Dictionary<string, int> coins = new Dictionary<string, int>();
coins.Add("1", 15);
coins.Add("2", 15);
coins.Add("5", 15);
coins.Add("10", 15);
coins.Add("20", 15);

List<int> vended = new List<int>(vendingMachine(coins, 25, 2));

int changeReceived = 0;

foreach (int coin in vended)
{
    changeReceived += coin;
}

Console.WriteLine("Total change received: $" + Convert.ToDecimal(changeReceived));

/* 
 This function takes a dictionary of coins, user money input and item price as parameters.
 In whole it returns the least amount of coins possible as change.
 It uses another function to calculate how many coins are returned to keep organized.
 returns List<int> containing coins the user receives
 */
List<int> vendingMachine(Dictionary<string, int> coins, int inputMoney, int itemPrice)
{
    int remainingCash = inputMoney - itemPrice;

    List<int> coinReturn = new List<int>(calculateCoins(coins, remainingCash));

    foreach (int coin in coinReturn)
    {
        Console.WriteLine("Coin dispensed: $" + coin);

    }

    return coinReturn;//if it doesn't have .00 as decimals, it'll return two decimal places Math.Round(Convert.ToDecimal(coins[0]), 2)
}
/*
 Function that takes a dictionary of coins to subtract values, and the user's inputted money to compare as parameters.
 Subtracts by the highest possible coins first until coins run out or it can't subtract anymore before moving to the next set of coins.
 Helps vendingMachine function to calculate how many coins to dispense.
 returns List<int> containing coins the user receives
 */
List<int> calculateCoins(Dictionary<string, int> coins, int inputMoney)
{
    List<int> coinReturn = new List<int>();

    while (inputMoney > 0)//subtract until no more need for change
    {
        if (inputMoney >= 20 && coins["20"] > 0)//it will check this first, as well as see if there's actually coins to dispense.
        {
            inputMoney -= 20;
            coins["20"] -= 1;
            coinReturn.Add(20);
        }
        else if (inputMoney >= 10 && coins["10"] > 0)
        {
            inputMoney -= 10;
            coins["10"] -= 1;
            coinReturn.Add(10);
        }
        else if (inputMoney >= 5 && coins["5"] > 0)
        {
            inputMoney -= 5;
            coins["5"] -= 1;
            coinReturn.Add(5);
        }
        else if (inputMoney >= 2 && coins["2"] > 0)
        {
            inputMoney -= 2;
            coins["2"] -= 1;
            coinReturn.Add(2);
        }
        else if (inputMoney >= 1 && coins["1"] > 0)
        {
            inputMoney -= 1;
            coins["1"] -= 1;
            coinReturn.Add(1);
        }
        else//when there's no more coins
        {
            Console.WriteLine("! Vending machine is out of coins !");
            break;
        }

    }
    return coinReturn;
}

//Question 2


Console.WriteLine("Compressor Function:   "+compressor("RTFFFFYYUPPPeeeuu"));
Console.WriteLine("Decompressor Function: "+decompressor("RTF4YYUP3E3UU"));

/*
 Function that compresses duplicate letters more than 2 in length into numbers and returns it as a new string.
 */
string compressor(string inputData)
{
    inputData = inputData.ToUpper();
    char[] chars = inputData.ToCharArray();

    StringBuilder sb = new StringBuilder();
    int counter = 0;

    for (int i = 0; i < chars.Length; i++)
    {
        
        if (i != chars.Length-1 && chars[i] == chars[i + 1])
        {
            counter++;
        }
        sb.Append(chars[i] + Convert.ToString(counter) + " ");
    }
    
    return sb.ToString();
}

/*
 Function that decompresses a compressed string, uses indicated numbers to duplicate the letter preceding it by the number's amount.
 Returns it as a new string.
 */
string decompressor(string inputData)
{
    inputData = inputData.ToUpper();
    char[] chars = inputData.ToCharArray();

    StringBuilder sb = new StringBuilder();
    int counter = 0;

    for (int i = 0; i < chars.Length; i++)
    {
        if (Char.IsNumber(chars[i]) == true)//if its a number, remove the number and add letters.
        {
            counter = Convert.ToInt32(Char.GetNumericValue(chars[i]));
            for(int j = counter; j > 1; j--)
            {
                sb.Append(chars[i - 1]);
            }
            counter = 0;
        }
        else
        {
            sb.Append(chars[i]);
        }
    }

    return sb.ToString();
}