using FluentValidation;

namespace ListSmarter.DTOs.Validators
{
    public class TaskDtoValidator : AbstractValidator<TaskDto>

    {
    public TaskDtoValidator()
    {
        RuleFor(task => task.Id).GreaterThan(0);
        RuleFor(task => task.Title).NotEmpty().WithMessage("Task title cannot be empty");
        RuleFor(task => task.Description).NotEmpty();
        RuleFor(task => task.Status).NotNull();
        RuleFor(task => task.Assignee).NotNull();
        RuleFor(task => task.Bucket).NotNull();
    }
    }
}