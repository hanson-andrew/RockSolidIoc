using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockSolidIoc.Tests
{

  public class ObjectChain : IChain<ObjectChain>
  {
    public ObjectChain NextStep { get; set; }
  }

}