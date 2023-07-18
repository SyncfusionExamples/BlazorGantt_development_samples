using Syncfusion.Blazor.Gantt;
using Syncfusion.Blazor.Grids;

namespace Ganttfeatures.Pages.BST.Gantt
{
    public partial class GanttPage
    {
        private async Task ActionCompletedHandler(GanttActionEventArgs<BstTaskData> args)
        {

        }
        private async Task SplitterResized(Syncfusion.Blazor.Layouts.ResizingEventArgs args)
        {

        }
        private async Task OnColumnResized(ResizeArgs args)
        {

        }
        private async Task RowDragStart(RowDragEventArgs<BstTaskData> e)
        {

        }
        private async Task RowDropping(RowDroppedEventArgs<BstTaskData> e)
        {

        }
        private async Task RowSelecting(RowSelectingEventArgs<BstTaskData> e)
        {

        }
        private async Task RowDeselecting(RowDeselectEventArgs<BstTaskData> e)
        {

        }
        private async Task RowCollapsed(Syncfusion.Blazor.TreeGrid.RowCollapsedEventArgs<BstTaskData> e)
        {
            
        }
        private async Task RowExpanded(Syncfusion.Blazor.TreeGrid.RowExpandedEventArgs<BstTaskData> e)
        {
           
        }
        private async Task TaskbarEditing(TaskbarEditingEventArgs<BstTaskData> e)
        {
            this.taskbarEditAction = e.Action;
        }
    }
}
