using System;
using System.IO;
using System.Collections.Generic;
namespace GXPEngine
{
	public class Level : GameObject
	{
		private LevelCreator _levelCreator;
		public Level()
		{
			_levelCreator = new LevelCreator();
			AddChild( _levelCreator );
		}
	}
}
