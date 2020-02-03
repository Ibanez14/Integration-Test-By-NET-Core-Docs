using System;

namespace XUnitTestProject.Custom_Factory_Testing
{
    public class RoleService : IRoleService
    {
        string IRoleService.GiveSomeData()
        {
            throw new NotImplementedException();
        }
    }

}


