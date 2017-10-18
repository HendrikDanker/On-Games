using System;
using System.IO;
using System.Collections.Generic;
namespace GXPEngine
{
	public class Level : GameObject
	{
		private LevelCreator _levelCreator;
		private Player _player;
		public Level()
		{
			_levelCreator = new LevelCreator();
			AddChild( _levelCreator );
			//_player = new Player();
		}
	}
}
