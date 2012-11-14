using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockSolidIoc.Tests
{

  public class StandardConstruction
  {
    public object O { get; set; }
    public string S { get; set; }
    public int I { get; set; }

    public StandardConstruction(object o, string s, int i)
    {
      this.O = o;
      this.S = s;
      this.I = i;
    }
  }

}