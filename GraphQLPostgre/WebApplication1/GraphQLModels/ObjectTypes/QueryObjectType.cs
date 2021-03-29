using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.GraphQLCore;
using WebApplication1.GraphQLModels.InputObjectTypes;

namespace WebApplication1.GraphQLModels.ObjectTypes
{
    public class QueryObjectType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(a => a.GetAllUserAsync(default)).Name("GetAllUser").UsePaging().UseFiltering().UseSorting();
            //descriptor.Field(a => a.GetAllUserAsync1(default)).Name("GetAllUser1").UseFiltering().UseSorting();
            //descriptor.Field(a => a.GetAllUserAsync2(default)).Name("GetAllUser2").UseSorting();
            descriptor.Field(a => a.GetUserByIdAsync(default, default)).Name("GetUserById");

            descriptor.Field(a => a.GetAllRoleAsync(default)).Name("GetAllRole");

            descriptor.Field(a => a.GetAllFarmerAsync(default)).Name("GetAllFarmer");
            descriptor.Field(a => a.GetFarmerByIdAsync(default, default)).Name("GetFarmerById");

            descriptor.Field(a => a.GetAllByreAsync(default)).Name("GetAllByre");
            descriptor.Field(a => a.GetByreById(default, default)).Name("GetByreById");

            descriptor.Field(a => a.GetAllCattleAsync(default)).Name("GetAllCattle");
            descriptor.Field(a => a.GetCattleById(default, default)).Name("GetCattleById");

            descriptor.Field(a => a.GetAllTypeOfCattleAsync(default)).Name("GetAllTypeOfCattle");
            descriptor.Field(a => a.GetTypeOfCattleById(default, default)).Name("GetTypeOfCattleById");
        }

    }
}
