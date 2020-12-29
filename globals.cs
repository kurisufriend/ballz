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
	static class g// a5 moment// ok thats not funny
	{
		public static mouse_t mouse = new mouse_t();
		public static Random rand = new Random();
		public static entityList_t entityList = new entityList_t();
		public static RenderTexture renderTexture = new RenderTexture(1280, 720);
	}
}
