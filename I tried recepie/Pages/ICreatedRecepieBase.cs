﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_tried_recepie.Pages
{
    public class ICreatedRecepieBase : ComponentBase
    {
        #region Recepie class
        public class Recepie
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public int Rating { get; set; }

            public List<Image> RecepieImages = new List<Image>();
            public List<DescriptionProcess> DescriptionsList = new List<DescriptionProcess>();
            public List<Ingredient> SpicesList = new List<Ingredient>();

            public Recepie() { }
        }

        #endregion

        #region Ingredient class
        public class Ingredient
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Ammount { get; set; }
            public string AmmountName { get; set; }

            public Ingredient() { }
        }
        #endregion

        #region DescriptionProcess class
        public class DescriptionProcess
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Text { get; set; }
            public double Time { get; set; }

            public DescriptionProcess() { }
        }
        #endregion
        #region Image class
        public class Image
        {
            public int Id { get; set; }
            public string Path { get; set; }
            public string Name { get; set; }

            public Image() { }
        }
        #endregion


        #region Functions and variables for toglleying websites
        protected bool main_page = false;
        protected bool create_recepie_page = true;


        /// <summary>
        /// Will close all pages views
        /// </summary>
        public void CloseAllPages()
        {
            main_page = false;
            create_recepie_page = false;
        }

        /// <summary>
        /// Will open main page
        /// </summary>
        public void OpenMainPage()
        {
            CloseAllPages();
            main_page = true;
        }

        /// <summary>
        /// Will open create recepie page
        /// </summary>
        public void OpenCreateRecepiePage()
        {
            CloseAllPages();
            create_recepie_page = true;
        }

        #endregion
    }
}