

using Classes;
/**
* @(#) MoveRight.cs
*/
namespace TankaiRework.Commander
{
	public class MoveRight : ICommand
	{
		Transportas receiver;
		
		public void Execute(  )
		{
			this.receiver.Move(1, 0);
		}

		public MoveRight( Transportas receiver )
		{
			this.receiver = receiver;
		}
		
	}
	
}
