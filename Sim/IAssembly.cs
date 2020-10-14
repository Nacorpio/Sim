using System;
using System.Collections.Generic;

namespace Sim
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