using Hostelz_FunctionalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostelz_DBService
{
    public static class DBContextInitializer
    {

        public static async Task Initialize(DataProtectionKeysContext dataProtectionKeysContext, ApplicationDbContext applicationDBContext,
            IFunctionalService functionalService)
        {
            // Check, if db DataProtectionKeysContext is created
            // Check, if db ApplicationDbContext is created
            await dataProtectionKeysContext.Database.EnsureCreatedAsync();
            await applicationDBContext.Database.EnsureCreatedAsync();


            // Check, if db contains any users. If db is not empty, then db has been already seeded
            if (applicationDBContext.ApplicationUsers.Any())
            {
                return;
            }

            // If empty create Admin User and App User
            await functionalService.CreateDefaultAdminUser();
            await functionalService.CreateDefaultUser();
        }

    }
}
