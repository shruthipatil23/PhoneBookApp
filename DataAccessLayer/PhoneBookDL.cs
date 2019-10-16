using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PhoneBookDL
    {
        public static void AddUpdatePhoneBookDetails(PhoneDetails phoneDetails)
        {
            try
            {
                var context = new PhoneContext();
                if (phoneDetails.PhoneBookId == 0)
                {
                    context.dbPhoneDetails.Add(phoneDetails);
                    context.SaveChanges();
                }
                else
                {
                    var result = context.dbPhoneDetails.Find(phoneDetails.PhoneBookId);
                    if (result != null)
                    {
                        context.Entry(result).CurrentValues.SetValues(phoneDetails);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<PhoneDetails> GetAllPhoneBookDetails()
        {
            try
            {
                List<PhoneDetails> phoneDetails = new List<PhoneDetails>();
                var context = new PhoneContext();
                if (context.dbPhoneDetails.Any())
                {
                    phoneDetails = context.dbPhoneDetails.ToList<PhoneDetails>();
                }
                return phoneDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PhoneDetails GetPhoneBookDetailsById(int phoneBookId)
        {
            try
            {
                PhoneDetails phoneDetails = new PhoneDetails();
                var context = new PhoneContext();
                if (context.dbPhoneDetails.Any())
                {
                    phoneDetails = context.dbPhoneDetails.Where(a => a.PhoneBookId == phoneBookId).FirstOrDefault();
                }
                return phoneDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletePhoneBookDetailsById(int phoneBookId)
        {
            try
            {
                var context = new PhoneContext();
                PhoneDetails detail = new PhoneDetails { PhoneBookId = phoneBookId };
                context.Entry(detail).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<PhoneDetails> GetPhoneBookDetailsBySearch(string searchText)
        {
            List<PhoneDetails> phoneDetails = new List<PhoneDetails>();
            var context = new PhoneContext();
            if (context.dbPhoneDetails.Any())
            {
                phoneDetails = context.dbPhoneDetails.Where(a => a.FirstName.Contains(searchText) || 
                    a.MiddleName.Contains(searchText) || a.LastName.Contains(searchText) || 
                    a.PhoneNo.Contains(searchText) || a.Email.Contains(searchText)).ToList<PhoneDetails>();
            }
            return phoneDetails;
        }
    }
}
