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

			CircleShape cursor = new CircleShape(25f);
			cursor.FillColor = Color.Green;

			ball_t ball = new ball_t(50f);
			ball_t ball2 = new ball_t(50f, new Vector2f(100, 100), new Vector2f(1f, .5f));

			// main loop
			while (window.IsOpen)
			{
				window.DispatchEvents();

				cursor.Position = new Vector2f(g.mouse.position.X - (cursor.GetLocalBounds().Width / 2), g.mouse.position.Y - (cursor.GetLocalBounds().Height / 2));
				if (g.mouse.button == Mouse.Button.Left && g.mouse.buttonState)
					cursor.FillColor = Color.Red;
				else
					cursor.FillColor = Color.Green;

				window.Clear();

				// add stuff to drawing surface
				window.Draw(cursor);
				ball.Run(window);
				ball2.Run(window);
				window.Display();
			}
		}
	}
}
