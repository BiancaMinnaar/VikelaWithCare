﻿using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;

namespace Vikela.Trunk.Service
{
    public interface IDynamixService
    {
		Task RegisterUserAsync(RegisterViewModel model);
        Task AddTrustedSourceAsync(ContactDetailViewModel model);
		Task AddBeneficiaryAsync(ContactDetailViewModel model);
        Task UpdateContactAsync(ContactDetailViewModel model);
        Task UpdateCommunityAsync(MyCommunityViewModel model);
    }
}
