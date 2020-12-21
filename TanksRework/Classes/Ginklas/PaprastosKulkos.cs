

using System.Drawing;
/**
* @(#) PaprastosKulkos.cs
*/
namespace TankaiRework.ER
{
	public class PaprastosKulkos : Kulkos
	{
		public PaprastosKulkos(int x, int y, Image txture)
		{
			cordx = x;
			cordy = y;
			texture = txture;
		}
		public PaprastosKulkos(int x, int y)
		{
			cordx = x;
			cordy = y;
		}
		public PaprastosKulkos(Image txture)
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
