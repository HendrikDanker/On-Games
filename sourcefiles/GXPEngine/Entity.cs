using System;
namespace GXPEngine
{
	public class Entity : AnimationSprite
	{
		protected readonly EntityType _type;
		protected float xSpeed;
		protected float ySpeed;
		protected bool _isGrounded;


		protected Entity( string filename, int columns, int rows, EntityType type ) : base( filename, columns, rows )
		{
			_type = type;
		}

		public void Update()
		{
			applyGravity();
			TryMove( xSpeed, 0 );
			TryMove( 0, ySpeed );
		}

		protected bool TryMove( float moveX, float moveY )
		{
			if (moveX == 0 && moveY == 0)
				return false;
			x += moveX;
			y += moveY;


			bool canMove = true;
			foreach (GameObject other in GetCollisions())
			{

				if (other is Tile)
				{
					Tile tile = other as Tile;
					if (tile.GetLayerType == LayerType.Collidable)
					{
						canMove = canMove && resolveCollision( tile, moveX, moveY );
					}
				}
			}
			return canMove;
		}

		protected bool manageCollision( GameObject other, float moveX, float moveY )
		{
			if (other is Tile)
			{
				Tile tile = other as Tile;

				if (tile.GetLayerType == LayerType.Collidable)
				{
					return resolveCollision( other as Sprite, moveX, moveY );
				}
			}
			return true;
		}

		protected bool resolveCollision( Sprite collisionObject, float moveX, float moveY )
		{
			if (moveX > 0)
			{
				x = collisionObject.x - collisionObject.width / 2 - width / 2;
				return false;
			}
			if (moveX < 0)
			{
				x = collisionObject.x + collisionObject.width / 2 + width / 2;
				return false;
			}
			if (moveY > 0)
			{
				y = collisionObject.y - collisionObject.height / 2 - height / 2;
				return false;
			}
			if (moveY < 0)
			{
				y = collisionObject.y + collisionObject.height / 2 + width / 2;
				return true;
			}
			return true;
		}

		protected void applyGravity()
		{
			if (ySpeed >= 1.0f && ySpeed < 1.0f)
			{
				ySpeed += 1.0f;
			}
			else
			{
				ySpeed += 0.5f;
			}

			if (ySpeed > 32.0f)
			{
				ySpeed = 32.0f;
			}


			if (!TryMove( 0, ySpeed ))
			{
				_isGrounded = true;
				ySpeed = 0;
			}
			Console.WriteLine( _isGrounded );
		}
	}
}
