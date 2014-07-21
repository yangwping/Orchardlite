using System;
using JetBrains.Annotations;
using Orchard.Data;
using Orchard.DisplayManagement;
using Orchard.UI.Notify;

namespace Orchard.Environment {
    [UsedImplicitly]
    public class OrchardServices : IOrchardServices {
        private readonly Lazy<IShapeFactory> _shapeFactory;
        private readonly IWorkContextAccessor _workContextAccessor;

        public OrchardServices(
            ITransactionManager transactionManager,
            INotifier notifier,
            Lazy<IShapeFactory> shapeFactory,
            IWorkContextAccessor workContextAccessor) {
            _shapeFactory = shapeFactory;
            _workContextAccessor = workContextAccessor;
            TransactionManager = transactionManager;
            Notifier = notifier;
        }


        public ITransactionManager TransactionManager { get; private set; }
        public INotifier Notifier { get; private set; }
        public dynamic New { get { return _shapeFactory.Value; } }
        public WorkContext WorkContext { get { return _workContextAccessor.GetContext(); } }
    }
}
