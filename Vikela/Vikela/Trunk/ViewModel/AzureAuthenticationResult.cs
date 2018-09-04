using System;
using Vikela.Trunk.ViewModel.Interfaces;

namespace Vikela.Trunk.ViewModel
{
	public class AzureAuthenticationResult : IAuthenticationResult
    {
        public string IdToken{get;set;}
    }
}
