namespace AgendaOnlineAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo")
        {
        }

        public virtual DbSet<aluno> aluno { get; set; }
        public virtual DbSet<conversa> conversa { get; set; }
        public virtual DbSet<mensagem> mensagem { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<aluno>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<conversa>()
                .Property(e => e.tipo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<conversa>()
                .HasMany(e => e.mensagem)
                .WithOptional(e => e.conversa)
                .HasForeignKey(e => e.id_conversa);

            modelBuilder.Entity<conversa>()
                .HasMany(e => e.usuario)
                .WithMany(e => e.conversa)
                .Map(m => m.ToTable("usuario_conversa").MapLeftKey("id_conversa").MapRightKey("id_usuario"));

            modelBuilder.Entity<mensagem>()
                .Property(e => e.texto)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.tipo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .HasMany(e => e.aluno)
                .WithOptional(e => e.usuario)
                .HasForeignKey(e => e.id_usuario_responsavel);

            modelBuilder.Entity<usuario>()
                .HasMany(e => e.mensagem)
                .WithOptional(e => e.usuario)
                .HasForeignKey(e => e.id_usuario);
        }
    }
}
