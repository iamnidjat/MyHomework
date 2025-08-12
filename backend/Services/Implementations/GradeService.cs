using backend.Models;
using backend.Services.Interfaces;

namespace backend.Services.Implementations
{
    public class GradeService : CRUDBaseService<Grade>, IGradeService
    {
        public GradeService(MyHomeworkDbContext context, ILogger<GradeService> logger)
        : base(context, logger)
        {}


    }
}
