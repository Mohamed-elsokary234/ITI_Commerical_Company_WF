using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;//1
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iti.Commerical.Company
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //new database
        iti_commerical_model iti = new iti_commerical_model();
        //ITIcommerical iti2 = new ITIcommerical();
        //1 story مخازن
        //ADD
        private void btn_add_story_Click(object sender, EventArgs e)
        {
            try
            {
                Story story1 = new Story();

                story1.Stored_Id = int.Parse(txtStoryID.Text); //
                story1.Stored_Name = txt_name_story.Text;
                story1.Stored_Address = txt_address_story.Text;
                story1.Stored_Supervisor = txt_Supervisor_story.Text;
                
                iti.Stories.Add(story1);

                iti.SaveChanges();
                txt_name_story.Text = txt_address_story.Text = txt_Supervisor_story.Text =txtStoryID.Text= string.Empty;
                MessageBox.Show("تم اضافة المخزن الجديد ");
            }
            catch
            {
                MessageBox.Show(" (الرجاء ادخال رقم جديد للمخزن) هذا المخزن موجود بالفعل ");
            }
   
        }
        //display
        private void btn_Display_story_Click(object sender, EventArgs e)
        {
           int id=int.Parse(txtStoryID.Text);

            try
            {
                var row_story = (from row in iti.Stories
                                 where row.Stored_Id == id
                                 select row).First();
                MessageBox.Show(txtStoryID.Text);
                txt_name_story.Text = row_story.Stored_Name;
                txt_address_story.Text = row_story.Stored_Address;
                txt_Supervisor_story.Text = row_story.Stored_Supervisor;
            }
            catch
            {
                MessageBox.Show(" هذا المخزن غير موجود ");

            }
        }
        //update 
        private void btn_update_story_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtStoryID.Text);
            try
            {
                var row_story = (from row in iti.Stories
                                 where row.Stored_Id == id
                                 select row).First();
                if (txt_Supervisor_story.Text != "" || txt_name_story.Text != "" || txt_address_story.Text != "")
                {
                    row_story.Stored_Address= txt_address_story.Text;
                    row_story.Stored_Name=txt_name_story.Text;
                    row_story.Stored_Supervisor=txt_Supervisor_story.Text;

                    iti.SaveChanges();

                }
                else
                {
                    MessageBox.Show("الرجاء ملئ الخانات الفارغه ");
                }
            }
            catch
            {
                MessageBox.Show(" الرجاء ادخال رقم مخزن صحيح");
            }


        }
        //---------------------------------------------------------------//
        //2 category اصناف
        private void btn_add_category_Click(object sender, EventArgs e)
        {
            try
            {
                Category category1 = new Category();
                //Category_Measuring_Unit categoryMeasuring1 = new Category_Measuring_Unit();

                category1.Category_Code = int.Parse(txt_category_num.Text); //
                category1.Category_Name = txt_category_name.Text;
                category1.Category_Amount = int.Parse(txt_category_Amount.Text);
                category1.Category_expiry = int.Parse(txt_category_expiry.Text);
                category1.Product_Date = Convert.ToDateTime(txt_category_ProductDate.Text);
                category1.measure_units = txt_Category_measuring_unit.Text;


                //test if suplier found or not
                
                    category1.Suplier_Id = int.Parse(listBoxsuplier_name.SelectedValue.ToString());


                //
                category1.Stored_Id = int.Parse(listBox_stored_name.SelectedValue.ToString());
                //
                // categoryMeasuring1.categ_Code_Id = category1.Category_Code;

                iti.Categories.Add(category1);
                //iti.Category_Measuring_Unit.Add(categoryMeasuring1);

                iti.SaveChanges();
                // txt_name_story.Text = txt_address_story.Text = txt_Supervisor_story.Text = txtStoryID.Text = string.Empty;
                MessageBox.Show("تم اضافة الصنف الجديد ");
            }
            catch
            {
                MessageBox.Show(" (الرجاء ادخال رقم جديد للصنف) هذا الصنف موجود بالفعل ");
            }
        }

        private void btn_update_category_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_category_num.Text);
            try
            {

                var row_category = (from row in iti.Categories
                                    where row.Category_Code == id
                                    select row).First();

                if (txt_category_num.Text != "" || txt_category_name.Text != "" || txt_Category_measuring_unit.Text != "" || txt_category_expiry.Text != "" || txt_category_Amount.Text != "" || txt_category_ProductDate.Text != "" )
                {
                    row_category.Category_Code = int.Parse(txt_category_num.Text.Trim());
                    row_category.Category_Name = txt_category_name.Text.Trim();
                    row_category.Category_expiry = int.Parse(txt_category_expiry.Text.Trim());
                    row_category.Category_Amount = int.Parse(txt_category_Amount.Text.Trim());
                    row_category.Product_Date = Convert.ToDateTime(txt_category_ProductDate.Text.Trim());
                    row_category.measure_units = txt_Category_measuring_unit.Text.Trim();

                    
                    row_category.Stored_Id = int.Parse(listBox_stored_name.SelectedValue.ToString());

                   
                    row_category.Suplier_Id = int.Parse(listBoxsuplier_name.SelectedValue.ToString());
                    //-----------------------------------------------------------//
                    //int Category_code = row_category.Category_Code;
                    //var row_Category_Measuring_Unit = (from s in iti.Category_Measuring_Unit
                    //                                   where s.categ_Code_Id == Category_code
                    //                                   select s).First();
                    //MessageBox.Show(row_Category_Measuring_Unit.categ_measuring_unit,txt_Category_measuring_unit.Text);

                    iti.SaveChanges();
                    MessageBox.Show(" تم تعديل الصنف ");
                }
                else
                {
                    MessageBox.Show("الرجاء ملئ الخانات الفارغه او صحيحه   ");
                }
            }
            catch
            {
                MessageBox.Show($"او التاكد من ان كل البيانات صحيحه ","   الرجاء ادخال رقم صنف صحيح");
            }

        }
        //display
        private void btn_display_category_Click(object sender, EventArgs e)
        {
            Category category1 = new Category();
            //Category_Measuring_Unit categoryMeasuring1 = new Category_Measuring_Unit();

            // 
            if (txt_category_num.Text.Trim()!="")
            {
                int id = int.Parse(txt_category_num.Text.Trim());
           
            var row_Category = (from s in iti.Categories
                                where s.Category_Code == id
                                select s).First();
            //
            int category_Id = row_Category.Category_Code;//1
            //error
            //var row_category_unit = (from d in iti.Category_Measuring_Unit
            //                         where d.categ_Code_Id == category_Id
            //                         select d).First();
            //
            txt_category_num.Text = row_Category.Category_Code.ToString();
            txt_category_name.Text = row_Category.Category_Name;
            txt_category_Amount.Text = row_Category.Category_Amount.ToString();
            txt_category_ProductDate.Text = row_Category.Product_Date.ToString();
            txt_category_expiry.Text = row_Category.Category_expiry.ToString();
            txt_Category_measuring_unit.Text = row_Category.measure_units;

            listBox_stored_name.SelectedValue = row_Category.Stored_Id;

            var suplier_id = (from r in iti.Supliers
                                where r.Suplier_Id == row_Category.Suplier_Id
                                select r.Suplier_Id).First();
                listBoxsuplier_name.SelectedValue = suplier_id;
                //
            }
            else { MessageBox.Show("ادخل داتا صحيحه "); }
        }
        // 3 Suplier
        //1 add 
        private void btn_add_suplier_Click(object sender, EventArgs e)
        {
            try
            {
                Suplier suplier1 = new Suplier();

                suplier1.Suplier_Id = int.Parse(txt_Suplier_num.Text); //
                suplier1.Suplier_Name = txt_Suplier_name.Text;
                suplier1.Suplier_Phone = txt_Suplier_phone.Text;
                suplier1.Suplier_Fax = txt_Suplier_Fax.Text;
                suplier1.Suplier_telephone = txt_Suplier_Telephone.Text;
                iti.Supliers.Add(suplier1);

                iti.SaveChanges();
                // txt_name_story.Text = txt_address_story.Text = txt_Supervisor_story.Text = txtStoryID.Text = string.Empty;
                MessageBox.Show("تم اضافة المورد الجديد ");
            }
            catch
            {
                MessageBox.Show(" (الرجاء ادخال رقم جديد للمورد) هذا المورد موجود بالفعل ");
            }
        }
        // update
        private void btn_update_suplier_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_Suplier_num.Text);
            try
            {

                var row_Suplier = (from row in iti.Supliers
                                   where row.Suplier_Id ==id
                                   select row).First();

                if (txt_Suplier_num.Text != "" || txt_Suplier_name.Text != "" || txt_Suplier_phone.Text != "" || txt_Suplier_Fax.Text != "" || txt_Suplier_Telephone.Text != "")
                {
                    row_Suplier.Suplier_Id = int.Parse(txt_Suplier_num.Text.Trim());
                    row_Suplier.Suplier_Name = txt_Suplier_name.Text.Trim();
                    row_Suplier.Suplier_Phone = txt_Suplier_phone.Text.Trim();
                    row_Suplier.Suplier_Fax = txt_Suplier_Fax.Text.Trim();
                    row_Suplier.Suplier_telephone = txt_Suplier_Telephone.Text.Trim();

                    iti.SaveChanges();
                    MessageBox.Show(" تم تعديل المورد ");
                }
                else
                {
                    MessageBox.Show("الرجاء ملئ الخانات الفارغه او صحيحه   ");
                }
            }
            catch
            {
                MessageBox.Show(" الرجاء ادخال رقم المورد صحيح");
            }

        }
        // display
        private void btn_display_suplier_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_Suplier_num.Text.Trim());
            try
            {
                var row_Suplier1 = (from row1 in iti.Supliers
                                    where row1.Suplier_Id == id
                                    select row1).First();
                //MessageBox.Show(txt_Suplier_num.Text);
                //MessageBox.Show(row_Suplier1);
                txt_Suplier_name.Text = row_Suplier1.Suplier_Name;
                txt_Suplier_phone.Text = row_Suplier1.Suplier_Phone;
                txt_Suplier_Fax.Text = row_Suplier1.Suplier_Fax;
                txt_Suplier_Telephone.Text = row_Suplier1.Suplier_telephone;

            }
            catch
            {
                MessageBox.Show(" هذا المورد غير موجود ");

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iTI_Commercial_CompanyDataSet.Clients_Permission_Category' table. You can move, or remove it, as needed.
            this.clients_Permission_CategoryTableAdapter.Fill(this.iTI_Commercial_CompanyDataSet.Clients_Permission_Category);
            // TODO: This line of code loads data into the 'iTI_Commercial_CompanyDataSet.Suplier_Category' table. You can move, or remove it, as needed.
            this.suplier_CategoryTableAdapter.Fill(this.iTI_Commercial_CompanyDataSet.Suplier_Category);
            // TODO: This line of code loads data into the 'iTI_Commercial_CompanyDataSet.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.iTI_Commercial_CompanyDataSet.Categories);
            // TODO: This line of code loads data into the 'iTI_Commercial_CompanyDataSet.Stories' table. You can move, or remove it, as needed.
            this.storiesTableAdapter.Fill(this.iTI_Commercial_CompanyDataSet.Stories);
            // TODO: This line of code loads data into the 'iTI_Commercial_CompanyDataSet.Clients' table. You can move, or remove it, as needed.
            this.clientsTableAdapter.Fill(this.iTI_Commercial_CompanyDataSet.Clients);
            // TODO: This line of code loads data into the 'iTI_Commercial_CompanyDataSet.Supliers' table. You can move, or remove it, as needed.
            this.supliersTableAdapter.Fill(this.iTI_Commercial_CompanyDataSet.Supliers);

        }

        private void btn_display_all_Click(object sender, EventArgs e)
        {
            dataGridViewStories.Rows.Clear();
            foreach (var item in iti.Stories)
            {
                dataGridViewStories.Rows.Add(item.Stored_Id, item.Stored_Name, item.Stored_Address, item.Stored_Supervisor);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridViewSupliers.Rows.Clear();
            foreach (var item in iti.Supliers)
            {
                dataGridViewSupliers.Rows.Add(item.Suplier_Id,item.Suplier_Name,item.Suplier_Phone,item.Suplier_Fax,item.Suplier_Phone);
            }
            
        }
/// <summary>
/// --------clients العملاء
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Client Client1 = new Client();

                Client1.Client_Id = int.Parse(txt_client_id.Text); //
                Client1.Client_Name = txt_client_name.Text;
                Client1.Client_Phone = txt_client_phone.Text;
                Client1.Client_Address = txt_client_address.Text;
                Client1.Client_Telephone = txt_client_telephone.Text;
                iti.Clients.Add(Client1);

                iti.SaveChanges();
                // txt_name_story.Text = txt_address_story.Text = txt_Supervisor_story.Text = txtStoryID.Text = string.Empty;
                MessageBox.Show("تم اضافة العميل الجديد ");
            }
            catch
            {
                MessageBox.Show(" (الرجاء ادخال رقم جديد للعميل) هذا العميل موجود بالفعل ");
            }
        }
        //update
        private void btn_clients_updates_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_client_id.Text);
            try
            {

                var row_Suplier = (from row in iti.Clients
                                   where row.Client_Id == id
                                   select row).First();

                if (txt_client_id.Text != "" || txt_client_name.Text != "" || txt_client_phone.Text != "" || txt_client_address.Text != "" || txt_client_telephone.Text != "")
                {
                    row_Suplier.Client_Id = int.Parse(txt_client_id.Text.Trim());
                    row_Suplier.Client_Name = txt_client_name.Text.Trim();
                    row_Suplier.Client_Phone = txt_client_phone.Text.Trim();
                    row_Suplier.Client_Address = txt_client_address.Text.Trim();
                    row_Suplier.Client_Telephone = txt_client_telephone.Text.Trim();

                    iti.SaveChanges();
                    MessageBox.Show(" تم تعديل العميل ");
                }
                else
                {
                    MessageBox.Show("الرجاء ملئ الخانات الفارغه او صحيحه   ");
                }
            }
            catch
            {
                MessageBox.Show(" الرجاء ادخال رقم العميل صحيح");
            }
        }
        //Display
        private void btn_clients_Display_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_client_id.Text.Trim());
            try
            {
                var row_Client1 = (from row1 in iti.Clients
                                    where row1.Client_Id == id
                                    select row1).First();
                //MessageBox.Show(txt_Suplier_num.Text);
                //MessageBox.Show(row_Suplier1);
                txt_client_name.Text = row_Client1.Client_Name;
                txt_client_phone.Text = row_Client1.Client_Phone;
                txt_client_address.Text = row_Client1.Client_Address;
                txt_client_telephone.Text = row_Client1.Client_Telephone;

            }
            catch
            {
                MessageBox.Show(" هذا العميل غير موجود ");

            }
        }
        //Display all
        private void btn_clients_all_Click(object sender, EventArgs e)
        {
            dataGridViewClients.Rows.Clear();
            foreach (var item in iti.Clients)
            {
                dataGridViewClients.Rows.Add(item.Client_Id, item.Client_Name, item.Client_Phone, item.Client_Address, item.Client_Telephone);
            }
        }

        private void btnCategory_all_Click(object sender, EventArgs e)
        {
            dataGridViewCategories.Rows.Clear();
            try
            {
                var storyName = "";
                foreach (var item in iti.Categories)
                {
                    int? id =(item.Stored_Id);
                    //if (id != null)
                    //{
                    storyName = (from row in iti.Stories
                                 where row.Stored_Id == id
                                 select row.Stored_Name).First();
                    //}

                    var suplierName = (from row in iti.Supliers
                                       where row.Suplier_Id == item.Suplier_Id
                                       select row.Suplier_Name).First();

                    //
                    //string measuring_unit = (from r in iti.Category_Measuring_Unit
                    //                         where r.categ_Code_Id == item.Category_Code
                    //                         select r.categ_measuring_unit).First();

                    dataGridViewCategories.Rows.Add(item.Category_Code, item.Category_Name, item.Product_Date, item.Category_expiry, item.Category_Amount, suplierName, storyName, item.measure_units);
                }
            }
            catch
            {
                MessageBox.Show("حدث خطاء ");
            }
        }
        int permission_num_category_suplier;
        int permission_num_category_client;
        private void btn_premion_add_Click(object sender, EventArgs e)
        {
            try
            {
                Suplier_Permission suplier_Permission1 = new Suplier_Permission();

                suplier_Permission1.Permission_num = ((from r in iti.Suplier_Permission
                                                      select r.Permission_num).Max())+1;
                //int.Parse(txt_premission_num.Text);
                //1
                txt_premission_num.ReadOnly = true;
                txt_premission_num.Text = suplier_Permission1.Permission_num.ToString();
                suplier_Permission1.Permission_Date = DateTime.Now;//Convert.ToDateTime(txt_premission_Date.Text);
                txt_premission_Date.Text = suplier_Permission1.Permission_Date.ToString();


                suplier_Permission1.Stored_Id = int.Parse(listBox_stored_name_suplier_permission.SelectedValue.ToString());

                suplier_Permission1.Suplier_Id = int.Parse(listBox_suplier_name_permission.SelectedValue.ToString());
                
                iti.Suplier_Permission.Add(suplier_Permission1);

                iti.SaveChanges();
                // txt_name_story.Text = txt_address_story.Text = txt_Supervisor_story.Text = txtStoryID.Text = string.Empty;
                MessageBox.Show("تم اضافة اذن جديد ");
                //---------------------------------------//
                //1 open textboxes
                txt_permission_num_sup_cates.Text = txt_premission_num.Text;
                permission_num_category_suplier = int.Parse(txt_premission_num.Text);

                 txt_permission_cates_expiry.ReadOnly= txt_permission_cates_date.ReadOnly = txt_permission_cates_amount.ReadOnly = false;
                //2 open btns
                btn_add_cates.Enabled = btn_update_cates.Enabled= btn_display_cates.Enabled = btn_add_all_cates.Enabled = true;
                //2-close permission txtboxes 
                txt_premission_num.ReadOnly = txt_premission_Date.ReadOnly = true;
                // listBox_stored_name_suplier_permission.Visible = listBox_suplier_name_permission .Visible = false;
                btn_premion_add.Enabled = btn_permission_update.Enabled = btn_premission_display.Enabled = false;
            }
            catch
            {
                MessageBox.Show(" (الرجاء ادخال رقم جديد للاذن) هذا الاذن موجود بالفعل ");
            }
        }

        private void btn_permission_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_premission_num.Text.Trim() != "")
                {
                    int id = int.Parse(txt_premission_num.Text);
                    var row = (from r in iti.Suplier_Permission
                               where r.Permission_num == id
                               select r).First();
                    //
                    //row.Permission_Date = Convert.ToDateTime(txt_premission_Date.Text);
                    row.Stored_Id = int.Parse(listBox_stored_name_suplier_permission.SelectedValue.ToString());
                    row.Suplier_Id = int.Parse(listBox_suplier_name_permission.SelectedValue.ToString());

                    iti.SaveChanges();
                    MessageBox.Show(" تم التعديل الاذن وجارى عرض الاصناف للتعديل");
                    //---------------------------------------------------------------//
                    //1 open textboxes
                    txt_permission_num_sup_cates.Text = txt_premission_num.Text;
                    int permission_num = int.Parse(txt_premission_num.Text);
                    permission_num_category_suplier = int.Parse(txt_premission_num.Text);

                    txt_permission_cates_expiry.ReadOnly = txt_permission_cates_date.ReadOnly = txt_permission_cates_amount.ReadOnly = false;
                    //2 open btns
                    btn_add_cates.Enabled = btn_update_cates.Enabled = btn_display_cates.Enabled = btn_add_all_cates.Enabled = true;
                    //2-close permission txtboxes 
                    txt_premission_num.ReadOnly = txt_premission_Date.ReadOnly = true;
                    // listBox_stored_name_suplier_permission.Visible = listBox_suplier_name_permission .Visible = false;
                    btn_premion_add.Enabled = btn_permission_update.Enabled = btn_premission_display.Enabled = false;
                    //0-===================================-//
                    //listBox_category_name_permission.DataSource 
                      var suplier_category_permission  = (from r in iti.Suplier_Category
                                                          where r.Premission_num == permission_num
                                                          select r.Suplier_category_Code);
                    var suplier_category_permission_names = (from r in iti.Suplier_Category
                                                       where r.Premission_num == permission_num
                                                       select r.Suplier_category_Name);

                    //listBox1.Items.Clear();
                    //foreach (var item in suplier_category_permission)
                    //{
                    //    listBox1.ValueMember=(item.ToString());
                    //}

                    //foreach (var item in suplier_category_permission_names)
                    //{
                    //    listBox1.DisplayMember = (item.ToString());
                    //}

                    //listBox_category_name_permission.ValueMember= (from r in iti.Suplier_Category
                    //                                               where r.Premission_num == permission_num
                    //                                               select r.Suplier_category_Code);
                }
                else
                {
                    MessageBox.Show(" الرجاء ادخال رقم صحيح ");
                }
            }
            catch
            {
                MessageBox.Show("حدث مشكله فى التعديل ");
            }
        }
        //clients 
        //add 
        private void btn_client_permession_add_Click(object sender, EventArgs e)
        {
            try
            {
                Clients_Permission Clients_Permission1 = new Clients_Permission();

                Clients_Permission1.Permission_num = ((from r in iti.Clients_Permission
                                                       select r.Permission_num).Max()) + 1;
                //int.Parse(txt_premission_num.Text);
                //1
                txt_client_premission_num.ReadOnly = true;
                txt_client_premission_num.Text = Clients_Permission1.Permission_num.ToString();
                Clients_Permission1.Permission_Date = DateTime.Now;//Convert.ToDateTime(txt_premission_Date.Text);
                txt_client_premission_product_date.Text = Clients_Permission1.Permission_Date.ToString();


                Clients_Permission1.Stored_Id = int.Parse(listBox_stored_permission.SelectedValue.ToString());

                Clients_Permission1.Client_Id = int.Parse(listBoxClient_permission.SelectedValue.ToString());

                iti.Clients_Permission.Add(Clients_Permission1);

                iti.SaveChanges();
                // txt_name_story.Text = txt_address_story.Text = txt_Supervisor_story.Text = txtStoryID.Text = string.Empty;
                MessageBox.Show("تم اضافة اذن جديد ");
                //---------------------------------------//
                //1 open textboxes
                txt_client_premission_num1.Text = txt_client_premission_num.Text;
                permission_num_category_client = int.Parse(txt_client_premission_num.Text);
                txt_client_premission_expiry.ReadOnly = txt_client_premission_product_date.ReadOnly = txt_client_premission_amount.ReadOnly = false;
                //2 open btns
                btn_client_add_cates.Enabled = btn_client_update_cates.Enabled = btn_client_display_cates.Enabled = btn_client_add_all_cates.Enabled = true;
                //2-close permission txtboxes 
                txt_client_premission_num.ReadOnly = txt_client_premission_product_date.ReadOnly = true;
                // listBox_stored_name_suplier_permission.Visible = listBox_suplier_name_permission .Visible = false;
                btn_client_permession_add.Enabled = btn_client_permission_update.Enabled = btn_client_permission_display.Enabled = false;
            }
            catch
            {
                MessageBox.Show(" (الرجاء ادخال رقم جديد للاذن) هذا الاذن موجود بالفعل ");
            }
        }

        private void btn_clients_All_permission_Click(object sender, EventArgs e)
        {
            dataGridView_client_permssion.Rows.Clear();
            foreach (var item in iti.Clients_Permission)
            {
                string stored_name = (from r in iti.Stories
                                      where r.Stored_Id == item.Stored_Id
                                      select r.Stored_Name).First();
                string client_name = (from r in iti.Clients
                                      where r.Client_Id == item.Client_Id
                                      select r.Client_Name).First();

                dataGridView_client_permssion.Rows.Add(item.Permission_num, item.Permission_Date,stored_name,client_name);
            }
            MessageBox.Show("الكل");
        }

        private void btn_allCategory_story_Click(object sender, EventArgs e)
        {
            dataGridViewCategories.Rows.Clear();
            //MessageBox.Show(listBoxStored_all.SelectedValue.ToString());
            int id = int.Parse(listBoxStored_all.SelectedValue.ToString());
            foreach (var item in iti.Categories)
            {
                if (item.Stored_Id == id)
                {
                    var suplierName = (from row in iti.Supliers
                                       where row.Suplier_Id == item.Suplier_Id
                                       select row.Suplier_Name).First();
                    dataGridViewCategories.Rows.Add(item.Category_Code, item.Category_Name, item.Product_Date, item.Category_expiry,item.Category_Amount, suplierName,listBoxStored_all.Text);
                } 
            }
        }

        private void btn_category_expire_date_Click(object sender, EventArgs e)
        {
            try {
                dataGridViewCategories.Rows.Clear();
               
               // dataGridViewCategories.Columns.Add();

                foreach (var item in iti.Categories)
                {
                    string[] n = (item.Product_Date.ToString()).Split(' ');
                    string[] arr = n[0].Split('/');
                    int day = int.Parse(arr[0]);
                    int sum_months = int.Parse(arr[1]) + int.Parse(item.Category_expiry.ToString());
                    //MessageBox.Show("sum "+arr[0]+" "+arr[1]);
                    int year =  int.Parse(arr[2]) ;

                    do
                    {
                        if (sum_months > 12)
                        {
                            //1
                            sum_months -= 12;
                            //2
                            year += 1;
                        }
                    } while (sum_months >= 12);
                    //تاريخ انتهاء الصلاحيه 
                    int s_day = int.Parse(arr[0]);

                    //sum_month
                    //year
                    //------------------------
                    //current date
                    string[] current_date = DateTime.Now.ToString().Split(' ');
                    string[] curr_arr = current_date[0].Split('/');

                    int curr_day = int.Parse(curr_arr[1]);
                    int curr_month = int.Parse(curr_arr[0]);
                    int curr_year = int.Parse(curr_arr[2]);


                   // MessageBox.Show(year+" "+item.Category_Name);
                    if (year >= curr_year)
                    {
                        if (year == curr_year)
                        {
                            if (sum_months == curr_month || sum_months - 2 == curr_month)
                            {
                                var suplierName = (from row in iti.Supliers
                                                   where row.Suplier_Id == item.Suplier_Id
                                                   select row.Suplier_Name).First();
                                //الوقت المتبقى من الصلاحيه 
                                int s_m = sum_months - curr_month;
                                int s_d = s_day - curr_day;
                                string s= $"الايام="+ s_d.ToString()+"الاشهر = "+s_m.ToString();
                                dataGridViewCategories.Rows.Add(item.Category_Code, item.Category_Name, item.Product_Date, item.Category_expiry, item.Category_Amount, suplierName, listBoxStored_all.Text,item.measure_units,s);
                              //  MessageBox.Show("تم عرض كل الاصناف ");
                            }
                            else
                            {
                                //MessageBox.Show("قرب شهر لا يوجد  ");

                            }
                        }
                        else
                        {
                            // MessageBox.Show("لا يوجد قرب عام  ");

                        }
                    }
                    else
                    {
                        // MessageBox.Show("لا يوجد  ");

                    }
                }
            }
            catch
            {
                 MessageBox.Show("لا يوجد  ");

            }
        }

        private void btn_client_permission_display_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_client_premission_num.Text.Trim() != "")
                {
                    int id = int.Parse(txt_client_premission_num.Text);
                    var row = (from r in iti.Clients_Permission
                               where r.Permission_num == id
                               select r).First();
                    //
                    txt_client_permission_date.Text= row.Permission_Date.ToString();
                    listBox_stored_permission.SelectedValue = row.Stored_Id;
                    listBoxClient_permission.SelectedValue = row.Client_Id;

                    iti.SaveChanges();
                    MessageBox.Show("تم العرض ");
                }
                else
                {
                    MessageBox.Show(" الرجاء ادخال رقم صحيح ");
                }
            }
            catch
            {
                MessageBox.Show("حدث مشكله فى العرض ");
            }
        }

        private void btn_client_permission_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_client_premission_num.Text.Trim()!="")
                {
                    int id = int.Parse(txt_client_premission_num.Text);
                    var row = (from r in iti.Clients_Permission
                               where r.Permission_num == id
                               select r).First();
                    //
                    row.Permission_Date = Convert.ToDateTime(txt_client_permission_date.Text);
                    row.Stored_Id = int.Parse(listBox_stored_permission.SelectedValue.ToString());
                    row.Client_Id = int.Parse(listBoxClient_permission.SelectedValue.ToString());

                    iti.SaveChanges();
                    MessageBox.Show("تم التعديل ");
                }
                else
                {
                    MessageBox.Show(" الرجاء ادخال رقم صحيح ");
                }
            }
            catch
            {
                MessageBox.Show("حدث مشكله فى التعديل ");
            }
        }

        private void btn_premission_display_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_premission_num.Text.Trim() != "")
                {
                    int id = int.Parse(txt_premission_num.Text);

                    var row_permission = (from r in iti.Suplier_Permission
                                                  where r.Permission_num == id
                                                  select r).First();
                    txt_premission_Date.ReadOnly = false;
                    txt_premission_Date.Text = row_permission.Permission_Date.ToString();
                    txt_premission_Date.ReadOnly = true;

                    listBox_suplier_name_permission.SelectedValue = row_permission.Stored_Id;
                    listBox_suplier_name_permission.SelectedValue = row_permission.Suplier_Id;
                    MessageBox.Show("تم عرض الاذن  ");
                }
                else
                {
                    MessageBox.Show("لايوجد الاذن  ");

                }
            }
            catch
            {
                MessageBox.Show("لايوجد   ");

            }
        }

        private void btn_prmissions_all_supliers_Click(object sender, EventArgs e)
        {

            dataGridViewsuplier_permission.Rows.Clear();
            foreach (var item in iti.Suplier_Permission)
            {
                string stored_name = (from r in iti.Stories
                                      where r.Stored_Id == item.Stored_Id
                                      select r.Stored_Name).First();
                string suplier_name = (from r in iti.Supliers
                                      where r.Suplier_Id == item.Suplier_Id
                                      select r.Suplier_Name).First();

                dataGridViewsuplier_permission.Rows.Add(item.Permission_num, item.Permission_Date, stored_name, suplier_name);
            }
            MessageBox.Show("ALL");
        }

        private void btn_add_cates_Click(object sender, EventArgs e)
        {
            try
            {
                Suplier_Category suplier_Category1 = new Suplier_Category();
                //1
                MessageBox.Show(permission_num_category_suplier.ToString());
                suplier_Category1.Premission_num = permission_num_category_suplier;
                if ( txt_permission_cates_amount.Text.Trim() != "" || txt_permission_cates_date.Text.Trim() != "" || txt_permission_cates_expiry.Text.Trim() != "")
                {   //2
                    suplier_Category1.Suplier_category_Code =int.Parse(listBox1.SelectedValue.ToString());
                    suplier_Category1.Suplier_category_Name = listBox1.Text;
                    suplier_Category1.Suplier_category_Product_date = Convert.ToDateTime(txt_permission_cates_date.Text);
                    suplier_Category1.Suplier_category_expiry = int.Parse(txt_permission_cates_expiry.Text);
                    suplier_Category1.Suplier_category_Amount =int.Parse(txt_permission_cates_amount.Text);

                    //3
                    iti.Suplier_Category.Add(suplier_Category1);
                    //iti.Categories.Add(suplier_Category1);

                    iti.SaveChanges();
                    MessageBox.Show(" تم حفظ الصنف");
                    //4
                   txt_permission_cates_amount.Text = txt_permission_cates_date.Text = txt_permission_cates_expiry.Text  =string.Empty;
                }
                else
                {
                    MessageBox.Show("الرجاء ادخال بيانات صحيحه  ");
                }
            }
            catch
            {
                MessageBox.Show(" الرجاء ادخال بيانات صحيحه");
            }
        }

        private void btn_update_cates_Click(object sender, EventArgs e)
        {
            try
            {
                //1
                

               
                    int code = int.Parse(listBox1.SelectedValue.ToString());
                    var row = (from r in iti.Suplier_Category
                               where r.Premission_num == permission_num_category_suplier && r.Suplier_category_Code == code
                               select r).First();
                    //2
                    row.Suplier_category_Code = int.Parse(listBox1.SelectedValue.ToString());
                    row.Suplier_category_Name = listBox1.Text;
                    row.Suplier_category_Product_date = Convert.ToDateTime(txt_permission_cates_date.Text);
                    row.Suplier_category_expiry = int.Parse(txt_permission_cates_expiry.Text);
                    row.Suplier_category_Amount = int.Parse(txt_permission_cates_amount.Text);

                    //3
                    iti.SaveChanges();
                    MessageBox.Show(" تم تعديل الصنف");
                    //4
                     txt_permission_cates_amount.Text = txt_permission_cates_date.Text = txt_permission_cates_expiry.Text = string.Empty;
                
            }
            catch
            {
                MessageBox.Show(" الرجاء ادخال بيانات صحيحه");
            }
        }

        private void btn_display_cates_Click(object sender, EventArgs e)
        {
            try
            {
                //1

               
                    int code_categs = int.Parse(listBox1.SelectedValue.ToString());
                int permission_code = int.Parse(txt_permission_num_sup_cates.Text);
                    //MessageBox.Show("code "+code.ToString(), permission_num_category_suplier.ToString());
                var row = (from r in iti.Suplier_Category
                           where r.Premission_num == permission_code && r.Suplier_category_Code == code_categs
                           select r).First();

                //2
                //listBox1.SelectedValue = row.Suplier_category_Code.ToString();
                // listBox1.Text= row.Suplier_category_Name;
                txt_permission_cates_date.Text = row.Suplier_category_Product_date.ToString();
                txt_permission_cates_expiry.Text = row.Suplier_category_expiry.ToString();
                txt_permission_cates_amount.Text = row.Suplier_category_Amount.ToString();

                //3
                // iti.SaveChanges();
                //4
               // txt_permission_cates_amount.Text = txt_permission_cates_date.Text = txt_permission_cates_expiry.Text = string.Empty;
               
            }
            catch
            {
                MessageBox.Show(" الرجاء ادخال بيانات صحيحه");
            }
        }

        private void btn_add_all_cates_Click(object sender, EventArgs e)
        {
            //1 close textboxes


            //1 open textboxes
            //txt_permission_num_sup_cates.ReadOnly = false ;
            //txt_permission_num_sup_cates.Text = "";
            //txt_permission_num_sup_cates.ReadOnly = true;

            txt_permission_cates_expiry.ReadOnly = txt_permission_cates_date.ReadOnly = txt_permission_cates_amount.ReadOnly = true;
            //2 open btns
            btn_add_cates.Enabled = btn_update_cates.Enabled = btn_display_cates.Enabled = btn_add_all_cates.Enabled = false;
            //2-open permission txtboxes 
            txt_premission_num.ReadOnly = false; txt_premission_Date.ReadOnly = true;
            // listBox_stored_name_suplier_permission.Visible = listBox_suplier_name_permission .Visible = false;
            btn_premion_add.Enabled = btn_permission_update.Enabled = btn_premission_display.Enabled = true;
            //نقل من جدول الاذن الى جدول الاصناف
            MessageBox.Show(txt_permission_num_sup_cates.Text);
            txt_permission_num_sup_cates.ReadOnly = false;
            int permission_code = int.Parse(txt_permission_num_sup_cates.Text);
            txt_permission_num_sup_cates.ReadOnly = true;

            MessageBox.Show(permission_code.ToString());
            var all_categs = (from r in iti.Suplier_Category //|| iti.Suplier_Permission
                              where r.Premission_num == permission_code
                              select r);
            var all_permission = (from r in iti.Suplier_Permission
                                  where r.Permission_num == permission_code
                                  select r).First();

            foreach (var item in all_categs )
            {
                Category category1 = new Category();
                
                category1.Category_Code = item.Suplier_category_Code;
                category1.Category_Name = item.Suplier_category_Name;
                category1.Category_expiry = item.Suplier_category_expiry;
                category1.Category_Amount = item.Suplier_category_Amount;
                category1.Product_Date = item.Suplier_category_Product_date;
                
                category1.Stored_Id = all_permission.Stored_Id;
                
                category1.Suplier_Id = all_permission.Suplier_Id;

                iti.Categories.Add(category1);
            }
            MessageBox.Show(" تم ادخال البيانات الى المخرن");
        }

        private void btn_client_add_cates_Click(object sender, EventArgs e)
        {
            try
            {
                Clients_Permission_Category Clients_Permission_Category1 = new Clients_Permission_Category();
                //1
                Clients_Permission_Category1.Client_Premission_num = int.Parse(txt_client_premission_num1.Text);
                if ( txt_client_premission_amount.Text.Trim() != "" || txt_client_premission_product_date.Text.Trim() != "" || txt_client_premission_expiry.Text.Trim() != "" )
                {   //2
                    Clients_Permission_Category1.Client_category_Code = int.Parse(listBox2.SelectedValue.ToString());
                    Clients_Permission_Category1.Client_category_Name = listBox2.Text;
                    //MessageBox.Show(listBox2.SelectedValue.ToString(),listBox2.Text);
                    Clients_Permission_Category1.Client_category_Product_date = Convert.ToDateTime(txt_client_premission_product_date.Text);
                    Clients_Permission_Category1.Client_category_expiry = int.Parse(txt_client_premission_expiry.Text);
                    Clients_Permission_Category1.Client_category_Amount = int.Parse(txt_client_premission_amount.Text);

                    //3
                    iti.Clients_Permission_Category.Add(Clients_Permission_Category1);
                    iti.SaveChanges();
                    MessageBox.Show(" تم حفظ الصنف");
                    //4
                     txt_client_premission_amount.Text = txt_client_premission_product_date.Text = txt_client_premission_expiry.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("الرجاء ادخال بيانات صحيحه  ");
                }
            }
            catch
            {
                MessageBox.Show(" الرجاء ادخال بيانات صحيحه");
            }
        }

        private void btn_client_display_cates_Click(object sender, EventArgs e)
        {
            try
            {
                //1


                int code_categs = int.Parse(listBox2.SelectedValue.ToString());
                int permission_code = int.Parse(txt_client_premission_num1.Text);
                //MessageBox.Show("code "+code.ToString(), permission_num_category_suplier.ToString());
                var row = (from r in iti.Clients_Permission_Category
                           where r.Client_Premission_num == permission_code && r.Client_category_Code == code_categs
                           select r).First();

                //2
                //listBox1.SelectedValue = row.Suplier_category_Code.ToString();
                // listBox1.Text= row.Suplier_category_Name;
                txt_client_premission_product_date.Text = row.Client_category_Product_date.ToString();
                txt_client_premission_expiry.Text = row.Client_category_expiry.ToString();
                txt_client_premission_amount.Text = row.Client_category_Amount.ToString();

                //3
                // iti.SaveChanges();
                //4
                // txt_permission_cates_amount.Text = txt_permission_cates_date.Text = txt_permission_cates_expiry.Text = string.Empty;

            }
            catch
            {
                MessageBox.Show(" الرجاء ادخال بيانات صحيحه");
            }
        }

        private void btn_client_update_cates_Click(object sender, EventArgs e)
        {
            try
            {
                //1

                int permission_num_category_client = int.Parse(txt_client_premission_num1.Text);


                int code = int.Parse(listBox2.SelectedValue.ToString());
                var row = (from r in iti.Clients_Permission_Category
                           where r.Client_Premission_num == permission_num_category_client && r.Client_category_Code == code
                           select r).First();
                //2
                row.Client_category_Code = int.Parse(listBox2.SelectedValue.ToString());
                row.Client_category_Name = listBox2.Text;
               // txt_client_premission_product_date.ReadOnly = false;
                row.Client_category_Product_date = Convert.ToDateTime(txt_client_premission_product_date.Text);
               // txt_client_premission_product_date.ReadOnly = true;

                row.Client_category_expiry = int.Parse(txt_client_premission_expiry.Text);
                row.Client_category_Amount = int.Parse(txt_client_premission_amount.Text);

                //3
                iti.SaveChanges();
                MessageBox.Show(" تم تعديل الصنف");
                //4
                txt_client_premission_amount.Text = txt_client_permission_date.Text = txt_client_premission_expiry.Text = string.Empty;

            }
            catch
            {
                MessageBox.Show(" الرجاء ادخال بيانات صحيحه");
            }
        }

        private void btn_client_add_all_cates_Click(object sender, EventArgs e)
        {
            //1 close textboxes


            //1 open textboxes
            //txt_permission_num_sup_cates.ReadOnly = false ;
            //txt_permission_num_sup_cates.Text = "";
            //txt_permission_num_sup_cates.ReadOnly = true;

            txt_client_premission_expiry.ReadOnly = txt_client_premission_product_date.ReadOnly = txt_client_premission_amount.ReadOnly = true;
            //2 open btns
            btn_client_add_cates.Enabled = btn_client_update_cates.Enabled = btn_client_display_cates.Enabled = btn_client_add_all_cates.Enabled = false;
            //2-open permission txtboxes 
            txt_client_premission_num1.ReadOnly = false; txt_client_premission_product_date.ReadOnly = true;
            // listBox_stored_name_suplier_permission.Visible = listBox_suplier_name_permission .Visible = false;
            btn_client_permession_add.Enabled = btn_client_permission_update.Enabled = btn_client_permission_display.Enabled = true;
            //نقل من جدول الاذن الى جدول الاصناف
            // MessageBox.Show(txt_permission_num_sup_cates.Text);
            txt_client_premission_num1.ReadOnly = false;
            int permission_code = int.Parse(txt_client_premission_num1.Text);
            txt_client_premission_num1.ReadOnly = true;

            //MessageBox.Show(permission_code.ToString());
            var all_categs = (from r in iti.Clients_Permission_Category //|| iti.Suplier_Permission
                              where r.Client_Premission_num == permission_code
                              select r);
            var all_permission = (from r in iti.Clients_Permission
                                  where r.Permission_num == permission_code
                                  select r).First();

            foreach (var item in all_categs)
            {
                Category category1 = new Category();

                category1.Category_Code = item.Client_category_Code;
                category1.Category_Name = item.Client_category_Name;
                category1.Category_expiry = item.Client_category_expiry;
                category1.Category_Amount = item.Client_category_Amount;
                category1.Product_Date = item.Client_category_Product_date;

                category1.Stored_Id = all_permission.Stored_Id;

                category1.Suplier_Id = all_permission.Client_Id;

                iti.Categories.Add(category1);
            }
            MessageBox.Show(" تم ادخال البيانات الى المخرن");
        }
    }
}
