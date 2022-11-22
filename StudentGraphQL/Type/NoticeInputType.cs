using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGraphQL.Type
{
    public class NoticeInputType : InputObjectGraphType
    {
        public NoticeInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("noticeData");
            Field<DateTimeGraphType>("date");
        }
    }
}
