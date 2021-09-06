//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        /*
        Utilizamos Expert para delegar la funcion de imprimir el costo total a
        la clase Recipe. Debido a que debe imprimir un resultado en base a valores
        que existen en otras clases, utilizando SRP delegamos el calculo del subtotal
        a las clases que si conocen esa informacion.
        */
        public double GetProductionCost()
        {
            double result = 0;
            double resultUnitCost = 0;
            double resultEquipmentCost = 0;
            foreach (Step item in this.steps)
            {
                resultUnitCost += item.UnitCostSubTotal;
                resultEquipmentCost += item.EquipmentSubTotal;
            }

            result = resultUnitCost + resultEquipmentCost;
            return Math.Round(result, 1);
        }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"Coste total de produccion: {this.GetProductionCost()}");
        }
    }
}