// Type: Microsoft.Exchange.Management.PowerShell.AdminPSSnapIn
// Assembly: Microsoft.Exchange.PowerShell.Configuration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Program Files\Microsoft\Exchange Server\Bin\Microsoft.Exchange.PowerShell.Configuration.dll

using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;

namespace Microsoft.Exchange.Management.PowerShell
{
  public sealed class AdminPSSnapIn : ExchangePSSnapIn
  {
    public static readonly string PSSnapInName = "Microsoft.Exchange.Management.PowerShell.Admin";
    private Collection<CmdletConfigurationEntry> cmdlets;

    public override string Name
    {
      get
      {
        return AdminPSSnapIn.PSSnapInName;
      }
    }

    public override Collection<CmdletConfigurationEntry> Cmdlets
    {
      get
      {
        if (this.cmdlets == null)
        {
          this.cmdlets = new Collection<CmdletConfigurationEntry>();
          foreach (CmdletConfigurationEntry configurationEntry in CmdletConfigurationEntries.ExchangeCmdletConfigurationEntries)
            this.cmdlets.Add(configurationEntry);
          foreach (CmdletConfigurationEntry configurationEntry in CmdletConfigurationEntries.ExchangeNonEdgeCmdletConfigurationEntries)
            this.cmdlets.Add(configurationEntry);
        }
        return this.cmdlets;
      }
    }

    static AdminPSSnapIn()
    {
    }
  }
}
