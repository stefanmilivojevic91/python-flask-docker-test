using Domain.Entities.Common;
using Domain.Entities.Core;

namespace Domain.Entities.PropertyAggregate
{
    public class Price :
        Entity<PropertyId>
    {
        public Money January { get; set; }
        public Money February { get; set; }
        public Money March { get; set; }
        public Money April { get; set; }
        public Money May { get; set; }
        public Money June { get; set; }
        public Money July { get; set; }
        public Money August { get; set; }
        public Money September { get; set; }
        public Money October { get; set; }
        public Money November { get; set; }
        public Money December { get; set; }

        private Price(PropertyId id,
            Money january,
            Money february,
            Money march,
            Money april,
            Money may,
            Money june,
            Money july,
            Money august,
            Money september,
            Money october,
            Money november,
            Money december)
            : base(id)
        {
            January = january;
            February = february;
            March = march;
            April = april;
            May = may;
            June = june;
            July = july;
            August = august;
            September = september;
            October = october;
            November = november;
            December = december;
        }

        public static Price Create(PropertyId id,
            Money january,
            Money february,
            Money march,
            Money april,
            Money may,
            Money june,
            Money july,
            Money august,
            Money september,
            Money october,
            Money november,
            Money december)
        {
            return new(id, 
                january, 
                february, 
                march, 
                april, 
                may, 
                june, 
                july, 
                august, 
                september, 
                october, 
                november, 
                december);
        }
    }
}