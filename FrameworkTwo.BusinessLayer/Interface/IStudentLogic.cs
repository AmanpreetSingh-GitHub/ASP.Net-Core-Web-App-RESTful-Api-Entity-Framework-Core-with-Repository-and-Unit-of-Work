using FrameworkTwo.Model;
using System.Collections.Generic;

namespace FrameworkTwo.BusinessLayer.Interface
{
    public interface IStudentLogic
    {
        List<StudentModel> GetStudents();
    }
}
