using System;
using paramore.commandprocessor;
using tasklist.web.Commands;
using tasklist.web.DataAccess;
using tasklist.web.Models;

namespace tasklist.web.Handlers
{
    public class CompleteTaskCommandHandler : RequestHandler<CompleteTaskCommand>
    {
        readonly ITasksDAO tasksDAO;

        public CompleteTaskCommandHandler(ITasksDAO tasksDao)
        {
            tasksDAO = tasksDao;
        }

        [Validation(step: 2, timing: HandlerTiming.Before)]
        [Trace(step:1, timing: HandlerTiming.Before)]
        public override CompleteTaskCommand Handle(CompleteTaskCommand completeTaskCommand)
        {
            Task task = tasksDAO.FindById(completeTaskCommand.TaskId);
            if (task != null)
            {
                task.CompletionDate = completeTaskCommand.CompletionDate;
                tasksDAO.Update(task);
            }
            else
            {
                throw new ArgumentOutOfRangeException("completeTaskCommand", completeTaskCommand, "Could not find the task to complete");
            }
            return completeTaskCommand;
        }
    }
}