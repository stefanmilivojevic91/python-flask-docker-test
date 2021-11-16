using System;

namespace Domain.Entities.Common
{
    public record Email
    {
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }
        public static Email From(string value)
        {
            if (!value.Contains("@"))
            {
                throw new Exception("Email is invalid");
            }

            return new Email(value);
        }

        public static implicit operator Email(string email)
        {
            return From(email);
        }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }
    }
}
