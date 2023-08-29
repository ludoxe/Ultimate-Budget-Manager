using System;
using System.Collections.Generic;
using System.Text;
using Ultra_Budget_Gamify;

public class SingletonBudgetArray
{

    // Instance unique du Singleton
    private static BudgetArray budgetArray;

    // Verrou pour la synchronisation multithread
    private static readonly object lockObject = new object();

    // Constructeur privé pour empêcher l'instanciation directe
    private SingletonBudgetArray()
    {
        // Initialisation ou configuration ici
    }
    #region public get

    // Méthode pour obtenir l'instance unique du Singleton
    public static BudgetArray GetSingleBudgetArray()
    {
        if (budgetArray == null)
        {
            lock (lockObject)
            {
                if (budgetArray == null)
                {
                    budgetArray = new BudgetArray();
                }
            }
        }
        return budgetArray;
    }
    #endregion

    #region public set

    public static void SetSingleBudgetArray(BudgetArray NewBudgetArray)
    {
         budgetArray = new BudgetArray(NewBudgetArray);
    }

    // Méthodes et propriétés du Singleton

    #endregion

}
