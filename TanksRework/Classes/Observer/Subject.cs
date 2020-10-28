using System;
using System.Collections.Generic;
using System.Text;

namespace Classes.Observer
{
	public abstract class Subject
	{
		public List<IObserver> observers;

		public void pranesti(List<Transportas> priesai)//POSTina savo pos ir serveri, mainais gauna priesu pos ir updeitina.
		{
			observers.ForEach(o =>
			{
				o.atnaujinti(priesai);
			});
		}

		public void prideti(IObserver observer)
		{
			observers.Add(observer);
		}

		public void pasalinti(IObserver observer)
		{
			observers.Remove(observer);
		}

	}
}
