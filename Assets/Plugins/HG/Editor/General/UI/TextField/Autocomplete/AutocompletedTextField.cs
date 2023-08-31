using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using HG.Extensions;
using HG.TextField;

namespace HG.Autocomplete
{
    public class AutocompletedTextField : IDrawer, ITextField
    {
        private string _text = "";
        private int _maxShownCount;
        private float _distance;

        private List<string> _options;

        private AutocompleteImpl _autocomplete = new AutocompleteImpl();

        public event Action<string> OnOptionClicked;
        
        public AutocompletedTextField(List<string> options, int maxShownCount = 10, float levenshteinDistance = 0.5f)
        {
            _options = RemoveDuplicates(options);
            _maxShownCount = maxShownCount;
            _distance = levenshteinDistance;

            _autocomplete.OnOptionClicked += (s) =>
            {
                OnOptionClicked.InvokeSafe(s);
            };
        }

        private List<string> RemoveDuplicates(List<string> source)
        {
           return new List<string>(new HashSet<string>(source));
        }

        public string GetCurrentText()
        {
            return _text;
        }

        public void ClearInput()
        {
            _text = "";
        }

        public void SetCurrentText(string text)
        {
            _text = text;
        }

        // @LATER some sort of (on finished event, add a button or something?)

        public void Draw()
        {
            _text = _autocomplete.TextFieldAutoComplete(_text, _options, maxShownCount: _maxShownCount, levenshteinDistance: _distance);
        }
    }
}