﻿using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.DependencyInjection;

namespace Volo.Abp.Uow
{
    public interface IUnitOfWork : IDisposable, IServiceProviderAccessor, ITransientDependency
    {
        [CanBeNull]
        IDatabaseApi FindDatabaseApi([NotNull] string id);

        //TODO: Move Database API methods to another interface!

        [NotNull]
        IDatabaseApi GetOrAddDatabaseApi(string id, Func<IDatabaseApi> factory);

        IDatabaseApi AddDatabaseApi(string id, IDatabaseApi databaseApi);

        void SaveChanges();

        Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        void Complete();

        Task CompleteAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
