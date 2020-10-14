using System;

namespace Sim
{
  /// <summary>
  /// Defines functionality for a part that can be installed to an assembly.
  /// </summary>
  public interface IPart : IThing
  {
    /// <summary>
    /// Raised when the <see cref="IPart"/> has been installed to an assembly.
    /// </summary>
    event EventHandler Installed;

    /// <summary>
    /// Raised when the <see cref="IPart"/> has been uninstalled from an assembly.
    /// </summary>
    event EventHandler Uninstalled;


    /// <summary>
    /// Gets the template of the <see cref="IPart"/>.
    /// </summary>
    new IPartTemplate Template { get; }


    /// <summary>
    /// Gets a value indicating whether the <see cref="IPart"/> is enabled.
    /// </summary>
    bool IsEnabled { get; }


    /// <summary>
    /// Fixes the part.
    /// </summary>
    void Fix();

    /// <summary>
    /// Breaks the part.
    /// </summary>
    void Break();


    /// <summary>
    /// Sets whether the <see cref="IPart"/> is enabled.
    /// </summary>
    /// <param name="value">The new value.</param>
    void SetEnabled(bool value);
  }

}