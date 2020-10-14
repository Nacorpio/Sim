using System;

namespace Sim
{
  /// <summary>
  /// Defines functionality for an object that can be fixed.
  /// </summary>
  public interface IFixable
  {
    /// <summary>
    /// Raised when the object has been fixed.
    /// </summary>
    event EventHandler Fixed;

    /// <summary>
    /// Fixes the object.
    /// </summary>
    void Fix();
  }

}