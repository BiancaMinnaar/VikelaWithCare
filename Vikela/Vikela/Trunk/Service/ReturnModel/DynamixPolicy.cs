﻿using System;
using System.Collections.Generic;
using SQLite;

namespace Vikela.Trunk.Service.ReturnModel
{
    public class DynamixPolicy// : BaseViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public List<PoliciesSummary> Summary { get; set; }  //List<> will be returned as an array
        public List<PolicyDetails> Details { get; set; }    //List<> will be returned as an array 
    }
    public class PolicyDetails
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Guid PolicyId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double ExpiresInDays { get; set; }
        public double PremiumAmount { get; set; }
        public double EnsuredAmount { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerProfileImageUrl { get; set; }
        public int PolicyRAG { get; set; }
        public PolicyStoreResponse Store { get; set; }
        public PolicyBeneficiaryResponse Beneficiary { get; set; }
        public PolicyProductResponse Product { get; set; }
    }

    public class PolicyStoreResponse// : BaseViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Guid StoreId { get; set; }
        public string StoreName { get; set; }
    }

    public class PolicyBeneficiaryResponse// : BaseViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Guid BeneficiaryId { get; set; }
        public string BeneficiaryFullName { get; set; }
        public string BeneficiaryProfileImageUrl { get; set; }
    }

    public class PolicyProductResponse// : BaseViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
    }

    public class PoliciesSummary// : BaseViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public Guid BeneficiaryId { get; set; }
        public string BeneficiaryName { get; set; }
        public double EnsuredAmount { get; set; }
        public int TotalPolicies { get; set; }
        public int OverallRAG { get; set; }
    }
}
