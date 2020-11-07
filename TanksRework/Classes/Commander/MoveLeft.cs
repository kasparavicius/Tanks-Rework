

using Classes;
/**
* @(#) MoveLeft.cs
*/
namespace TankaiRework.Commander
{
	public class MoveLeft : ICommand
	{
		Transportas receiver;
		
		public void Execute(  )
		{
			this.receiver.Move(-1, 0);
		}

		public MoveLeft( Transportas receiver )
		{
			this.receiver = receiver;
		}
		
	}
	
}
