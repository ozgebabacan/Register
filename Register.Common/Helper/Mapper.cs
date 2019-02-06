using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Register.Model.DatabaseModel;
using Register.Model.ViewModel;

namespace Register.Common.Helper
{
    public static class Mapper
    {
        public static List<StudentViewModel> MapStudentStudentViewModel(List<Student> studentList)
        {
            var studentViewModelList = new List<StudentViewModel>();

            for (int i = 0; i < studentList.Count; i++)
            {
                var student = studentList[i];

                var studentViewModel = new StudentViewModel
                {
                    Id = student.Id,
                    Name = student.Name,
                    Surname = student.Surname,
                    MobilePhone = student.MobilePhone,
                    District = student.District?.Name,
                    City = student.City?.Name,
                    Description = student.Description
                };

                studentViewModelList.Add(studentViewModel);
            }

            return studentViewModelList;
        }
    }
}
