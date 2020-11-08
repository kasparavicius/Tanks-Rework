

using Classes;
/**
* @(#) MoveDown.cs
*/
namespace TankaiRework.Commander
{
	public class MoveDown : ICommand
	{
		Transportas receiver;
		
		public void Execute(  )
		{
			this.receiver.Move(0, 1);
		}

		public MoveDown( Transportas receiver )
		{
			this.receiver = receiver;
		}
		
	}
	
}
