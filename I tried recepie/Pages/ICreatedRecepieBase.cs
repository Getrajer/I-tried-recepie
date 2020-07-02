using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_tried_recepie.Pages
{
    public class ICreatedRecepieBase : ComponentBase
    {
        #region UserRecepie
        public class UserRecepies
        {
            public int RecepiesId { get; set; }
            public int UserId { get; set; }

            /// <summary>
            /// This list will hold ongoing recepies of user
            /// </summary>
            public List<Recepie> Ongoing_Recepies = new List<Recepie>();

            /// <summary>
            /// This list will hold list of recepies user thinks is perfect
            /// </summary>
            public List<Recepie> Finished_Recepies = new List<Recepie>();

            /// <summary>
            /// This list will hold recepies of user who thinks there is no hope in this recepie
            /// </summary>
            public List<Recepie> Abandoned_Recepies = new List<Recepie>();

            public UserRecepies() { }

        }
        #endregion

        #region Recepie class
        public class Recepie
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

            /// <summary>
            /// Each number will idicate type for the icon: 
            /// 1 - Breakfast
            /// 2 - Lunch
            /// 3 - Dinner
            /// 4 - Dessert
            /// 5 - Snack
            /// </summary>
            public int Type { get; set; }

            /// <summary>
            /// From 1 - 10
            /// </summary>
            public int Rating { get; set; }

            public string Comment { get; set; }

            /// <summary>
            /// If user is satisfied with the end result
            /// </summary>
            public bool Finished { get; set; }

            /// <summary>
            /// If user is still working on perfecting the recepie
            /// </summary>
            public bool Ongoing { get; set; }

            /// <summary>
            /// If user thinks there is no home in this recepie
            /// </summary>
            public bool Abandon { get; set; }

            public List<Image> RecepieImages = new List<Image>();
            public List<DescriptionProcess> DescriptionsList = new List<DescriptionProcess>();
            public List<Ingredient> IngredientsList = new List<Ingredient>();

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

        #region Rating class
        public class Rating
        {
            public int Id { get; set; }
            public int RatePoint { get; set; }
            public string Class { get; set; }

            public Rating() { }
        }
        #endregion

        #region Type class
        public class Type
        {
            public int Id { get; set; }
            public int TypeNumber { get; set; }
            public string Name { get; set; }
            public string Class { get; set; }

            public Type() { }
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

        #region Create Recepie
        //Variables for creating recepie
        protected string new_recepie_name = "";
        protected string new_recepie_description = "";
        protected int creator_recepie_rating = 0;
        protected int user_rating = 0;
        protected int new_type;

        /// <summary>
        /// This will contain all ingredients for new recepie | Max Count = 100
        /// </summary>
        protected List<Ingredient> ingredients = new List<Ingredient>();

        /// <summary>
        /// This will contain all steps to create recepie
        /// </summary>
        protected List<DescriptionProcess> steps = new List<DescriptionProcess>();

        /// <summary>
        /// Will hold images for the new reciepe
        /// </summary>
        protected List<Image> images = new List<Image>();

        /// <summary>
        /// Will hold recepies 
        /// </summary>
        protected List<Recepie> Recepies = new List<Recepie>();

        /// <summary>
        /// This variable will hold recepies for example user in this demonstration
        /// </summary>
        protected UserRecepies example_user = new UserRecepies();

        /// <summary>
        /// This list will hold rating numbers form 1 to 10
        /// </summary>
        protected List<Rating> ratings = new List<Rating>();

        /// <summary>
        /// This List will store types of which food is
        /// </summary>
        protected List<Type> types = new List<Type>();

        /// <summary>
        /// Will reset variables for input
        /// </summary>
        public void ResetVariablesCreateNew()
        {
            types = new List<Type>();
            ratings = new List<Rating>();
            Recepies = new List<Recepie>();
            steps = new List<DescriptionProcess>();
            images = new List<Image>();
            ingredients = new List<Ingredient>();
            new_recepie_name = "";
            new_recepie_description = "";
            creator_recepie_rating = 0;
            user_rating = 0;
            new_type = 0;
        }

        /// <summary>
        /// Will add new window for adding ingredient
        /// </summary>
        public void AddNewIngredient()
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Id = ingredients.Count;
            ingredients.Add(ingredient);
        }


        /// <summary>
        /// Will add new window for adding next step
        /// </summary>
        public void AddNewStep()
        {
            DescriptionProcess descriptionProcess = new DescriptionProcess();
            descriptionProcess.Id = steps.Count;
            steps.Add(descriptionProcess);
        }

        /// <summary>
        /// Will add new window for adding new image
        /// </summary>
        public void AddNewImage()
        {
            Image i = new Image();
            i.Id = images.Count;
            images.Add(i);
        }

        /// <summary>
        /// Will change rating how user liked its recepie
        /// </summary>
        public void ChangeRating(int rating)
        {
            for (int i = 0; i < ratings.Count; i++)
            {
                ratings[i].Class = "";
            }

            user_rating = rating;
            ratings[rating - 1].Class = "checked_rating";
        }

        /// <summary>
        /// Will type of the food 
        /// </summary>
        public void ChangeType(int type)
        {
            for (int i = 0; i < types.Count; i++)
            {
                types[i].Class = "";
            }

            types[type].Class = "checked_rating";
            new_type = type;
        }

        /// <summary>
        /// Adds recepie to
        /// </summary>
        public void AddNewRecepie()
        {
            Recepie r = new Recepie();

            r.Id = example_user.Ongoing_Recepies.Count;
            r.Abandon = false;
            r.Description = new_recepie_description;
            r.DescriptionsList = steps;
            r.Finished = false;
            r.Name = new_recepie_name;
            r.Ongoing = true;
            r.Rating = creator_recepie_rating;
            r.RecepieImages = images;
            r.IngredientsList = ingredients;
            r.Rating = user_rating;
            r.Type = new_type;

            example_user.Ongoing_Recepies.Add(r);

            ResetVariablesCreateNew();
        }


        #endregion


        protected override async Task OnInitializedAsync()
        {
            //Create first ingredient for window
            Ingredient ingredient = new Ingredient();
            ingredient.Id = 0;
            ingredients.Add(ingredient);

            //Create first step for window
            DescriptionProcess descriptionProcess = new DescriptionProcess();
            descriptionProcess.Id = 0;
            steps.Add(descriptionProcess);

            //Create first img for window
            Image img = new Image();
            img.Id = 0;
            images.Add(img);

            //Create ratings
            for (int i = 1; i < 11; i++)
            {
                Rating r = new Rating();
                r.Id = i - 1;
                r.RatePoint = i;
                ratings.Add(r);
            }

            Type t1 = new Type();
            Type t2 = new Type();
            Type t3 = new Type();
            Type t4 = new Type();
            Type t5 = new Type();

            t1.Id = 0;
            t2.Id = 1;
            t3.Id = 2;
            t4.Id = 3;
            t5.Id = 4;

            t1.Name = "Breakfast";
            t2.Name = "Lunch";
            t3.Name = "Dinner";
            t4.Name = "Dessert";
            t5.Name = "Snack";

            t1.TypeNumber = 0;
            t2.TypeNumber = 1;
            t3.TypeNumber = 2;
            t4.TypeNumber = 3;
            t5.TypeNumber = 4;

            types.Add(t1);
            types.Add(t2);
            types.Add(t3);
            types.Add(t4);
            types.Add(t5);
        }
    }
}
