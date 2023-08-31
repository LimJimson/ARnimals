using System;

namespace HG.Dropdown
{
    public interface IDropdown
    {
        event Action OnChangedSelection;
    }
}