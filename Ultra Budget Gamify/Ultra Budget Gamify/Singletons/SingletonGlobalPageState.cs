using System;
using System.Collections.Generic;
using System.Text;

namespace Ultra_Budget_Gamify
{
    public class SingletonGlobalPageState
    {
        #region Private variable
        private static SingletonGlobalPageState GlobalPageState;

        private DateTime CurrentDatePages;

        #endregion

        // Verrou pour la synchronisation multithread
        private static readonly object lockObject = new object();

        // Constructeur privé pour empêcher l'instanciation directe
        private SingletonGlobalPageState()
        {
            // Initialisation ou configuration ici
        }
        #region public get

        // Méthode pour obtenir l'instance unique du Singleton
        public static SingletonGlobalPageState GetSingleGlobalPageState()
        {
            if (GlobalPageState == null)
            {
                lock (lockObject)
                {
                    if (GlobalPageState == null)
                    {
                        GlobalPageState = new SingletonGlobalPageState();
                    }
                }
            }
            return GlobalPageState;
        }
        #endregion

        #region Public Propreties

        public DateTime CurrentDatePagesProprety
        {
            get => CurrentDatePages.Date;
            set => CurrentDatePages = value;
        }

        #endregion
    }
}
