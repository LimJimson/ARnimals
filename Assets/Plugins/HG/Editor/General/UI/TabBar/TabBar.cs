﻿using System.Collections.Generic;
using UnityEngine;

namespace HG
{
    public class TabBar : IDrawer
    {
        private List<TabView> _tabs = new List<TabView>();
        private int selectedTab = 0;
        private string[] tabNames; // Note: used for caching as tabs count doesn't change after creation
        
        public void AddTab(TabView tab)
        {
            _tabs.Add(tab);
            RefreshTabNames();
        }

        private void RefreshTabNames()
        {
            tabNames = new string[_tabs.Count];
            for (int i = 0; i < tabNames.Length; ++i)
            {
                tabNames[i] = _tabs[i].Title;
            }  
        }

        public void Draw()
        {
            selectedTab = GUILayout.Toolbar(selectedTab, tabNames);
            _tabs[selectedTab].Draw();
        }
    }
}