using UnityEngine;

namespace HG
{
    public class Space : IDrawer
    {
        private int _pixels;
        
        public Space(int pixels)
        {
            _pixels = pixels;
        }

        public void Draw()
        {
            GUILayout.Space(_pixels);
        }
    }
}