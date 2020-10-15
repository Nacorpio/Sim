using System;
using System.Collections.Generic;

using Sim.API.Objects;

namespace Sim.API
{
  /// <summary>
  /// Defines functionality for an object that is made up of parts.
  /// </summary>
  /// <typeparam name="TPart">The part type to use.</typeparam>
  public interface IAssembly<in TPart> where TPart : IPart
  {
    /// <summary>
    /// Raised when a part has been installed to the assembly.
    /// </summary>
    event EventHandler PartInstalled;

    /// <summary>
    /// Raised when a part has been uninstalled to the assembly.
    /// </summary>
    event EventHandler PartUninstalled;


    /// <summary>
    /// Gets the installed parts of the assembly.
    /// </summary>
    IReadOnlyList <IPart> Parts { get; }


    /// <summary>
    /// Installs the specified part to the assembly.
    /// </summary>
    /// <param name="part">The part to install.</param>
    void InstallPart(TPart part);

    /// <summary>
    /// Uninstalls the specified part from the assembly.
    /// </summary>
    /// <param name="part">The part to uninstall.</param>
    /// <returns><c>true</c> if the part was successfully uninstalled; otherwise, <c>false</c>.</returns>
    bool UninstallPart(TPart part);
  }

}