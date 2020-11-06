/**
 * @(#) SprogstanciosKulkos.cs
 */

namespace TankaiRework.ER
{
	public class SprogstanciosKulkos : KulkosDecorator
	{
		public SprogstanciosKulkos(Kulkos c) : base(c)
        {
        }
		public override int CalculateDamage(int zala)
		{
			return base.CalculateDamage(zala) * 5;
		}

	}
	
}
