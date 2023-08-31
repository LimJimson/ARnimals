using System.Collections.Generic;
using UnityEngine;

namespace HG
{
    public class TabView : ScrollView
    {
        public TabView(string title)
        {
            Title = title;
        }


        public string Title { get; private set; }
    }
}