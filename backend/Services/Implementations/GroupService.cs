using backend.Models;
using backend.Services.Interfaces;
using backend.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Group = backend.Models.Group;

namespace backend.Services.Implementations
{
    public class GroupService : CRUDBaseService<Group>, IGroupService
    {
        public GroupService(MyHomeworkDbContext context, ILogger<GroupService> logger)
        : base(context, logger)
        {
        }
    }
}
