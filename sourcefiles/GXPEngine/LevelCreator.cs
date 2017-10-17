using System;
using System.Collections.Generic;
namespace GXPEngine
{
	public class LevelCreator
	{
		private string filename;
		private List<Layer> _layerList;
		private const int NUMLAYERS = 4;
		private Tile[,] tileArray;
		public LevelCreator( Level level )
		{
			_layerList = new List<Layer>();

			for (int i = 0; i < NUMLAYERS; i++)
			{
				Layer layer = new Layer( "layer-" + i + ".csv" );
				_layerList.Add( layer );
				_layerList[i].CreateLayer();

				tileArray = new Tile[_layerList[0].GetLayerWidth, _layerList[0].GetLayerWidth];

				for (int j = 0; j < _layerList[i].GetLayerWidth; j++)
				{
					for (int k = 0; k < _layerList[i].GetLayerHeight; k++)
					{
						Tile tile = new Tile( filename, 1, 1 );
						tile.SetFrame(int.Parse(_layerList[i].GetLayerValue(j,k)));
						tile.x = j * tile.width;
						tile.y = k * tile.height;
					}
				}
			}
		}
	}
}
