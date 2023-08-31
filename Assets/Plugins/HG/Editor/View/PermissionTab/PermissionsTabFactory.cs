namespace HG
{
    internal class PermissionsTabFactory
    {
        public static TabView CreateTab(IPermissionsManipulator permissionsManipulator, DataHolder data)
        {
            var tab = new TabView("Permissions");

            tab.AddDrawer(new PermissionsListDrawer(permissionsManipulator, new PermissionsListController(permissionsManipulator), data));
            return tab;
        }
    }
}