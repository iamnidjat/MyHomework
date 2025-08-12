using backend.Models;
using backend.Services.Interfaces;

namespace backend.Services.Implementations
{
    public class AnnouncementService : CRUDBaseService<Announcement>, IAnnouncementService
    {
        public AnnouncementService(MyHomeworkDbContext context, ILogger<AnnouncementService> logger)
        : base(context, logger)
        { }
    }
}
