using System;
using GXPEngine;

public class Player : Entity
{

	float xSpeedMax = 5.0f;
	float xSpeedInc = 0.5f;
	float grav = 0.5f;
	float oldYSpeed;
	float oldXSpeed;
	float oldY;
	float oldX;

	int doubleJumpTime;
	float jumpHeight = 8;
	bool hasJumpPowerup;
	bool hasJumped;

	bool movingRight = true;
	bool running = false;
	bool _isGrounded;
	int animationFrameDelay = 8;
	private int animationStep;

<<<<<<< HEAD
	public Player() : base( "player.png", 4, 1, EntityType.Player )
=======

	public Player() : base("player_all.png", 23, 1)

>>>>>>> 7c69aab6556b4a3a196ac24ba2e2a7323dd455bd
	{
		x = 100;    //Starting Position X
		y = 600;    //Starting Position Y

		SetOrigin( width * 0.5f, height * 0.5f );
	}

	public void ExecuteAnimation()
	{
		if (oldX < x || oldX > x || ySpeed != 0)
		{
			animationStep += 1;
		}
		//Animation based on Movement
		if (animationStep > animationFrameDelay)
		{
			if (ySpeed == 0)    //On the Ground
			{
				SetFrame( 1 );
			}
			if (ySpeed > 0)     //Falling
			{
				SetFrame( 2 );
			}
			if (ySpeed < 0)     //Jumping
			{
				SetFrame( 3 );
			}
			if (ySpeed == 0 && running == true) //Running
			{

			}
		}
	}

	void Update()
	{
		if (Input.GetKey( Key.D ) || Input.GetKey( Key.RIGHT ))
		{
			TryMove( xSpeed, 0 );
		}
		//Moing Left
		if (Input.GetKey( Key.A ) || Input.GetKey( Key.LEFT ))
<<<<<<< HEAD
=======
		{
			if (xSpeed > -xSpeedMax)
			{
				xSpeed -= xSpeedInc;
			}
			x += xSpeed;
		}

		ExecuteAnimation();

		//Moving Left
		if (movingRight == false & oldX > x)
		{
			movingRight = true;
			_mirrorX = true;
		}
		//Moving Right
		if (movingRight == true & oldX < x)
		{
			movingRight = false;
			_mirrorX = false;
		}

		//Double Jumping
		if (doubleJumpTime > 0 && ySpeed != 0 && Input.GetKeyDown( Key.SPACE ) && hasJumped == false)
>>>>>>> 7c69aab6556b4a3a196ac24ba2e2a7323dd455bd
		{
			TryMove( -xSpeed, 0 );
		}
<<<<<<< HEAD
=======

		//Save old Stats for later comparison
		oldX = x;
		oldY = y;
		oldXSpeed = xSpeed;
		oldYSpeed = ySpeed;


		//bool canMove = true;
		//foreach (GameObject other in GetCollisions())
		//{

		//	if (other is Tile)
		//	{
		//		Tile tile = other as Tile;
		//		if (tile.GetLayerType == LayerType.Collidable)
		//		{
		//			canMove = canMove && resolveCollision( tile, moveX, moveY );
		//		}
		//	}
		//}
		//return canMove;
	}

	private bool manageCollision( GameObject other, float moveX, float moveY )
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
>>>>>>> 7c69aab6556b4a3a196ac24ba2e2a7323dd455bd
	}

	private bool resolveCollision( Sprite collisionObject, float moveX, float moveY )
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
<<<<<<< HEAD
		return true;	}
	private void applyGravity()
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


		//if (!TryMove( 0, ySpeed ))
		//{
		//	_isGrounded = true;
		//	ySpeed = 0;
		//}
		Console.WriteLine( _isGrounded );
=======
		return true;
>>>>>>> fd697f8b3651678395837a5bf42227417d4aee95
	}

}


