using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS13_P2_1_ZePereira
{
    class Collaborator : Person
    {
        #region Properties
       
        #endregion

        #region Constructors
        //Apenas se pode criar um colaborador se já houver username e password
        public Collaborator(string username, string password) :base(username, password) { }

        #endregion

        #region Methods
        public override string GetRole() => "Collaborator";
        
        //------------------
        //Aadicionar férias-
        //------------------
        //---------------
        //-Listar férias-
        //----------------

        //---------------
        //-Editar férias-
        //---------------

        //-----------------
        //-Consulta férias-
        //-----------------
        //-----------------
        //-Consulta férias por aprovar-
        //-----------------

        //-----------------
        //-Consulta férias aprovadasa-
        //-----------------

        //-----------------
        //-Consulta férias negadas-
        //-----------------
        #endregion

    }
}
