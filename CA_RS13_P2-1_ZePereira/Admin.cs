using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS13_P2_1_ZePereira
{
    class Admin : Person
    {
        #region Properties

        #endregion

        #region Constructors
        //Apenas se pode criar um colaborador se já houver username e password
        public Admin(string username, string password) : base(username, password) { }
        #endregion

        #region Methods
        public override string GetRole() => "Admin";
        //------------------
        //Aadicionar férias-
        //------------------
        //---------------
        //-Listar férias-
        //----------------

        //---------------
        //-Editar férias-
        //---------------

        //----------------
        //-Aprovar férias-
        //----------------

        //----------------
        //-Recusar férias-
        //----------------

        //-----------------
        //-Consulta férias por pessoa-
        //-----------------

        //-----------------
        //-Consulta férias por data-
        //-----------------

        //-----------------
        //-Consulta férias por pessoa e data-
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
