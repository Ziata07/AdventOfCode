using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
/* To handle this problem, I went about it the following way
 * 1. Grab each char of each line and put them in it's own list according to it's position on the string.
 * 2. Go through each list of each char and get the mode (and not mode)
 * 3. Return the results from each list into a readable string to get answer.
 */
namespace AdventOfCodeFrontEnd
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Initiate Variables 
			List<char> firstBit = new List<char>(); //could have made a list of lists or a class of lists?
			List<char> secondBit = new List<char>();
			List<char> thirdBit = new List<char>();
			List<char> fourthBit = new List<char>();
			List<char> fifthBit = new List<char>();

			List<char> sixthBit = new List<char>();
			List<char> seventhBit = new List<char>();
			List<char> eightBit = new List<char>();
			List<char> ninthBit = new List<char>();
			List<char> tenthBit = new List<char>();

			List<char> eleventhBit = new List<char>();
			List<char> twelthBit = new List<char>();

			string line;
			char[] charArray;
			#endregion
			StreamReader binaryNumFile = new StreamReader(@"F:\LearningProgramming\LearningCSharp\AdventOfCode_Day3\BinaryNumbers.txt");

			using (binaryNumFile)
			{//open the document, put each line in an array then assign each slot in array to appropriate list
				while ((line = binaryNumFile.ReadLine()) != null)
				{
					charArray = line.ToCharArray(); //lots of code, go back and condense this if I want to
					CollectBitsToList(charArray, firstBit, secondBit, thirdBit, fourthBit, fifthBit, sixthBit, seventhBit
						, eightBit, ninthBit, tenthBit,eleventhBit, twelthBit);
				}

				char[] modeArray = {GetModes(firstBit), GetModes(secondBit), GetModes(thirdBit), GetModes(fourthBit)
						,GetModes(fifthBit), GetModes(sixthBit), GetModes(seventhBit), GetModes(eightBit), GetModes(ninthBit)
						,GetModes(tenthBit), GetModes(eleventhBit), GetModes(twelthBit)};

				char[] notModeArray = {GetNotModes(firstBit), GetNotModes(secondBit), GetNotModes(thirdBit), GetNotModes(fourthBit)
						,GetNotModes(fifthBit), GetNotModes(sixthBit), GetNotModes(seventhBit), GetNotModes(eightBit), GetNotModes(ninthBit)
						,GetNotModes(tenthBit), GetNotModes(eleventhBit), GetNotModes(twelthBit)};

				string modeString = new string(modeArray);//These two lines putting the arrays into strings
				string notModeString = new string(notModeArray);

				Console.WriteLine(ConvertBitsToDecimal(modeString) * ConvertBitsToDecimal(notModeString));	//multiply the converted bits for answer		
			}
			//a function with A LOT of parameters. Probably more readable way to do this? 
			void CollectBitsToList(char[] bits, List<char> sone, List<char> stwo, List<char> sthree, List<char> sfour
		   , List<char> sfive, List<char> ssix, List<char>sseven, List<char>seight, List<char>snine, List<char>sten
		   , List<char> seleven, List<char> stwelve)
			{
				for (int slotCounter = 0; slotCounter < 12; slotCounter++) //could make this a function for less work here
				{
					if (slotCounter == Array.IndexOf(bits, '0', 0, 1) | slotCounter == Array.IndexOf(bits, '1', 0, 1))
					{
						sone.Add(bits[slotCounter]);
					}
					else if (slotCounter == Array.IndexOf(bits, '0', 1, 1) | slotCounter == Array.IndexOf(bits, '1', 1, 1))
					{
						stwo.Add(bits[slotCounter]);
					}
					else if (slotCounter == Array.IndexOf(bits, '0', 2, 1) | slotCounter == Array.IndexOf(bits, '1', 2, 1))
					{
						sthree.Add(bits[slotCounter]);
					}
					else if (slotCounter == Array.IndexOf(bits, '0', 3, 1) | slotCounter == Array.IndexOf(bits, '1', 3, 1))
					{
						sfour.Add(bits[slotCounter]);
					}
					else if (slotCounter == Array.IndexOf(bits, '0', 4, 1) | slotCounter == Array.IndexOf(bits, '1', 4, 1))
					{
						sfive.Add(bits[slotCounter]);
					}
					else if (slotCounter == Array.IndexOf(bits, '0', 5, 1) | slotCounter == Array.IndexOf(bits, '1', 5, 1))
					{
						ssix.Add(bits[slotCounter]);
					}
					else if (slotCounter == Array.IndexOf(bits, '0', 6, 1) | slotCounter == Array.IndexOf(bits, '1', 6, 1))
					{
						sseven.Add(bits[slotCounter]);
					}
					else if (slotCounter == Array.IndexOf(bits, '0', 7, 1) | slotCounter == Array.IndexOf(bits, '1', 7, 1))
					{
						seight.Add(bits[slotCounter]);
					}
					else if (slotCounter == Array.IndexOf(bits, '0', 8, 1) | slotCounter == Array.IndexOf(bits, '1', 8, 1))
					{
						snine.Add(bits[slotCounter]);
					}
					else if (slotCounter == Array.IndexOf(bits, '0', 9, 1) | slotCounter == Array.IndexOf(bits, '1', 9, 1))
					{
						sten.Add(bits[slotCounter]);
					}
					else if (slotCounter == Array.IndexOf(bits, '0', 10, 1) | slotCounter == Array.IndexOf(bits, '1', 10, 1))
					{
						seleven.Add(bits[slotCounter]);
					}
					else if (slotCounter == Array.IndexOf(bits, '0', 11, 1) | slotCounter == Array.IndexOf(bits, '1', 11, 1))
					{
						stwelve.Add(bits[slotCounter]);
					}
					else
					{
						break;
					}
				}
			}

			char GetModes(List<char> x)
			{
				var anotherTest = x.GroupBy(j => j).
				OrderByDescending(g => g.Count()).
				Select(g => g.Key).FirstOrDefault();

				return anotherTest;
			}

			char GetNotModes(List<char> x)
			{
				var anotherTest = x.GroupBy(j => j).
				OrderByDescending(g => g.Count()).
				Select(g => g.Key).LastOrDefault();

				return anotherTest;
			}

			double  ConvertBitsToDecimal(string bitString)
			{
				double binary = double.Parse(bitString);//had to make this a double because num was "too big/small for int32 parse

				int results = Convert.ToInt32(bitString.ToString(), 2);
				return results;
			}
		}
	}
}