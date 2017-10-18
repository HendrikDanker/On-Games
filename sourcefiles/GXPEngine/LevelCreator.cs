using System.Collections.Generic;
namespace GXPEngine
{
	public class LevelCreator : GameObject
	{
		private string filename = "World.png";
		private List<Layer> _layerList;
		private const int NUMLAYERS = 4;
		private Tile[,] tileArray;

		public LevelCreator()
		{
			_layerList = new List<Layer>();

			for (int i = 0; i < NUMLAYERS; i++)
			{
				Layer layer = new Layer( "layer-" + i + ".csv", (LayerType)i );
				_layerList.Add( layer );
				_layerList[i].CreateLayer();
				_layerList[i].TransponseLayer();
				tileArray = new Tile[_layerList[0].GetLayerWidth, _layerList[0].GetLayerWidth];

				for (int j = 0; j < _layerList[i].GetLayerWidth; j++)
				{
					for (int k = 0; k < _layerList[i].GetLayerHeight; k++)
					{
						if (_layerList[i].GetIntValue( j, k ) != -1)
						{
							Tile tile = new Tile( filename, 10, 8, (LayerType)i );
							tileArray[j, k] = tile;
							tileArray[j, k].SetFrame( _layerList[i].GetIntValue( j, k ) );
							tileArray[j, k].x = j * tileArray[j, k].width;
							tileArray[j, k].y = k * tileArray[j, k].height;
							AddChild( tileArray[j, k] );
						}
					}
				}
			}
		}
	}
}
