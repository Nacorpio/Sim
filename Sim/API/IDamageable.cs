using System;

using Sim.Common.Data;

namespace Sim.API
{
  /// <summary>
  /// Defines functionality for an object that can take damage.
  /// </summary>
  public interface IDamageable : IFixable, IBreakable
  {
    /// <summary>
    /// Raised when the health value of the object has changed.
    /// </summary>
    event EventHandler HealthValueChanged;

    /// <summary>
    /// Raised when the object has taken damage.
    /// </summary>
    event EventHandler DamageTaken;


    /// <summary>
    /// Gets the health value of the object.
    /// </summary>
    int Health { get; }


    /// <summary>
    /// Applies the specified <see cref="DamageInfo"/> to the object.
    /// </summary>
    /// <param name="damageInfo">The damage info to apply.</param>
    /// <returns>The resulting health value.</returns>
    int ApplyDamage(DamageInfo damageInfo);


    /// <summary>
    /// Sets the health value of the object.
    /// </summary>
    /// <param name="hpValue">The new health value.</param>
    void SetHealth(int hpValue);
  }

}