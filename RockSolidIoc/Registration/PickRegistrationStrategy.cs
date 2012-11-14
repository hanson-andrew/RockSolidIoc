using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public abstract class PickRegistrationStrategy : Strategy<PickRegistrationStrategy>
  {

    public abstract object PickRegistration(IRegistrationMap map, Type type, string identifier);

  }
}