using System;
using System.IO;
using System.Collections.Generic;
namespace GXPEngine
{
	public class Level : GameObject
	{
		private Player _player;
		private GameObject _focus;
		private LevelCreator _levelCreator;
		public Level()
		{
			_levelCreator = new LevelCreator();
			AddChild( _levelCreator );

			AddChild( _player );
			_focus = _player;

			game.OnAfterStep += UpdateCamera;
		}

		void Update()
		{

		}

		private void UpdateCamera()
		{
			if (_focus != null)
			{
				x = (game.width / 2 - _focus.x);
				y = (game.height / 2 - _focus.y);

			}

		}
	}
}
