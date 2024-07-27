using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Util
    {
        #region Constants

        /// <summary>
        /// Обозначение крестика.
        /// </summary>
        public static char symbolX = 'X';

        /// <summary>
        /// Обозначение нолика.
        /// </summary>
        public static char symbolO = 'O';

        #endregion

        #region Methods

        /// <summary>
        /// Проверка: текущий игрок X или O.
        /// </summary>
        /// <param name="currentPlayer">Текущий игрок.</param>
        /// <returns></returns>
        public static char CheckXorO(int currentPlayer)
            => currentPlayer == 1 ? symbolX : symbolO;

        #endregion
    }
}
