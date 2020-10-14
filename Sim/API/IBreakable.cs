using System;

namespace Sim.API
{
  /// <summary>
  /// Defines functionality for an object that can be broken.
  /// </summary>
  public interface IBreakable
  {
    /// <summary>
    /// Raised when the object has been broken.
    /// </summary>
    event EventHandler Broken;


    /// <summary>
    /// Gets a value indicating whether the object is broken.
    /// </summary>
    bool IsBroken { get; }


    /// <summary>
    /// Breaks the object.
    /// </summary>
    void Break();
  }

}