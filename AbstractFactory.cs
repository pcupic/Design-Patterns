Tester.TestWaterLevel();
Tester.TestFireLevel();

public abstract class Wizard
{
    public abstract void DoMagic();
}

public abstract class Goblin
{
    public abstract void DoDamage();
}

public class FireWizard : Wizard
{
    public override void DoMagic()
    {
        Console.WriteLine("Do Fire Magic");
    }
}

public class WaterGoblin : Goblin
{
    public override void DoDamage()
    {
        Console.WriteLine("Do Water Damage");
    }
}

public class WaterWizard : Wizard
{
    public override void DoMagic()
    {
        Console.WriteLine("Do Water Magic");
    }
}

public class FireGoblin : Goblin
{
    public override void DoDamage()
    {
        Console.WriteLine("Do Fire Damage");
    }
}

public abstract class CharacterFactory
{
    public abstract Wizard CreateWizard();
    public abstract Goblin CreateGoblin();
} 

public class FireCharacterFactory: CharacterFactory
{
    public override Goblin CreateGoblin()
    {
        return new FireGoblin();
    }
    public override Wizard CreateWizard()
    {
        return new FireWizard();
    }
}

public class WaterCharacterFactory : CharacterFactory
{
    public override Goblin CreateGoblin()
    {
        return new WaterGoblin();
    }
    public override Wizard CreateWizard()
    {
        return new WaterWizard();
    }
}
public class GameManager
{
    private CharacterFactory factory;

    public GameManager(CharacterFactory factory)
    {
        this.factory = factory;
    }

    public void PlayLevel()
    {
        Wizard wizard = factory.CreateWizard();
        Goblin goblin = factory.CreateGoblin();

        wizard.DoMagic();
        goblin.DoDamage();
    }
}

public static class Tester
{
    public static void TestWaterLevel()
    {
        Console.WriteLine("Testing Water Level:");
        CharacterFactory waterFactory = new WaterCharacterFactory();
        GameManager waterGameManager = new GameManager(waterFactory);
        waterGameManager.PlayLevel();
        Console.WriteLine();
    }

    public static void TestFireLevel()
    {
        Console.WriteLine("Testing Fire Level:");
        CharacterFactory fireFactory = new FireCharacterFactory();
        GameManager fireGameManager = new GameManager(fireFactory);
        fireGameManager.PlayLevel();
        Console.WriteLine();
    }
}

/* Poveži klase i metode s ulogama u obrascu:
 * 
 * Apstraktna tvornica -> CharacterFactory
 * Konkretna tvornica -> FireCharachterFactory
 * Proizvod	-> Goblin
 * Konkretni proizvod -> WaterWizard
 * Klijentski kod -> GameManager
 * Obitelj -> Fire
 * Metoda stvaranja -> CreateWizard
 */