using SFEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFEF.Repository
{
    public class UserRepository : Repository<User>
    {

        public UserRepository(SFEFContext dbContext):base(dbContext)
        { 
            
        }

        public void UpdateName(int Id, string name)
        {
            User user = this.GetById(Id);
            if (user == null)
                return;

            user.Name = name;
            this.Save();
        }

    }
}
