using UnityEngine;

namespace HG.HelpBox
{
    // Helpbox with the ability to enable RichText 
    // Lacks the image of the message type
    public class RichHelpbox : IDrawer
    {
        private string _text;
        private GUIStyle _style = null;
        private bool _richTextEnabled = false;
        
        // @LATER implement font size
        public RichHelpbox(string text, int fontSize = 12)
        {
            _text = text;
        }

        public RichHelpbox EnableRichText()
        {
            _richTextEnabled = true;
            return this;
        }
        
        public void Draw()
        {
            if (_style == null)
            {
                _style = GUI.skin.GetStyle("HelpBox");
            }
            _style.richText = _richTextEnabled;

            GUILayout.Label(_text, _style);
        }
    }
}