// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Timers;
using System.Resources;
using NewYearTree;

List<(int left, int top)> ls = new List<(int left, int top)>();
string text = Resource.load;
//Console.BackgroundColor = ConsoleColor.Yellow;
foreach (var item in text)
{
    Set(item);
    Console.Write(item);
}
Task.Run(async () =>
{
    while (true)
    {
        await Task.Delay(3000);
        Change();
    }
});
//Console.BackgroundColor = ConsoleColor.Red;

void Set(char obj)
{
    if (obj == '@')
    {
        Console.ForegroundColor = ConsoleColor.Red;
        ls.Add(Console.GetCursorPosition());
    }
    else if (obj == '|' ||
        obj == '_' ||
        obj == ',' ||
        obj == '(' ||
        obj == ')' ||
        obj == '-' ||
        obj == '/' ||
        obj == '\\' ||
        obj == '\'') Console.ForegroundColor = ConsoleColor.Blue;
    else if (obj == 'o') Console.ForegroundColor = ConsoleColor.Yellow;
    else if (obj == '*') Console.ForegroundColor = ConsoleColor.Magenta;
    else Console.ForegroundColor = ConsoleColor.Green;
}
void Change()
{
    foreach (var item in ls)
    {
        Console.SetCursorPosition(item.left, item.top);
        if (Console.ForegroundColor == ConsoleColor.Red)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Y");
        }
        else// if(Console.ForegroundColor == ConsoleColor.Yellow)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("R");
        }
    }

}
Console.ReadKey();