using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Slide15
{
	public class Data : System.IComparable
	{
		public int data{get;set;}
		public string name{get;set;}
		public int CompareTo(object obj)
		{
			return this.data.CompareTo(((Data)obj).data);
			//または、次のようにもできる
			//return this.Price - ((Product)other).Price;
		}
	}
	public class Slide15
	{
		public static int[] map;
		public static int x,y,w,h;
		public static bool isExit;
		public static bool isClear;
		public static string PlayerName="";
		public static Data[][] Data;
		public static void Menu()
		{
			int selected=3;
			isExit=false;
			isClear=false;
			while(true)
			{
				Console.SetCursorPosition(0,0);
				switch(selected)
				{
					case 3:
						Console.ForegroundColor=ConsoleColor.Black;
						Console.BackgroundColor=ConsoleColor.White;
						Console.Write("Level 1\n");
						Console.ResetColor();
						Console.Write("Level 2\n");
						Console.Write("Level 3\n");
						Console.Write("Quit\n");
						break;
					case 4:
						Console.Write("Level 1\n");
						Console.ForegroundColor=ConsoleColor.Black;
						Console.BackgroundColor=ConsoleColor.White;
						Console.Write("Level 2\n");
						Console.ResetColor();
						Console.Write("Level 3\n");
						Console.Write("Quit\n");
						break;
					case 5:
						Console.Write("Level 1\n");
						Console.Write("Level 2\n");
						Console.ForegroundColor=ConsoleColor.Black;
						Console.BackgroundColor=ConsoleColor.White;
						Console.Write("Level 3\n");
						Console.ResetColor();
						Console.Write("Quit\n");
						break;
					case 6:
						Console.Write("Level 1\n");
						Console.Write("Level 2\n");
						Console.Write("Level 3\n");
						Console.ForegroundColor=ConsoleColor.Black;
						Console.BackgroundColor=ConsoleColor.White;
						Console.Write("Quit\n");
						Console.ResetColor();
						break;

				}
				ConsoleKeyInfo c = Console.ReadKey(true);
				switch(c.Key)
				{
					case ConsoleKey.DownArrow:
						if(selected!=6)
							selected++;
						break;
					case ConsoleKey.UpArrow:
						if(selected!=3)
							selected--;
						break;
					case ConsoleKey.Enter:
						if(selected==6)
						{
							Console.CursorVisible=true;
							Environment.Exit(0);
						}
						System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
						init(selected,selected);
						stopwatch.Start();
						while(!isExit)
						{
							ConsoleKeyInfo kb = Console.ReadKey(true);
							switch(kb.Key)
							{
								case ConsoleKey.UpArrow:
									swap(3);
									Check();
									break;
								case ConsoleKey.DownArrow:
									swap(4);
									Check();
									break;
								case ConsoleKey.LeftArrow:
									swap(1);
									Check();
									break;
								case ConsoleKey.RightArrow:
									swap(2);
									Check();
									break;
								case ConsoleKey.Escape:
									isExit=true;
									break;
							}
						}
						stopwatch.Stop();
						Console.Clear();
						if(isClear)
						{
							Console.SetCursorPosition(Console.WindowWidth/2 -10,Console.WindowHeight/2);
							Console.Write("Clear!!");
							Console.ReadKey();
							Console.Clear();
							{
								int tmplength = Data[selected-3].Length;
								Array.Resize(ref Data[selected-3],Data[selected-3].Length+1);
								Data[selected-3][tmplength]=new Data();
								Data[selected-3][tmplength].data=stopwatch.Elapsed.Hours*3600+stopwatch.Elapsed.Minutes*60+stopwatch.Elapsed.Seconds;
								Data[selected-3][tmplength].name=PlayerName;
								Array.Sort(Data[selected-3]);
								Console.SetCursorPosition(Console.WindowWidth/2-5,Console.WindowHeight/2-7);
								Console.Write("現在のタイム: {0}秒",stopwatch.Elapsed.Hours*3600+stopwatch.Elapsed.Minutes*60+stopwatch.Elapsed.Seconds);
							}
						}
						for(int i=0;i<Data[selected-3].Length-1 || i<5;i++)
						{
							if(0<=i && i<= Data[selected-3].Length-1)
							{
								Console.SetCursorPosition(Console.WindowWidth/2-5,Console.WindowHeight/2-5+2*i);
								Console.Write("{0}位: {1}秒 ({2})",i+1,Data[selected-3][i].data,Data[selected-3][i].name);
								using (var streamWriter = new StreamWriter("Data", false, Encoding.UTF8))
								{
									var xmlSerializer1 = new XmlSerializer(typeof(Data[][]));
									xmlSerializer1.Serialize(streamWriter, Data);
								}
							}
						}
						stopwatch.Reset();
						break;
				}
			}
		}
		public static void Main()
		{
			string title = Console.Title;
			Console.Title = "";
			Console.Clear();
			try{
				var xmlSerializer2 = new XmlSerializer(typeof(Data[][]));
				var xmlSettings = new System.Xml.XmlReaderSettings()
				{
					CheckCharacters = false, // （2）
				};
				using (var streamReader = new StreamReader("Data", Encoding.UTF8))
					using (var xmlReader
							= System.Xml.XmlReader.Create(streamReader, xmlSettings))
					{
						Data = (Data[][])xmlSerializer2.Deserialize(xmlReader); // （3）
					}
			}catch{
				Data=new Data[3][]{
					new Data[0],
					new Data[0],
					new Data[0]
				};
			}
			Console.WriteLine("ランキングに使うので、名前を入力してください。");
			PlayerName=Console.ReadLine();
			Console.Clear();
			Console.CursorVisible = false;
			Menu();
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
			Console.SetCursorPosition(0,h+2);
			Console.Write("空白を矢印キーで動かして、\n");
			Console.SetCursorPosition(0,h+3);
			Draw();
			Console.SetCursorPosition(0,h*2+3);
			Console.Write("の形にしてください。\n\nMenuに戻る時はESCを押してください。");
			isExit=true;
			while(isExit)
			{
				for(int i=0;i<1000;i++)
				{
					Random r = new Random(seed ++);
					int a = r.Next(5);
					swap(a);
				}
				Console.SetCursorPosition(0,0);
				Draw();
				Check();
			}
		}
		public static void Check()
		{
			for(int i=0;i<(w*h-1);i++)
			{
				if(map[i]!=i+1)
				{
					isExit=false;
					isClear=false;
					return;
				}
			}
			isExit=true;
			isClear=true;
			return;
		}
		public static void Draw()
		{
			for(int i=0;i<h;i++)
			{
				for(int j=0;j<w;j++)
				{
					switch(map[w*i+j])
					{
						case 1:
							Console.BackgroundColor=ConsoleColor.Cyan;
							Console.Write("１");
							break;
						case 2:
							Console.BackgroundColor=ConsoleColor.Blue;
							Console.Write("２");
							break;
						case 3:
							Console.BackgroundColor=ConsoleColor.Magenta;
							Console.Write("３");
							break;
						case 4:
							Console.BackgroundColor=ConsoleColor.Gray;
							Console.ForegroundColor=ConsoleColor.Black;
							Console.Write("４");
							break;
						case 5:
							Console.BackgroundColor=ConsoleColor.DarkYellow;
							Console.Write("５");
							break;
						case 6:
							Console.BackgroundColor=ConsoleColor.Blue;
							Console.Write("６");
							break;
						case 7:
							Console.BackgroundColor=ConsoleColor.Red;
							Console.Write("７");
							break;
						case 8:
							Console.BackgroundColor=ConsoleColor.DarkYellow;
							Console.Write("８");
							break;
						case 9:
							Console.BackgroundColor=ConsoleColor.Gray;
							Console.ForegroundColor=ConsoleColor.Black;
							Console.Write("９");
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
							Console.Write("　");
							Console.ResetColor();
							break;
					}
					Console.ForegroundColor=ConsoleColor.White;
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
					if(x<(w-1))
					{
						map[w*y+x]=map[w*y+x+1];
						map[w*y+x+1]=0;
						x++;
						Console.SetCursorPosition(0,0);
						Draw();
					}
					break;
				case 2://->
					if(x>0)
					{
						map[w*y+x]=map[w*y+x-1];
						map[w*y+x-1]=0;
						x--;
						Console.SetCursorPosition(0,0);
						Draw();
					}
					break;
				case 3://↑
					if(y<(h-1))
					{
						map[w*y+x]=map[w*y+x+w];
						map[w*y+x+w]=0;
						y++;
						Console.SetCursorPosition(0,0);
						Draw();
					}
					break;
				case 4://↓
					if(y>0)
					{
						map[w*y+x]=map[w*y+x-w];
						map[w*y+x-w]=0;
						y--;
						Console.SetCursorPosition(0,0);
						Draw();
					}
					break;
			}
		}
	}
}
