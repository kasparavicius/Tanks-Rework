/**
 * @(#) DeganciosKulkos.cs
 */

namespace TankaiRework.ER
{
	public class DeganciosKulkos : KulkosDecorator
	{
		public DeganciosKulkos(Kulkos c) : base(c)
        {
        }
		public override int CalculateDamage(int zala)
		{
			return base.CalculateDamage(zala) * 2;
		}
	}
	
}
