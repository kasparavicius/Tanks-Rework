/**
 * @(#) Ginklas.cs
 */

namespace TankaiRework.ER
{
	public class Ginklas
	{
		int Nuotolis;
		int Zala;
		Kulkos Kulkos;

		public Ginklas(int nuotolis, int zala)
        {
			Zala = zala;
			Nuotolis = nuotolis;
			Kulkos = new PaprastosKulkos();
        }

		public void AddPowerUp(int tipas) //1 - degancios kulkos, 2 - sprogstancios
        {
            switch (tipas)
            {
				case 1:
					Kulkos = new DeganciosKulkos(Kulkos);
					break;
				case 2:
					Kulkos = new SprogstanciosKulkos(Kulkos);
					break;
                default:
                    break;
            }
        }
		public void RemovePowerUps()
        {
			Kulkos = new PaprastosKulkos();
        }

		public int GetZala()
        {
			return Kulkos.CalculateDamage(Zala);
        }

	}
	
}
