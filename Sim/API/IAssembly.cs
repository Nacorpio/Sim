using System;
using System.Collections.Generic;

using Sim.API.Objects;

namespace Sim.API
{

  public interface IAssembly<in TPart> where TPart : IPart
  {
    event EventHandler PartInstalled;
    event EventHandler PartUninstalled;

    IReadOnlyList <IPart> Parts { get; }

    void InstallPart(TPart part);
    bool UninstallPart(TPart part);
  }

}