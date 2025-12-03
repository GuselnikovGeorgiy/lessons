using student.Models;

namespace student;

public class StudentService
{
    public List<(Student Student, List<Course> Courses)> GetStudentsWithCourses(
        ICollection<Student> students,
        ICollection<Course> courses)
    {
        return students.GroupJoin(
            courses,
            student => student.Id,
            course => course.StudentId,
            (student, studentCourses) => (
                Student: student,
                Course: studentCourses.ToList()
            ))
        .ToList();
    }
}