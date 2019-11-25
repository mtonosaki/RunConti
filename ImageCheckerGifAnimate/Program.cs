using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCheckerGifAnimate
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length < 1)
			{
				Console.Error.WriteLine("Error : Only one full pass name is accepted in ImageCheckerAlphaChannel");
				Environment.Exit(-1);
				return;
			}
			try
			{
				var fname = args[0];
				if (File.Exists(fname) == false)
				{
					Console.Error.WriteLine($"File '{fname}' is not found.");
					Environment.Exit(-2);
					return;
				}
				proc(fname);
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
				Console.Error.WriteLine(ex.StackTrace);
				Environment.Exit(-3);
			}
		}

		static void proc(string fname)
		{
			Image img = Image.FromFile(fname);
			if(ImageAnimator.CanAnimate(img))
			{
				Environment.Exit(1);
			} else
			{
				Environment.Exit(0);
			}
		}
	}
}
