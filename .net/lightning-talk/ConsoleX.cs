using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lightning_talk
{
    public static class ConsoleX
    {
        private const int ConsoleSpeed = 5;

        public static void WriteLine()
        {
            Console.WriteLine();
        }

        public static void WriteLine(string format, params object[] args)
        {
            var str = string.Format(format, args);

            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;
            bool currentCursorVisible = Console.CursorVisible;


            Console.CursorVisible = false;

            var ms = new MatrixString(str);

            for (int i = 0; i <= ms.MaxSteps + ConsoleSpeed; i += ConsoleSpeed)
            {
                Console.SetCursorPosition(currentLeft, currentTop);
                Console.WriteLine(ms.Step(i));

                Thread.Sleep(1);
            }

            Console.CursorVisible = currentCursorVisible;
        }
    }

    public class MatrixString
    {
        private string str;
        private readonly int shuffles;
        private Random rnd;
        private const string shuffleChars = "ABCDEFGHIJKLMNOPQRSTUVXYZÅÄÖabcdefghijklmnopqrstuvxyzåäö";

        public MatrixString(string str, int shuffles = 0, int seed = 0)
        {
            this.str = str;

            if (shuffles == 0)
                this.shuffles = str.Length;
            else
                this.shuffles = shuffles;

            if (seed == 0)
                this.rnd = new Random();
            else
                this.rnd = new Random(seed);
        }

        public int MaxSteps
        {
            get
            {
                return str.Length + shuffles;
            }
        }

        public string Step(int step)
        {
            var sb = new StringBuilder();
            var maxChar = step > str.Length ? str.Length : step;

            for (int i = 0; i < maxChar; i++)
            {
                if (step - i <= shuffles)
                    sb.Append(GetRandomShuffleChar());
                else
                    sb.Append(str[i]);
            }

            return sb.ToString();
        }

        private char GetRandomShuffleChar()
        {
            return shuffleChars[rnd.Next(0, shuffleChars.Length)];
        }
    }

}
