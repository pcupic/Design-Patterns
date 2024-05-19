public interface IArrow
{
    public void ShootArrow();
}

public abstract class Bow
{
    public List<IArrow> arrows;
    public Bow(List<IArrow> arrows) { this.arrows = arrows; }
    public void ShootArrows()
    {
        foreach (var arrow in arrows) arrow.ShootArrow();
        arrows.Clear();
    }
    public void ShootArrow()
    {
        arrows[0].ShootArrow();
        arrows.Remove(arrows[0]);
    }
}

public class SteelBow : Bow
{
    public SteelBow(List<IArrow> arrows) : base(arrows) { }
}

public class RegularArrow : IArrow
{
    public void ShootArrow()
    {
        Console.WriteLine("Shoot Regular Arrow");
    }
}
public class FireArrow : IArrow
{
    public void ShootArrow()
    {
        Console.WriteLine("Shoot Fire Arrow");
    }
}

public class Tester
{
    public static void Test()
    {
        List<IArrow> arrows = new List<IArrow>()
        {
            new RegularArrow(),
            new RegularArrow(),
            new FireArrow()
        };
        SteelBow steelBow = new SteelBow(arrows);
        steelBow.ShootArrows();
    }
}