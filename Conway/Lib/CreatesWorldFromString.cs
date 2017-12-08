﻿using System;
using System.Collections.Generic;
using System.Linq;
using Conway.Contracts;
using Conway.Values;

namespace Conway.Lib
{
    public class CreatesWorldFromString : ICreatesWorldFromString
    {
        const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string[] lines;
        int width;
        int height;

        public World CreateWorldFrom(string input)
        {
            lines = TrimLeft(input.Split(new []{ "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
            width = lines.Max(x => x.Length);
            height = lines.Length;

            return new World
            {
                LivingCells = ParseLivingCells()
            };
        }

        string[] TrimLeft(string[] lines)
        {
            var chars_to_trim = lines.Select(CountLeadingSpaces).Min();
            return lines.Select(x => x.Substring(chars_to_trim)).ToArray();
        }

        int CountLeadingSpaces(string line)
        {
            return line.Length - line.TrimStart().Length;
        }

        string[] ParseLivingCells()
        {
            List<string> list = new List<string>();
            
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    if (CellAt(x, y)) list.Add(Cell(x, y));

            return list.ToArray();
        }

        string Cell(int x, int y)
        {
            return String.Format("{0}:{1}", Alphabet[x], y+1);
        }

        bool CellAt(int x, int y)
        {
            if (y < 0 || y >= lines.Length) return false;
            if (x < 0 || x >= lines[y].Length) return false;
            return lines[y][x] == '#';
        }
    }
}