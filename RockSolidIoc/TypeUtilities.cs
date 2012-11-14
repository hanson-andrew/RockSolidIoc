using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace RockSolidIoc
{
  internal static class TypeUtilities
  {
    /// <summary>
    /// A replacement for <see cref="Type.[GetType]" />, this searches all loaded assemblies
    /// for the type name and returns the first one it finds.
    /// </summary>
    /// <param name="name">The name of the type.</param>
    public static Type GetType(string name)
    {
      Type t = Type.GetType(name);
      if (t != null)
      {
        return t;
      }
      foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
      {
        t = assembly.GetType(name, false, true);
        if (t != null)
        {
          return t;
        }
      }
      throw new ArgumentException(String.Format("Type name {0} not found in currently loaded assemblies", name));
    }
  }
}
