namespace HG
{
    internal class GeneralTabFactory
    {
        public static TabView CreateTab(IManifestCollection manifestCollection, ISkipPermissionsDialogManipulator skipPermissionsDialogManipulator)
        {
            var tab = new TabView("General");

            tab.AddDrawer(new ManifestListDrawer(manifestCollection, new ManifestListController(manifestCollection)));
            tab.AddDrawer(new Space(10));
            tab.AddDrawer(new GeneralSettingsDrawer(skipPermissionsDialogManipulator));
            tab.AddDrawer(new Spacer());
            tab.AddDrawer(new RatingDrawer("https://assetstore.unity.com/packages/tools/integration/android-permission-manager-111005", "APM_"));
            return tab;
        }
    }
}