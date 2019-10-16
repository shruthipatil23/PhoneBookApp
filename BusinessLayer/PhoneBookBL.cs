using DataAccessLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PhoneBookBL
    {
        public static void AddPhoneBookDetails(PhoneDetails phoneDetails)
        {
            try
            {
                PhoneBookDL.AddUpdatePhoneBookDetails(phoneDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<PhoneDetails> GetAllPhoneBookDetails()
        {
            return PhoneBookDL.GetAllPhoneBookDetails();
        }

        public static void UpdatePhoneBookDetails(PhoneDetails phoneDetail)
        {
            PhoneBookDL.AddUpdatePhoneBookDetails(phoneDetail);
        }

        public static List<PhoneDetails> GetPhoneDetailsBySearch(string searchText)
        {
            return PhoneBookDL.GetPhoneBookDetailsBySearch(searchText);
        }

        public static void DeletePhoneBookDetailById(int phoneBookId)
        {
            PhoneBookDL.DeletePhoneBookDetailsById(phoneBookId);
        }
    }
}
