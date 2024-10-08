using Dinely.Domain.HostAggregate.ValueObjects;

using Dinely.Domain.MenuAggregate;
using Dinely.Domain.MenuAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinely.Infrastructure.Persistance.Configurations
{
    public class MenuConfigurations : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenusTable(builder);

            ConfigureMenuSectionsTable(builder);

            ConfigureMenuDinnerIdsTable(builder);

            ConfigureMenuReviewIdsTable(builder);

        }

        private static void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.DinnerIds, dib =>
            {
                dib.ToTable("MenuDinnerIds");

                dib.WithOwner().HasForeignKey("MenuId");

                dib.HasKey("Id");

                dib.Property(d => d.Value)
                    .ValueGeneratedNever()
                    .HasColumnName("DinnerId");
            });

            builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
        private static void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.MenuReviewIds, dib =>
            {
                dib.ToTable("MenuReviewIds");

                dib.WithOwner().HasForeignKey("MenuId");

                dib.HasKey("Id");

                dib.Property(d => d.Value)
                    .ValueGeneratedNever()
                    .HasColumnName("ReviewId");
            });

            builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
        private static void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.Sections, sb =>
            {
                sb.ToTable("MenuSections");

                sb.WithOwner().HasForeignKey("MenuId");

                sb.HasKey("Id", "MenuId");

                sb.Property(s => s.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("MenuSectionId")
                    .HasConversion(
                        id => id.Value,
                        value => MenuSectionId.Create(value)
                    );

                sb.Property(s => s.Name)
                    .HasMaxLength(100);

                sb.Property(s => s.Description)
                    .HasMaxLength(100);

                sb.OwnsMany(s => s.Items, ib =>
                {
                    ib.ToTable("MenuItems");

                    ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                    ib.HasKey("Id", "MenuSectionId", "MenuId");

                    ib.Property(i => i.Id)
                        .ValueGeneratedNever()
                        .HasColumnName("MenuItemId")
                        .HasConversion(
                            id => id.Value,
                            value => MenuItemId.Create(value)
                        );

                    ib.Property(s => s.Name)
                        .HasMaxLength(100);

                    ib.Property(s => s.Description)
                        .HasMaxLength(100);
                });
                sb.Navigation(s => s.Items).Metadata.SetField("_items");
                sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.Metadata.FindNavigation(nameof(Menu.Sections))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);

        }
        private static void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuId.Create(value)
                );

            builder.Property(m => m.Name)
                .HasMaxLength(100);

            builder.Property(m => m.Description)
                .HasMaxLength(100);

            builder.Property(m => m.HostId)
                .ValueGeneratedNever()
                .HasConversion(
                    hostId => hostId.Value,
                    value => HostId.Create(value)
                );
        }
    }
}