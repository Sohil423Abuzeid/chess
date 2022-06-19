Console.WriteLine("by: Smile Man ^ _ ^\n team: Red Planet\n13 hours coding hhhhhh\n90% completed\nthanks for try my code \n enter enter to continue");
Console.ReadLine();
Console.Clear();
Console.WindowWidth = 75;
Console.WindowHeight = Console.LargestWindowHeight;
SortedList<Char, int> ASDF = new SortedList<char, int>() { { 'A', 0 }, { 'B', 1 }, { 'C', 2 }, { 'D', 3 }, { 'E', 4 }, { 'F', 5 }, { 'G', 6 }, { 'H', 7 } };
List<Char> ASD = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
SortedList<Char, int> NUM = new SortedList<char, int>() { { '1', 0 }, { '2', 1 }, { '3', 2 }, { '4', 3 }, { '5', 4 }, { '6', 5 }, { '7', 6 }, { '8', 7 } };
horse HB = new horse("HOSRE B", "BLACK"), HR = new horse("HOSRE R", "RED");
king KB = new king("KING B", "BLACK"), KR = new king("KING R", "RED");
castle CB = new castle("ROOK B", "BLACK"), CR = new castle("ROOK R", "RED");
PAWN[] SB = { new PAWN("PAWN 1", "BLACK"), new PAWN("PAWN 2", "BLACK"), new PAWN("PAWN 3", "BLACK"), new PAWN("PAWN 4", "BLACK"), new PAWN("PAWN 5", "BLACK"), new PAWN("PAWN 6", "BLACK"), new PAWN("PAWN 7", "BLACK"), new PAWN("PAWN 8", "BLACK") };
PAWN[] SR = { new PAWN("PAWN 9", "RED"), new PAWN("PAWN 10", "RED"), new PAWN("PAWN 11", "RED"), new PAWN("PAWN 12", "RED"), new PAWN("PAWN 13", "RED"), new PAWN("PAWN 14", "RED"), new PAWN("PAWN 15", "RED"), new PAWN("PAWN 16", "RED") };
queen QB = new queen("QUEEN B", "BLACK"), QR = new queen("QUEEN W", "RED");
bishop BB = new bishop("BISHOP B", "BLACK"), BR = new bishop("BISHOP R", "RED");
chess SP = new chess("SPACE", "NONE");
char[] MO = new char[4] ;
chess[,] TABLE = new chess[8, 8] {
	{CB,HB,BB,QB,KB,BB,HB,CB},
	{SB[0],SB[1],SB[2],SB[3],SB[4],SB[5],SB[6],SB[7]},
	{SP,SP,SP,SP,SP,SP,SP,SP},
	{SP,SP,SP,SP,SP,SP,SP,SP},
	{SP,SP,SP,SP,SP,SP,SP,SP},
	{SP,SP,SP,SP,SP,SP,SP,SP},
	{SR[0],SR[1],SR[2],SR[3],SR[4],SR[5],SR[6],SR[7]},
	{CR,HR,BR,QR,KR,BR,HR,CR}};




while (true)
{
	Console.BackgroundColor = ConsoleColor.Black;
	Console.ForegroundColor = ConsoleColor.Red;
	Console.WriteLine(" \t1111111122222222333333334444444455555555666666667777777788888888");
	for (int A = 0; A < 8; A++)
		for (int B = 0; B < 7; B++)
		{
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(ASD[A] + "\t");
			for (int C = 0; C < 8; C++)
			{
				if ((C + A) % 2 == 0)
					Console.BackgroundColor = ConsoleColor.White;
				else Console.BackgroundColor = ConsoleColor.Black;
				TABLE[A, C].draw(B);
			}
			Console.WriteLine();
		}
	Console.WriteLine("enter step LIKE A5B6  AS (A5 FIRST PLACE AND B6 SECOND PLACE )");
	MO = ((Console.ReadLine()).ToUpper()).ToCharArray();
	move(ASDF[MO[0]],NUM[MO[1]],ASDF[MO[2]],NUM[MO[3]]);
	Console.Clear();
}

