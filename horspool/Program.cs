using System;

namespace horspool
{
    class Program
    {

        public static int[] ShiftTable(string P)
        {
            int[] shifttable= new int [256];
            char[] Parray = P.ToCharArray();
            for(int i =0; i < shifttable.Length;i++)
            {
                shifttable[i] = P.Length;
            }
            for(int j = 0; j < P.Length-1;j++)
            {
                shifttable[Parray[j]] = P.Length - 1 - j;
            }
            return shifttable;

        }

        public static int HorspoolMatching(string P, string T)
        {
            char[] Parray = P.ToCharArray();
            char[] Tarray = T.ToCharArray();
            int[] shifttable = ShiftTable(P);
            int i = Parray.Length - 1;
            while(i <= Tarray.Length -1)
            {
                int k = 0;
                while(k < Parray.Length && Parray[Parray.Length -1 - k] == Tarray[i-k])
                {
                    k++;
                }
                if(k == Parray.Length)
                {
                    return i - Parray.Length + 1;
                }
                else
                {
                    i = i + shifttable[Tarray[i]];
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            for(int i = 0; i <= 5; i++)
            {
            Console.WriteLine("Horspool Algorithm \n give your text here:");
            string text = Console.ReadLine();
                Console.WriteLine("Give your key here: ");
            string key = Console.ReadLine();
            int t = HorspoolMatching(key, text);
                if(t != -1)
                    Console.WriteLine("Your key ({0}) was founded in this position({1})",key,t);
                else
                    Console.WriteLine("There's no key({0}) in your text({1})",key,text);
            }
            
            Console.ReadLine();
        }
    }
}
