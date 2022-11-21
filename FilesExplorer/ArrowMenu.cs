using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesExplorer
{
    internal class ArrowMenu
    {
        int min, max;
        ConsoleKey keyPressed;
        int markPosition;
        public ArrowMenu(int max, int min = 0)
        {
            //ctor
            //min - минимальное значение Console.SetCursorPosition по высоте
            //max - максимальное значение Console.SetCursorPosition по высоте
            this.min = min;
            this.max = max-1;
        }
        public int Arrows()
        {
            //Реализация стрелочного меню через if
            //Метод возвращает выбранную позицию (int)
            string mark = "->";
            markPosition = min;
            do
            {
                keyPressed = Console.ReadKey(true).Key;
                MenuClear();
                if (keyPressed == ConsoleKey.Escape)
                    return markPosition = -444;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    markPosition--;
                    if (markPosition < min)
                    {
                        markPosition = max;
                    }
                    if (markPosition > max)
                    {
                        markPosition = min;
                    }
                    Console.SetCursorPosition(0, markPosition);
                    Console.Write(mark);
                }
                if (keyPressed == ConsoleKey.DownArrow)
                {
                    markPosition++;
                    if (markPosition < min)
                    {
                        markPosition = max;
                    }
                    if (markPosition > max)
                    {
                        markPosition = min;
                    }
                    Console.SetCursorPosition(0, markPosition);
                    Console.Write(mark);
                }
            }
            while (keyPressed != ConsoleKey.Enter);
            Console.Clear();
            return markPosition;
        }
        private void MenuClear()
        {
            //Очистка стрелочек в зависимости от их позиции (markPosition)
            Console.SetCursorPosition(0, markPosition);
            Console.Write("  ");
        }
    }
}
