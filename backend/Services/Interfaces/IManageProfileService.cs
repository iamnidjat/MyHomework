using backend.DTOs;
using backend.Models;
using backend.Utilities;

namespace backend.Services.Interfaces
{
    public interface IManageProfileService
    {
        Task<OperationResult> UpdateStudentProfileAsync(int id, StudentProfile updatedProfile);
        Task<OperationResult> UpdateTeacherProfileAsync(int id, TeacherProfile updatedProfile);
        Task<OperationResult> UpdateUsernameAsync(int id, string newUsername, string userType);
        Task<OperationResult> UpdateEmailAsync(int id, string newEmail, string userType, bool flag);
        Task<OperationResult> DeleteStudentProfileAsync(int id);
        Task<OperationResult> FreezeStudentProfileAsync(int id);
        Task<OperationResult> TeacherProfileClosingRequestAsync(CreateTeacherProfileClosingRequestDto dto);
    }
}
