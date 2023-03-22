using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomFunction {
    public static string ToCamelCase(string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;
        
        string[] words = str.Split(' ');

        for (int i = 1; i < words.Length; i++)
        {
            string word = words[i];
            if (word.Length > 0)
            {
                char firstChar = char.ToUpper(word[0]);
                string rest = "";
                if (word.Length > 1)
                    rest = word.Substring(1);
                words[i] = firstChar + rest;
            }
        }

        return string.Join("", words);
    }
}
