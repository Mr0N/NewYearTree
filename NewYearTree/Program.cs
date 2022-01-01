// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Timers;
using System.Resources;
using NewYearTree;

string text = Resource.load;
//Console.BackgroundColor = ConsoleColor.Yellow;
foreach (var item in text)
{
    Set(item);
    Console.Write(item);
}
Console.BackgroundColor = ConsoleColor.Red;
void Set(char obj)
{
    if (obj == '@')
        Console.ForegroundColor = ConsoleColor.Red;
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
Console.ReadKey();