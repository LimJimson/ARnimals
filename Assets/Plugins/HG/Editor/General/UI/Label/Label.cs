using UnityEditor;
using UnityEngine;

namespace HG.Label
{
    public class Label : IDrawer
    {
        private string _text;
        private string _tooltip;

        private GUIStyle _style = null;
        private FontStyle? _fontStyle;
        private bool _richTextEnabled = false;
        
        public Label(string text, string tooltip = null)
        {
            _text = text;
            _tooltip = tooltip;
        }

        public Label()
        {
        }


        public virtual void Draw()
        {
            if (_text != null)
            {
                Draw(_text, _tooltip);
            }
        }

        public Label SetText(string text)
        {
            _text = text;
            return this;
        }

        public Label SetBold(bool bold)
        {
            SetFontStyle(bold ? FontStyle.Bold : FontStyle.Normal);
            return this;
        }

        public Label SetFontStyle(FontStyle style)
        {
            _fontStyle = style;
            if (_style != null)
            {
                _style.fontStyle = _fontStyle.Value;
            }

            return this;
        }

        public Label SetStyle(GUIStyle style)
        {
            _style = style;
            return this;
        }
        
        public Label EnableRichText()
        {
            _richTextEnabled = true;
            return this;
        }

        protected void Draw(string text, string tooltip)
        {
            // @LATER consider adding a mechanism for that, as we cent use GUI.skin.label outside Draw calls, but we need to init only once
            if (_style == null)
            {
                _style = new GUIStyle(EditorStyles.label);
                if (_fontStyle != null)
                {
                    _style.fontStyle = _fontStyle.Value;
                }
            }

            _style.richText = _richTextEnabled;
            
            if (string.IsNullOrEmpty(tooltip))
            {
                GUILayout.Label(new GUIContent(text), _style);
            }
            else
            {
                GUILayout.Label(new GUIContent(text, tooltip), _style);    
            }
        }
    }
}