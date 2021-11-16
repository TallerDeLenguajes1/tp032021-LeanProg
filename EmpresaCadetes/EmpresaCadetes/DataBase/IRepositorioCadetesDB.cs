using EmpresaCadetes.Entidades;
using System.Collections.Generic;

namespace EmpresaCadetes.DataBase
{
    public interface IRepositorioCadetesDB
    {
        void DeleteCadetes(int id);
        Cadete GetCadeteById(int id);
        List<Cadete> ReadCadetes();
        void SaveCadete(Cadete cadete);
        void UpdateCadete(Cadete unCadete);
    }
}