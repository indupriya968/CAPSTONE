using IMS.models;

namespace IMS.repository
{
    public class repo : Irepo
    {
        private readonly userdbcontext _dbcontext;

        public repo(userdbcontext x)
        {
            _dbcontext = x;
        }

        public  string createCustomers(registermodel rm)
        {
            _dbcontext.Register.Add(new usermodel
            {

                FIRSTNAME = rm.FIRSTNAME,
                LASTNAME = rm.LASTNAME ,
                USERNAME = rm.USERNAME,
                PASSWORD = rm.PASSWORD,

            });
            _dbcontext.SaveChanges();
            return "OK";
        }


    }
}

