

using System.Drawing;
/**
* @(#) Kulkos.cs
*/
namespace TankaiRework.ER
{
	public abstract class Kulkos
	{
		public int cordx { get; set; } = -1;
		public int cordy { get; set; } = -1;
		public Image texture { get; set; }
		public abstract int CalculateDamage( int zala );
		
	}
	
}
