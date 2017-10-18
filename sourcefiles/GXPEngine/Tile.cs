using System;
namespace GXPEngine
{
	public class Tile : AnimationSprite
	{
		private LayerType _layerType;
		public Tile( string filename, int columns, int rows, LayerType layerType ) : base( filename, columns, rows )
		{
			_layerType = layerType;
		}

		public LayerType GetLayerType { get { return _layerType; } }

	}
}
