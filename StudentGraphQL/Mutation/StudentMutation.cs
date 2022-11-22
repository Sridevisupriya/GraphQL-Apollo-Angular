using GraphQL;
using GraphQL.Types;
using StudentGraphQL.Interfaces;
using StudentGraphQL.Models;
using StudentGraphQL.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGraphQL.Mutation
{
    public class StudentMutation : ObjectGraphType
    {
        public StudentMutation(IStudentService studentService)
        {
            Field<StudentType>("createStudent", arguments: new QueryArguments(new QueryArgument<StudentInputType> { Name = "student" }),
               resolve: context =>
               {
                   return studentService.AddStudent(context.GetArgument<Student>("student"));
               });
            Field<NoticeType>("addNotice", arguments: new QueryArguments(new QueryArgument<NoticeInputType> { Name = "notice" }),
               resolve: context =>
               {
                   return studentService.AddNotice(context.GetArgument<Notice>("notice"));
               });

            Field<StudentType>("updateStudent", arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "email" },
                (new QueryArgument<StudentInputType> { Name = "student" })),
               resolve: context =>
               {
                   var id = context.GetArgument<string>("email");
                   var student = context.GetArgument<Student>("student");
                   return studentService.UpdateStudentDetails(id,student);
               });

            Field<StringGraphType>("deleteStudent", arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "email" }
                ),
               resolve: context =>
               {
                   var id = context.GetArgument<string>("email");
                   studentService.DeleteStudent(id);
                   return "The Student Details are removed";
               });           
        }
    }
}
