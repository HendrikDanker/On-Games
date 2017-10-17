using System;
using System.IO;
using System.Collections.Generic;
namespace GXPEngine
{
	public class Level : GameObject
	{
		private LayerHandler _layerHandler;
		public Level()
		{
			_layerHandler = new LayerHandler(this);
		}
	}
}
