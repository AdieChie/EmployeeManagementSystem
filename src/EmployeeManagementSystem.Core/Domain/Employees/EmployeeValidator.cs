using Abp.Dependency;
using Abp.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Domain.Employees
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("Email Address is required");
            RuleFor(x => x.ContactNumber).NotEmpty().WithMessage("Contact Number is required");

            RuleFor(x => x).Custom((entity, context) => {

                if (ValidateEmail(entity.EmailAddress))
                {
                    context.AddFailure("Email address is not valid");
                }

                if (!IsValidPhoneNumber(entity.ContactNumber))
                {
                    context.AddFailure("Contact number is not valid");
                }

                var repo = IocManager.Instance.Resolve<IRepository<Employee, string>>();
                var exist = repo.GetAllList().Any(x => x.EmailAddress == entity.EmailAddress);

                if (exist)
                {
                    context.AddFailure("Email address already exists");
                }

            });
        }

        private bool ValidateEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    
            public static bool IsValidPhoneNumber(string number)
            {
                // South African phone number regex pattern
                string pattern = @"^(?:\+27|0)[1-9]\d{8}$";
                Regex regex = new Regex(pattern);
                return regex.IsMatch(number);
            }
        
    }
}
