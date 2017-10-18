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

	int animationFrameDelay = 8;
	private int animationStep;

	public Player() : base( "player.png", 4, 1, EntityType.Player )
	{
		x = 100;    //Starting Position X
		y = 600;    //Starting Position Y
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
		{
			TryMove( -xSpeed, 0 );
		}
	}
}


