

using Classes;
using TanksRework;
/**
* @(#) MoveUp.cs
*/
namespace TankaiRework.Commander
{
	public class Shoot : ICommand
	{
		Transportas receiver;
		int[,] zemelapis;
		
		public void Execute(  )
		{
			this.receiver.Move(0, -1, zemelapis);
		}
		
		public Shoot( Transportas receiver, int[,] zemelapis )
		{
			this.receiver = receiver;
			this.zemelapis = zemelapis;
		}
		
	}
	
}
