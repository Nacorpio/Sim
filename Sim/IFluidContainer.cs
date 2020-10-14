using System;

using UnitsNet;

namespace Sim
{
  public interface IFluidContainer
  {
    event EventHandler ContentChanged;
    event EventHandler Emptied;

    Volume Stored { get; }
    Volume Capacity { get; }

    void Refill(Volume amount);
    void Transfer(IFluidContainer recipient, Volume amount);

    void Fill();
    void Clear();
  }

}