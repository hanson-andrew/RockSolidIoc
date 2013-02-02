using System;
using System.Linq;

namespace RockSolidIoc
{

	public class OneImplementationStrategyImpl : PickRegistrationStrategy
	{

		public override object PickRegistration(System.Type type, string identifier)
		{
			if (type.IsInterface) {
                Type[] implementingTypes = AppDomain.CurrentDomain.GetAssemblies().ToList().SelectMany(s => s.GetTypes()).Where(prop => !prop.Equals(type) && type.IsAssignableFrom(prop)).ToArray();
				if (implementingTypes.Count() == 1) {
					return implementingTypes.First();
				}
			}
			if ((this.NextStep != null)) {
				return this.NextStep.PickRegistration(type, identifier);
			}
			return null;
		}
	}

}
