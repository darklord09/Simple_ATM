

using System;
public class CardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    //constructor
    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }
    public string getFirstName()
    {
        return firstName;
    }
    public string getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }

    //create setters
    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    //main method 
    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit");
            double deposit = Double.Parse(Console.ReadLine());
            deposit = deposit + currentUser.getBalance();
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for your deposit. Your new balance is:  " + currentUser.getBalance());

        }
        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much money would like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //check if the user has enough money
            if (withdrawal<currentUser.getBalance())
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Take your money ");
                
            }
            else
            {
                Console.WriteLine("insufficient balance ");
                
            }
        }
        void balance(CardHolder currentUser)
        {
                Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

            //create a simple database for test app
        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("346413241971249", 1124, "Ruth", "Sam", 150.32));
        cardHolders.Add(new CardHolder("346413241977783", 1658, "John", "Luke", 149));
        cardHolders.Add(new CardHolder("346413241971889", 2233, "Jalani", "Samuel", 180.09));
        cardHolders.Add(new CardHolder("346413241970098", 2424, "Andrew", "Sam", 130.98));
        cardHolders.Add(new CardHolder("346413241972234", 1024, "Matt", "John", 140.32));


        // prompt user
        Console.WriteLine("Welcome to SampleATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        CardHolder currentUser;


        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("card not recongniszed. Please try again"); }

            }
            catch
            {
                Console.WriteLine("card not recognized. Please try again");
            }
        }
        
        //check pin 
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //check against our db
                if (currentUser.getPin() == userPin) { break; }
                else
                {
                    Console.WriteLine("Incorrent pin. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Incorrent pin. Please try again");
            }
        }
        

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
             option = int.Parse(Console.ReadLine());
            }
            catch
            {

            }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! have a nice day");


        
    }

}

