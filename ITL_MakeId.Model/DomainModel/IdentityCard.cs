using System;
using System.ComponentModel.DataAnnotations;

namespace ITL_MakeId.Model.DomainModel
{
    public class IdentityCard
    {
        public IdentityCard()
        {
            CompanyName = "Interlink Technologies Ltd.";
            CompanyAddress = "Office No. 801 (7th Floor) 1205, 185 Sonargaon Road, Dhaka";
            ImagePathOfAuthorizedSignature = "";
            ImagePathOfAuthorizedSignature = "";
            CompanyLogoPath = "";
            CardInfo = "This card should be used by card holder only. If this card is found ownerless, please, return" +
                       "it to the issuing authority. This card is not transferable to anybody.";

        }

        public int Id { get; set; }

        public int CardCategoryId { get; set; }
        public CardCategory CardCategory { get; set; }
        public string Name { get; set; }

        public int DesignationId { get; set; }
        public Designation Designation { get; set; }

        public string Department { get; set; }

        public int BloodGroupId { get; set; }


        public BloodGroup BloodGroup { get; set; }

        public string CardNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string ImagePathOfUser { get; set; }
        public string ImagePathOfUserSignature { get; set; }

        public string ImagePathOfAuthorizedSignature { get; set; }

        public string CompanyName { get; set; }


        public string CompanyAddress { get; set; }

        public string CompanyLogoPath { get; set; }

        public string CardInfo { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ValidationStartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ValidationEndDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? IssueDate { get; set; }

    }
}
