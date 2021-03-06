﻿using CorePCL;

namespace Vikela.Trunk.Service.ReturnModel
{
	public class DynamixContact : BaseViewModel
    {
        public string name {get;set;}
        public string userId {get;set;}
        public string firstName {get;set;}
        public string lastName {get;set;}
        public string profileImage {get;set;}
        public string connectionId {get;set;}
        public DynamixRole connectedRole { get; set; }
    }
}
