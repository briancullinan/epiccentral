// Type: Microsoft.VisualStudio.TestTools.UnitTesting.TestContext
// Assembly: Microsoft.VisualStudio.QualityTools.UnitTestFramework, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// Assembly location: c:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\PublicAssemblies\Microsoft.VisualStudio.QualityTools.UnitTestFramework.dll

using Microsoft.VisualStudio.TestTools.Resources;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Web.UI;

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
  public abstract class TestContext
  {
    public const string AspNetDevelopmentServerPrefix = "AspNetDevelopmentServer.";

    public abstract IDictionary Properties { get; }

    public abstract DataRow DataRow { get; }

    public abstract DbConnection DataConnection { get; }

    public virtual string TestRunDirectory
    {
      get
      {
        return this.GetProperty<string>("TestRunDirectory");
      }
    }

    public virtual string DeploymentDirectory
    {
      get
      {
        return this.GetProperty<string>("DeploymentDirectory");
      }
    }

    public virtual string ResultsDirectory
    {
      get
      {
        return this.GetProperty<string>("ResultsDirectory");
      }
    }

    public virtual string TestRunResultsDirectory
    {
      get
      {
        return this.GetProperty<string>("TestRunResultsDirectory");
      }
    }

    public virtual string TestResultsDirectory
    {
      get
      {
        return this.GetProperty<string>("TestResultsDirectory");
      }
    }

    public virtual string TestDir
    {
      get
      {
        return this.GetProperty<string>("TestDir");
      }
    }

    public virtual string TestDeploymentDir
    {
      get
      {
        return this.GetProperty<string>("TestDeploymentDir");
      }
    }

    public virtual string TestLogsDir
    {
      get
      {
        return this.GetProperty<string>("TestLogsDir");
      }
    }

    public virtual string FullyQualifiedTestClassName
    {
      get
      {
        return this.GetProperty<string>("FullyQualifiedTestClassName");
      }
    }

    public virtual string TestName
    {
      get
      {
        return this.GetProperty<string>("TestName");
      }
    }

    public virtual UnitTestOutcome CurrentTestOutcome
    {
      get
      {
        return UnitTestOutcome.Unknown;
      }
    }

    public virtual Page RequestedPage
    {
      get
      {
        return this.GetProperty<Page>("RequestedPage");
      }
    }

    public abstract void WriteLine(string format, params object[] args);

    public abstract void AddResultFile(string fileName);

    public abstract void BeginTimer(string timerName);

    public abstract void EndTimer(string timerName);

    private T GetProperty<T>(string name) where T : class
    {
      object obj = this.Properties[(object) name];
      if (obj != null && !(obj is T))
        throw new InvalidCastException((string) FrameworkMessages.InvalidPropertyType((object) name, (object) obj.GetType(), (object) typeof (T)));
      else
        return (T) obj;
    }
  }
}
