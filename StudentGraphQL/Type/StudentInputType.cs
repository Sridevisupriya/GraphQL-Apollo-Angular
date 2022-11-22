using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGraphQL.Type
{
    public class StudentInputType : InputObjectGraphType
    {
        public StudentInputType()
        {
            Field<IntGraphType>("studentId");
            Field<StringGraphType>("name");
            Field<StringGraphType>("course");
            Field<StringGraphType>("email");
            Field<StringGraphType>("gender");
            Field<StringGraphType>("mobile");
            Field<IntGraphType>("yearOfJoining");
            Field<StringGraphType>("address");
            Field<StringGraphType>("dateofbirth");
        }
    }
}
