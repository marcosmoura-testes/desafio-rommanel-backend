using Domain.Entity;
using FluentValidation;
using MediatR;

namespace Application.Commands
{
    public class UpdateClientCommand : IRequest<Client>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string CpfCnpj { get; set; }
        public string BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string StateRegistration { get; set; }
        public bool IsStateRegistrationExempt { get; set; }
        public ClientAddress Address { get; set; }

        public UpdateClientCommand(Guid id, string fullName, string cpfCnpj, string birthDate, string phone, string email,
                                   string stateRegistration, bool isStateRegistrationExempt, ClientAddress address)
        {
            Id = id;
            FullName = fullName;
            CpfCnpj = cpfCnpj;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            StateRegistration = stateRegistration;
            IsStateRegistrationExempt = isStateRegistrationExempt;
            Address = address;
        }
    }

    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full Name is required.")
                .Length(3, 100).WithMessage("Full Name must be between 3 and 100 characters.");

            RuleFor(x => x.CpfCnpj)
                .NotEmpty().WithMessage("CPF/CNPJ is required.")
                .Must(ValidateCpfCnpj).WithMessage("Invalid CPF or CNPJ.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Birth Date is required.")
                .Must(BeAtLeast18YearsOld).WithMessage("Client must be at least 18 years old.");

            RuleFor(x => x.StateRegistration)
                .NotEmpty().When(x => !x.IsStateRegistrationExempt)
                .WithMessage("State Registration is required when not exempt.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\d{10,11}$").WithMessage("Invalid phone number.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Address)
                .NotNull().WithMessage("Address is required.")
                .SetValidator(new ClientAddressValidator());
        }

        private bool ValidateCpfCnpj(string cpfCnpj)
        {
            // Lógica de validação para CPF/CNPJ
            return true;// CpfCnpjValidator.ValidateCpfCnpj(cpfCnpj);
        }

        private bool BeAtLeast18YearsOld(string birthDate)
        {
            var birth = DateTime.Parse(birthDate);
            var today = DateTime.Now;
            var age = today.Year - birth.Year;
            if (today.Month < birth.Month || (today.Month == birth.Month && today.Day < birth.Day))
            {
                age--;
            }
            return age >= 18;
        }
    }
}
