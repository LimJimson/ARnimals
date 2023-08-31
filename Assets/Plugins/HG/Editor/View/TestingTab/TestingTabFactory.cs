using HG.Testing;

namespace HG
{
    internal class TestingTabFactory
    {
        public static TabView CreateTab(ISkipPermissionsDialogManipulator skipPermissionsDialogManipulator, TestingSettings settings)
        {
            var tab = new TabView("Testing");
            tab.AddDrawer(new TestingOptionsDrawer(settings, skipPermissionsDialogManipulator));
            return tab;
        }
    }
}