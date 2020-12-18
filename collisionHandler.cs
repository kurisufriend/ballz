using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SFML.System;

namespace game
{
	class collision_t
	{
		public bool colliding;
		public float force;
		public collision_t(bool colliding_, float force_)
		{
			this.colliding = colliding_;
			this.force = force_;
		}
	}
	static class collisionHandler
	{
		public static float TEMP_vecLen(Vector2f v)
		{
			return (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
		}
		public static List<ball_t> registry = new List<ball_t>();

		public static collision_t isColliding(ball_t ball)
		{
			foreach (ball_t registeredBall in registry)
			{
				if (registeredBall != ball && registeredBall.shape.GetGlobalBounds().Intersects(ball.shape.GetGlobalBounds()))
				{
					/*
					// conservation of momentum: m*v = M, net momentum is conserved through collision
					// (r.m*r.vx)/b.m == b.vx 
					// (r.m*r.vy)/b.m == b.vy 
					// where r is object we're colliding with and b is us, m is maass and v is velocity
					Vector2f calcVelocity = new Vector2f();
					calcVelocity.X = (registeredBall.shape.Radius * registeredBall.velocity.X) / ball.shape.Radius;
					calcVelocity.Y = (registeredBall.shape.Radius * registeredBall.velocity.Y) / ball.shape.Radius;
					return new collision_t(true, calcVelocity);
					 */
					float forceCalc = 10 / ((ball.shape.Radius * TEMP_vecLen(ball.velocity) > registeredBall.shape.Radius * TEMP_vecLen(registeredBall.velocity)) ? (ball.shape.Radius * TEMP_vecLen(ball.velocity)) : registeredBall.shape.Radius * TEMP_vecLen(registeredBall.velocity));
					return new collision_t(true, forceCalc);
				}
			}
			return new collision_t(false, 1f);
		}
	}
}
