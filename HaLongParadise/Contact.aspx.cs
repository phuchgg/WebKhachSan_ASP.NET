using HaLongParadise.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaLongParadise
{
    public partial class Contact : System.Web.UI.Page
    {
        HaLongParadiseDataContext db = new HaLongParadiseDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                messError.Visible = false;
                messSuccess.Visible = false;
                LoadData();
            }
        }
        //Download source code mien phi tai Sharecode.vn
        /// <summary>
        /// Show dữ liệu của page
        /// </summary>
        void LoadData()
        {
            try
            {
                var pa = db.Contacts.SingleOrDefault(a => a.ContactId != -1);
                if (pa != null)
                {
                    txtAddress.Text = pa.ContactAddress;
                    txtAddressEng.Text = pa.ContactAddressEng;
                    txtPhone.Text = pa.phone;
                    txtEmail.Text = pa.Email;
                    txtFax.Text = pa.Fax;
                    ckContactDetail.Text = pa.ContactDetail;
                    ckContactDetailEng.Text = pa.ContactDetailEng;
                    ckDescription.Text = pa.Description;
                    ckDescriptionEng.Text = pa.DescriptionEng;
                    txtDescriptionSort.Text = pa.DescriptionSort;
                    txtDescriptionSortEng.Text = pa.DescriptionSortEng;
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Cập nhật lại dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                var pa = db.Contacts.SingleOrDefault(a => a.ContactId != -1);
                if (pa != null)
                {
                    pa.ContactAddress = txtAddress.Text;
                    pa.ContactAddressEng = txtAddressEng.Text;
                    pa.Description = ckDescription.Text;
                    pa.DescriptionEng = ckDescriptionEng.Text;
                    pa.DescriptionSort = txtDescriptionSort.Text;
                    pa.DescriptionSortEng = txtDescriptionSortEng.Text;
                    pa.ContactDetail = ckContactDetail.Text;
                    pa.ContactDetailEng = ckContactDetailEng.Text;
                    pa.phone = txtPhone.Text;
                    pa.Fax = txtFax.Text;
                    pa.Email = txtEmail.Text;
                    //thay thế ảnh mới nếu có
                    if (fulImage.HasFile)
                    {
                        //delete ảnh nếu có
                        if (ParadiseHotelPath.Contact_Image_Upload != pa.ImageUrl)//khác default
                            ParadiseHotelFile.DeleteFile(Setup.host + pa.ImageUrl);
                        // thêm ảnh mới
                        if (ParadiseHotelFile.IsFileImage(fulImage.FileName))
                        {
                            ParadiseHotelFile.CreateFoder(Setup.host + ParadiseHotelPath.Contact_Image_Upload);
                            if (ParadiseHotelFile.StrFoder != "")
                            {
                                ParadiseHotelFile.CreateFile(ParadiseHotelFile.StrFoder,
                                                     ParadiseHotelFile.StyleFile.HOUR_MINUTE_SECOND.ToString(),
                                                     fulImage.FileName);

                                if (ParadiseHotelFile.StrFile != "")
                                {
                                    fulImage.PostedFile.SaveAs(ParadiseHotelFile.StrFile);

                                    pa.ImageUrl = ParadiseHotelFile.StrFile.Replace(Setup.host, "");
                                }
                                else pa.ImageUrl = ParadiseHotelPath.Contact_Image_Default;
                            }
                            else pa.ImageUrl = ParadiseHotelPath.Contact_Image_Default;

                        }
                        else
                        {
                            pa.ImageUrl = ParadiseHotelPath.Contact_Image_Default;
                        }
                    }


                    db.SubmitChanges();
                }
                else
                {
                    var ct = new Contact();
                    ct.ContactAddress = txtAddress.Text;
                    ct.ContactAddressEng = txtAddressEng.Text;
                    ct.Description = ckDescription.Text;
                    ct.DescriptionEng = ckDescriptionEng.Text;
                    ct.DescriptionSort = txtDescriptionSort.Text;
                    ct.DescriptionSortEng = txtDescriptionSortEng.Text;
                    ct.ContactDetail = ckContactDetail.Text;
                    ct.ContactDetailEng = ckContactDetailEng.Text;
                    ct.phone = txtPhone.Text;
                    ct.Fax = txtFax.Text;
                    ct.Email = txtEmail.Text;
                    // xu ly anh

                    if (fulImage.HasFile)
                    {

                        if (ParadiseHotelFile.IsFileImage(fulImage.FileName))
                        {
                            ParadiseHotelFile.CreateFoder(Setup.host + ParadiseHotelPath.Contact_Image_Upload);
                            if (ParadiseHotelFile.StrFoder != "")
                            {
                                ParadiseHotelFile.CreateFile(ParadiseHotelFile.StrFoder,
                                                     ParadiseHotelFile.StyleFile.HOUR_MINUTE_SECOND.ToString(),
                                                     fulImage.FileName);

                                if (ParadiseHotelFile.StrFile != "")
                                {
                                    fulImage.PostedFile.SaveAs(ParadiseHotelFile.StrFile);

                                    ct.ImageUrl = ParadiseHotelFile.StrFile.Replace(Setup.host, "");
                                }
                                else ct.ImageUrl = ParadiseHotelPath.Contact_Image_Default;
                            }
                            else ct.ImageUrl = ParadiseHotelPath.Contact_Image_Default;

                        }
                        else
                        {
                            ct.ImageUrl = ParadiseHotelPath.Contact_Image_Default;
                        }
                    }
                    else ct.ImageUrl = ParadiseHotelPath.Contact_Image_Default;


                    db.Contacts.InsertOnSubmit(ct);
                    db.SubmitChanges();

                }
                messError.Visible = false;
                messSuccess.Visible = true;

            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Load lại dữ liệu cũ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            messError.Visible = false;
            messSuccess.Visible = false;
            LoadData();
            LoadData();
        }
    }
}