using System;
using System.Collections.Generic;
using Vikela.Implementation.View;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Trunk.View.Controls.Factory
{
    public class TileViewFactory
    {
        private Dictionary<Type, Func<ITableScrollItemModel, Xamarin.Forms.View>> supportedInterfaces;

        public TileViewFactory()
        {
            var type = typeof(PersonalDetailViewModel);
            supportedInterfaces = 
                new Dictionary<Type, Func<ITableScrollItemModel, Xamarin.Forms.View>>
            {{type, (model) => new PersonalDetailsTile(model)}};
        }

        public Xamarin.Forms.View GetView(ITableScrollItemModel model)
        {
            return supportedInterfaces[model.GetType()]?.Invoke(model);
        }
    }
}
