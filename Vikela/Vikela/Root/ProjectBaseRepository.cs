using Vikela.Interface.Repository;
using PCLBase.DataContracts;
using System;

namespace Vikela.Root.Repository
{
    public class ProjectBaseRepository : BaseRepository
    {
        protected IMasterRepository _MasterRepo;
		public string[] Errors { get; set; }
        public Action<string[]> OnError { get; set; }

        public ProjectBaseRepository(IMasterRepository masterRepository)
        {
            _MasterRepo = masterRepository;
        }
    }
}

