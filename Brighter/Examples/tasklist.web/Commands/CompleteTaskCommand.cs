using System;
using paramore.commandprocessor;

namespace tasklist.web.Commands
{
    public class CompleteTaskCommand : Command, IRequest
    {
        public CompleteTaskCommand(int taskId, DateTime completionDate)
            : base(Guid.NewGuid())
        {
            TaskId = taskId;
            CompletionDate = completionDate;
        }

        public DateTime CompletionDate{ get; set; }
        public int TaskId { get; set; }
    }
}