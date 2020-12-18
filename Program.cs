using System;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Net;
using System.Threading;
using System.Collections.Generic;

namespace game
{
	class Program
	{
		static void Main(string[] args)
		{
			RenderWindow window = new RenderWindow(new VideoMode(1280, 720), "test", Styles.Default);

			callbacks.registerCallbacks(window);

			g.entityList.Add(new ball_t(50f, new Vector2f(1280 / 2, 720 / 2), new Vector2f(.2f, .2f)));
			g.entityList.Add(new ball_t(25f, new Vector2f(100, 100), new Vector2f(.2f, .2f)));
			g.entityList.Add(new ball_t(25f, new Vector2f(300, 100), new Vector2f(.2f, .2f)));
			g.entityList.Add(new ball_t(25f, new Vector2f(200, 100), new Vector2f(.2f, .2f)));

			while (window.IsOpen)
			{
				window.DispatchEvents();
				window.Clear();
				g.entityList.Run(window);
				window.Display();
			}
		}
	}
}
