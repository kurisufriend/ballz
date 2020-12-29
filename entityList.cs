using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using game;

namespace game
{
	class entityList_t : List<ball_t>
	{
		public void Run(RenderWindow window)
		{
			foreach (ball_t ball in this)
			{
				ball.Run(window);
			}
		}
	}
}
