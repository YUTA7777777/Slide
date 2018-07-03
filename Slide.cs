using System;

namespace Slide15
{
	public class Slide15
	{
		public static int[] map;
		public static int x,y;
		public static void Main()
		{
			bool isExit=false;
			init();
			while(!isExit)
			{
				ConsoleKeyInfo kb = Console.ReadKey(true);
				switch(kb.Key)
				{
					case ConsoleKey.UpArrow:
						swap(3);
						break;
					case ConsoleKey.DownArrow:
						swap(4);
						break;
					case ConsoleKey.LeftArrow:
						swap(1);
						break;
					case ConsoleKey.RightArrow:
						swap(2);
						break;
					case ConsoleKey.Escape:
						isExit=true;
						break;
					case ConsoleKey.Enter:
						isExit=Check();
						break;
				}
			}
		}
		public static void init()
		{
			x=3;
			y=3;
			map=new int[16]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,0};
			Draw();
		}
		public static bool Check()
		{
			for(int i=0;i<15;i++)
			{
				if(map[i]!=i+1)
					return false;
			}
			return true;
		}
		public static void Draw()
		{
			Console.Clear();
			for(int i=0;i<4;i++)
			{
				for(int j=0;j<4;j++)
				{
					switch(map[4*i+j])
					{
						case 1:
							Console.BackgroundColor=ConsoleColor.Cyan;
							Console.Write("ÇP");
							break;
						case 2:
							Console.BackgroundColor=ConsoleColor.Blue;
							Console.Write("ÇQ");
							break;
						case 3:
							Console.BackgroundColor=ConsoleColor.Magenta;
							Console.Write("ÇR");
							break;
						case 4:
							Console.BackgroundColor=ConsoleColor.Gray;
							Console.Write("ÇS");
							break;
						case 5:
							Console.BackgroundColor=ConsoleColor.DarkYellow;
							Console.Write("ÇT");
							break;
						case 6:
							Console.BackgroundColor=ConsoleColor.Blue;
							Console.Write("ÇU");
							break;
						case 7:
							Console.BackgroundColor=ConsoleColor.Red;
							Console.Write("ÇV");
							break;
						case 8:
							Console.BackgroundColor=ConsoleColor.DarkYellow;
							Console.Write("ÇW");
							break;
						case 9:
							Console.BackgroundColor=ConsoleColor.Gray;
							Console.Write("ÇX");
							break;
						case 10:
							Console.BackgroundColor=ConsoleColor.Magenta;
							Console.Write("10");
							break;
						case 11:
							Console.BackgroundColor=ConsoleColor.Cyan;
							Console.Write("11");
							break;
						case 12:
							Console.BackgroundColor=ConsoleColor.DarkRed;
							Console.Write("12");
							break;
						case 13:
							Console.BackgroundColor=ConsoleColor.DarkBlue;
							Console.Write("13");
							break;
						case 14:
							Console.BackgroundColor=ConsoleColor.DarkYellow;
							Console.Write("14");
							break;
						case 15:
							Console.BackgroundColor=ConsoleColor.DarkGray;
							Console.Write("15");
							break;
						case 0:
							Console.BackgroundColor=ConsoleColor.Black;
							Console.Write("Å@");
							Console.ResetColor();
							break;
					}
				}
				Console.Write("\n");
			}
			Console.ResetColor();
		}
		public static void swap(int houkou)
		{
			switch(houkou)
			{
				case 1://<-
					if(x<3)
					{
						map[4*y+x]=map[4*y+x+1];
						map[4*y+x+1]=0;
						x++;
						Draw();
					}
					break;
				case 2://->
					if(x>0)
					{
						map[4*y+x]=map[4*y+x-1];
						map[4*y+x-1]=0;
						x--;
						Draw();
					}
					break;
				case 3://Å™
					if(y<3)
					{
						map[4*y+x]=map[4*y+x+4];
						map[4*y+x+4]=0;
						y++;
						Draw();
					}
					break;
				case 4://Å´
					if(y>0)
					{
						map[4*y+x]=map[4*y+x-4];
						map[4*y+x-4]=0;
						y--;
						Draw();
					}
					break;
			}
		}
	}
}
