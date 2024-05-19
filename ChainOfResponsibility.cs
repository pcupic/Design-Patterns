Tester.Test();

abstract class StringChecker
{
    private StringChecker next;
    public void SetNext(StringChecker next) => this.next = next;
    public bool Check(string stringToCheck)
    {
        bool result = this.PerformCheck(stringToCheck);

        if (this.next != null && result == true)
        {
            return this.next.Check(stringToCheck);
        }

        return result;
    }
    protected abstract bool PerformCheck(string stringToCheck);
}

class StringDigitChecker : StringChecker
{
    protected override bool PerformCheck(string stringToCheck)
    {
        foreach (char c in stringToCheck)
        {
            if (char.IsDigit(c))
            {
                return true;
            }
        }
        return false;
    }
}

class StringLengthChecker : StringChecker
{
    protected override bool PerformCheck(string stringToCheck)
    {
        return stringToCheck.Length >= 8; 
    }
}

class StringUpperCaseChecker : StringChecker
{
    protected override bool PerformCheck(string stringToCheck)
    {
        foreach (char c in stringToCheck)
        {
            if (char.IsUpper(c))
            {
                return true;
            }
        }
        return false;
    }
}

class StringLowerCaseChecker : StringChecker
{
    protected override bool PerformCheck(string stringToCheck)
    {
        foreach (char c in stringToCheck)
        {
            if (char.IsLower(c))
            {
                return true;
            }
        }
        return false;
    }
}

class PasswordValidator
{
    private StringChecker checker;
    public PasswordValidator(StringChecker checker) { this.checker = checker; }
    public bool ValidatePassword(string password)
    {
        return checker.Check(password);
    }
}

public class Tester
{
    public static void Test()
    {
        StringChecker digitChecker = new StringDigitChecker();
        StringChecker lengthChecker = new StringLengthChecker();
        StringChecker upperCaseChecker = new StringUpperCaseChecker();
        StringChecker lowerCaseChecker = new StringLowerCaseChecker();

        digitChecker.SetNext(lengthChecker);
        lengthChecker.SetNext(upperCaseChecker);
        upperCaseChecker.SetNext(lowerCaseChecker);

        PasswordValidator validator = new PasswordValidator(digitChecker);

        string password1 = "Abcdefg1"; // Valid password
        string password2 = "Abcdef";   // Invalid password (no digit)
        string password3 = "1234567";  // Invalid password (no upper case)

        Console.WriteLine($"Is password '{password1}' valid? {validator.ValidatePassword(password1)}");
        Console.WriteLine($"Is password '{password2}' valid? {validator.ValidatePassword(password2)}");
        Console.WriteLine($"Is password '{password3}' valid? {validator.ValidatePassword(password3)}");
    }
}