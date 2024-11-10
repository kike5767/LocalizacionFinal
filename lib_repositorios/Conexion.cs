// Librerias
using lib_entidades.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

// Proyecto
namespace lib_repositorios
{
    // Clase que actua como puente entre la aplicacion y la base de datos relacionando las entidades y sus representaciones en la DB
    public class Conexion : DbContext
    {
        // Propiedad para almacenar nuestra conexion a la base de datos
        public string? StringConnection { get; set; }
        // Configuracion del contexto para usar SQL Server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConnection!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        // Conjuntos de datos DbSet para gestionarlas como tablas en la base de datos
        protected DbSet<Personas>? Personas { get; set; }
        protected DbSet<Ubicaciones>? Ubicaciones { get; set; }
        protected DbSet<Localidades>? Localidades { get; set; }
        protected DbSet<Imagenes>? Imagenes { get; set; }
        protected DbSet<DetallesImagenes>? DetallesImagenes { get; set; }
        protected DbSet<Localizaciones>? Localizaciones { get; set; }
        // Metodos
        public virtual DbSet<T> ObtenerSet<T>() where T : class, new()
        {
            return this.Set<T>();
        }

        public virtual List<T> Listar<T>() where T : class, new()
        {
            return this.Set<T>().ToList();
        }

        public virtual List<T> Buscar<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>().Where(condiciones).ToList();
        }

        public virtual bool Existe<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>().Any(condiciones);
        }

        public virtual void Guardar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Add(entidad);
        }

        public virtual void Modificar<T>(T entidad) where T : class
        {
            var entry = this.Entry(entidad);
            entry.State = EntityState.Modified;
        }

        public virtual void Borrar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Remove(entidad);
        }

        public virtual void Separar<T>(T entidad) where T : class, new()
        {
            this.Entry(entidad).State = EntityState.Detached;
        }

        public virtual void GuardarCambios()
        {
            this.SaveChanges();
        }
    }
}