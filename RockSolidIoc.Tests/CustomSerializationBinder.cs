using System.Runtime.Serialization;

namespace RockSolidIoc.Tests
{

  public class CustomSerializationBinder : SerializationBinder
  {
    public override System.Type BindToType(string assemblyName, string typeName)
    {
      return System.Reflection.Assembly.Load(assemblyName).GetType(typeName);
    }
  }

}