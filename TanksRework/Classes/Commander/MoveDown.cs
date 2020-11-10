

using Classes;
/**
* @(#) MoveDown.cs
*/
namespace TankaiRework.Commander
{
	public class MoveDown : ICommand
	{
		Transportas receiver;
		int[,] zemelapis;
		
		public void Execute(  )
		{
			this.receiver.Move(0, 1, zemelapis);
		}

		public MoveDown( Transportas receiver, int[,] zemelapis )
		{
			this.receiver = receiver;
			this.zemelapis = zemelapis;
		}
		
	}
	
}
