﻿namespace Ganttfeatures.Data
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
            new TaskData() { ID = 2, Name = "Self-Referential", PID = 1 },
            new TaskData() { ID = 3, Name = "Self-Referential default", PID = 2, Url="Self-Referential" },
            new TaskData() { ID = 4, Name = "ExpandoObject Binding", PID = 2, Url="ExpandoObject_Binding" },
            new TaskData() { ID = 5,  Name = "DynamicObject binding", PID = 2, Url="DynamicObject_binding" },
            new TaskData() { ID = 6, Name = "Hierarchical data Binding",PID=1 },
            new TaskData() { ID = 7,  Name = "Hierarchical data Binding default", PID = 6, Url="Hierarchical_data_Binding" },
            new TaskData() { ID = 8, Name = "ResourceView"  },
            new TaskData() { ID = 9, Name = "ResourceView", Url="ResourceView", PID = 8 },
            new TaskData() { ID = 10, Name = "Columns"  },
            new TaskData() { ID = 11, Name = "DateOnlyTimeOnly", Url="DateOnlyTimeOnly", PID = 10 },
            new TaskData() { ID = 12, Name = "Remote data binding", PID = 1 },
            new TaskData() { ID = 13, Name = "Load child on demand", PID=12, Url="LoadChildOnDemand" },
            new TaskData() { ID = 14, Name = "Custom Adaptor", PID=12, Url="CustomAdaptor" },
            new TaskData() { ID = 15, Name = "URL Adaptor", PID=12, Url="URLAdaptor" },
            new TaskData() { ID = 16, Name = "WebAPI Adaptor", PID=12, Url="WebAPIAdaptor" },
            new TaskData() { ID = 17, Name = "Miscellaneous" },
            new TaskData() { ID = 18, Name = "Persist state", PID=17, Url="Persistence" },
            new TaskData() { ID = 19, Name = "Read-Only", PID=17, Url="Read-Only" },
            new TaskData() { ID = 20, Name = "Templates" },
            new TaskData() { ID = 21, Name = "Column-Tooltip-Taskbar", PID=20, Url="Template" },
            new TaskData() { ID = 22, Name = "Scheduling" },
            new TaskData() { ID = 23, Name = "Unscheduled", PID=22, Url="Unscheduled" },
        };
            return Tasks;
        }

        public static List<TaskData> GetTreeGridData()
        {
            List<TaskData> Tasks1 = new List<TaskData>() {
            new TaskData() { ID = 1,Name = "Selection", PID = 14 },
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
            new TaskData() { ID = 12, Name = "Frozen", PID = 14},
            new TaskData() { ID = 13, Name = "FrozenTemplateColumns", Url="TreeGrid/Frozen/ColumnTemplate", PID = 12},
            new TaskData() { ID = 14, Name = "TreeGrid" },
            new TaskData() { ID = 15, Name = "Grid" },
            new TaskData() { ID = 16, Name = "DropDown" },
            new TaskData() { ID = 17, Name = "MultiSelect", Url="DropDown/MultiSelect-Dropdown", PID = 16 },
        };
            return Tasks1;
        }

        public static List<TaskData> GetBSTData()
        {
            List<TaskData> Tasks1 = new List<TaskData>()
            {
                new TaskData() { ID = 1, Name = "RowVirtual", Url="BST/GanttPage"}
            };
            return Tasks1;
        }

    }
}
