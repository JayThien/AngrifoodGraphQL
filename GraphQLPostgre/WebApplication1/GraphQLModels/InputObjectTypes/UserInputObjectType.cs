using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.GraphQLModels.InputObjectTypes
{
    public class UserInputObjectType : InputObjectType<UserInputK>
    {
        protected override void Configure(IInputObjectTypeDescriptor<UserInputK> descriptor)
        {
            descriptor.Field(a => a.Email).Type<StringType>().Name("Email");
            descriptor.Field(a => a.Password).Type<StringType>().Name("Password");
            descriptor.Field(a => a.UserName).Type<StringType>().Name("UserName");
        }
    }
}
