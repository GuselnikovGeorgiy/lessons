using student;
using student.Models;

namespace studentTests;

public class GetStudentsWithCoursesTests
{
    private readonly StudentService _studentService = new();
    
    [Fact]
    public void GetStudentsWithCourses_ShouldReturnStudentsWithCourses_WhenStudentsAndCoursesExist()
    {
        // Arrange
        var students = new List<Student>
        {
            new() { FullName = "Zhora", Id = Guid.NewGuid() },
            new() { FullName = "Petya", Id = Guid.NewGuid() },
        };

        var courses = new List<Course>
        {
            new() { Id = Guid.NewGuid(), StudentId = students[0].Id, Title = "C# bloody enterprise" },
        };

        var expected = new List<(Student student, List<Course> courses)>
        {
            (students[0], new List<Course> { courses[0] }),
            (students[1], new List<Course>())
        };
        
        // Act
        var result = _studentService.GetStudentsWithCourses(students, courses);
        
        // Assert
        Assert.Equal(expected.Count, result.Count);

        Assert.Equal(expected[0].student.Id, result[0].Student.Id);
        Assert.Equal(expected[0].student.FullName, result[0].Student.FullName);
        Assert.Equal(expected[0].courses[0].StudentId, result[0].Student.Id);
        Assert.Equal(expected[0].courses[0].Title, result[0].Courses[0].Title);
        
        Assert.Equal(expected[1].student.Id, result[1].Student.Id);
        Assert.Equal(expected[1].student.FullName, result[1].Student.FullName);
        Assert.Empty(result[1].Courses);
    }
    
    [Fact]
    public void GetStudentsWithCourses_ShouldReturnEmpty_WhenStudentsAndCoursesNotExist()
    {
        // Arrange
        var students = new List<Student>();

        var courses = new List<Course>();
        
        // Act
        var result = _studentService.GetStudentsWithCourses(students, courses);
        
        // Assert
        Assert.Empty(result);
    }
}