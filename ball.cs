using System;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Net;
using System.Threading;

namespace game
{
	class ball_t
	{
		public CircleShape shape;
		public Vector2f velocity;
		public ball_t(float radius)
		{
			this.shape = new CircleShape(radius);
			this.shape.Position = new Vector2f(1280 / 2, 720 / 2);
			this.velocity = new Vector2f(.5f, .5f);
			collisionHandler.registry.Add(this);
		}
		public ball_t(float radius, Vector2f position)
		{
			this.shape = new CircleShape(radius);
			this.shape.Position = position;
			this.velocity = new Vector2f(.5f, .5f);
			collisionHandler.registry.Add(this);
		}
		public ball_t(float radius, Vector2f position, Vector2f velocity)
		{
			this.shape = new CircleShape(radius);
			this.shape.Position = position;
			this.velocity = velocity;
			collisionHandler.registry.Add(this);
		}
		private void RunPhysics(Vector2f forces)
		{
			//temp place for collision stuff
			Vector2f center = new Vector2f(this.shape.Position.X + (this.shape.GetLocalBounds().Width / 2), this.shape.Position.Y + (this.shape.GetLocalBounds().Height / 2));
			bool isValidPosition = ((center.X > (1280 - (this.shape.GetLocalBounds().Width / 2)) || center.Y > (720 - (this.shape.GetLocalBounds().Height / 2))) || (center.X < (0 + (this.shape.GetLocalBounds().Width / 2)) || center.Y < (0 + (this.shape.GetLocalBounds().Height / 2))));
			if (isValidPosition || collisionHandler.isColliding(this))
			{
				//this.shape.Position = new Vector2f(1280 / 2, 720 / 2);
				this.velocity *= -1;
				this.velocity /= 2f;
				this.shape.Position += new Vector2f(0, -1F);
				this.shape.Position = new Vector2f(Math.Clamp(this.shape.Position.X, 0, 1280), Math.Clamp(this.shape.Position.Y, 0, 720));
				Console.WriteLine("COLLISION: "+this.velocity.Y.ToString());
			}
			Vector2f oldPosition = this.shape.Position;
			this.shape.Position += this.velocity;
			ball_t dummy = this;
			dummy.shape.Position = this.shape.Position;
			if (collisionHandler.isColliding(dummy))
			{ 
				this.shape.Position = oldPosition;
				this.velocity *= -1;
				this.velocity /= 2f;
			}
			if ((Math.Abs(this.velocity.X) < 1 ) && (Math.Abs(this.velocity.Y) < 1))
				this.velocity += forces;
		}
		public void Run(RenderWindow window)
		{
			RunPhysics(new Vector2f(0f, .0001f));
			window.Draw(this.shape);
		}
	}
}
