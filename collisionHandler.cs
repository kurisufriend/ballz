using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace game
{
	static class collisionHandler
	{
		public static List<ball_t> registry = new List<ball_t>();

		public static bool isColliding(ball_t ball)
		{
			foreach (ball_t registeredBall in registry)
			{
				if (registeredBall != ball && registeredBall.shape.GetGlobalBounds().Intersects(ball.shape.GetGlobalBounds()))
					return true;
			}
			return false;
		}
	}
}
