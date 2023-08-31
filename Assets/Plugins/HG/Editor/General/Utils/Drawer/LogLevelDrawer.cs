using HG.Dropdown;

namespace HG
{
    public class LogLevelDrawer : IDrawer
    {
        private EnumDropdown logLevelEnum;
        
        public LogLevelDrawer()
        {
            logLevelEnum = new EnumDropdown(HG.HGLogger.SelectedLoggingLevel, "Log Level");
            logLevelEnum.OnChangedSelection += () =>
            {
                OnLoggingLevelSelectionChanged((LogLevel)logLevelEnum.GetCurrentValue());
            };
        }

        private void OnLoggingLevelSelectionChanged(LogLevel level)
        {
            HGLogger.SelectedLoggingLevel = level;
        }
        
        public void Draw()
        {
            logLevelEnum.Draw();
        }
    }
}