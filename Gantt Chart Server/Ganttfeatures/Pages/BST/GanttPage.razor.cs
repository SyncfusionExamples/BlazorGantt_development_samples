using Syncfusion.Blazor.Gantt;

namespace Ganttfeatures.Pages.BST
{
    public partial class GanttPage
    {
        private static readonly string[] workWeek = new[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        private static readonly List<DependencyType> dependencyType = new() { DependencyType.FS };
        private DateTime projectStart = new DateTime(2021, 03, 26);
        private DateTime projectEnd = new DateTime(2021, 12, 31);
        private string? taskbarEditAction;
        private const string parentDrag = "ParentDrag";
        private const string childDrag = "ChildDrag";
        private const string leftResizing = "LeftResizing";
        private const string rightResizing = "RightResizing";
    }
}
