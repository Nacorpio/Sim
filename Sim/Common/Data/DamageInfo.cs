using JetBrains.Annotations;

using Sim.API.Objects;

namespace Sim.Common.Data
{

  public readonly struct DamageInfo
  {
    public DamageInfo([NotNull] IOrganism recipient, int hpValue, [CanBeNull] IOrganism sender = null)
    {
      Sender      = sender;
      Recipient   = recipient;
      HealthValue = hpValue;
    }

    public IOrganism Sender { get; }
    public IOrganism Recipient { get; }

    public int HealthValue { get; }
  }

}