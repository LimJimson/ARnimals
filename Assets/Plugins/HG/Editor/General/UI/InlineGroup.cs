using UnityEditor;
using UnityEngine;

namespace HG
{
    // @LATER - rename?
    public class InlineGroup : IDrawer
    {
        public enum Padding
        {
            MinusHeight,
            None
        }

        private readonly IDrawerWithHeight _drawer;
        private readonly Padding _padding;

        public InlineGroup(IDrawerWithHeight drawer, Padding padding = Padding.None)
        {
            _drawer = drawer;
            _padding = padding;
        }

        public void Draw()
        {
            // @LATER - move to a helper from all the places that is currently used. To be able to replace in one spot.
            var area = EditorGUILayout.GetControlRect(true, 0f); // this is a hack to get a rect, specify 0 height to not add extra padding

            float y = area.y;
            if (_padding == Padding.MinusHeight)
            {
                y = area.y - _drawer.GetHeight();
                if (y < 0) y = 0;
            }

            area = new Rect(area.x, y, area.width, _drawer.GetHeight());
            
            GUI.BeginGroup(area);
            //GUI.BeginClip(area);
            _drawer.Draw();
            GUI.EndGroup();
            //GUI.EndClip();
        }
    }
}