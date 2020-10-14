using System;

using JetBrains.Annotations;

using Sim.API.Objects;
using Sim.API.Templates;

namespace Sim.Common.Objects
{

  public abstract class PartBase : Unit, IPart
  {
    public event EventHandler Installed;
    public event EventHandler Uninstalled;

    public event EventHandler Fixed;
    public event EventHandler Broken;

    protected PartBase(ulong instanceId, [CanBeNull] IPartTemplate template) : base(instanceId, template)
    {
      SetEnabled(true);
    }

    protected PartBase()
    {
    }

    public new IPartTemplate Template => base.Template as IPartTemplate;

    public bool IsEnabled { get; private set; }
    public bool IsBroken { get; private set; }


    public void SetEnabled(bool value)
    {
      IsEnabled = value;
    }


    public void Fix()
    {
      if (!IsBroken)
      {
        return;
      }

      IsBroken = false;

      SetHealth(Template.MaxHealth);
      OnFixed();
    }

    public void Break()
    {
      if (IsBroken)
      {
        return;
      }

      IsBroken = true;

      SetHealth(0);
      OnBroken();
    }


    internal virtual void OnInstalled()
    {
      Installed?.Invoke(this, EventArgs.Empty);
    }

    internal virtual void OnUninstalled()
    {
      Uninstalled?.Invoke(this, EventArgs.Empty);
    }


    protected virtual void OnFixed()
    {
      Fixed?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnBroken()
    {
      Broken?.Invoke(this, EventArgs.Empty);
    }

  }

}