using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toptal
{
    class November2016
    {
        //Given a string, containing only open and closed brackets: ( and ) symbols,
        // return an index, where number of open brackets on the left side equal to 
        // the number of closed brackets on the right side
        public static int solution(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int nlength = S.Length;
            if (S.Length == 0)
            {
                return 0;
            }
            int index = 0;
            bool bFound = false;
            int j = S.Length - 1;
            for (int i = 0; i < S.Length; i++)
            {
                bFound = false;
                if (S[i] == '(')
                {                    
                    for (int k = j; k > i; k--)
                    {
                        j = k-1;
                        if (S[k] == ')')
                        {
                            bFound = true;
                            break;
                        }

                    }
                }else
                {
                    bFound = true;
                }


                if (j == i)
                {
                    if (!bFound)
                    {
                        i--;
                    }
                    index = i;
                    break;

                }
            }
            return index +1;
        }


        // Given an array representing number base -2, return array representing number equal to (-)number in the same base, -2
        // { 1, 1, 0, 1, 0, 1, 1 } = 23, return { 1, 1, 1, 0, 0, 1} = -23
        // https://en.wikipedia.org/wiki/Negative_base
        static public int[] solution2(int[] A)
        {
            long number = 0;
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            for(int j= A.Length-1; j >= 0; j--)
            {
                number += (long)( A[j] * Math.Pow(-2, j));
            }

            number = -number;
            List <int> newNum = new List<int>();
            int i = 0;
            while(true)
            {

                if (number % -2 != 0)
                    newNum.Add(1);
                else
                {
                    newNum.Add(0);
                }
                number = (int)Math.Ceiling((double)number / -2.0);
                if(number == 1)
                {
                    newNum.Add(1);
                    break;
                }else
                {
                    i++;
                }
            }
            newNum.Reverse();
            return newNum.ToArray();
        }

		//The knight is the piece in the game of chess that, in one turn, can move two squares horizontally and one square vertically or two squares vertically and one square horizontally.
		//An infinite chessboard is given. All of its squares are empty except for the square with coordinates (0,0), where a knight stands.
		//Write a function:
		//def solution(A, B)
		//that, given two numbers A and B, returns the minimum number of turns required for the knight to move from square (0,0) to square (A,B). The function should return -1 if the knight cannot reach the given square. The function should return -2 if the required number of turns exceeds 100,000,000.
		//For example, given A=4 and B=5 the function should return 3, because the knight requires three turns to move from square (0,0) to square (4,5):
		//in the first turn the knight moves from square (0,0) to square (2,1);
		//in the second turn the knight moves from square (2,1) to square (3,3);
		//in the thirs turn the knight moves from square (3,3) to square (4,5)
		//Assume that:
		//A and B are integers within the range [-100,000,000...100,000,000]
		//Complexity:
		//expected worst-case time complexity is O(1);
		//expected worst-case space complexity is O(1).

		//	https://github.com/Jarosh/Exercises/wiki/Finding-the-shortest-path-as-for-knight--in-the-game-of-chess-on-an-infinite-board        
        public static int solution3(int A, int B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            double a = (double)A;
            double b = (double)B;

            if (((a / b >= 0.5 && a / b <= 2) || (a / b <= -0.5 && a / b >= -2)) && ((A + B) % 3 == 0))
            {
                if ((a + b) / 3 <= 100000000)
                {
                    double res = (a + b) / 3;
                    return (int)(res > 0 ? res : -res);
                }
                else
                {
                    return -2;
                }
            }
            else
            {
                return -1;
            }
        }
        static void Main(string[] args)
        {
            //int[] a = new int[4] { 1, 0, 1, 1 };
            //int[] a = new int[7] { 1, 1, 0, 1, 0, 1, 1 };
            //int[] res = solution2(a);


            //int res = solution("(())))");
            //int res = solution("(((((");
            //int res = solution("))");


            int res = solution3(2000000,4000000);
        }
    }
}
