using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication1.GraphQLModels.ObjectTypes
{
    public class QueryObjectType : ObjectType<Query>
    {
    }
}
