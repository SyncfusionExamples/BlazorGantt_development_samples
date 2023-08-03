using Ganttfeatures.Models;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Linq.Dynamic.Core;
using Syncfusion.Blazor.Gantt;
using System.Collections;

namespace Ganttfeatures.Pages.Gantt.DataBinding
{
    public partial class LoadOnDemand
    {
        public static IEnumerable FetchChildRecords(IEnumerable DataSource, IQueryCollection queryString)
        {
            var GroupData = TaskData.ganttData.ToList().GroupBy(rec => rec.ParentId)
                                .Where(g => g.Key != null).ToDictionary(g => g.Key?.ToString(), g => g.ToList());
            foreach (TaskData Record in DataSource)
            {
                if (GroupData.ContainsKey(Record.ID.ToString()))
                {
                    var ChildGroup = GroupData[Record.ID.ToString()];
                    var dataList = DataSource.Cast<TaskData>().ToList();
                    if (ChildGroup?.Count > 0)
                        AppendChildren(ChildGroup, Record, GroupData, dataList, queryString);
                    DataSource = dataList.AsEnumerable();
                }
            }
            return DataSource;
        }
        private static void AppendChildren(List<TaskData> ChildRecords, TaskData ParentItem, Dictionary<string, List<TaskData>> GroupData, List<TaskData> dataList, IQueryCollection queryString)
        {
            string TaskId = ParentItem.ID.ToString();
            if (queryString.Keys.Contains("$orderby"))
            {
                StringValues srt;
                queryString.TryGetValue("$orderby", out srt);
                srt = srt.ToString().Replace("desc", "descending");
                List<TaskData> SortedChildRecords = SortingExtend.Sort(ChildRecords.AsQueryable(), srt).ToList();
                var index = dataList.IndexOf(ParentItem);
                foreach (var Child in SortedChildRecords)
                {
                    string ParentId = Child.ParentId.ToString();
                    if (TaskId == ParentId)
                    {
                        if (dataList.IndexOf(Child) == -1)
                            dataList.Insert(++index, Child);
                        if (GroupData.ContainsKey(Child.ID.ToString()))
                        {
                            var DeepChildRecords = GroupData[Child.ID.ToString()];
                            if (DeepChildRecords?.Count > 0)
                                AppendChildren(DeepChildRecords, Child, GroupData, dataList, queryString);
                        }
                    }
                }
            }
            else
            {
                var index = dataList.IndexOf(ParentItem);
                foreach (var Child in ChildRecords)
                {
                    string ParentId = Child.ParentId.ToString();
                    if (TaskId == ParentId)
                    {
                        if (dataList.IndexOf(Child) == -1)
                            dataList.Insert(++index, Child);
                        if (GroupData.ContainsKey(Child.ID.ToString()))
                        {
                            var DeepChildRecords = GroupData[Child.ID.ToString()];
                            if (DeepChildRecords?.Count > 0)
                                AppendChildren(DeepChildRecords, Child, GroupData, dataList, queryString);
                        }
                    }
                }
            }
        }
        public static List<TaskData> FetchRecordsToUpdate(TaskData dataAfterUpdate)
        {
            IQueryable<TaskData> dataSource = TaskData.ganttData.AsQueryable();
            return GanttDataOperations.UpdateDependentRecords<TaskData>(GanttRef, dataSource, dataAfterUpdate);
        }
    }
    public static class SortingExtend
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> source, string sortBy)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (string.IsNullOrEmpty(sortBy))
                throw new ArgumentNullException("sortBy");

            source = source.OrderBy(sortBy);

            return source;
        }
    }
}