void move(int a, int b, int c, int d)    
{
	if ((TABLE[a,b].color != TABLE[c,d].color)&&((a!=c)||(b!=d)))
		if (TABLE[a, b].move(a, b, c, d, TABLE))
		{
			TABLE[c, d] = TABLE[a, b];
			TABLE[a, b] = SP;
		}
}
class chess
{
	public int moves = 0;
	public string color;
	public string name;
	public chess()
	{ }
	public chess(string name, string color)
	{
		this.color = color;
		this.name = name;
	}
	public virtual void draw(int i)
	{
		if (color == "RED")
			Console.ForegroundColor = ConsoleColor.Red;
		else if (color == "BLACK")
			Console.ForegroundColor = ConsoleColor.Blue;
		else
		{
			switch (i)
			{
				case 0: Console.Write("        "); break;
				default:Console.Write("        "); break;
			}
		}
	}
	public virtual Boolean move(int a, int b, int c, int d,chess [,] TA)
	{
		return false;
	}
}
class horse : chess
{
	public horse() : base() { }
	public horse(string name, string color) : base(name, color) { }
	public override void draw(int i)
	{
		base.draw(i);
		switch (i)
		{
			case 1: Console.Write("  ****  "); break;
			case 2: Console.Write(" ####** "); break;
			case 3: Console.Write(" ###*   "); break;
			case 4: Console.Write(" ###**  "); break;
			case 5: Console.Write(" ###*** "); break;
			case 6: Console.Write(" knight "); break;
			case 0: Console.Write("        "); break;
		}
	}
	public override Boolean move(int a, int b, int c, int d, chess[,] TA)
	{
		if (((b + 1 == d) && (a - 2 == c)) || ((b + 1 == d) && (a - 2 == c)) || ((b - 1 == d) && (a - 2 == c)) || ((b - 1 == d) && (a + 2 == c)) || ((a + 1 == c) && (b - 2 == d)) || ((a + 1 == c) && (b + 2 == d)) || ((a - 1 == c) && (b - 2 == d)) || ((a - 1 == c) && (b + 2 == d)))
			return true;
		else return false;
	}

}
class bishop : chess
{
	public bishop() : base()
	{ }
	public bishop(string name, string color) : base(name, color) { }
	public override void draw(int i)
	{
		base.draw(i);
		switch (i)
		{
			case 0: Console.Write("        "); break;
			case 1: Console.Write("B  **   "); break;
			case 2: Console.Write("I ****  "); break;
			case 3: Console.Write("S****** "); break;
			case 4: Console.Write("H ****  "); break;
			case 5: Console.Write("O  **   "); break;
			case 6: Console.Write("P ####  "); break;
		}
	}
	public override Boolean move(int a, int b, int c, int d, chess[,] TA)
	{
		bool g = true;
		if (((a + 1 == c) && (b + 1 == d)) || ((a + 1 == c) && (b - 1 == d)) || ((a - 1 == c) && (b + 1 == d)) || ((a - 1 == c) && (b - 1 == d)))
		{
			return true;
		}
		else
		{
			if (a > c)
			{
				
				if (b > d)	
					for (; a > (c+1);)
					{
						a--; b--;
						if (TA[a, b].color != "NONE") { g = false; }
					}
				else if (b < d)
					for (; a > (c+1);)
					{
						a--; b++;
						if (TA[a, b].color != "NONE") { g = false; }
					}
			}
			else if (a < c)
			{
				
				if (b > d)
					for (; a < (c-1);)
					{
						a++; b--;
						if (TA[a, b].color != "NONE") { g = false; }
					}
				else if (b < d)
					for (; a< c; )
					{
						a++; b++;
						if (TA[a, b].color != "NONE") { g = false; }
					}
			}
		}
		if (g)
			return true;
		else return false;
	}

}
class castle : chess
{
	public castle() : base()
	{ }
	public castle(string name, string color) : base(name, color) { }
	public override void draw(int i)
	{
		base.draw(i);
		switch (i)
		{
			case 0: Console.Write(" ^ ^^ ^ "); break;
			case 1: Console.Write(" # ## # "); break;
			case 2: Console.Write(" # ## # "); break;
			case 3: Console.Write(" ###### "); break;
			case 4: Console.Write(" ###### "); break;
			case 5: Console.Write(" #ROOK# "); break;
			case 6: Console.Write(" #    # "); break;
			case 7: Console.Write(" ###### "); break;
		}
	}
	public override Boolean move(int a, int b, int c, int d, chess[,] TA)
	{
		bool g = true;
		if ((((a == c) && ((b + 1 == d) || (b - 1 == d))) || ((b == d) && ((a + 1 == c) || (a - 1 == c))))) 
		{
			return true;
	    }
		else
		{
			if(a==c)
			{
				if (b > d)
				{
					for (; b > d;)
					{
						b--;
						if (TA[a, b].color != "NONE") { g = false; }
					}
				}
				else if(b < d)
				{
					for (; b < d ; )
					{
						b++;
						if (TA[a, b].color != "NONE") { g = false; }
					}
				}
			}
			else if(b==d)
			{
				if (a > c)
				{
					for (; a > (c+1);)
					{
						a--;
						if (TA[a, b].color != "NONE") { g = false; }
					}
				}
				else if (a < c)
				{
					for (; a < (c-1);)
					{
						a++;
						if(TA[a, b].color != "NONE") { g = false; }
					}
						
				}
			}
		}
		if (g)
			return true;
		else return false;
	}

}
class PAWN : chess
{
	public PAWN() : base()
	{ }
	public PAWN(string name, string color) : base(name, color) { }
	public override void draw(int i)
	{
		base.draw(i);
		switch (i)
		{
			case 0: Console.Write("        "); break;
			case 1: Console.Write("  ^^^^  "); break;
			case 2: Console.Write("P ****  "); break;
			case 3: Console.Write("A ####  "); break;
			case 4: Console.Write("W ####  "); break;
			case 5: Console.Write("N ####  "); break;
			case 6: Console.Write("  ####  "); break;
		}
	}
	public override Boolean move(int a, int b, int c, int d, chess[,] TA)
	{
		if (TA[a,b].color == "RED")
		{
			if (((b == d) && ((a - 1 == c) || ((a - 2 == c) && (a == 6)))) || ((a - 1 == c) && (TA[c, d].color != "NONE") && ((b - 1 == d) || (b + 1 == d)))) 
			{   
				TA[a,b].moves++;
				return true;
			}
		}
		else if (TA[a,b].color == "BLACK")
		{
			if (((b == d) && ((a + 1 == c) || ((a + 2 == c) && (a == 1)))) || ((a + 1 == c) && (TA[c, d].color != "NONE") && ((b - 1 == d) || (b + 1 == d))))
			{
				TA[a, b].moves++;
				return true;
			}
		}
		if (5 == 6)
			return true;
		else return false; 
	}

}
class king : chess
{
	public king() : base()
	{ }
	public king(string name, string color) : base(name, color) { }
	public override void draw(int i)
	{
		base.draw(i);
		switch (i)
		{
			case 1: Console.Write(" * ** * "); break;
			case 2: Console.Write(" * ** * "); break;
			case 3: Console.Write("  ****  "); break;
			case 4: Console.Write(" ****** "); break;
			case 5: Console.Write("        "); break;
			case 6: Console.Write("  King  "); break;
			case 0: Console.Write("        "); break;
		}
	}
	public override Boolean move(int a, int b, int c, int d, chess[,] TA)
	{
		if ((((a == c) && ((b + 1 == d) || (b - 1 == d))) || ((b == d) && ((a + 1 == c) || (a - 1 == c)))))
		{
			return true;
		}
		else if (((a + 1 == c) && (b + 1 == d)) || ((a + 1 == c) && (b - 1 == d)) || ((a - 1 == c) && (b + 1 == d)) || ((a - 1 == c) && (b - 1 == d)))
		{
			return true;
		}
		else 
		{ 
			return false; 
		}
	}

}
class queen : chess
{
	public queen() : base()
	{ }
	public queen(string name, string color) : base(name, color) { }
	public override void draw(int i)
	{
		base.draw(i);
		switch (i)
		{
			case 0: Console.Write("        "); break;
			case 1: Console.Write("**    **"); break;
			case 2: Console.Write("Q**  ** "); break;
			case 3: Console.Write("U ****  "); break;
			case 4: Console.Write("E ####  "); break;
			case 5: Console.Write("E###### "); break;
			case 6: Console.Write("N       "); break;
		}
	}
	public override Boolean move(int a, int b, int c, int d, chess[,] TA)
	{
		bool g = true;
		if ((((a == c) && ((b + 1 == d) || (b - 1 == d))) || ((b == d) && ((a + 1 == c) || (a - 1 == c)))))
		{
			return true;
		}
		else if (((a + 1 == c) && (b + 1 == d)) || ((a + 1 == c) && (b - 1 == d)) || ((a - 1 == c) && (b + 1 == d)) || ((a - 1 == c) && (b - 1 == d)))
		{
			return true;
		}
		else
		{
			if (a == c)
			{
				if (b > d)
				{
					for (; b > d;)
					{
						b--;
						if (TA[a, b].color != "NONE") { g = false; }
					}
				}
				else if (b < d)
				{
					for (; b < d;)
					{
						b++;
						if (TA[a, b].color != "NONE") { g = false; }
					}
				}
			}
			else if (b == d)
			{
				if (a > c)
				{
					for (; a > (c + 1);)
					{
						a--;
						if (TA[a, b].color != "NONE") { g = false; }
					}
				}
				else if (a < c)
				{
					for (; a < (c - 1);)
					{
						a++;
						if (TA[a, b].color != "NONE") { g = false; }
					}

				}
			}
			else if ((a!=c)&&(b!=d))
			{
				if (a > c)
				{

					if (b > d)
						for (; a > (c + 1);)
						{
							a--; b--;
							if (TA[a, b].color != "NONE") { g = false; }
						}
					else if (b < d)
						for (; a > (c + 1);)
						{
							a--; b++;
							if (TA[a, b].color != "NONE") { g = false; }
						}
				}
				else if (a < c)
				{

					if (b > d)
						for (; a < (c - 1);)
						{
							a++; b--;
							if (TA[a, b].color != "NONE") { g = false; }
						}
					else if (b < d)
						for (; a < c;)
						{
							a++; b++;
							if (TA[a, b].color != "NONE") { g = false; }
						}
				}
			}
		}
		if (g)
			return true;
		else return false;
	}

}