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
		private Player _player;
		public Level()
		{
			_levelCreator = new LevelCreator();
			_player = new Player();
			AddChild( _levelCreator );
<<<<<<< HEAD
			//_player = new Player();
=======

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

>>>>>>> 7c69aab6556b4a3a196ac24ba2e2a7323dd455bd
		}
	}
}
