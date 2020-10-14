using System;

using JetBrains.Annotations;

namespace Sim
{
  /// <summary>
  /// Defines functionality for an object that can be either alive or dead, meaning an organism.
  /// </summary>
  public interface IOrganism : IUnit
  {
    /// <summary>
    /// Raised when the creature has been revived.
    /// </summary>
    event EventHandler Revived;

    /// <summary>
    /// Raised when the creature has been killed.
    /// </summary>
    event EventHandler Killed;

    /// <summary>
    /// Raised when the creature has been healed.
    /// </summary>
    event EventHandler Healed;


    /// <summary>
    /// Gets the last attacker of the creature.
    /// </summary>
    IOrganism LastAttacker { get; }

    /// <summary>
    /// Gets the last killer of the creature.
    /// </summary>
    IOrganism LastKiller { get; }


    /// <summary>
    /// Gets a value indicating whether the creature is dead.
    /// </summary>
    bool IsDead { get; }

    /// <summary>
    /// Gets a value indicating whether the creature is alive.
    /// </summary>
    bool IsAlive { get; }


    /// <summary>
    /// Gets a value indicating whether the creature was killed.
    /// </summary>
    bool WasKilled { get; }


    /// <summary>
    /// Kills the creature, specifying the killer.
    /// </summary>
    /// <param name="killer">The killer.</param>
    void Kill([NotNull] IOrganism killer);

    /// <summary>
    /// Revives the creature, specifying the reviver.
    /// </summary>
    /// <param name="reviver">The reviver.</param>
    void Revive([NotNull] IOrganism reviver);

    /// <summary>
    /// Heals the creature, specifying the healer.
    /// </summary>
    /// <param name="healer">The healer.</param>
    /// <param name="amount">The healing amount (hp).</param>
    void Heal([NotNull] IOrganism healer, int amount);
  }

}