using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using static Ganttfeatures.Controller.LoadOnDemandController;


namespace Ganttfeatures.Models
{
    public class TaskData
    {
        public static List<TaskData> ganttData = new List<TaskData>();
        
        [JsonPropertyName("ID")]
        public int ID { get; set; }
        [JsonPropertyName("TaskName")]
        public string TaskName { get; set; }
        [JsonPropertyName("StartDate")]
        public DateTime StartDate { get; set; }
        [JsonPropertyName("EndDate")]
        public DateTime EndDate { get; set; }
        [JsonPropertyName("Duration")]
        public string Duration { get; set; }
        [JsonPropertyName("Assignee")]
        public string Assignee { get; set; }
        [JsonPropertyName("Reporter")]
        public string Reporter { get; set; }
        [JsonPropertyName("Progress")]
        public int Progress { get; set; }
        [JsonPropertyName("ParentId")]
        public int? ParentId { get; set; }
        [JsonPropertyName("Status")]
        public string Status { get; set; }
        [JsonPropertyName("Work")]
        public double? Work { get; set; }
        [JsonPropertyName("WorkersCount")]
        public int WorkersCount { get; set; }
        [JsonPropertyName("TaskType")]
        public string TaskType { get; set; }
        [JsonPropertyName("ApprovedBy")]
        public string ApprovedBy { get; set; }
        [JsonPropertyName("Shift")]
        public string Shift { get; set; }
        [JsonPropertyName("PlatForm")]
        public string PlatForm { get; set; }
        [JsonPropertyName("StoryPoint")]
        public int StoryPoint { get; set; }
        [JsonPropertyName("Priority")]
        public string Priority { get; set; }
        [JsonPropertyName("FixVerison")]
        public string FixVerison { get; set; }
        [JsonPropertyName("ActualStartDate")]
        public DateTime ActualStartDate { get; set; }
        [JsonPropertyName("ActualEndDate")]
        public DateTime ActualEndDate { get; set; }
        [JsonPropertyName("Predecessor")]
        public string Predecessor { get; set; }
        [JsonPropertyName("isParent")]
        public bool? isParent { get; set; }
        public static List<TaskData> GetTree()
        {
            if (ganttData.Count == 0)
            {
                Random rand = new Random();
                var x = 0;
                int duration = 0;
                int recordCount = queryParams != null && queryParams.ContainsKey("RecordCount") ?
                    Convert.ToInt32(queryParams["RecordCount"].ToString()) : 10;
                DateTime startDate = queryParams != null && queryParams.ContainsKey("StartDate") ?
                    Convert.ToDateTime(queryParams["StartDate"].ToString()) : new DateTime(2000, 1, 5);
                DateTime endDate = queryParams != null && queryParams.ContainsKey("EndDate") ?
                    Convert.ToDateTime(queryParams["EndDate"].ToString()) : new DateTime(2000, 1, 12);

                string[] assignee = { "Allison Janney", "Bryan Fogel", "Richard King", "Alex Gibson" };
                string[] reporter = { "James Ivory", "Jordan Peele", "Guillermo del Toro", "Gary Oldman" };
                string[] priority = { "Normal", "High", "Low", "Ultra Critical" };
                string[] status = { "Validated", "InProgress", "Approved", "Completed" };
                string[] tasktype = { "FixedDuration", "FixedWork", "FixedUnit" };
                string[] shift = { "Noon Shift", "Night Shift", "Regular" };
                int[] storypoint = { 1, 2, 3, 4 };
                string[] fixversion = { "19.1", "19.2", "20.1", "20.2" };
                string[] approvedby = { "Margaret Buchanan", "Van Jack", "Fuller King", "Rose Fuller" };
                string[] platform = { "Blazor", "Angular", "EJ2", "EJ1" };
                for (var i = 1; i <= recordCount; i++)
                {
                    startDate = startDate.AddDays(i == 1 ? 0 : 7);
                    DateTime childStartDate = startDate;
                    TaskData Parent = new TaskData()
                    {
                        ID = ++x,
                        TaskName = "Task " + x,
                        StartDate = startDate,
                        EndDate = startDate.AddDays(26),
                        ActualStartDate = startDate,
                        ActualEndDate = endDate,
                        Duration = "20",
                        Assignee = "Mark Bridges",
                        Reporter = "Kobe Bryant",
                        Progress = rand.Next(100),
                        Priority = "High",
                        TaskType = "FixedWork",
                        Status = "Open",
                        Work = 16 + x,
                        Shift = "Regular",
                        StoryPoint = 5,
                        WorkersCount = 4,
                        FixVerison = "20.2",
                        ApprovedBy = "Van Jack",
                        PlatForm = "Blazor",
                        Predecessor = null,
                        isParent = true,
                        ParentId = null
                    };
                    ganttData.Add(Parent);
                    for (var j = 1; j <= 4; j++)
                    {
                        childStartDate = childStartDate.AddDays(j == 1 ? 0 : duration + 2);
                        duration = 5;
                        ganttData.Add(new TaskData()
                        {
                            ID = ++x,
                            TaskName = "Task " + x,
                            StartDate = childStartDate,
                            EndDate = childStartDate.AddDays(5),
                            ActualStartDate = childStartDate,
                            ActualEndDate = childStartDate.AddDays(5),
                            Duration = duration.ToString(),
                            Assignee = assignee[j - 1],
                            Reporter = reporter[j - 1],
                            Progress = rand.Next(100),
                            ParentId = Parent.ID,
                            Priority = priority[j - 1],
                            Status = status[j - 1],
                            Work = 96 + x,
                            TaskType = tasktype[(j - 1) % 3],
                            Shift = shift[(j - 1) % 3],
                            StoryPoint = storypoint[j - 1],
                            WorkersCount = 1,
                            FixVerison = fixversion[j - 1],
                            ApprovedBy = approvedby[j - 1],
                            PlatForm = platform[j - 1],
                            Predecessor = j > 1 ? (x - 1) + "FS" : "",
                            isParent = false
                        });
                    }
                }
            }
            return ganttData;
        }
    }
}
