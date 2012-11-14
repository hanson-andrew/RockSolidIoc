using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockSolidIoc.Tests
{

  public class PropertyAndMethodInitialization
  {
    [IocDependency()]
    public object O { get; set; }

    public string S { get; set; }

    [IocDependency()]
    public void SetupObject(string s)
    {
      this.S = s;
    }
  }

}