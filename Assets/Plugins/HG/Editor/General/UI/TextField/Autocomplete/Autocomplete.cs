using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using HG.Extensions;

namespace HG.Autocomplete
{

    //http://www.clonefactor.com/wordpress/public/1769/
public sealed class AutocompleteImpl
{
#region Text AutoComplete
    private const string m_AutoCompleteField = "AutoCompleteField";
    private const int MIN_LENGTH_FOR_LEVENSHTEIN = 3; // 3 characters on input, hidden value to avoid doing too early.

    
    private List<string> m_CacheCheckList = null;
    private string m_AutoCompleteLastInput;
    private string m_EditorFocusAutoComplete;
    private float _levenshteinDistance;

    /// <summary>A textField to popup a matching popup, based on developers input values.</summary>
    /// <param name="input">string input.</param>
    /// <param name="source">the data of all possible values (string).</param>
    /// <param name="maxShownCount">the amount to display result.</param>
    /// <param name="levenshteinDistance">
    /// value between 0f ~ 1f,
    /// - more then 0f will enable the fuzzy matching
    /// - 1f = anything thing is okay.
    /// - 0f = require full match to the reference
    /// - recommend 0.4f ~ 0.7f
    /// </param>
    /// <returns>output string.</returns>
    public event Action<string> OnOptionClicked;

    private string _selectedOption = null;
    
    public string TextFieldAutoComplete(Rect position, string input, List<string> source, int maxShownCount = 5, float levenshteinDistance = 0.5f)
    {
        _selectedOption = null;
        _levenshteinDistance = Mathf.Clamp01(levenshteinDistance);
        
        string tag = m_AutoCompleteField + GUIUtility.GetControlID(FocusType.Passive);
        GUI.SetNextControlName(tag);
        string rst = EditorGUI.TextField(position, input);
        if (input.Length > 0 && GUI.GetNameOfFocusedControl() == tag)
        {
            if (m_AutoCompleteLastInput != input || // input changed
                m_EditorFocusAutoComplete != tag) // another field.
            {
                // Update cache
                m_EditorFocusAutoComplete = tag;
                m_AutoCompleteLastInput = input;
 
                List<string> options = new List<string>(source); // copy refs as we'll modify it
                
                m_CacheCheckList = new List<string>(System.Math.Min(maxShownCount, options.Count)); // optimize memory alloc
 
                FillWithOptions(input, maxShownCount, levenshteinDistance, options);
            }

            rst = DrawResults(position, rst);
        }

        if (_selectedOption != null)
        {
            OnOptionClicked.InvokeSafe(_selectedOption);
            rst = "";
        }

        return rst;
    }

    private void FillWithOptions(string input, int maxShownCount, float levenshteinDistance, List<string> options)
    {
        int srcCnt = options.Count;
        
        // try filling until we reach maxShowCount the the order of less processor work needed
        srcCnt = Fill(input, maxShownCount, srcCnt, options, StartsWith);
        //         if (m_CacheCheckList.Count != 0) return srcCnt; // @LATER it used to check that if we filled something, do not add any with fill
        srcCnt = Fill(input, maxShownCount, srcCnt, options, Contains);

        if (levenshteinDistance > 0f && // only developer request
            input.Length > MIN_LENGTH_FOR_LEVENSHTEIN &&
            m_CacheCheckList.Count < maxShownCount
        ) // have some empty space for matching. // @LATER check if (m_CacheCheckList.Count < maxShownCount) 'if' part is needed
        {
            srcCnt = Fill(input, maxShownCount, srcCnt, options, Levenshtein);
        }
    }

    private bool Levenshtein(string input, string option)
    {
        int distance = LevenshteinDistanceHelper.LevenshteinDistance(option, input, caseSensitive: false);
        bool closeEnough = (int) (_levenshteinDistance * option.Length) > distance;
        return closeEnough;
    }

    // @LATER to avoid string creation - ToLower all the options once (as they will probably be reused and not changed at all)
    // @LATER avoid string creation for "input" on each option checking
    private bool StartsWith(string input, string option)
    {
        return option.ToLower().StartsWith(input.ToLower());
    }
    
    private bool Contains(string input, string option)
    {
        return option.ToLower().Contains(input.ToLower());
    }

    private int Fill(string input, int maxShownCount, int srcCnt, List<string> options, Func<string, string, bool> Condition)
    {
        for (int i = 0; i < srcCnt && m_CacheCheckList.Count < maxShownCount; i++)
        {
            if (Condition(input, options[i]))
            {
                m_CacheCheckList.Add(options[i]);
                options.RemoveAt(i);
                srcCnt--;
                i--;
            }
        }
        return srcCnt;
    }


    private string DrawResults(Rect position, string rst)
    {
        // Draw recommend keyward(s)
        if (m_CacheCheckList.Count <= 0) return rst;
        
        
        int cnt = m_CacheCheckList.Count;
        float height = cnt * EditorGUIUtility.singleLineHeight;
        Rect area = position;
        area = new Rect(area.x, area.y - height, area.width, height);
        GUI.depth -= 10;
        //GUI.BeginGroup(area);
        // area.position = Vector2.zero;
        GUI.BeginClip(area);
        Rect line = new Rect(0, 0, area.width, EditorGUIUtility.singleLineHeight);

        for (int i = 0; i < cnt; i++)
        {
            if (GUI.Button(line, m_CacheCheckList[i], EditorStyles.toolbarButton)) //, EditorStyles.toolbarDropDown))
            {
                rst = m_CacheCheckList[i];
                GUI.changed = true;
                GUI.FocusControl(""); // force update

                _selectedOption = rst;
            }
            line.y += line.height;
        }
        GUI.EndClip();
        //GUI.EndGroup();
        GUI.depth += 10;
        return rst;
    }

    public string TextFieldAutoComplete(string input, List<string> source, int maxShownCount = 5, float levenshteinDistance = 0.5f)
    {
        Rect rect = EditorGUILayout.GetControlRect();
        return TextFieldAutoComplete(rect, input, source, maxShownCount, levenshteinDistance);
    }
    #endregion
}
}