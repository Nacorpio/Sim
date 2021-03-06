﻿using JetBrains.Annotations;

using Sim.API.Objects;
using Sim.API.Templates;

namespace Sim.Common.Objects
{
  public class Entity : IEntity
  {
    public static Entity Null => new Entity();

    protected Entity(ulong instanceId, [CanBeNull] ITemplate template)
    {
      InstanceId = instanceId;
      Template = template;
    }

    protected Entity()
    {
      InstanceId = null;
      Template = null;
    }

    public ulong? InstanceId { get; }
    public ulong? TemplateId => Template.Id;

    public ITemplate Template { get; }

    public bool IsNull => InstanceId == null;
  }

}