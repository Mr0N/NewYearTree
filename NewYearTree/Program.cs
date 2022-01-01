// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Timers;
using System.Resources;
using NewYearTree;

List<Check> ls = new List<Check>();
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
        await Task.Delay(1000);
        Change();
    }
});
//Console.BackgroundColor = ConsoleColor.Red;

void Set(char obj)
{
    if (obj == '@')
    {
        Console.ForegroundColor = ConsoleColor.Red;
        var result = Console.GetCursorPosition();
        var check =  new Check() { Left = result.Left, Top = result.Top, isRed = false };
        ls.Add(check);
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
        Console.SetCursorPosition(item.Left,item.Top);
        if (item.isRed)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("@");
            item.isRed = false;
        }
        else// if(Console.ForegroundColor == ConsoleColor.Yellow)
        {
            item.isRed = true;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@");
        }
    }

}
Console.ReadKey();
class Check
{
    public int Left { set; get; }
    public int Top { set; get; }
    public bool isRed { set; get; }
}