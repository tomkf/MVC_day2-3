using Portfolio.Models;
using portfolio_mvc.Models;
using portfolio_mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio_mvc.Repositories
{
    public class InterviewRequestVMRepo
    {
        private PortfolioContext db;

        private bool CompanyExist(string companyName)
        {

            return db.Companies.Any(cn => cn.Name == companyName);
        }

        public bool Create(InterviewRequestVM irVM)
        {
            Company newCompany;
            //If the company is not in the db then we need to create a new company object
            if (!CompanyExist(irVM.Company))
            {
                newCompany = new Company()
                {
                    //Primary key is auto updated

                    //actual Compaby table entity = irVM data
                    Name = irVM.Company,
                    Contact = irVM.Contact,
                    Phone = irVM.Phone,
                    Email = irVM.Email
                };

                //Add that new Company in the database Company Table
                db.Companies.Add(newCompany);

            }
            else
            {
                newCompany = db.Companies.FirstOrDefault(cn => cn.Name == irVM.Company);
            }


            //we want to create a new InterviewRequest in db. So we just create an object of IntreviewRequest
            InterviewRequest newRequest = new InterviewRequest()
            {
                // Remember you can't update the primary key without 
                // causing trouble. 

                //actual Compaby table entity = irVM data
                Id = irVM.Id,
                Time = irVM.Time,
                Location = irVM.Location,
                Company = newCompany
            };

            //Add the new Interview Request in the database InterviewRequest Table

            db.InterviewRequests.Add(newRequest);

            db.SaveChanges();
            return true;
        }
    }
}
