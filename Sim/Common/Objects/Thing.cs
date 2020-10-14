using JetBrains.Annotations;

using Sim.API.Objects;
using Sim.API.Templates;

using UnitsNet;

namespace Sim.Common.Objects
{

  public abstract class Thing : Entity, IThing
  {
    protected Thing(ulong instanceId, [CanBeNull] IThingTemplate template) : base(instanceId, template)
    {
    }

    protected Thing()
    {
    }

    public new IThingTemplate Template => base.Template as IThingTemplate;

    public virtual Volume? Volume => Template.Volume;
    public virtual Mass? Mass => Template.Mass;
  }

}