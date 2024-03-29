﻿using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IDAL
{
    public interface ILoanContainerDAL
    {
        /// <summary>
        /// Via deze methode kan de gebruiker boek lenen.
        /// </summary>
        /// <param name="loan"></param>
        /// <returns></returns>
        bool AddLoan(LoanDTO loan);
      
        /// <summary>
        /// De methode geeft de lijst van alle leningen 
        /// </summary>
        /// <returns></returns>
        List<LoanDTO> GetAllLoans();
        /// <summary>
        /// Geeft de lijst van de leningen op basis van de gebruiker.
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        List<LoanDTO> GetLoansByUser(int userid);
        

    }
}
