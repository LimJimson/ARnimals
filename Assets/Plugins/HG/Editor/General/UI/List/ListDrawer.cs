using System;
using System.Collections.Generic;
using HG.Button;
using HG.Label;

namespace HG.List
{
    public enum ListOrientation
    {
        Horizontal,
        Vertical
    }

    public class ButtonInfo<T> where T : class
    {
        private readonly Action<T> _onButtonPress;
        private readonly string _text;
        private readonly int _width;
        public ButtonInfo(string text, int width, Action<T> onButtonPress)
        {
            this._onButtonPress = onButtonPress;
            _text = text;
            _width = width;
        }

        public ButtonBase CreateButton(T data)
        {
            return new ButtonWithData<T>(_text, _onButtonPress, data).SetWidth(_width);
        }
    }
    
    public class ListDrawer<T> : IDrawer where T : class
    {
        private IDrawer _emptyDrawer = null;
        private AlteratingListDrawer _listDrawer;
        
        public ListDrawer(IEnumerable<T> list, Func<T, IDrawer> CreateDrawerDelegate, ListOrientation orientation)
        {
            _listDrawer = new AlteratingListDrawer(orientation);
            foreach (var item in list)
            {
                _listDrawer.AddDrawer(CreateDrawerDelegate.Invoke(item));
            }
        }


        public ListDrawer(IEnumerable<T> list, Func<T, IDrawer> CreateDrawerDelegate):this(list, CreateDrawerDelegate, ListOrientation.Vertical)
        {

        }

        // will draw this instead when list size == 0
        public ListDrawer<T> SetEmptyDrawer(IDrawer drawer)
        {
            _emptyDrawer = drawer;
            return this;
        }

        
        
        public void Draw()
        {
            if (_listDrawer.Count() == 0 &&_emptyDrawer != null) 
            {
                _emptyDrawer.Draw();
            }
            else
            {
                _listDrawer.Draw();
            }
        }
        

        // @LATER move from here, into some kinda generic, but still a separate factory
        public static ListDrawer<T> CreateLabelList(IEnumerable<T> list, Func<T, string> labelDlg, Func<T, string> tooltipDlg = null)
        {
            return new ListDrawer<T>(list, item => new DelegatedLabel<T>(item, labelDlg, tooltipDlg));
        }


        public static ListDrawer<T> CreateButtonedLabelList(IEnumerable<T> list, Func<T, string> labelDlg,
            Func<T, string> tooltipDlg = null, List<ButtonInfo<T>> buttons = null) 
        {

            return new ListDrawer<T>(list, item =>
            {
                var sequence = new HorizontalSequenceDrawer();
                sequence.AddDrawer(new DelegatedLabel<T>(item, labelDlg, tooltipDlg).EnableRichText());

                if (buttons != null)
                {
                    foreach (var buttonInfo in buttons)
                    {
                        sequence.AddDrawer(buttonInfo.CreateButton(item));
                    }
                }
                return sequence;
            });
        }

        // message system that is called at the next frame?
        // that way the OnPress will not effect other drawing.
        // the main problem really is that when i press 'x', i delete the array i iterate over, should i just copy it or something?
        // ORRRR it is no longer a problem cuz i don' store a list, i create drawers based on it....
        
        
        // @LATER removable list drawer create
        // create a horizontal sequence of a button & a DelegatedLabel.
        // should be just a one-two lines again
        
    }
}