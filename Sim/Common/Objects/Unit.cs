using System;

using JetBrains.Annotations;

using Sim.API.Objects;
using Sim.API.Templates;
using Sim.Common.Data;

namespace Sim.Common.Objects
{
  public abstract class Unit : Thing, IUnit
  {
    /// <summary>
    /// Raised when the health value of the object has changed.
    /// </summary>
    public event EventHandler HealthValueChanged;

    /// <summary>
    /// Raised when the object has taken damage.
    /// </summary>
    public event EventHandler DamageTaken;


    /// <summary>
    /// Raised when the object has been broken.
    /// </summary>
    public event EventHandler Broken;

    /// <summary>
    /// Raised when the object has been fixed.
    /// </summary>
    public event EventHandler Fixed;


    /// <summary>
    /// Initializes a new instance of the <see cref="Unit"/> class, specifying its unique instance identifier and template.
    /// </summary>
    /// <param name="instanceId">The unique instance identifier.</param>
    /// <param name="template">The template to use.</param>
    protected Unit(ulong instanceId, [CanBeNull] IUnitTemplate template) : base(instanceId, template)
    {
      Health = template?.MaxHealth ?? 100;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Unit"/> class.
    /// </summary>
    protected Unit()
    {
      Health = 0;
    }


    /// <summary>
    /// Gets the template of the <see cref="Unit"/>.
    /// </summary>
    public new IUnitTemplate Template => base.Template as IUnitTemplate;


    /// <summary>
    /// Gets the current health value of the <see cref="Unit"/>.
    /// </summary>
    public int Health { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the <see cref="Unit"/> is broken.
    /// </summary>
    public bool IsBroken { get; private set; }


    /// <summary>
    /// Applies the specified <see cref="DamageInfo"/> to the <see cref="Unit"/>.
    /// </summary>
    /// <param name="damageInfo">The damage info to apply.</param>
    /// <returns>The resulting health value.</returns>
    public int ApplyDamage(DamageInfo damageInfo)
    {
      SetHealth(Health - damageInfo.HealthValue);
      OnHealthValueChanged();

      return Health;
    }


    /// <summary>
    /// Fixes the <see cref="Unit"/>.
    /// </summary>
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

    /// <summary>
    /// Breaks the <see cref="Unit"/>.
    /// </summary>
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

    /// <summary>
    /// Sets the health value of the <see cref="Unit"/>.
    /// </summary>
    /// <param name="hpValue">The new health value.</param>
    public void SetHealth(int hpValue)
    {
      if (hpValue > Template.MaxHealth)
      {
        hpValue = Template.MaxHealth;
      }

      if (hpValue <= 0)
      {
        hpValue = 0;
      }

      Health = hpValue;
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