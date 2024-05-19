public class SpawnManger
{
    public int mobs = 0;
    public void SpawnMob()
    {
        mobs++;
    }
    public void UnspawnMob()
    {
        mobs--;
    }
}

public class EnemyManager
{
    public int enemies = 0;
    public void SpawnEnemie()
    {
        enemies++;
    }
}
public class EffectManager
{
    public void MagicEffect()
    {
        Console.WriteLine("Magic");
    }
    public void FireEffect()
    {
        Console.WriteLine("Fire");
    }
    public void WaterEffect()
    {
        Console.WriteLine("Water");
    }
}
public interface IManager
{
    public void ApplyEffect(string type);
    public void RandomSpawn();
}

public class Manager : IManager
{
    SpawnManger spawnManger;
    EffectManager effectManager;
    EnemyManager enemyManager;
    public Manager()
    {
        spawnManger = new SpawnManger();
        effectManager = new EffectManager();
        enemyManager = new EnemyManager();
    }
    public void ApplyEffect(string type)
    {
        if (type == "Magic")
        {
            effectManager.MagicEffect();
        }
        else if (type == "Fire")
        {
            effectManager.FireEffect();
        }
        else if (type == "Water")
        {
            effectManager.WaterEffect();
        }
        else
        {
            throw new Exception("Effect type doesn't exist");
        }
    }

    public void RandomSpawn()
    {
        Random random = new Random();
        if (random.Next(0, 1) == 0)
        {
            spawnManger.SpawnMob();
        }
        else if (random.Next(0, 1) == 1)
        {
            enemyManager.SpawnEnemie();
        }
        else
        {
            spawnManger.UnspawnMob();
        }
    }
}

class Tester
{
    public static void Test()
    {
        IManager manager = new Manager();
        manager.ApplyEffect("Fire");
        manager.RandomSpawn();
    }
}