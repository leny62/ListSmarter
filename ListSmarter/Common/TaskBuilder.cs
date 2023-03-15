using ListSmarter.Repositories.Models;
using ListSmarter.Repositories.Models.Enums;
using Task = ListSmarter.Repositories.Models.Task;

namespace ListSmarter.Common;

public class TaskBuilder
{
    private int _id;
    private string _title;
    private string _description;
    private int _bucketId;
    private Status _status;
    private int _assigneeId;
    
    public TaskBuilder WithId(int id)
    {
        _id = id;
        return this;
    }
    
    public TaskBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }
    
    public TaskBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }
    
    public TaskBuilder WithBucketId(int bucketId)
    {
        _bucketId = bucketId;
        return this;
    }
    
    public TaskBuilder WithStatus(Status status)
    {
        _status = status;
        return this;
    }
    
    public TaskBuilder WithAssigneeId(int assigneeId)
    {
        _assigneeId = assigneeId;
        return this;
    }
    
    public Task Build()
    {
        return new Task
        {
            Id = _id,
            Title = _title,
            Description = _description,
            Bucket = _bucketId,
            Status = _status,
            Assignee = _assigneeId
        };
    }
}