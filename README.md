# 2D Platform Game Project

## About the Project

This is a prototype of a 2D platform and action videogame where we will control a robot in a stage surrounded by enemies and other elements to interact with.

## Character Control

We can use different controls with our character starting with the movement. 
To be able to control the movement more accurately rigidbody2D velocity has been used in all character movements:

```
  horizontalInput = Input.GetAxisRaw("Horizontal");
  float currentSpeed = horizontalInput * speed * Time.fixedDeltaTime;
  Vector2 velocity = new Vector2(currentSpeed, rb2D.velocity.y);
  rb2D.velocity = velocity;
```

For the jump, a 2D box collider with trigger activated has been added, so that it detects the ground and only lets the character jump when it is attached to it.

![img](./img/jumpCollider.PNG)

For the shots of the projectiles the pooling technique has been used. In the "objectPool.cs" script, a certain number of projectiles are instantiated at the start of the game and enabled or disabled as needed. In case that more projectiles than usual are needed, a new one is instantiated.

![gif](./GIF/pooling.gif)

## Character Animations

## Stage Components

The stage is composed of a rectangular tileMap together with a Tilemap collider 2D and a Composite collider 2D so that the character can interact with their physics.

Parallax background has been implemented, it is composed of two quads with different texture. They follow the camera and change their texture depending on the movement of it. In the "Parallax.cs" script we set a different speed to each quad to achieve this effect.

![gif](./GIF/parallax.gif)

## Enemies

Enemies appear all over the stage and the player will be able to defeat them. These enemies are constantly moving from one side to another. 
To do this, they detect walls or edges with a special empty object attached to them:

![img](./img/emptyObject.PNG)

In the "EnemyPatrol.cs" script the enemy will always move in one direction. If it detects that the empty "Wallcheck" item detects a wall with the "Ground" layer activated, it will change the direction of the enemy. 
The same thing happens with the "EdgeCheck" object but this time when it stops hitting a wall:

```
  hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
  atEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);
  if(hittingWall || !atEdge){
    moveRight = !moveRight;
  }
```

![gif](./GIF/enemyPatrol.gif)

When the projectile collides with an enemy, its life is removed. In case of running out of lives we disable the enemy. This happens from the script "Projectile.cs" in the OnTriggerEnter2D event.

In the same way, if the enemy collides with us, it will take away our energy.

![gif](./GIF/enemyHit.gif)

## Switch / Door Event

In some areas of the game we will see closed doors, to open them we must find the corresponding switch. This switch is the notifier and contains a delegate to trigger the event "OnLeverActivate". When we are close to its trigger and press the E key the event starts.

```
    public delegate void leverDelegate();
    public event leverDelegate OnLeverActivate;
```

The door that opens is the receiver and subscribes to this event. When the event is triggered the collider its disabled and it start the animation.
In addition, the priority of the cinemachine is changed so that we can see the scene:

![gif](./GIF/switchDoorEvent.gif)

## Grappling Hook

## Other Elements

