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
	{//program is taking LONG to calculate. Does it instantly if only mode OR nonMode is not commented out. Figure it out
		static void Main(string[] args)
		{
			#region Initiate Variables 
			List<List<char>> mainList = new List<List<char>>();
			List<char> modeList = new List<char>();
			List<char> notModeList = new List<char>();
			int zeroCount = 0;
			int oneCount = 0;

			string line;
			char[] modeArray, notModeArray;
			#endregion

			CreateSubLists();
			StreamReader binaryNumFile = new StreamReader(@"F:\LearningProgramming\LearningCSharp\AdventOfCode_Day3\BinaryNumbers.txt");

			using (binaryNumFile)
			{
				Console.WriteLine("File is open!");
				while ((line = binaryNumFile.ReadLine()) != null)
				{					
					modeArray = line.ToCharArray();
					PutBitsToSubList(modeArray);

					notModeArray = line.ToCharArray();				
					PutBitsToSubList(notModeArray);
				}				
			}


			
			while (mainList[0].Count != 1)
			{
				DoModeCalculationinSubList();
				DoNonModeCalculationinSubList();
			}

			double answer = ConvertBitsToDecimal(ConvertListToBitString(modeList)) * ConvertBitsToDecimal(ConvertListToBitString(notModeList));
			Console.WriteLine("Answer is: {0}", answer);


			void PutBitsToSubList(char[] anArray)//Number in for loop
			{
				for (int j = 0; j < 12; j++)
				{
					if (j == Array.IndexOf(anArray, '0', j, 1) | j == Array.IndexOf(anArray, '1', j, 1))
					{
						mainList[j].Add(anArray[j]);
					}
					else
					{
						break;
					}
				}
			}

			void CreateSubLists()//Number in for loop
			{
				for (int listTotal = 0; listTotal < 12; listTotal++)
				{
					mainList.Add(new List<char>());
				}
			}

			void RemoveSlotsFromAllList(int slotPosition)
			{//function to remove positions from all lists. Need to condense this, make a list of lists?
				foreach (List<char> x in mainList)
				{
					x.RemoveAt(slotPosition);
				}
			}

			void DoModeCalculationinSubList()
			{
				foreach (List<char> sList in mainList)
				{
					if (CheckSameAmounts(sList))
					{
						RemoveNonMatchingRows('1', sList);
					}
					else
					{
						RemoveNonMatchingRows(GetModes(sList), sList);
					}
				}
			}

			void DoNonModeCalculationinSubList()
			{
				foreach (List<char> sList in mainList)
				{
					if (CheckSameAmounts(sList))
					{
						RemoveNonMatchingRows('0', sList);
					}
					else
					{
						RemoveNonMatchingRows(GetNotModes(sList), sList);
					}
				}
			}

			void RemoveNonMatchingRows(char theMode, List<char> aList)
			{
				for (int i = 0; i < aList.Count; i++)//Go through the list
				{
					if (theMode != aList[i]) //If a slot doesn't have the mode it in
					{
						RemoveSlotsFromAllList(i);//remove the slots that don't match from ALL lists
						i--;//go back one so it goes through the list again. 
					}
					else
					{
						continue;
					}
				}

			}

			bool CheckSameAmounts(List<char> x)
			{
				for (int i = 0; i < x.Count; i++)
				{
					if (x[i] == '0')
					{
						zeroCount++;
					}
					else if (x[i] == '1')
					{
						oneCount++;
					}
					else
					{
						break;
					}
				}
				if (zeroCount == oneCount)
				{
					return true;
				}
				else
				{
					zeroCount = 0;
					oneCount = 0;
				}
				return false;
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

			string ConvertListToBitString(List<char> x)
			{
				foreach (List<char> subList in mainList)
				{
					foreach (char singleBit in subList)
					{
						x.Add(singleBit);
					}
				}
				return new string(x.ToArray());
			}

			double ConvertBitsToDecimal(string bitString)
			{
				double binary = double.Parse(bitString);//had to make this a double because num was "too big/small for int32 parse

				int results = Convert.ToInt32(bitString.ToString(), 2);
				return results;
			}
		}
	}
}