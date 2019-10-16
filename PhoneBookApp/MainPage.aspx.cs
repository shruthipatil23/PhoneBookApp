using Entity;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace PhoneBookApp
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HideSuccessMessage();
                HideFailureMessage();
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (txtSearch.Text == string.Empty)
            {
                phoneBookGrid.DataSource = PhoneBookBL.GetAllPhoneBookDetails();
                phoneBookGrid.DataBind();
            }
            else
            {
                phoneBookGrid.DataSource = PhoneBookBL.GetPhoneDetailsBySearch(txtSearch.Text);
                phoneBookGrid.DataBind();
            }
        }

        protected void phoneBookGrid_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            phoneBookGrid.EditIndex = e.NewEditIndex;
            ShowData();
        }

        protected void phoneBookGrid_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            PhoneDetails phoneDetail = new PhoneDetails();

            phoneDetail.PhoneBookId = Convert.ToInt32((phoneBookGrid.Rows[e.RowIndex].FindControl("lblID") as Label).Text);
            phoneDetail.FirstName = (phoneBookGrid.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text;
            phoneDetail.MiddleName = (phoneBookGrid.Rows[e.RowIndex].FindControl("txtMiddleName") as TextBox).Text;
            phoneDetail.LastName = (phoneBookGrid.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text;
            phoneDetail.Email = (phoneBookGrid.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text;
            phoneDetail.PhoneNo = (phoneBookGrid.Rows[e.RowIndex].FindControl("txtPhoneNo") as TextBox).Text;
            phoneDetail.Address = (phoneBookGrid.Rows[e.RowIndex].FindControl("txtAddress") as TextBox).Text;

            PhoneBookBL.UpdatePhoneBookDetails(phoneDetail);

            phoneBookGrid.EditIndex = -1;
            Clear();
            ShowSuccessMessage();
            ShowData();
        }

        protected void phoneBookGrid_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            phoneBookGrid.EditIndex = -1;
            ShowData();
        }

        protected void phoneBookGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            phoneBookGrid.PageIndex = e.NewPageIndex;
            ShowData();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ValidateBeforeSave();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
            ShowData();
            phoneBookGrid.PageIndex = 0;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void ShowSuccessMessage()
        {
            HtmlControl control = (HtmlControl)Page.FindControl("successMsg");
            if (control != null)
            {
                control.Style.Add("display", "block");
            }
        }

        private void ShowFailureMessage()
        {
            HtmlControl control = (HtmlControl)Page.FindControl("failureMsg");
            if (control != null)
            {
                control.Style.Add("display", "block");
            }
        }

        private void HideSuccessMessage()
        {
            HtmlControl control = (HtmlControl)Page.FindControl("successMsg");
            if (control != null)
            {
                control.Style.Add("display", "none");
            }
        }

        private void HideFailureMessage()
        {
            HtmlControl control = (HtmlControl)Page.FindControl("failureMsg");
            if (control != null)
            {
                control.Style.Add("display", "none");
            }
        }

        private void ValidateBeforeSave()
        {
            if (txtFirstName.Text == string.Empty || txtLastName.Text == string.Empty || txtPhoneNo.Text == string.Empty)
            {
                Clear();
                ShowFailureMessage();
            }
            else
            {
                PhoneDetails phoneDetails = new PhoneDetails
                {
                    PhoneBookId = 0,
                    Address = txtAddress.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    MiddleName = txtMiddleName.Text.Trim(),
                    PhoneNo = txtPhoneNo.Text.Trim()
                };
                PhoneBookBL.AddPhoneBookDetails(phoneDetails);
                Clear();
                ShowSuccessMessage();
                ShowData();
            }
        }

        private void Clear()
        {
            txtAddress.Text = txtEmail.Text = txtFirstName.Text = txtLastName.Text =
                txtMiddleName.Text = txtPhoneNo.Text = txtSearch.Text = string.Empty;
            HideSuccessMessage();
            HideFailureMessage();
        }

        protected void phoneBookGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var phoneBookId = Convert.ToInt32((phoneBookGrid.Rows[e.RowIndex].FindControl("lblID") as Label).Text);
            PhoneBookBL.DeletePhoneBookDetailById(phoneBookId);
            phoneBookGrid.EditIndex = -1;
            ShowData();
            Clear();
        }
    }
}