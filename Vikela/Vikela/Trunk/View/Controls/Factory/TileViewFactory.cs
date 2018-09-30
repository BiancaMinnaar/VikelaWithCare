using System;
using System.Collections.Generic;
using Vikela.Implementation.View;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.View.Profile.MyCover.Tiles;
using Vikela.Trunk.View.Community.Tiles;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Trunk.View.Controls.Factory
{
    public class TileViewFactory
    {
        private Dictionary<Type, Func<ITableScrollItemModel, Xamarin.Forms.View>> supportedInterfaces;

        public TileViewFactory()
        {
            supportedInterfaces = SetViewFactoryMap();
        }

        public Dictionary<Type, Func<ITableScrollItemModel, Xamarin.Forms.View>> SetViewFactoryMap()
        {
            return new Dictionary<Type, Func<ITableScrollItemModel, Xamarin.Forms.View>>
            {
                {typeof(PersonalDetailViewModel), (model) => new PersonalDetailsTile(model)},
                {typeof(TrustedSourcesViewModel), (m) => new TrustedSourcesTile(m)},
                {typeof(SiyabongaViewModel), (m) => new SiyabongaTile(m)},
                {typeof(ActiveCoverViewModel), (m) => new ActiveCoverTile(m)},
                {typeof(PurchaseHistoryDetailViewModel), (m) => new PurchaseHistoryTileView(m)},
                {typeof(CareVoucherViewModel), (m) => new CareVoucerTileView(m)},
                {typeof(FriendsTileViewModel), (m) => new FriendsTileView(m)},
                {typeof(CommunityTileViewModel), (m) => new CommunityTileView(m)}
                //BonsaiTileViewMap
            };
        }

        public Xamarin.Forms.View GetView(ITableScrollItemModel model)
        {
            return supportedInterfaces[model.GetType()]?.Invoke(model);
        }
    }
}
