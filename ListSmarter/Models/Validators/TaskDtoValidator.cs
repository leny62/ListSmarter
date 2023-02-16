namespace ListSmarter.Models.Validators
{
    public class TaskDtoValidator
    {
        public static bool Validate(TaskDto task)
        {
            if (task == null)
            {
                return false;
            }
            if (task.Id < 0)
            {
                return false;
            }
            if (string.IsNullOrEmpty(task.Title))
            {
                return false;
            }
            if (string.IsNullOrEmpty(task.Description))
            {
                return false;
            }
            if (task.Status == null)
            {
                return false;
            }
            if (task.Assignee == null)
            {
                return false;
            }
            if (task.Bucket == null)
            {
                return false;
            }
            return true;
        }
    }
}