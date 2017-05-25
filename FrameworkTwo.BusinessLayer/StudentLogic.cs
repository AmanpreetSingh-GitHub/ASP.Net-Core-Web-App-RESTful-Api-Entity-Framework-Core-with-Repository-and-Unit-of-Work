using FrameworkTwo.BusinessLayer.Interface;
using FrameworkTwo.Domain;
using FrameworkTwo.Model;
using FrameworkTwo.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace FrameworkTwo.BusinessLayer
{
    public class StudentLogic : IStudentLogic
    {
        private IUnitOfWork unitOfWork;
        private IGenericRepository<Student> studentRepository;

        public StudentLogic(IUnitOfWork unitOfWork, IGenericRepository<Student> studentRepository)
        {
            this.unitOfWork = unitOfWork;
            this.studentRepository = studentRepository;
        }

        public List<StudentModel> GetStudents()
        {
            List<Student> students = studentRepository.GetAll().ToList();

            List<StudentModel> studentModels = new List<StudentModel>();
            foreach (Student student in students)
            {
                StudentModel studentModel = new StudentModel()
                {
                    StudentId = student.StudentId,
                    Name = student.Name
                };

                studentModels.Add(studentModel);
            }

            return studentModels;
        }
    }
}
