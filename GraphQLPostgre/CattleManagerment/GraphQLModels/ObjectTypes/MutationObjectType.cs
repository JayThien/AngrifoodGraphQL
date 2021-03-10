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
            descriptor.Field(_ => _.UserLogin(default, default))
            .Name("UserLogin")
            .Type<StringType>()
            .Argument("login", a => a.Type<LoginInputObjectType>());
        }
    }
}
