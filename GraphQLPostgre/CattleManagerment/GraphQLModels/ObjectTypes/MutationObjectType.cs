using CattleManagerment.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CattleManagerment
{
    public class MutationObjectType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(_ => _.UserLogin(default))
            .Type<StringType>()
            .Name("UserLogin")
            .Argument("login", a => a.Type<LoginInputObjectType>());
        }
    }
}
