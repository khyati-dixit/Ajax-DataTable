using DataRetrieveAajx.Entitiess;
using DataRetrieveAajx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataRetrieveAajx.Repository
{
    public class RepositoryUserDetailss : IUserDetailss
    {
        public IEnumerable<UserDetailModel> GetUserDetails()
        {
            using (var dbContext = new Entities())
            {
                List<UserDetail> userDetails = dbContext.UserDetails.ToList();
                List<CarDetail> carDetails = dbContext.CarDetails.ToList();
                List<UserDetailModel> userViewModels = new List<UserDetailModel>();
                foreach (var user in userDetails)
                {

                    var data = new UserDetailModel
                    {

                        UserId = user.UserId,
                        FullName = user.FullName,
                        UserEmail = user.UserEmail,
                        CivilIdNumber = user.CivilIdNumber,


                    };

                    var cardetails = string.Join(",", carDetails.Where(x => x.UserId == user.UserId).Select(y => y.CarLicense).ToList());

                    data.CarLicense = cardetails;


                    userViewModels.Add(data);

                }

                return userViewModels;




            }



        }
    }
}