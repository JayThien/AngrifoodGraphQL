using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.GraphQLCore;

namespace WebApplication1.GraphQLModels.ObjectTypes
{
    public class QueryObjectType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(a => a.GetAllUserAsync(default)).Name("GetAllUser");
            descriptor.Field(a => a.GetUserByIdAsync(default, default)).Name("GetUserById");
            descriptor.Field(a => a.GetAllRoleAsync(default)).Name("GetAllRole");
        }

    }
}
