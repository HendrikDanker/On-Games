using System;
using System.IO;
using System.Collections.Generic;
namespace GXPEngine
{
	public class Layer : GameObject
	{
		private string[,] _stringValues;
		private int[,] _intValues;
		private string _filename;
		private LayerType _layerType;

		public Layer( string filename, LayerType layerType )
		{
			try
			{
				_filename = filename;
				_layerType = layerType;
			}
			catch
			{
				Console.WriteLine( "File not found!" );
			}
		}

		public string[,] CreateLayer()
		{

			StreamReader sr = new StreamReader( _filename );
			var lines = new List<string[]>();
			int row = 0;

			while (!sr.EndOfStream)
			{
				string[] Line = sr.ReadLine().Split( ',' );
				lines.Add( Line );
				row++;
			}

			var data = lines.ToArray();

			_stringValues = new string[data.GetLength( 0 ), row];
			_intValues = new int[_stringValues.GetLength( 0 ), _stringValues.GetLength( 1 )];

			for (int i = 0; i < _stringValues.GetLength( 0 ); i++)
			{
				for (int j = 0; j < _stringValues.GetLength( 1 ); j++)
				{
					_stringValues[i, j] = data[i][j];
					_intValues[i, j] = Int32.Parse( _stringValues[i, j] );
				}
			}
			return _stringValues;
		}

		public void TransponseLayer()
		{
			_stringValues = Mathf.Transponse2( _stringValues );
			_intValues = Mathf.Transponse2( _intValues );
		}

		public int GetLayerWidth { get { return _stringValues.GetLength( 0 ); } }
		public int GetLayerHeight { get { return _stringValues.GetLength( 1 ); } }
		public string[,] GetLayerArray { get { return _stringValues; } }
		/// <summary>
		/// Returns the designatd value of the layer on the parsed x and y values
		/// </summary>
		/// <returns>The layer item.</returns>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public string GetStringValue( int x, int y )
		{
			return _stringValues[x, y];
		}
		public int GetIntValue( int x, int y )
		{
			return _intValues[x, y];
		}
		public LayerType GetLayerType { get { return _layerType; } }
	}
}

