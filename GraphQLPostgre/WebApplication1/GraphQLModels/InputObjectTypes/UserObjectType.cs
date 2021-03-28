using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.GraphQLModels.InputObjectTypes
{
    public class UserObjectType : InputObjectType<User>
    {
        protected override void Configure(IInputObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IntType>().Name("Id");
            descriptor.Field(a => a.Email).Type<StringType>().Name("Email");
            descriptor.Field(a => a.Password).Type<StringType>().Name("Password");
        }
    }
}
