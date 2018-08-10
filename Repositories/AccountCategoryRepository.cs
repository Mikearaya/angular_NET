
using angularNet.Models;
using angularNet.Services;

namespace angularNet.Repositories {

    public class AccountCategoryRepository : 
                    MainRepository<smart_financeContext, AccountCategory>, IAccountCategory 
    {
    
    }
}