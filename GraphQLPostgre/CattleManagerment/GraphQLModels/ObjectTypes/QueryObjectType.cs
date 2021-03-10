using CattleManagerment.GraphQLCore;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CattleManagerment.GraphQLModels.ObjectTypes
{
    public class QueryObjectType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(_ => _.Welcome()).Name("Welcome").Type<StringType>();
        }
    }
}
