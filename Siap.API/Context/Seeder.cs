using Siap.API.Models;

namespace Siap.API.Context
{
    public class Seeder
    {
        private readonly SiapContext _contex;

        public Seeder(SiapContext context)
        {
            _contex = context;
        }

        public void Seed()
        {
            if (_contex.Direcciones.Any())
            {
                return;
            }
            //_contex.Direcciones.Add();
            //Agregamos los datos
            _contex.Institucions.Add(new Institucion { Id = 1, Nombre = "No Informa", Sigla = "N/D", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Institucions.Add(new Institucion { Id = 2, Nombre = "Ejército de Chile", Sigla = "EJERCITO", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Institucions.Add(new Institucion { Id = 3, Nombre = "Armada de Chile", Sigla = "ARMADA", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Institucions.Add(new Institucion { Id = 4, Nombre = "Fuerza Aerea de Chile", Sigla = "FACH", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Institucions.Add(new Institucion { Id = 5, Nombre = "Carabineros de Chile", Sigla = "Carabineros", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Institucions.Add(new Institucion { Id = 6, Nombre = "Policia de Investigaciones", Sigla = "PDI", Created = DateTime.Now, Modified = DateTime.Now });

            /*-- DIRECCIONES --*/
            _contex.Direcciones.Add(new Direccion { Id = 1, Nombre = "No Informa", Sigla = "NOINFO", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Direcciones.Add(new Direccion { Id = 2, Nombre = "Jefatura del Estado Mayor Conjunto", Sigla = "JEMCO", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Direcciones.Add(new Direccion { Id = 3, Nombre = "Subjefatura del Estado Mayor Conjunto", Sigla = "SUBJEMCO", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Direcciones.Add(new Direccion { Id = 4, Nombre = "Direccion de Inteligencia de la Defensa", Sigla = "DID", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Direcciones.Add(new Direccion { Id = 5, Nombre = "Direccion de Personal y Logistica", Sigla = "DIPERLOG", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Direcciones.Add(new Direccion { Id = 6, Nombre = "Direccion de Finanzas", Sigla = "DIFEMCO", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Direcciones.Add(new Direccion { Id = 7, Nombre = "Direccion de Operaciones y Conduccion Conjunta", Sigla = "DOPCON", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Direcciones.Add(new Direccion { Id = 8, Nombre = "Direccion de Planificacion Conjunta", Sigla = "DIPLANCO", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Direcciones.Add(new Direccion { Id = 9, Nombre = "Direccion de Proyectos y Tecnologias Estrategicas", Sigla = "DIPRO", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Direcciones.Add(new Direccion { Id = 10, Nombre = "Direccion de Educacion, Doctrina y Entrenamiento Conjunto", Sigla = "DIREDENCO", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Direcciones.Add(new Direccion { Id = 11, Nombre = "Direccion de Apoyo General", Sigla = "DAG", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Direcciones.Add(new Direccion { Id = 12, Nombre = "Departamento de Asuntos Internacionales y Especiales", Sigla = "DIPRO", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Direcciones.Add(new Direccion { Id = 13, Nombre = "Comando Conjunto Norte", Sigla = "CCN", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Direcciones.Add(new Direccion { Id = 14, Nombre = "Comando Conjunto Centro", Sigla = "CCC", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Direcciones.Add(new Direccion { Id = 15, Nombre = "Comando Conjunto Austral", Sigla = "CCA", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Direcciones.Add(new Direccion { Id = 16, Nombre = "Centro Conjunto de Operaciones de Paz Chile", Sigla = "CECOPAC", Created = DateTime.Now, Modified = DateTime.Now });
            _contex.Direcciones.Add(new Direccion { Id = 17, Nombre = "Fuerza Conjunta Combinada Cruz del Sur", Sigla = "FCCCDZ", Created = DateTime.Now, Modified = DateTime.Now });
            
            /*-- Departamento --*/
            _contex.Departamentos.Add(new Departamento { Id = 1, Nombre = "No Disponible", Sigla = "N/D", DireccionId = 1, Created = DateTime.Now, Modified = DateTime.Now });

            /*-- Secciones --*/           
            _contex.Secciones.Add(new Seccion { Id = 1, DepartamentoId = 1, Nombre = "No Disponible", Created = DateTime.Now, Modified = DateTime.Now });

            /*-- Categoria --*/
            _contex.Categorias.Add(new Categoria { Id = 1, Nombre = "No Disponible", Sigla = "N/D", Antiguedad = 99, Created = DateTime.Now, Modified = DateTime.Now, InstitucionId = 1 });
            
            /*-- Escalafones --*/
            _contex.Escalafones.Add(new Escalafon { Id = 1, Nombre = "No Disponible", Antiguedad = 99, Created = DateTime.Now, Modified = DateTime.Now, InstitucionId = 1, CategoriaId = 1 });
            
            /*-- Grados --*/
            _contex.Grados.Add(new Grado { Id = 1, Nombre = "No Disponible", Sigla = "N/D", Created = DateTime.Now, Modified = DateTime.Now, InstitucionId = 1, CategoriaId = 1 });




        }
    }
}
