using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(ValidateUserModel request);
    }
}
