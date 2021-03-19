using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.GraphQLCore;
using WebApplication1.GraphQLModels.InputObjectTypes;

namespace WebApplication1.GraphQLModels.ObjectTypes
{
    public class MutationObjectType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(_ => _.UserLogin(default, default,default))
            .Name("UserLogin")
            .Type<StringType>()
            .Argument("login", a => a.Type<LoginInputObjectType>());
            descriptor.Field(a => a.CreateUserAsync(default, default)).Name("CreateUser").Argument("userInput", a=> a.Type<UserInputObjectType>());
            descriptor.Field(a => a.DeleteUserAsync(default, default)).Name("DeleteUser");
            descriptor.Field(a => a.UpdateUserAsync(default,default)).Name("UpdateUser");
            descriptor.Field(a => a.CreateRoleAsync(default, default)).Name("CreateRole");
            descriptor.Field(a => a.AddRoleToUserAsync(default, default, default)).Name("AddRoleToUser");
            descriptor.Field(a => a.DeleteFarmerAsync(default, default)).Name("DeleteFarmer");
            descriptor.Field(a => a.CreateFarmerAsync(default, default)).Name("CreateFarmer");
            descriptor.Field(a => a.UpdateFarmerAsync(default, default)).Name("UpdateFarmer");
        }
    }
}
