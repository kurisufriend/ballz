using System;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Net;
using System.Threading;

namespace game
{
	class callbacks
	{
		public static void CallbackClose(object sender, EventArgs e)
		{
			RenderWindow window = (RenderWindow)sender;
			window.Close();
		}
		public static void CallbackMouseMoved(object sender, MouseMoveEventArgs e)
		{
			g.mouse.position = new Vector2f(e.X, e.Y);
		}
		public static void CallbackMousePressed(object sender, MouseButtonEventArgs e)
		{
			g.mouse.button = e.Button;
			g.mouse.buttonState = true;
		}
		public static void CallbackMouseReleased(object sender, MouseButtonEventArgs e)
		{
			g.mouse.buttonState = false;
		}
		public static void registerCallbacks(RenderWindow window)
		{
			window.Closed += new EventHandler(callbacks.CallbackClose);
			window.MouseMoved += new EventHandler<MouseMoveEventArgs>(callbacks.CallbackMouseMoved);
			window.MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(callbacks.CallbackMousePressed);
			window.MouseButtonReleased += new EventHandler<MouseButtonEventArgs>(callbacks.CallbackMouseReleased);
		}
	}
}
