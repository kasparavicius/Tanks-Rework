/**
 * @(#) KulkosDecorator.cs
 */

namespace TankaiRework.ER
{
	public abstract class KulkosDecorator : Kulkos
	{
		protected Kulkos _component;
		
		public KulkosDecorator( Kulkos c )
		{
			this._component = c;
		}

		public override int CalculateDamage(int zala)
		{
			if (this._component != null)
			{
				return this._component.CalculateDamage(zala);
			}
			else
			{
				return 0;
			}
		}
		
	}
	
}
