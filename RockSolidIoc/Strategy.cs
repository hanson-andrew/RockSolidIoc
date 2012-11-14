using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public abstract class Strategy<T> : IChain<T>
  {
    public virtual T NextStep { get; set; }
  }
}