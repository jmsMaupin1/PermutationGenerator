using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationGenerator
{
    public class factoradicPermutationGenerator
    {
        /*
         * 
         * n this article, a factorial number representation 
         * will be flagged by a subscript "!", so for instance 341010!'s value is:
         * 
         * = 3×5! + 4×4! + 1×3! + 0×2! + 1×1! + 0×0! 
         * = ((((3×5 + 4)×4 + 1)×3 + 0)×2 + 1)×1 + 0
         * =  46310.
         *  = 3×5!         + 4×4!         + 1×3!         + 0×2!         + 1×1!         + 0×0!
         *  = (i+5)×(5)! + (i+4)×(4)! + (i+3)×(3)! + (i+2)×(2)! + (i+1)×(1)! + i×0 
         *  = (((((  3 ×5) +     4)×4 +     1)×3 +   0)×2 +   1)×1 + 0
         *  = (((((i+5)*5  + (i+4))*4 + (i+3))*3 + i+2)*2 + i+1)*1
         *  =  463.
         *  
         *  arr[] perm  = [3, 4, 1, 0, 1, 0];
         *  arr[] index = [0, 1, 2, 3, 4, 5];
         *  int n = perm.length;
         *  
         *  int sum = perm[0]; 
         *  
         *  for(int i = 1; i < n; ++i) 
         *      sum = (sum * (n - i)) + perm[i];
         *  
         *  
         *  given: 341010 as the factoradic index, we encode that into an integer n doing: 
         *  note: the order of the array is opposite of the number because you read each from
         *  different ends essentially.
         *  
         *  arr[] perm  = [3, 4, 1, 0, 1, 0];
         *  int      n  = 6;
         *  int    sum  = 3;
         *  
         *  loop: sum = (sum * (n - i)) + perm[i];
         *  
         *  i = 1: 
         *      sum = (3   * (6-1)) + 4 = 19
         *  i = 2:
         *      sum = (19  * (6-2)) + 1 = 77
         *  i = 3:
         *      sum = (77  * (6-3)) + 0 = 231
         *  i = 4:
         *      sum = (231 * (6-4)) + 1 = 463
         *  i = 5:
         *      sum = (463 * (6-5)) + 0 = 463
         *      
         *      
         *  Decoding:
         *  
         *  463 % 1 = 0
         *  463 / 1 = 463
         *  
         *  463 % 2 = 1
         *  463 / 2 = 231
         *  
         *  231 % 3 = 0
         *  231 / 3 = 77
         *  
         *  77 % 4  = 1
         *  77 / 4  = 19
         *  
         *  19 % 5 = 4
         *  19 / 5 = 3
         *  
         *  3 % 6 = 3
         *  3 / 6 < 0 --stop
         *  
         *  463 = [3, 4, 1, 0, 1, 0]
         *   
         *     to [3, 5, 1, 0, 4, 2]
         *  
         *  
         */


        /* 
         *  arr[] perm         = [0, 1, 2, 3, 5, 4]
         *  arr[] targ         = [0, 0, 0, 0, 1, 0]
         *  index = 1;
         *  
         *  arr[] perm         = [3, 5, 1, 0, 4, 2]
         *  arr[] targFactPerm = [3, 4, 1, 0, 1, 0]
         *  
         *  int n = 6;
         *  sum = count(elements < perm[0]) = 3
         *  
         *  for(int i = 1; i < perm.length; ++i) {
         *      sum *= (perm.length-(i))
         *      sum += count(element[j] < element[i] where j > i)
         *  }
         *  
         *  ------------------------------------------------------
         *  
         *  arr[] perm         = [3, 5, 1, 0, 4, 2]
         *  arr[] targFactPerm = [3, 4, 1, 0, 1, 0]
         *  
         *  sum = count(elements < perm[0]) = 3
         *  
         *  loop:
         *  i = 1:
         *      sum *= 6 - (1) = 3 * 5 = 15
         *      sum += count(element[j] < element[1] where j > 1) = 15 + 4 = 19;
         *      
         *  i = 2:
         *      sum *= 6 - 2 = 19 * 4 = 76
         *      sum += count(element[j] < element[2] where j > 2) = 76 + 1 = 77
         *      
         *  i = 3:
         *      sum *= 6 - 3 = 77 * 3 = 231
         *      sum += count(element[j] < element[3] where j > 3) = 231 + 0 = 231
         *      
         *  i = 4:
         *      sum *= 6 - 4 = 231 * 2 = 462
         *      sum += count(element[j] < element[4] where j > 4) = 462 + 1 = 463
         *      
         *  i = 5: (will alwayas be 0)
         *      sum *= 6 - 5 = 463 * 1 = 463
         *      sum += count(element[j] < element[5] where j > 1) = 463 + 0 = 463
         *      
         * Decoding:
         *  
         *  463 % 1 = 0
         *  463 / 1 = 463
         *  
         *  463 % 2 = 1
         *  463 / 2 = 231
         *  
         *  231 % 3 = 0
         *  231 / 3 = 77
         *  
         *  77 % 4  = 1
         *  77 / 4  = 19
         *  
         *  19 % 5 = 4
         *  19 / 5 = 3
         *  
         *  3 % 6 = 3
         *  3 / 6 < 0 --stop
         *  
         *  Read, the remainders backwards
         *  463 = [3, 4, 1, 0, 1, 0]
         *   
         *     to [3, 5, 1, 0, 4, 2]
         *     
         *     
         *   decoding 1
         *   
         *   1 % 1 = 0;
         *   1 / 2 = .5
         *   
         *   1 % .5 = 1;
         *   1 / .5 = stop
         *   
         *   1 = [1, 0]
         *       [0, 1, 2, 3, 4, 5]
         *       
         *   to = [1, 0, 2, 3, 4, 5]
         */

        public static int getPermIndex(int[] permutation)
        {
            int sum = 0;
            int permLen = permutation.Length;

            for (int i = 1; i < permLen; ++i)
                if (permutation[i] < permutation[0])
                    sum++;

            for(int i = 1; i < permLen; ++i)
            {
                sum *= permutation.Length - i;
                for (int j = i + 1; j < permLen; ++j)
                    if (permutation[j] < permutation[i])
                        sum++;
            }

            return sum;
        }

        public static int[] getPermutation(int n)
        {
            Stack<int> perm = new Stack<int>();

            int factBase = 1;
            while(n / factBase > 0)
            {
                perm.Push(n % factBase);
                n /= factBase;
                factBase++;
            }
            perm.Push(n % factBase);
            return perm.ToArray();
        }
    }

    class program
    {
        public static void Main(string[] args)
        {
            factoradicPermutationGenerator.getPermutation(463);
            Console.ReadKey();
        }
    }
}
