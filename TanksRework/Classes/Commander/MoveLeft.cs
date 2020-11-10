

using Classes;
/**
* @(#) MoveLeft.cs
*/
namespace TankaiRework.Commander
{
	public class MoveLeft : ICommand
	{
		Transportas receiver;
		int[,] zemelapis;
		
		public void Execute(  )
		{
			this.receiver.Move(-1, 0, zemelapis);
		}

		public MoveLeft( Transportas receiver, int[,] zemelapis )
		{
			this.receiver = receiver;
			this.zemelapis = zemelapis;
		}
		
	}
	
}
