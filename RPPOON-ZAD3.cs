public class Mail
{
    public string Subject { get; set; }
    public string Content { get; set; }
    public string Recipient { get; set; }
    public string Attachments { get; set; }
}

public interface IMailConstructor
{
    IMailConstructor SetSubject(string subject);
    IMailConstructor SetContent(string content);
    IMailConstructor SetRecipient(string recipient);
    IMailConstructor SetAttachments(string attachments);
    IMailConstructor Reset();
    Mail Build();
}

public class MailConstructor : IMailConstructor
{
    Mail mail;
    public MailConstructor()
    {
        mail = new Mail();
    }
    public IMailConstructor SetSubject(string subject)
    {
        mail.Subject = subject;
        return this;
    }
    public IMailConstructor SetRecipient(string recipient)
    {
        mail.Recipient = recipient;
        return this;
    }
    public IMailConstructor SetContent(string content)
    {
        mail.Content = content;
        return this;
    }
    public IMailConstructor SetAttachments(string attachments)
    {
        mail.Attachments = attachments;
        return this;
    }
    public IMailConstructor Reset()
    {
        mail = new Mail();
        return this;
    }
    public Mail Build()
    {
        return mail;
    }
}

public class SMTP
{
    IMailConstructor mailConstructor;
    public SMTP(IMailConstructor mailConstructor)
    {
        this.mailConstructor = mailConstructor;
    }

    public void SendNoReplyMail()
    {
        mailConstructor.SetSubject("No Reply").SetContent("Hello World").Build();
    }
}

public class WebElement
{
    string name;
    public WebElement(string name)
    {
        Console.WriteLine($"Found {name}");
        this.name = name;
    }
    public void Click()
    {
        Console.WriteLine($"Clicked {name}");
    }
}

public interface LoginPage
{
    public WebElement LoginButton();
    public WebElement UsernameInput();
    public WebElement PasswordInput();
}

public class ChromeLoginPage : LoginPage
{
    public WebElement LoginButton()
    {
        return new WebElement("Login Button");
    }
    public WebElement UsernameInput()
    {
        return new WebElement("Username Input");
    }
    public WebElement PasswordInput()
    {
        return new WebElement("Password Input");
    }
}

public abstract class LoginPageFactory
{
    public abstract LoginPage CreatePage();
}

public class ChromeLoginPageFactory : LoginPageFactory
{
    public override LoginPage CreatePage()
    {
        return new ChromeLoginPage();
    }
}