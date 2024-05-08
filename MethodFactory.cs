Tester.TestDragonDungeon();
Tester.TestIceDungeon();

public abstract class Dungeon
{
    public abstract void Open();
}

class DragonDungeon : Dungeon
{
    public override void Open()
    {
        Console.WriteLine("Open Dragon Dungeon");
    }
}

class IceDungeon : Dungeon
{
    public override void Open()
    {
        Console.WriteLine("Open Ice Dungeon");
    }
}

public abstract class DungeonFactory
{
    public abstract Dungeon Create();
}

public class DragonDungeonFactory : DungeonFactory
{
    public override Dungeon Create()
    {
        return new DragonDungeon();
    }
}

public class IceDungeonFactory : DungeonFactory
{
    public override Dungeon Create()
    {
        return new IceDungeon();
    }
}

class DungeonMaster
{
    DungeonFactory dungeonFactory;
    public DungeonMaster(DungeonFactory dungeonFactory)
    {
        this.dungeonFactory = dungeonFactory;
    }
    public void OpenDungeon()
    {
        dungeonFactory.Create().Open();
    }
}

public class Tester
{
    public static void TestIceDungeon()
    {
        DungeonFactory iceDungeonFactory = new IceDungeonFactory();
        DungeonMaster dungeonMaster = new DungeonMaster(iceDungeonFactory);
        dungeonMaster.OpenDungeon();
    }
    public static void TestDragonDungeon()
    {
        DungeonFactory dragonDungeonFactory = new DragonDungeonFactory();
        DungeonMaster dungeonMaster = new DungeonMaster(dragonDungeonFactory);
        dungeonMaster.OpenDungeon();
    }
}