using System;

namespace RockSolidIoc
{

	public interface ITupleMap<T1, T2, TMappedTo> : IDisposable
	{

		void AddOrUpdate(T1 t1, T2 t2, TMappedTo tMappedTo);
		void RemoveMapping(T1 t1, T2 t2);
		bool IsInMap(T1 t1, T2 t2);
		TMappedTo GetMappedObject(T1 t1, T2 t2);

	}

}
