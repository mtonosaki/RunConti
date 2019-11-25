using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCheckerAlphaChannel
{
	class Program
	{
		static void Main(string[] args)
		{
			if( args.Length < 1)
			{
				Console.Error.WriteLine("Only one full path name is accepted in ImageCheckerAlphaChannel");
				Environment.Exit(-1);
				return;
			}
			try
			{
				var fname = args[0];
				if( File.Exists(fname) == false)
				{
					Console.Error.WriteLine($"File '{fname}' is not found.");
					Environment.Exit(-2);
					return;
				}
				using (var bmp = new Bitmap(Image.FromFile(fname)))
				{
					for (int y = 0; y < bmp.Height; y += 2)
					{
						for (int x = 0; x < bmp.Width; x += 2)
						{
							var col = bmp.GetPixel(x, y);
							if (col.A < 255)
							{
								Environment.Exit(1);
								return;
							}
						}
					}
				}
				Environment.Exit(0);
			}
			catch(Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
				Console.Error.WriteLine(ex.StackTrace);
				Environment.Exit(-3);
			}
		}
	}
}
