

using Classes;
/**
* @(#) MoveRight.cs
*/
namespace TankaiRework.Commander
{
	public class MoveRight : ICommand
	{
		Transportas receiver;
		int[,] zemelapis;
		
		public void Execute(  )
		{
			this.receiver.Move(1, 0, zemelapis);
		}

		public MoveRight( Transportas receiver, int[,] zemelapis )
		{
			this.receiver = receiver;
			this.zemelapis = zemelapis;
		}
		
	}
	
}
