using Microsoft.EntityFrameworkCore;
using Qface.Application.Shared.Common.Interfaces;
using Qface.Domain.Shared.Common;
using QIMSchoolPro.Thesis.Domain.Entities;
using Qsmart.EventBus.Shared.Messages.Common;
using Qface.Persistence.EntityFramework.Extensions;
using Version = QIMSchoolPro.Thesis.Domain.Entities.Version;

namespace QIMSchoolPro.Thesis.Persistence
{
    public class ThesisDbContext: DbContextBase
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDomainEventService _domainEventService;
        public ThesisDbContext(DbContextOptions<ThesisDbContext> options)
              : base(options)
        {
        }

        public ThesisDbContext(
        DbContextOptions<ThesisDbContext> options,
        ICurrentUserService currentUserService,
            IDomainEventService domainEventService)
        : base(options)
        {
            _currentUserService = currentUserService;
            _domainEventService = domainEventService;

        }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Version> Versions { get; set; }
        public DbSet<ThesisAssignment> ThesisAssignments { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //var userId = _currentUserService.UserId ?? Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();

            SetAuditableEntity(userId);
            var result = await base.SaveChangesAsync(cancellationToken);
            await DispatchEvents();

            return result;
        }

        public override int SaveChanges()
        {
            var userId = _currentUserService.UserId ?? Guid.NewGuid().ToString();

            SetAuditableEntity(userId);
            return base.SaveChanges();
        }

        public void SaveChangesWithIdentityInsert<T>()
        {
            using var transaction = Database.BeginTransaction();
            EnableIdentityInsert<T>();
            SaveChanges();
            DisableIdentityInsert<T>();
            transaction.Commit();
        }
        public async Task SaveChangesWithIdentityInsertAsync<T>(CancellationToken cancellationToken = new CancellationToken())
        {
            await using var transaction = await Database.BeginTransactionAsync();
            await EnableIdentityInsertAsync<T>();
            await SaveChangesAsync(cancellationToken);
            await DisableIdentityInsertAsync<T>();
            await transaction.CommitAsync();
        }

        private async Task DispatchEvents()
        {
            while (true)
            {
                var domainEventEntity = ChangeTracker.Entries<AuditableDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .FirstOrDefault(domainEvent => !domainEvent.IsPublished);
                if (domainEventEntity == null)
                {
                    break;
                }

                domainEventEntity.IsPublished = true;
                await _domainEventService.Publish(domainEventEntity);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ThesisDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<DomainEvent>();
        }
    }
}
