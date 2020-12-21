/**
 * @(#) PaprastosKulkos.cs
 */

namespace TankaiRework.ER
{
	public class PaprastosKulkos : Kulkos
	{
		public PaprastosKulkos(int x, int y, string txture)
		{
			cordx = x;
			cordy = y;
			texture = txture;
		}
		public PaprastosKulkos(string txture)
		{
			texture = txture;
		}
		public PaprastosKulkos()
		{
		}
		public override int CalculateDamage(int zala)
		{
			return zala;
		}
		
	}
	
}
