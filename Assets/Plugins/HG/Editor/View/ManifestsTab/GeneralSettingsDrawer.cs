using HG.Dropdown;

namespace HG
{


    public class GeneralSettingsDrawer : VerticalSequenceDrawer
    {
        private IDrawer _skipPermissionDialogDrawer;

        public GeneralSettingsDrawer(ISkipPermissionsDialogManipulator skipPermissionsDialogManipulator)
        {
            AddDrawer(new Label.Label("General Settings").SetBold(true));
            AddDrawer(new SkipPermissionDialogDrawer(skipPermissionsDialogManipulator));
            AddDrawer(new LogLevelDrawer());
        }        
    }
}