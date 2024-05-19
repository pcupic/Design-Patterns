Tester.Test();
    
public interface IEffect
{
    void ApplyEffect();
}

public class BaseEffect : IEffect
{
    public void ApplyEffect()
    {
        Console.WriteLine("Apply Base Effect");
    }
}

public class NoEffect : IEffect
{
    public void ApplyEffect()
    {
        Console.WriteLine("No Effect");
    }
}

public class BaseEffectDecorator : IEffect
{
    IEffect effect;
    public BaseEffectDecorator(IEffect effect)
    {
        this.effect = effect;
    }
    public virtual void ApplyEffect()
    {
        effect.ApplyEffect();
    }
}

public class HealthRegenerationEffect : BaseEffectDecorator
{
    public HealthRegenerationEffect(IEffect effect) : base(effect) { }
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        Console.WriteLine("Health Regeneration");
    }
}

public class ArmorEffectDecorator : BaseEffectDecorator
{
    public ArmorEffectDecorator(IEffect effect) : base(effect) { }
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        Console.WriteLine("Armor Increase");
    }
}
public class MagicDamageDecorator : BaseEffectDecorator
{
    public MagicDamageDecorator(IEffect effect) : base(effect) { }
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        Console.WriteLine("Magic Damage Buff");
    }
}
public class Tester
{
    public static void Test()
    {
        IEffect noEffect = new NoEffect();
        IEffect healthRegenEffect = new HealthRegenerationEffect(noEffect);
        IEffect armorEffect = new ArmorEffectDecorator(healthRegenEffect);
        IEffect magicDamageEffect = new MagicDamageDecorator(armorEffect);

        Console.WriteLine("Applying combined effects:");
        magicDamageEffect.ApplyEffect();
    }
}