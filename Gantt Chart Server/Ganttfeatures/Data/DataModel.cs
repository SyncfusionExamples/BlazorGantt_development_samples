namespace Ganttfeatures.Data
{
    public class TaskData
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public int? PID { get; set; }
    }

    public class DataModel
    {
        public static List<TaskData> GetGanttData()
        {
            List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { ID = 1, Name = "Data Binding"  },
            new TaskData() { ID = 2, Name = "Self-Referential", Url="Self-Referential", PID = 1 },
            new TaskData() { ID = 3, Name = "Self-Referential default", PID = 2 },
            new TaskData() { ID = 4, Name = "ExpandoObject Binding", PID = 2 },
            new TaskData() { ID = 5,  Name = "DynamicObject binding", PID = 2 },
            new TaskData() { ID = 6, Name = "Hierarchical data Binding",PID=1 },
            new TaskData() { ID = 7,  Name = "Hierarchical data Binding default", PID = 6 },
        };
            return Tasks;
        }

        public static List<TaskData> GetTreeGridData()
        {
            List<TaskData> Tasks1 = new List<TaskData>() {
            new TaskData() { ID = 1,Name = "Selection" },
            new TaskData() { ID = 2,Name = "TreeGrid Selection", PID = 1 },
            new TaskData() { ID = 3,Name = "TreeGridSelectionDefault", PID = 2 },
            new TaskData() { ID = 4,Name = "cellselection", PID = 2 },
            new TaskData() { ID = 5,Name = "checkboxselection", PID = 2 },
            new TaskData() { ID = 6,Name = "Toggleselection", PID = 2 },
            new TaskData() { ID = 7,Name = "Grid Selection", PID = 1 },
            new TaskData() { ID = 8,Name = "GridSelectionDefault", PID = 7 },
            new TaskData() { ID = 9,Name = "GridCellSelection", PID = 7 },
            new TaskData() { ID = 10,Name = "GridCheckboxSelection", PID = 7 },
            new TaskData() { ID = 11,Name = "GridToggleselection", PID = 7},
            new TaskData() { ID = 12, Name = "Frozen"},
            new TaskData() { ID = 13, Name = "FrozenTemplateColumns", Url="Frozen/ColumnTemplate", PID = 12}
        };
            return Tasks1;
        }

        public static List<TaskData> GetBSTData()
        {
            List<TaskData> Tasks1 = new List<TaskData>()
            {

            };
            return Tasks1;
        }

    }
}
