using System;

using JetBrains.Annotations;

namespace Sim
{
  public abstract class Unit : Thing, IUnit
  {
    public event EventHandler HealthValueChanged;
    public event EventHandler DamageTaken;

    public event EventHandler Broken;
    public event EventHandler Fixed;

    protected Unit(ulong instanceId, [CanBeNull] IUnitTemplate template) : base(instanceId, template)
    {
      Health = template?.MaxHealth ?? 100;
    }

    protected Unit()
    {
      Health = 0;
    }

    public new IUnitTemplate Template => base.Template as IUnitTemplate;

    public int Health { get; private set; }
    public bool IsBroken { get; private set; }

    public int ApplyDamage(DamageInfo damageInfo)
    {
      SetHealth(Health - damageInfo.HealthValue);
      OnHealthValueChanged();
    }

    public void Fix()
    {
      if (!IsBroken)
      {
        return;
      }

      IsBroken = false;

      SetHealth(Template.MaxHealth);
      OnFixed();
    }

    public void Break()
    {
      if (IsBroken)
      {
        return;
      }

      IsBroken = true;

      SetHealth(0);
      OnBroken();
    }

    public void SetHealth(int newValue)
    {
      if (newValue > Template.MaxHealth)
      {
        newValue = Template.MaxHealth;
      }

      if (newValue <= 0)
      {
        newValue = 0;
      }

      Health = newValue;
      OnHealthValueChanged();
    }

    protected virtual void OnHealthValueChanged()
    {
      HealthValueChanged?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnDamageTaken()
    {
      DamageTaken?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnBroken()
    {
      Broken?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnFixed()
    {
      Fixed?.Invoke(this, EventArgs.Empty);
    }
  }

}