

using Classes;
using TanksRework;
/**
* @(#) MoveUp.cs
*/
namespace TankaiRework.Commander
{
	public class MoveUp : ICommand
	{
		Transportas receiver;
		
		public void Execute(  )
		{
			this.receiver.Move(0, -1);
		}
		
		public MoveUp( Transportas receiver )
		{
			this.receiver = receiver;
		}
		
	}
	
}
