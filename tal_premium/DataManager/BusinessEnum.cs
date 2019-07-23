using System.ComponentModel;

namespace DataManager
{ 
    public enum CustomerStatus
    {
        [Description("active customer status")]
        Active = 1,

        [Description("inctive customer status")]
        Inactive = 2,

        [Description("deleted customer status")]
        Deleted = 3,

        [Description("other customer status")]
        Other = 9
    }
    public enum InsuranceType
    {
        [Description("death insurance type")]
        Death = 1,

        [Description("education insurance type")]
        Education = 2,

        [Description("other insurance type")]
        Other = 9
    }
}
