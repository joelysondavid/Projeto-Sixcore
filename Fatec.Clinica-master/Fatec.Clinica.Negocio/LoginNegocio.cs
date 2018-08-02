using Fatec.Clinica.Dado;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fatec.Clinica.Negocio
{
  public  class LoginNegocio
    {
        private readonly LoginRepositorio _loginRepositorio;

        public LoginNegocio()
        {
            _loginRepositorio = new LoginRepositorio();
        }
    }
}
