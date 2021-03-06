﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OO_Final
{
    public partial class FormWelcome : Form
    {
        private User _CurrentUser = new User();
        private FakeUserRepository _Users = new FakeUserRepository();
        private FakeRecipeRepository _Recipes = new FakeRecipeRepository();
        private FakeScheduleRepository _Schedules = new FakeScheduleRepository();
        
        public FormWelcome()
        {
            InitializeComponent();
        }

        private void FormWelcome_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            // Force the user to log in to the application
            DialogResult isOK = DialogResult.OK;
            while(!_CurrentUser.isLoggedIn && isOK == DialogResult.OK)
            {
                FormLogin login = new FormLogin();
                isOK = login.ShowDialog();
                _CurrentUser = login._CurrentUser;
                login.Dispose();
            }
            if(isOK != DialogResult.OK)
            {
                Close();
                return;
            }
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            _CurrentUser.isLoggedIn = false;
            this.Close();
        }

        private void buttonAddRecipe_Click(object sender, EventArgs e)
        {
            FormAddRecipe form = new FormAddRecipe(_CurrentUser, _Users, _Recipes);
            form.ShowDialog();
            form.Dispose();
        }

        private void buttonViewRecipes_Click(object sender, EventArgs e)
        {
            FormViewRecipes form = new FormViewRecipes(_Recipes);
            form.ShowDialog();
            form.Dispose();
        }

        private void buttonNewSchedule_Click(object sender, EventArgs e)
        {
            FormNewSchedule form = new FormNewSchedule(_Recipes, _Users, _CurrentUser, _Schedules);
            form.ShowDialog();
            form.Dispose();
        }

        private void buttonViewSchedule_Click(object sender, EventArgs e)
        {
            FormViewSchedule form = new FormViewSchedule(_Recipes, _Users, _CurrentUser, _Schedules);
            form.ShowDialog();
            form.Dispose();
        }

        private void buttonViewGroceryList_Click(object sender, EventArgs e)
        {
            FormViewList form = new FormViewList(_Recipes, _Users, _CurrentUser, _Schedules);
            form.ShowDialog();
            form.Dispose();
        }
    }
}
