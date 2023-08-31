﻿using System;
using System.Text;

namespace HG.Extensions
{
    public static class StringExtensions
    {
        // Removes substring at the end if present
        public static string RemoveEndSubStr(this string inputText, string toRemove)
        {
            if (inputText.EndsWith(toRemove))
            {
                return inputText.Substring(0, inputText.LastIndexOf(toRemove, StringComparison.InvariantCulture));
            }

            return inputText;
        }


        public static string RemoveStartSubStr(this string inputText, string toRemove)
        {
            if (inputText.StartsWith(toRemove))
            {
                return inputText.Substring(toRemove.Length, inputText.Length - toRemove.Length);
            }
            
            return inputText;
        }

        public static bool StartsWithAny(this string text, params string[] options)
        {
            foreach (var option in options)
            {
                if (text.StartsWith(option))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool EndsWithAny(this string text, params string[] options)
        {
            foreach (var option in options)
            {
                if (text.EndsWith(option))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }
        
        // Clear to be able to reuse the builder without reallocations. (without new .Net versions)
        public static void Clear(this StringBuilder value)
        {
            value.Length = 0;
        }
    }
}