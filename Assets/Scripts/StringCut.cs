using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringCut : MonoBehaviour
{
    //string str = "castlejoycastlecatjoy";
    string str = "catstudycatstudy";
    //string str = "abc";
    //string[] wordSet = new string[] { "joy", "castle", "cat"};
    string[] wordSet = new string[] { "cats", "study", "cat"};
    //string[] wordSet = new string[] { "bc", "ab", "c", "a"};

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(canBeSplit(str, wordSet));
    }

    bool canBeSplit(string str, string[] wordSet)
    {
        var curP = 0;
        var states = new Stack<int>();
        states.Push(curP);
        while (states.Count != 0)
        {
            curP = states.Pop();
            if (curP == str.Length)
            {
                return true;
            }

            var right = str.Substring(curP);

            foreach (var word in wordSet)
            {
                if (right.StartsWith(word))
                {
                    states.Push(curP + word.Length);
                }
            }
        }
        return false;
    }
}
