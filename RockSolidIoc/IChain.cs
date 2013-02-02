namespace RockSolidIoc
{

	public interface IChain<T>
	{


		T NextStep { get; set; }
	}

}
