using System;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Net;
using System.Threading;

namespace game
{
	class mouse_t
	{
		public Vector2f position;
		public Mouse.Button button;
		public bool buttonState;
		public mouse_t()
		{
			this.position = new Vector2f(0, 0);
			this.button = Mouse.Button.Left;
			this.buttonState = false;
		}
	}
}
