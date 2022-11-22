using GraphQL.Types;
using StudentGraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGraphQL.Type
{
    public class NoticeType : ObjectGraphType<Notice>
    {
        public NoticeType()
        {
            Field(s => s.Id);
            Field(s => s.NoticeData);
            Field(s => s.date);
        }
    }
}
