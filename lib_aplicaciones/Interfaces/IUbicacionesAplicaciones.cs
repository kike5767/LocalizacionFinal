﻿// Librerias
using lib_entidades.Modelos;

// Proyecto
namespace lib_aplicaciones.Interfaces
{
    // Firma de los metodos
    public interface IUbicacionesAplicacion
    {
        void Configurar(string string_conexion);

        List<Ubicaciones> Listar();

        List<Ubicaciones> Buscar(Ubicaciones entidad, string tipo);

        Ubicaciones Guardar(Ubicaciones entidad);

        Ubicaciones Modificar(Ubicaciones entidad);

        Ubicaciones Borrar(Ubicaciones entidad);
    }
}