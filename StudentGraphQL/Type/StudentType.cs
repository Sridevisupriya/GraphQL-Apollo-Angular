using GraphQL.Types;
using StudentGraphQL.Models;

namespace StudentGraphQL.Type
{
    public class StudentType : ObjectGraphType<Student>
    {
        public StudentType()
        {
            Field(s => s.StudentID);
            Field(s => s.Name);
            Field(s => s.Course);
            Field(s => s.Email);
            Field(s => s.Gender);
            Field(s => s.Mobile);
            Field(s => s.YearOfJoining);
            Field(s => s.Address);
            Field(s => s.Dateofbirth);

        }
    }
}
