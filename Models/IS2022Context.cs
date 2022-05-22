using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProdajaPica.Models
{
    public partial class IS2022Context : DbContext
    {
        public IS2022Context()
        {
        }

        public IS2022Context(DbContextOptions<IS2022Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Anketa> Anketa { get; set; }
        public virtual DbSet<Hladnjak> Hladnjak { get; set; }
        public virtual DbSet<Kupac> Kupac { get; set; }
        public virtual DbSet<Lokacija> Lokacija { get; set; }
        public virtual DbSet<Narudzba> Narudzba { get; set; }
        public virtual DbSet<Podregija> Podregija { get; set; }
        public virtual DbSet<Proizvod> Proizvod { get; set; }
        public virtual DbSet<Regija> Regija { get; set; }
        public virtual DbSet<Ruta> Ruta { get; set; }
        public virtual DbSet<Stavka> Stavka { get; set; }
        public virtual DbSet<Zahtjev> Zahtjev { get; set; }
        public virtual DbSet<Zaposlenik> Zaposlenik { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=DESKTOP-762T8UA\\SQL2019;initial catalog=IS2022_PP;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anketa>(entity =>
            {
                entity.ToTable("anketa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrojProizvoda).HasColumnName("brojProizvoda");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dostupnost).HasColumnName("dostupnost");

                entity.Property(e => e.KupacId).HasColumnName("kupacId");

                entity.Property(e => e.Ocjena).HasColumnName("ocjena");

                entity.Property(e => e.Popunjenost).HasColumnName("popunjenost");

                entity.Property(e => e.ProdajniPredstavnikId).HasColumnName("prodajniPredstavnikId");

                entity.Property(e => e.Vidljivost).HasColumnName("vidljivost");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Anketa)
                    .HasForeignKey(d => d.KupacId)
                    .HasConstraintName("FK__anketa__kupacId__4AB81AF0");

                entity.HasOne(d => d.ProdajniPredstavnik)
                    .WithMany(p => p.Anketa)
                    .HasForeignKey(d => d.ProdajniPredstavnikId)
                    .HasConstraintName("FK__anketa__prodajni__49C3F6B7");
            });

            modelBuilder.Entity<Hladnjak>(entity =>
            {
                entity.ToTable("hladnjak");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.KupacId).HasColumnName("kupacId");

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasMaxLength(255);

                entity.Property(e => e.Napomena)
                    .HasColumnName("napomena")
                    .HasMaxLength(255);

                entity.Property(e => e.Velicina).HasColumnName("velicina");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Hladnjak)
                    .HasForeignKey(d => d.KupacId)
                    .HasConstraintName("FK__hladnjak__kupacI__44FF419A");
            });

            modelBuilder.Entity<Kupac>(entity =>
            {
                entity.ToTable("kupac");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dug).HasColumnName("dug");

                entity.Property(e => e.KorisnickoIme)
                    .HasColumnName("korisnickoIme")
                    .HasMaxLength(255);

                entity.Property(e => e.LokacijaId).HasColumnName("lokacijaId");

                entity.Property(e => e.Lozinka)
                    .HasColumnName("lozinka")
                    .HasMaxLength(255);

                entity.Property(e => e.NazivObjekta)
                    .HasColumnName("nazivObjekta")
                    .HasMaxLength(255);

                entity.Property(e => e.OdobreniDug).HasColumnName("odobreniDug");

                entity.HasOne(d => d.Lokacija)
                    .WithMany(p => p.Kupac)
                    .HasForeignKey(d => d.LokacijaId)
                    .HasConstraintName("FK__kupac__lokacijaI__403A8C7D");
            });

            modelBuilder.Entity<Lokacija>(entity =>
            {
                entity.ToTable("lokacija");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lokacija1)
                    .HasColumnName("lokacija")
                    .HasMaxLength(255);

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(255);

                entity.Property(e => e.PodregijaId).HasColumnName("podregijaId");

                entity.HasOne(d => d.Podregija)
                    .WithMany(p => p.Lokacija)
                    .HasForeignKey(d => d.PodregijaId)
                    .HasConstraintName("FK__lokacija__podreg__48CFD27E");
            });

            modelBuilder.Entity<Narudzba>(entity =>
            {
                entity.ToTable("narudzba");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iznos).HasColumnName("iznos");

                entity.Property(e => e.KupacId).HasColumnName("kupacId");

                entity.Property(e => e.Napomena)
                    .HasColumnName("napomena")
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Narudzba)
                    .HasForeignKey(d => d.KupacId)
                    .HasConstraintName("FK__narudzba__kupacI__47DBAE45");
            });

            modelBuilder.Entity<Podregija>(entity =>
            {
                entity.ToTable("podregija");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ime)
                    .HasColumnName("ime")
                    .HasMaxLength(255);

                entity.Property(e => e.RegijaId).HasColumnName("regijaId");

                entity.HasOne(d => d.Regija)
                    .WithMany(p => p.Podregija)
                    .HasForeignKey(d => d.RegijaId)
                    .HasConstraintName("FK__podregija__regij__3F466844");
            });

            modelBuilder.Entity<Proizvod>(entity =>
            {
                entity.ToTable("proizvod");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cijena).HasColumnName("cijena");

                entity.Property(e => e.Kolicina).HasColumnName("kolicina");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Regija>(entity =>
            {
                entity.ToTable("regija");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ime)
                    .HasColumnName("ime")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Ruta>(entity =>
            {
                entity.ToTable("ruta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dan).HasColumnName("dan");

                entity.Property(e => e.KupacId).HasColumnName("kupacId");

                entity.Property(e => e.ProdajniPredstavnikId).HasColumnName("prodajniPredstavnikId");

                entity.HasOne(d => d.ProdajniPredstavnik)
                    .WithMany(p => p.Ruta)
                    .HasForeignKey(d => d.ProdajniPredstavnikId)
                    .HasConstraintName("FK__ruta__prodajniPr__4CA06362");
            });

            modelBuilder.Entity<Stavka>(entity =>
            {
                entity.ToTable("stavka");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Kolicina)
                    .HasColumnName("kolicina")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NarudzbaId).HasColumnName("narudzbaId");

                entity.Property(e => e.ProivodId).HasColumnName("proivodId");

                entity.HasOne(d => d.Narudzba)
                    .WithMany(p => p.Stavka)
                    .HasForeignKey(d => d.NarudzbaId)
                    .HasConstraintName("FK__stavka__narudzba__46E78A0C");

                entity.HasOne(d => d.Proivod)
                    .WithMany(p => p.Stavka)
                    .HasForeignKey(d => d.ProivodId)
                    .HasConstraintName("FK__stavka__proivodI__47DBAE45");
            });

            modelBuilder.Entity<Zahtjev>(entity =>
            {
                entity.ToTable("zahtjev");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.HladnjakId).HasColumnName("hladnjakId");

                entity.Property(e => e.KupacId).HasColumnName("kupacId");

                entity.Property(e => e.ProdajniPredstavnik).HasColumnName("prodajniPredstavnik");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.Property(e => e.Supevizor).HasColumnName("supevizor");

                entity.HasOne(d => d.Hladnjak)
                    .WithMany(p => p.Zahtjev)
                    .HasForeignKey(d => d.HladnjakId)
                    .HasConstraintName("FK__zahtjev__hladnja__412EB0B6");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Zahtjev)
                    .HasForeignKey(d => d.KupacId)
                    .HasConstraintName("FK__zahtjev__kupacId__4222D4EF");

                entity.HasOne(d => d.ProdajniPredstavnikNavigation)
                    .WithMany(p => p.ZahtjevProdajniPredstavnikNavigation)
                    .HasForeignKey(d => d.ProdajniPredstavnik)
                    .HasConstraintName("FK__zahtjev__prodajn__4316F928");

                entity.HasOne(d => d.SupevizorNavigation)
                    .WithMany(p => p.ZahtjevSupevizorNavigation)
                    .HasForeignKey(d => d.Supevizor)
                    .HasConstraintName("FK__zahtjev__supeviz__440B1D61");
            });

            modelBuilder.Entity<Zaposlenik>(entity =>
            {
                entity.ToTable("zaposlenik");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ime)
                    .HasColumnName("ime")
                    .HasMaxLength(255);

                entity.Property(e => e.KorisnickoIme)
                    .HasColumnName("korisnickoIme")
                    .HasMaxLength(255);

                entity.Property(e => e.Lozinka)
                    .HasColumnName("lozinka")
                    .HasMaxLength(255);

                entity.Property(e => e.PodregijaId).HasColumnName("podregijaId");

                entity.Property(e => e.Prezime)
                    .HasColumnName("prezime")
                    .HasMaxLength(255);

                entity.Property(e => e.RegijaId).HasColumnName("regijaId");

                entity.Property(e => e.SupervizorId).HasColumnName("supervizorId");

                entity.Property(e => e.Uloga)
                    .IsRequired()
                    .HasColumnName("uloga")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Podregija)
                    .WithMany(p => p.Zaposlenik)
                    .HasForeignKey(d => d.PodregijaId)
                    .HasConstraintName("FK__zaposleni__podre__3E52440B");

                entity.HasOne(d => d.Regija)
                    .WithMany(p => p.Zaposlenik)
                    .HasForeignKey(d => d.RegijaId)
                    .HasConstraintName("FK__zaposleni__regij__3D5E1FD2");

                entity.HasOne(d => d.Supervizor)
                    .WithMany(p => p.InverseSupervizor)
                    .HasForeignKey(d => d.SupervizorId)
                    .HasConstraintName("FK__zaposleni__super__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
