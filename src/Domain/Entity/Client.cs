namespace Domain.Entity
{
    public class Client
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string CpfCnpj { get; private set; }
        public string BirthDate { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string StateRegistration { get; private set; }
        public bool IsStateRegistrationExempt { get; private set; }
        public ClientAddress Address { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public Client(Guid id)
        {
            Id = id;
        }
        public Client(string fullName, string cpfCnpj, string birthDate, string phone, string email,
                      string stateRegistration, bool isStateRegistrationExempt, ClientAddress address)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            CpfCnpj = cpfCnpj;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            StateRegistration = stateRegistration;
            IsStateRegistrationExempt = isStateRegistrationExempt;
            Address = address;
            CreatedDate = DateTime.Now;
        }

        public Client(Guid id, string fullName, string cpfCnpj, string birthDate, string phone, string email,
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
            CreatedDate = DateTime.Now;
        }
    }

}
