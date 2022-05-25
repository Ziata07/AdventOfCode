using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCodeFrontEnd
{
	class Program
	{
		static void Main(string[] args)
		{
			//int zeroCheck;
			//int oneCheck;			
			string line;
			StreamReader binaryNumFile = new StreamReader(@"F:\LearningProgramming\LearningCSharp\AdventOfCode_Day3\BinaryNumbers.txt");		

			using (binaryNumFile)
			{
				for (int i = 0; i < 5; i++)
				{//trying to split up the string, then get each char into it's own list
					while ((line = binaryNumFile.ReadLine()) != null) //this line just goes through document
					{
						
					}
				}
			}
		}
	}
}
