using System;

namespace Slide15
{
	public class Slide15
	{
		public static int[] map;
		public static int x,y,w,h;
		public static bool isExit;
		public static void Main()
		{
			isExit=false;
			Console.CursorVisible = false;
			init(5,5);
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
						for(int i=0;i<(w*h-1);i++)
						{
							map[i]=i+1;
						}
						map[w*h-1]=0;
						Draw();
						Console.ReadKey();
						break;
				}
				Check();
			}
			Console.CursorVisible=true;
		}
		public static void init(int sw,int sh)
		{
			x=sw-1;
			y=sh-1;
			w=sw;
			h=sh;
			Console.Clear();
			int seed = Environment.TickCount;
			map=new int[w*h];
			for(int i=0;i<(w*h-1);i++)
			{
				map[i]=i+1;
			}
			map[w*h-1]=0;
			for(int i=0;i<1112;i++)
			{
				Random r = new Random(seed ++);
				int a = r.Next(5);
				swap(a);
			}
			Draw();
		}
		public static void Check()
		{
			for(int i=0;i<(w*h-1);i++)
			{
				if(map[i]!=i+1)
					return;
			}
			Console.Clear();
			Console.SetCursorPosition(Console.WindowWidth/2-3,Console.WindowHeight/2);
			Console.Write("Great");
			Console.ReadKey();
			isExit=true;
			return;
		}
		public static void Draw()
		{
			Console.SetCursorPosition(0,0);
			for(int i=0;i<h;i++)
			{
				for(int j=0;j<w;j++)
				{
					switch(map[w*i+j])
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
							Console.ForegroundColor=ConsoleColor.Black;
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
							Console.ForegroundColor=ConsoleColor.Black;
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
						case 16:
							Console.BackgroundColor=ConsoleColor.Blue;
							Console.Write("16");
							break;
						case 17:
							Console.BackgroundColor=ConsoleColor.DarkRed;
							Console.Write("17");
							break;
						case 18:
							Console.BackgroundColor=ConsoleColor.DarkYellow;
							Console.Write("18");
							break;
						case 19:
							Console.BackgroundColor=ConsoleColor.DarkMagenta;
							Console.Write("19");
							break;
						case 20:
							Console.BackgroundColor=ConsoleColor.Red;
							Console.Write("20");
							break;
						case 21:
							Console.BackgroundColor=ConsoleColor.Yellow;
							Console.ForegroundColor=ConsoleColor.Black;
							Console.Write("21");
							break;
						case 22:
							Console.BackgroundColor=ConsoleColor.DarkGray;
							Console.Write("22");
							break;
						case 23:
							Console.BackgroundColor=ConsoleColor.DarkMagenta;
							Console.Write("23");
							break;
						case 24:
							Console.BackgroundColor=ConsoleColor.DarkBlue;
							Console.Write("24");
							break;
						case 25:
							Console.BackgroundColor=ConsoleColor.DarkRed;
							Console.Write("25");
							break;
						case 0:
							Console.BackgroundColor=ConsoleColor.Black;
							Console.Write("Å@");
							Console.ResetColor();
							break;
					}
					Console.ForegroundColor=ConsoleColor.White;
				}
				Console.Write("\n");
			}
			Console.ResetColor();
			Console.Write("ãÛîíÇÃÉXÉyÅ[ÉXÇñÓàÛÉLÅ[Ç≈à⁄ìÆÇµÇƒ\nÇP ÇQ ÇR ÇS\nÇT ÇU ÇV ÇW\nÇX 10 11 12\n13 14 15\nÇÃèáÇ…ÇµÇƒÇ≠ÇæÇ≥Ç¢ÅB");
		}
		public static void swap(int houkou)
		{
			switch(houkou)
			{
				case 1://<-
					if(x<(w-1))
					{
						map[w*y+x]=map[w*y+x+1];
						map[w*y+x+1]=0;
						x++;
						Draw();
					}
					break;
				case 2://->
					if(x>0)
					{
						map[w*y+x]=map[w*y+x-1];
						map[w*y+x-1]=0;
						x--;
						Draw();
					}
					break;
				case 3://Å™
					if(y<(h-1))
					{
						map[w*y+x]=map[w*y+x+w];
						map[w*y+x+w]=0;
						y++;
						Draw();
					}
					break;
				case 4://Å´
					if(y>0)
					{
						map[w*y+x]=map[w*y+x-w];
						map[w*y+x-w]=0;
						y--;
						Draw();
					}
					break;
			}
		}
	}
}
