using GraphQL;
using GraphQL.Types;
using StudentGraphQL.Interfaces;
using StudentGraphQL.Type;

namespace StudentGraphQL.Query
{
    public class StudentQuery : ObjectGraphType
    {
        public StudentQuery(IStudentService studentService)
        {
            Field<ListGraphType<StudentType>>("students", resolve: context => 
            { 
                return studentService.GetAllStudents();
            });
            Field<ListGraphType<NoticeType>>("notices", resolve: context =>
            {
                return studentService.GetAllNotices();
            });
            Field<StudentType>("student", arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "email" }),
                resolve: context =>
                {
                    return studentService.GetStudentsByEmail(context.GetArgument<string>("email"));
                });
            Field<ListGraphType<StudentType>>("studentsbyCourse", arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "course" }),
                resolve: context =>
                {
                    return studentService.GetStudentsByCourse(context.GetArgument<string>("course"));
                });
        }
    }
}
