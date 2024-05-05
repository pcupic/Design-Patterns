Console.WriteLine("TEST 1:");
Tester.TestTransactionBetweenTwoUsers();
Console.WriteLine("TEST 2:");
Tester.TestMultipleTransactions();
Console.WriteLine("TEST 3:");
Tester.TestWithdrawalAndDeposit();
Console.WriteLine("TEST 4:");
Tester.TestInvalidTransaction();

public interface IBankAccount
{
    double CheckBalance();
    void Withdraw(double amount);
    void Deposit(double amount);
}

public interface ITransaction
{
    void Execute();
}

public abstract class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class User : Person, IBankAccount
{
    private double Balance { get; set; }
    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        Balance = 0;
    }

    public double CheckBalance()
    {
        return Balance;
    }
    public void Withdraw(double amount)
    {
        if (amount <= Balance) Balance -= amount;
        else throw new InvalidOperationException("Not enough funds to withdraw");
    }
    public void Deposit(double amount) => Balance += amount;
}

public class Bank
{
    private List<User> users;
    public Bank()
    {
        users = new List<User>();
    }

    public void AddUser(User user) => users.Add(user);
    public void RemoveUser(User user) => users.Remove(user);
    public void ExecuteTransaction(Transaction transaction) => transaction.Execute();
}

public abstract class Transaction : ITransaction
{
    public double Amount { get; set; }
    public DateTime Time { get; set; }
    public Transaction(double amount, DateTime time)
    {
        Amount = amount;
        Time = time;
    }
    public abstract void Execute();
}

public class TransferFunds : Transaction
{
    private User Sender { get; set; }
    private User Reciever { get; set; }
    public TransferFunds(User sender, User reciever, double amount) : base(amount, DateTime.Now)
    {
        Sender = sender;
        Reciever = reciever;
    }

    public override void Execute()
    {
        if (Sender == Reciever) throw new InvalidOperationException("Invalid transaction");
        else if (Sender.CheckBalance() >= Amount)
        {
            Sender.Withdraw(Amount);
            Reciever.Deposit(Amount);
        }
        else throw new InvalidOperationException("Not enough funds");
    }
}

public class Tester
{
    public static void TestTransactionBetweenTwoUsers()
    {
        User user1 = new User("Bilali", "Nebi");
        User user2 = new User("Zdravko", "Dren");
        List<User> users = new List<User>() { user1, user2 };
        Bank bank = new Bank();
        bank.AddUser(user1);
        bank.AddUser(user2);

        user1.Deposit(1000);
        user2.Deposit(1000);

        Transaction transaction = new TransferFunds(user1, user2, 100);

        try
        {
            bank.ExecuteTransaction(transaction);
            Console.WriteLine($"{user1.FirstName} {user1.LastName} - Balance: {user1.CheckBalance()} EUR");
            Console.WriteLine($"{user2.FirstName} {user2.LastName} - Balance: {user2.CheckBalance()} EUR");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Transaction failed: {ex.Message}");
        }


    }
    public static void TestMultipleTransactions()
    {
        User user1 = new User("Bilali", "Nebi");
        User user2 = new User("Zdravko", "Dren");
        User user3 = new User("Ana", "Anić");

        List<User> users = new List<User>() { user1, user2, user3 };
        Bank bank = new Bank();
        foreach (User user in users)
        {
            bank.AddUser(user);
            user.Deposit(1000);
        }

        Transaction transaction1 = new TransferFunds(user1, user2, 300);

        try
        {
            bank.ExecuteTransaction(transaction1);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Transaction failed: {ex.Message}");
        }

        Transaction transaction2 = new TransferFunds(user2, user3, 500);

        try
        {
            bank.ExecuteTransaction(transaction2);
            foreach (User user in users)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName} - Balance: {user.CheckBalance()} EUR");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Transaction failed: {ex.Message}");
        }
    }

    public static void TestWithdrawalAndDeposit()
    {
        User user1 = new User("Bilali", "Nebi");
        List<User> users = new List<User>() { user1 };
        Bank bank = new Bank();
        bank.AddUser(user1);

        user1.Deposit(500);

        try
        {
            user1.Withdraw(500);
            Console.WriteLine($"{user1.FirstName} {user1.LastName} - Balance: {user1.CheckBalance()} EUR");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Withdrawal failed: {ex.Message}");
        }

        user1.Deposit(500);

        try
        {
            user1.Withdraw(501);
            Console.WriteLine($"{user1.FirstName} {user1.LastName} - Balance: {user1.CheckBalance()} EUR");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Withdrawal failed: {ex.Message}");
        }
    }

    public static void TestInvalidTransaction()
    {
        User user1 = new User("Bilali", "Nebi");
        List<User> users = new List<User>() { user1 };
        Bank bank = new Bank();
        bank.AddUser(user1);

        user1.Deposit(1000);
        Transaction transaction = new TransferFunds(user1, user1, 500);

        try
        {
            bank.ExecuteTransaction(transaction);
            Console.WriteLine($"{user1.FirstName} {user1.LastName} - Balance: {user1.CheckBalance()} EUR");

        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Transaction failed: {ex.Message}");
        }
    }

}