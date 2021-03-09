using CattleManagerment.Entities;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CattleManagerment.Models
{
    public class LoginInputObjectType : InputObjectType<LoginInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<LoginInput> descriptor)
        {
            descriptor.Field(_ => _.Email).Type<StringType>().Name("Email");
            descriptor.Field(_ => _.Password).Type<StringType>().Name("Password");
        }
    }
}
