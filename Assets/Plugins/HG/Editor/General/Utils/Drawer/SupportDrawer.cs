using HG.Button;
using UnityEditor;
using UnityEngine;

namespace HG
{
    public class SupportDrawer : IDrawer
    {
        private readonly string _supportUrl;
        private VerticalSequenceDrawer _drawer = new VerticalSequenceDrawer();

        public SupportDrawer(string supportUrl)
        {
            _supportUrl = supportUrl;

            _drawer.SetStyle(EditorStyles.helpBox);
            _drawer.AddDrawer(new Label.Label("Support").SetBold(true));
            
            var horizontal = new HorizontalSequenceDrawer();
            horizontal.AddDrawer(new Space(10));
            horizontal.AddDrawer(new Clickable(new Label.Label("Something is missing or isn’t working?\n<b>Click here</b> to contact support").EnableRichText(),
                OnLabelPressed));
            
            _drawer.AddDrawer(horizontal);
        }

        private void OnLabelPressed()
        {
            Application.OpenURL(_supportUrl);
        }

        public void Draw()
        {
            _drawer.Draw();
        }
    }
}