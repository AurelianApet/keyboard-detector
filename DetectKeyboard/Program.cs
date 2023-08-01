using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace DetectKeyboard
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int vKey);
        //static int num = 0;
        static bool isPressed = false;
        static void Detect()
        {
            //while (true)
            //{
            //    if (GetAsyncKeyState(32) != 0)
            //    {
            //        num++;
            //    }
            //    if (GetAsyncKeyState(32) == 0)
            //    {
            //        if (num > 1)
            //        {
            //            num = 0;
            //            Console.WriteLine("Released");
            //        }

            //        if (num == 1)
            //        {
            //            num = 0;
            //            Console.WriteLine("Pressed");
            //        }
            //    }

            //    Thread.Sleep(50);
            //}

            while (true)
            {
                if (!isPressed && GetAsyncKeyState(32) != 0)
                {
                    Console.WriteLine("Pressed");
                    isPressed = true;
                }

                if (isPressed && GetAsyncKeyState(32) == 0)
                {
                    Console.WriteLine("Released");
                    isPressed = false;
                }
                Thread.Sleep(100);
            }
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(Detect);
            t.IsBackground = true;
            t.Start();
            Console.ReadLine();
        }
    }
}
