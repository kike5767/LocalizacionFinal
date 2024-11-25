// Librerias
using lib_entidades.Modelos;
using System.Linq.Expressions;

// Proyecto
namespace lib_repositorios.Interfaces
{
    // Firma de los metodos
    public interface IAuditoriaRepositorio
    {
        void Configurar(string string_conexion);

        List<Auditoria> Listar();

        List<Auditoria> Buscar(Expression<Func<Auditoria, bool>> condiciones);

        Auditoria Guardar(Auditoria entidad);

        Auditoria Modificar(Auditoria entidad);

        Auditoria Borrar(Auditoria entidad);

        bool Existe(Expression<Func<Auditoria, bool>> condiciones);
    }
}
