﻿using System.Collections.Generic;

namespace N2W.CORE
{
  public static class Constants
  {
    public static string And = "and";
    public static string Zero = "zero";
    public static string Hundred = "hundred";
    public static string Thousand = "thousand";
    public static string Million = "million";

    public static IDictionary<int, string> OneToNine = new Dictionary<int, string>
      {
        { 1, "one" },
        { 2, "two" },
        { 3, "three" },
        { 4, "four" },
        { 5, "five" },
        { 6, "six" },
        { 7, "seven" },
        { 8, "eight" },
        { 9, "nine" },
      };

    public static IDictionary<int, string> TenToNineteen = new Dictionary<int, string>
      {
        { 10, "ten" },
        { 11, "eleven" },
        { 12, "twelve" },
        { 13, "thirteen" },
        { 14, "fourteen" },
        { 15, "fifteen" },
        { 16, "sixteen" },
        { 17, "seventeen" },
        { 18, "eighteen" },
        { 19, "nineteen" },
      };

    public static IDictionary<int, string> TwentyToNinety = new Dictionary<int, string>
      {
        { 20, "twenty" },
        { 30, "thirty" },
        { 40, "forty" },
        { 50, "fifty" },
        { 60, "sixty" },
        { 70, "seventy" },
        { 80, "eighty" },
        { 90, "ninety" },
      };
  }
}
