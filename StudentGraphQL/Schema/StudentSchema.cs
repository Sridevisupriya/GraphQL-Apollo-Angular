using StudentGraphQL.Mutation;
using StudentGraphQL.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGraphQL.Schema
{
    public class StudentSchema : GraphQL.Types.Schema
    {
        public StudentSchema(StudentQuery studentQuery , StudentMutation studentMutation)
        {
            Query = studentQuery;
            Mutation = studentMutation;
        }
    }
}
