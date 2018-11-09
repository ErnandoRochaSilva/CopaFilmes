using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWorldCup.UnitTest.TestingTools
{
    public static class ExceptionTools
    {
        /// <summary>
        /// Gera uma exception com uma ou mais InnerExceptions para simular situações onde uma ou mais exceptions ocorreram no decorrer do código
        /// </summary>
        /// <param name="emptyException"></param>
        /// <returns></returns>
        public static Exception GerarContextoException(Exception emptyException)
        {
            Exception fullException = null;

            for (int i = 0; i < 4; i++)
            {
                try
                {
                    if (emptyException != null)
                        throw emptyException;
                }
                catch (Exception ex)
                {
                    fullException = ex;
                }
            }

            return fullException;
        }
    }
}
