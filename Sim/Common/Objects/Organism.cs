using System;

using JetBrains.Annotations;

using Sim.API.Objects;
using Sim.API.Templates;

namespace Sim.Common.Objects
{
  /// <summary>
  /// Represents any organism.
  /// </summary>
  public class Organism : Unit, IOrganism
  {
    /// <summary>
    /// Raised when the <see cref="Organism"/> has been revived.
    /// </summary>
    public event EventHandler Revived;

    /// <summary>
    /// Raised when the <see cref="Organism"/> has been killed.
    /// </summary>
    public event EventHandler Killed;

    /// <summary>
    /// Raised when the <see cref="Organism"/> has been healed.
    /// </summary>
    public event EventHandler Healed;

    /// <summary>
    /// Raised when the <see cref="Organism"/> has died.
    /// </summary>
    public event EventHandler Died;

    /// <summary>
    /// Initializes a new instance of the <see cref="Organism"/> class, specifying its unique instance identifier and template.
    /// </summary>
    /// <param name="instanceId">The unique instance identifier.</param>
    /// <param name="template">The template to use.</param>
    public Organism(ulong instanceId, [NotNull] ICreatureTemplate template) : base(instanceId, template)
    {
      LastAttacker = null;
      LastKiller = null;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Organism"/> class.
    /// </summary>
    public Organism()
    {
      LastAttacker = null;
      LastKiller = null;
    }


    /// <summary>
    /// Gets the last attacker of the <see cref="Organism"/>.
    /// </summary>
    public IOrganism LastAttacker { get; internal set; }

    /// <summary>
    /// Gets the last killer of the <see cref="Organism"/>,.
    /// </summary>
    public IOrganism LastKiller { get; internal set; }


    /// <summary>
    /// Gets a value indicating whether the <see cref="Organism"/> is dead.
    /// </summary>
    public bool IsDead => !IsAlive;

    /// <summary>
    /// Gets a value indicating whether the <see cref="Organism"/> is alive.
    /// </summary>
    public bool IsAlive { get; private set; }


    /// <summary>
    /// Gets a value indicating whether the <see cref="Organism"/> was killed.
    /// </summary>
    public bool WasKilled => LastKiller != null;


    /// <summary>
    /// Kills the <see cref="Organism"/>, specifying the killer.
    /// </summary>
    /// <param name="killer">The killer.</param>
    public void Kill(IOrganism killer)
    {
      if (IsDead)
      {
        return;
      }

      IsAlive = false;

      SetHealth(0);
      OnKilled();
    }

    /// <summary>
    /// Revives the <see cref="Organism"/>, specifying the reviver.
    /// </summary>
    /// <param name="reviver">The reviver.</param>
    public void Revive(IOrganism reviver)
    {
      if (!IsDead)
      {
        return;
      }

      IsAlive = true;

      SetHealth(Template.MaxHealth);
      OnRevived();
    }

    /// <summary>
    /// Heals the <see cref="Organism"/>, specifying the healer.
    /// </summary>
    /// <param name="healer">The healer.</param>
    /// <param name="amount">The healing amount (hp).</param>
    public void Heal(IOrganism healer, int amount)
    {
      if (IsDead)
      {
        return;
      }

      if (Health + amount > Template.MaxHealth)
      {
        SetHealth(Template.MaxHealth);
        return;
      }

      SetHealth(Health + amount);
      OnHealed();
    }

    /// <summary>
    /// Makes the <see cref="Organism"/> die.
    /// </summary>
    public void Die()
    {
      if (IsDead)
      {
        return;
      }

      IsAlive = false;
      OnDied();
    }

    protected virtual void OnRevived()
    {
      Revived?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnKilled()
    {
      Killed?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnHealed()
    {
      Healed?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnDied()
    {
      Died?.Invoke(this, EventArgs.Empty);
    }
  }

}