using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1;

public partial class EventsContext : DbContext
{
    public EventsContext()
    {
    }

    public EventsContext(DbContextOptions<EventsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Organizer> Organizers { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TypeEvent> TypeEvents { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=events;Username=postgres;Password=Jocker365365");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.IdEvent).HasName("event_pkey");

            entity.ToTable("event");

            entity.Property(e => e.IdEvent).HasColumnName("id_event");
            entity.Property(e => e.DataEnd).HasColumnName("data_end");
            entity.Property(e => e.DataStart).HasColumnName("data_start");
            entity.Property(e => e.IdOrganizer).HasColumnName("id_organizer");
            entity.Property(e => e.IdPlace).HasColumnName("id_place");
            entity.Property(e => e.IdTicket).HasColumnName("id_ticket");
            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Note)
                .HasMaxLength(150)
                .HasColumnName("note");
            entity.Property(e => e.TimeEnd).HasColumnName("time_end");
            entity.Property(e => e.TimeStart).HasColumnName("time_start");

            entity.HasOne(d => d.IdOrganizerNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdOrganizer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("event_id_organizer_fkey");

            entity.HasOne(d => d.IdPlaceNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdPlace)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("event_id_place_fkey");

            entity.HasOne(d => d.IdTicketNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdTicket)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("event_id_ticket_fkey");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("event_id_type_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("event_id_user_fkey");
        });

        modelBuilder.Entity<Organizer>(entity =>
        {
            entity.HasKey(e => e.IdOrganizer).HasName("organizers_pkey");

            entity.ToTable("organizers");

            entity.Property(e => e.IdOrganizer).HasColumnName("id_organizer");
            entity.Property(e => e.OrgEmail)
                .HasMaxLength(30)
                .HasColumnName("org_email");
            entity.Property(e => e.OrgName)
                .HasMaxLength(50)
                .HasColumnName("org_name");
            entity.Property(e => e.OrgPhone)
                .HasMaxLength(11)
                .HasColumnName("org_phone");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.IdPlace).HasName("place_pkey");

            entity.ToTable("place");

            entity.Property(e => e.IdPlace).HasColumnName("id_place");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.NumberHouse)
                .HasMaxLength(4)
                .HasColumnName("number_house");
            entity.Property(e => e.PlaceName)
                .HasMaxLength(50)
                .HasColumnName("place_name");
            entity.Property(e => e.RentalCost)
                .HasMaxLength(60)
                .HasColumnName("rental_cost");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .HasColumnName("street");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Role1)
                .HasMaxLength(6)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.IdTicket).HasName("tickets_pkey");

            entity.ToTable("tickets");

            entity.Property(e => e.IdTicket).HasColumnName("id_ticket");
            entity.Property(e => e.CountTickets)
                .HasMaxLength(5)
                .HasColumnName("count_tickets");
            entity.Property(e => e.UnsoldTickets)
                .HasMaxLength(5)
                .HasColumnName("unsold_tickets");
        });

        modelBuilder.Entity<TypeEvent>(entity =>
        {
            entity.HasKey(e => e.IdType).HasName("type_event_pkey");

            entity.ToTable("type_event");

            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.Type)
                .HasMaxLength(60)
                .HasColumnName("type");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(30)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_id_role_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
