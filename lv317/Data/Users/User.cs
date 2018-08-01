using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lv317.Tools;

namespace lv317.Data.Users
{
    public interface IFirstname
    {
        ILastname SetFirstname(string firstname);
    }

    public interface ILastname
    {
        IEmail SetLastname(string lastname);
    }

    public interface IEmail
    {
        IPhone SetEmail(string email);
    }

    public interface IPhone
    {
        IAddressMain SetPhone(string phone);
    }

    public interface IAddressMain
    {
        ICity SetAddressMain(string addressMain);
    }

    public interface ICity
    {
        IPostcode SetCity(string city);
    }

    public interface IPostcode
    {
        ICoutry SetPostcode(string postcode);
    }

    public interface ICoutry
    {
        IRegionState SetCoutry(string coutry);
    }

    public interface IRegionState
    {
        IPassword SetRegionState(string regionState);
    }

    public interface IPassword
    {
        ISubscribe SetPassword(string password);
    }

    public interface ISubscribe
    {
        IFax SetSubscribe(bool subscribe);
    }

    public interface IFax : IUserBuilder
    {
        ICompany SetFax(string fax);
    }

    public interface ICompany : IUserBuilder
    {
        IAddressAdd SetCompany(string company);
    }

    public interface IAddressAdd : IUserBuilder
    {
        IUserBuilder SetAddressAdd(string addressAdd);
    }

    public interface IUserBuilder
    {
        // 5. Add Builder
        //User Build();
        // 6. Add Dependency Inversion
        IUser Build();
    }

    // 6. Add Dependency Inversion
    public interface IUser
    {
        string GetFirstname();
        string GetLastname();
        string GetEmail();
        string GetPhone();
        string GetAddressMain();
        string GetCity();
        string GetPostcode();
        string GetCoutry();
        string GetRegionState();
        string GetPassword();
        bool GetSubscribe();
        string GetFax();
        string GetCompany();
        string GetAddressAdd();
    }

    public class User : IFirstname, ILastname, IEmail,
                        IPhone, IAddressMain, ICity, IPostcode, ICoutry,
                        IRegionState, IPassword, ISubscribe,
                        IFax, ICompany, IAddressAdd, IUserBuilder, IUser
    {
        // Required
        private string firstname;
        private string lastname;
        private string email;
        private string phone;
        private string addressMain;
        private string city;
        private string postcode;
        private string coutry;
        private string regionState;
        private string password;
        private bool subscribe;
        // Advanced
        private string fax;
        private string company;
        private string addressAdd;

        // 1. Bad practics
        //public User(string firstname, string lastname, string email,
        //    string phone, string addressMain, string city,
        //    string postcode, string coutry, string regionState,
        //    string password, bool subscribe)
        //{
        //    this.firstname = firstname;
        //    this.lastname = lastname;
        //    this.email = email;
        //    this.phone = phone;
        //    this.addressMain = addressMain;
        //    this.city = city;
        //    this.postcode = postcode;
        //    this.coutry = coutry;
        //    this.regionState = regionState;
        //    this.password = password;
        //    this.subscribe = subscribe;
        //}
        //
        // 2. Add public Default Constructor and Setters/Getters
        //public User()
        //{ }
        //
        // 4. Static Factory
        private User()
        { }

        // 4. Static Factory
        //public static User Get()
        // 5. Add Builder.
        public static IFirstname Get()
        {
            return new User();
        }

        // Setters

        // 2.
        //public void SetFirstname(string firstname)
        // 3. Add Fluent Interface
        //public User SetFirstname(string firstname)
        // 5. Add Builder
        public ILastname SetFirstname(string firstname)
        {
            this.firstname = firstname;
            return this;
        }

        public IEmail SetLastname(string lastname)
        {
            this.lastname = lastname;
            return this;
        }

        public IPhone SetEmail(string email)
        {
            this.email = email;
            return this;
        }

        public IAddressMain SetPhone(string phone)
        {
            this.phone = phone;
            return this;
        }

        public ICity SetAddressMain(string addressMain)
        {
            this.addressMain = addressMain;
            return this;
        }

        public IPostcode SetCity(string city)
        {
            this.city = city;
            return this;
        }

        public ICoutry SetPostcode(string postcode)
        {
            this.postcode = postcode;
            return this;
        }

        public IRegionState SetCoutry(string coutry)
        {
            this.coutry = coutry;
            return this;
        }

        public IPassword SetRegionState(string regionState)
        {
            this.regionState = regionState;
            return this;
        }

        public ISubscribe SetPassword(string password)
        {
            this.password = password;
            return this;
        }

        public IFax SetSubscribe(bool subscribe)
        {
            this.subscribe = subscribe;
            return this;
        }

        public ICompany SetFax(string fax)
        {
            this.fax = fax;
            return this;
        }

        public IAddressAdd SetCompany(string company)
        {
            this.company = company;
            return this;
        }

        public IUserBuilder SetAddressAdd(string addressAdd)
        {
            this.addressAdd = addressAdd;
            return this;
        }

        // 5. Add Builder
        //public User Build()
        // 6. Add Dependency Inversion
        public IUser Build()
        {
            return this;
        }

        // Getters

        public string GetFirstname()
        {
            return firstname;
        }

        public string GetLastname()
        {
            return lastname;
        }
        public string GetEmail()
        {
            return email;
        }

        public string GetPhone()
        {
            return phone;
        }

        public string GetAddressMain()
        {
            return addressMain;
        }

        public string GetCity()
        {
            return city;
        }

        public string GetPostcode()
        {
            return postcode;
        }

        public string GetCoutry()
        {
            return coutry;
        }

        public string GetRegionState()
        {
            return regionState;
        }

        public string GetPassword()
        {
            return password;
        }

        public bool GetSubscribe()
        {
            return subscribe;
        }

        public string GetFax()
        {
            return fax;
        }

        public string GetCompany()
        {
            return company;
        }

        public string GetAddressAdd()
        {
            return addressAdd;
        }

        public static IList<IUser> GetAllUsers(IExternalReader externalData)
        {
            //logger.Debug("Start GetAllUsers, path = " + path);
            //IExternalReader externalData = new CSVReader(filename);
            IList<IUser> users = new List<IUser>();
            foreach (IList<string> row in externalData.GetAllCells())
            {
                if (row[2].ToLower().Equals("email")
                        && row[9].ToLower().Equals("password"))
                {
                    continue;
                }
                users.Add(User.Get()
                        .SetFirstname(row[0])
                        .SetLastname(row[1])
                        .SetEmail(row[2])
                        .SetPhone(row[3])
                        .SetAddressMain(row[4])
                        .SetCity(row[5])
                        .SetPostcode(row[6])
                        .SetCoutry(row[7])
                        .SetRegionState(row[8])
                        .SetPassword(row[9])
                        .SetSubscribe(row[10].ToLower().Equals("true"))
                        .Build());
                //logger.Debug("Add User Firstname= " + row[0] + " Lastname = " + row[1] + " Email = " + row[2]);
            }
            //logger.Debug("Done GetAllUsers, path = " + externalData.GetConnection());
            return users;
        }

    }
}
