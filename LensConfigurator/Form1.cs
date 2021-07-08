using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Web;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.Net.Http;


namespace BalluffVisionConfigurator

{
    public partial class BalluffVisionScannerSelector : Form
    {


        SettingProperty SP = new SettingProperty();
        ProductDataBase PDB = new ProductDataBase();


        List<ListView> list_lvTabScanner = new List<ListView>();
        List<ListView> list_lvTabVisionSensor = new List<ListView>();
        List<ListView> list_lvTabSmartCamera = new List<ListView>();
        List<ListView> list_lvTabIndustrialCamera = new List<ListView>();
        List<ListView> list_lvTabLens = new List<ListView>();
        List<ListView> list_lvTabCable = new List<ListView>();
        List<ListView> list_lvTabCockpit = new List<ListView>();
        List<ListView> list_lvTabAccessory = new List<ListView>();

        List<Scanner> listScanner_local = new List<Scanner>();
        List<VisionSensor> listVisionSensor_local = new List<VisionSensor>();
        List<SmartCamera> listSmartCamera_local = new List<SmartCamera>();
        List<IndustrialCamera> listIndustrialCamera_local = new List<IndustrialCamera>();
        List<Lens> listLens_local = new List<Lens>();
        List<Cable> listCable_local = new List<Cable>();
        List<Cockpit> listcockpit_local = new List<Cockpit>();
        List<Accessory> listAccessory_local = new List<Accessory>();

        List<product> QS_List_Product = new List<product>();

        bool bScannerInit = false;
        bool bVisionSensorInit = false;
        bool bSmartCameraInit = false;
        bool bIndustrialCameraInit = false;
        bool bLensInit = false;
        bool bCableInit = false;
        bool bCockpitInit = false;
        bool bAccessoriesInit = false;


        public BalluffVisionScannerSelector()
        {
            InitializeComponent();
            //x = this.Width;
            // y = this.Height;
            //setTag(this);
            listScanner_local = (List<Scanner>)PDB.CloneLstScanner(PDB.ScannerList);
            listVisionSensor_local = (List<VisionSensor>)PDB.CloneLstVisionSensor(PDB.VisionSensorList);
            listSmartCamera_local = (List<SmartCamera>)PDB.CloneLstSmartCamera(PDB.SmartCameraList);
            listIndustrialCamera_local = (List<IndustrialCamera>)PDB.CloneLstIndustrialCamera(PDB.CAList);
            listLens_local = (List<Lens>)PDB.CloneLstLens(PDB.LensList);
            listCable_local = (List<Cable>)PDB.CloneLstCable(PDB.CableList);
            listcockpit_local = (List<Cockpit>)PDB.CloneLstCockpit(PDB.CockpitList);
            listAccessory_local = (List<Accessory>)PDB.CloneLstAccessory(PDB.AccessoryList);

            LoadScanner_Scanner();
            initForm();
        }


        #region 初始化数据

        private void initForm()
        {
            list_lvTabScanner.Add(listViewScanner_Scanner);
            list_lvTabScanner.Add(listViewScanner_AccessorySelector);
            list_lvTabVisionSensor.Add(listViewVisionSensor);
            list_lvTabVisionSensor.Add(listViewVisionSensorAccessory);
            list_lvTabSmartCamera.Add(listViewSmartCamera);
            list_lvTabSmartCamera.Add(listViewSmartCameraAccessory);
            list_lvTabIndustrialCamera.Add(listViewCA);
            list_lvTabIndustrialCamera.Add(listViewCA_Accessory);
            list_lvTabLens.Add(listViewLens);
            list_lvTabCable.Add(listViewCable);
            list_lvTabCockpit.Add(listViewCockpit);
            list_lvTabAccessory.Add(listViewAccessory);

            colHeaderDescription.Width = listViewMaterial.Width;
        }


        #endregion


        #region 控件选型结果增加，减少，清空，导出的按钮


        private ListView findSelectedItem()
        {
            ListView tmplistview = new ListView();
            int tabindex = tbProduct.SelectedIndex;

            if (tabindex == 1)
            {
                foreach (ListView listview in list_lvTabScanner)
                {
                    if (listview.SelectedItems.Count != 0)
                    {
                        tmplistview = listview;
                        break;
                    }
                }
            }
            else if (tabindex == 2)
            {
                foreach (ListView listview in list_lvTabVisionSensor)
                {
                    if (listview.SelectedItems.Count != 0)
                    {
                        tmplistview = listview;
                        break;
                    }
                }
            }
            else if (tabindex == 3)
            {
                foreach (ListView listview in list_lvTabSmartCamera)
                {
                    if (listview.SelectedItems.Count != 0)
                    {
                        tmplistview = listview;
                        break;
                    }
                }
            }
            else if (tabindex == 4)
            {
                foreach (ListView listview in list_lvTabIndustrialCamera)
                {
                    if (listview.SelectedItems.Count != 0)
                    {
                        tmplistview = listview;
                        break;
                    }
                }
            }
            else if (tabindex == 5)
            {
                foreach (ListView listview in list_lvTabLens)
                {
                    if (listview.SelectedItems.Count != 0)
                    {
                        tmplistview = listview;
                        break;
                    }
                }
            }
            else if (tabindex == 6)
            {
                foreach (ListView listview in list_lvTabCable)
                {
                    if (listview.SelectedItems.Count != 0)
                    {
                        tmplistview = listview;
                        break;
                    }
                }
            }
            else if (tabindex == 7)
            {
                foreach (ListView listview in list_lvTabCockpit)
                {
                    if (listview.SelectedItems.Count != 0)
                    {
                        tmplistview = listview;
                        break;
                    }
                }
            }
            else if (tabindex == 8)
            {
                foreach (ListView listview in list_lvTabAccessory)
                {
                    if (listview.SelectedItems.Count != 0)
                    {
                        tmplistview = listview;
                        break;
                    }
                }
            }
            return tmplistview;


        }


        // 增加选型结果
        private void btnAddML_Click(object sender, EventArgs e)
        {
            this.listViewMaterial.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度

            ListView foundselected = null;
            ListView.SelectedListViewItemCollection foundItem = null;
            int PositionIndex = 0;
            if (tbProduct.SelectedIndex !=0)
            { 
            foundselected = findSelectedItem(); //找到选中的listview
            foundItem = foundselected.SelectedItems;  //找到listview选中的items
            PositionIndex = this.listViewMaterial.Items.Count;
            }

            int count = 0;

            foreach (ListViewItem lvItem in foundItem)   //添加选中数据
            {
                ListViewItem item1 = listViewMaterial.FindItemWithText(lvItem.Text);
                product tmpProduct = product.getProduct(lvItem.Text, PDB.ProductList);

                if (tmpProduct.ProductFamily == product.enumProductFamily.Scanner)
                    getScannerAccessories(findSelectedItem().SelectedItems);

                if (item1 != null)
                {
                    int number = Helper.getIntFromString(item1.SubItems[3].Text);
                    item1.SubItems[3].Text = (number + 1).ToString();
                }
                else
                {
                    ListViewItem lvi = new ListViewItem();


                    lvi.Text = (count + PositionIndex + 1).ToString();     //通过与imageList绑定，显示imageList中第i项图标

                    lvi.SubItems.Add(tmpProduct.OrderCode);
                    lvi.SubItems.Add(tmpProduct.LongCode);
                    lvi.SubItems.Add("1");

                    if (SP.Systemlanguage == "English")
                    { lvi.SubItems.Add(tmpProduct.DescriptionEN); }
                    else
                    {
                        lvi.SubItems.Add(tmpProduct.DescriptionCN);
                    }

                    this.listViewMaterial.Items.Add(lvi);
                    count++;
                }

            }

            this.listViewMaterial.EndUpdate();  //结束数据处理，UI界面一次性绘制。
        }

        private void QuickAddML(List<product>  list_product)
        {
            int count = 0;
            int PositionIndex = this.listViewMaterial.Items.Count;

            foreach (product tmpProduct in list_product)
            {   
               

                ListViewItem lvi = new ListViewItem();


                lvi.Text = (count + PositionIndex + 1).ToString();     //通过与imageList绑定，显示imageList中第i项图标

                lvi.SubItems.Add(tmpProduct.OrderCode);
                lvi.SubItems.Add(tmpProduct.LongCode);
                lvi.SubItems.Add("1");

                if (SP.Systemlanguage == "English")
                { lvi.SubItems.Add(tmpProduct.DescriptionEN); }
                else
                {
                    lvi.SubItems.Add(tmpProduct.DescriptionCN);
                }

                this.listViewMaterial.Items.Add(lvi);
                count++;
            }

        }


        // 删减选中的选型结果
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int NumberofSelected = this.listViewMaterial.SelectedItems.Count;


            //有>1的数量，数量减少，=1数量时剔除
            foreach (ListViewItem lvi in this.listViewMaterial.SelectedItems)
            {
                int number = Helper.getIntFromString(lvi.SubItems[3].Text);
                if (number > 1)
                {
                    number--;
                    lvi.SubItems[3].Text = number.ToString();
                }
                else
                {
                    lvi.Remove();
                }

            }

            //检查位置，看是否中间项被删除，位置不准确
            this.listViewMaterial.BeginUpdate();   //
            int ItemCount = this.listViewMaterial.Items.Count;
            for (int i = 0; i < ItemCount; i++)
            {
                this.listViewMaterial.Items[i].Text = (i + 1).ToString();

            }

            this.listViewMaterial.EndUpdate();  //结束数据处理，UI界面一次性绘制。

        }

        // 清空选型列表
        private void btnCLRML_Click(object sender, EventArgs e)
        {
            this.listViewMaterial.Items.Clear();
        }


        private void btnExportML_Click(object sender, EventArgs e)
        {
            string filename = "";
            SaveFileDialog SaveDialog = new SaveFileDialog();

            SaveDialog.InitialDirectory = "C:\\Users\\Users\\Desktop";
            SaveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|CSV (*.csv)|*.csv";
            SaveDialog.FilterIndex = 1;
            SaveDialog.RestoreDirectory = true;

            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filename = SaveDialog.FileName;

            }
            try
            {
                ListViewToExcel(this.listViewMaterial, filename);
            }
            catch
            {

            }

           
        }



        protected void ListViewToExcel(ListView Listview_, string file)
        {
            //从Item中取数据
            ListView.ListViewItemCollection Item_ = Listview_.Items;
            int Itemlength = Item_.Count;
            Object[] array = new Object[100];
            Item_.CopyTo(array, 0);
            List<ListViewItem.ListViewSubItem> subitems_ = new List<ListViewItem.ListViewSubItem>();

            //创建workbook
            IWorkbook workbook;

            string fileExt = Path.GetExtension(file).ToLower();
            if (fileExt == ".xlsx")
                workbook = new XSSFWorkbook();
            else if (fileExt == ".xls")
                workbook = new HSSFWorkbook();
            else
                workbook = null;

            //创建sheet
            ISheet sheet = workbook.CreateSheet("ProductList");
            int X_Width = 2000;
            //表头
            IRow headrow = sheet.CreateRow(0);
            ICell headcell = headrow.CreateCell(0);
            headcell.SetCellValue("Position");
            sheet.SetColumnWidth(0, X_Width);
            
            headcell = headrow.CreateCell(1);
            headcell.SetCellValue("Order Code");
            sheet.SetColumnWidth(1, 2 * X_Width);

            headcell = headrow.CreateCell(2);
            headcell.SetCellValue("Long Code");
            sheet.SetColumnWidth(2, 5 * X_Width);

            headcell = headrow.CreateCell(3);
            headcell.SetCellValue("Number");
            sheet.SetColumnWidth(3, 1 * X_Width);

            headcell = headrow.CreateCell(4);
            headcell.SetCellValue("单价 Unit Price");
            sheet.SetColumnWidth(4, 2 * X_Width);

            headcell = headrow.CreateCell(5);
            headcell.SetCellValue("Description");
            sheet.SetColumnWidth(5, 12 * X_Width);


            for (int i = 0; i < Itemlength; i++)
            {
                ListViewItem Itemtmp = (ListViewItem)array[i];
                ListViewItem.ListViewSubItemCollection SubItem_ = Itemtmp.SubItems;

                IRow newRow = sheet.CreateRow(i + 1);

                int count = 0;
                foreach (ListViewItem.ListViewSubItem test in SubItem_)
                {
                    if (count == 4)
                    {
                        headcell = newRow.CreateCell(count);
                        headcell.SetCellValue("");

                        subitems_.Add(test);
                        headcell = newRow.CreateCell(count+1);
                        headcell.SetCellValue(test.Text);
                    }
                    else
                    {
                        subitems_.Add(test);
                        headcell = newRow.CreateCell(count);
                        headcell.SetCellValue(test.Text);
                        //dt.Columns.Add(test.Text);
                    }
                    
                    count++;
                   
                }


            }

            sheet.AutoSizeColumn(0);
            sheet.AutoSizeColumn(1);
            sheet.AutoSizeColumn(2);
            sheet.AutoSizeColumn(3);
            sheet.AutoSizeColumn(5);

            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }
            }

        }


        #endregion 控件选型结果文档的按钮


        #region 建立窗口，设置参数，语言变化


        private void SettingAplliedFromWindow(object sender, EventArgs e)
        {
            SP = sender as SettingProperty;

            updateWindowsProperty(SP);
            //this.Show();
        }


        private void btnSetting_Click(object sender, EventArgs e)
        {
            FormSettingWindow WindowSetting = new FormSettingWindow(SP); //传递参数到参数窗口
            WindowSetting.SettingApllied += new EventHandler(this.SettingAplliedFromWindow);
            WindowSetting.Show();
            //this.Hide();

        }


        private void updateWindowsProperty(SettingProperty newsettingproperty)
        {
            if (SP.Systemlanguage == "English")
            {
                // 选择表控制按钮
                this.btnAddML.Text = "Add";
                this.btnCLRML.Text = "Clear";
                this.btnDelete.Text = "Delete";
                this.btnExportML.Text = "Export";


                //选择表
                this.colHeaderPosition.Text = "Position";
                this.colHeaderOderCode.Text = "Order Code";
                this.colHeaderLongCode.Text = "Long Code";
                this.colHeaderNumber.Text = "Number";
                this.colHeaderDescription.Text = "Description";
                foreach (ListViewItem lvi in this.listViewMaterial.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[1].Text, PDB.ProductList);
                    lvi.SubItems[4].Text = tmpProduct.DescriptionEN;
                }

                //选项表
                this.tabPageCable.Text = "Cable";
                this.tabPageIndustrialCamera.Text = "Industrial camera";
                this.tabPageCockpit.Text = "Cockpit";
                this.tabPageLens.Text = "Lens";
                this.tabPageScanner.Text = "Scanner";
                this.tabPageSmartCamera.Text = "Smart camera";
                this.tabPageVisionSensor.Text = "Vision sensor";
                this.tabPageAccessory.Text = "Accessory";

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //扫码枪区域
                this.labelScanner_CodeType.Text = "Code Type:";
                this.labelScanner_Cable.Text = "Cable:";
                this.labelScanner_Communication.Text = "Communication:";
                this.colHeaderOrderCode_Scanner.Text = "Order Code";
                this.colHeaderLongCode_Scanner.Text = "Long Code";
                this.colHeaderDescription_Scanner.Text = "Description";
                foreach (ListViewItem lvi in this.listViewScanner_Scanner.Items)
                {
                    Scanner tmpScanner = Scanner.getScanner(lvi.SubItems[0].Text, PDB.ScannerList);
                    lvi.SubItems[2].Text = tmpScanner.DescriptionEN;
                }

                //扫码枪附件选型区域
                this.gBScanner_Accessory.Text = "Accessory Selector";
                this.colHeaderScanner_AS_ProductFamily.Text = "Product";
                this.colHeaderScanner_AS_OrderCode.Text = "Order Code";
                this.colHeaderScanner_AS_Description.Text = "Description";
                foreach (ListViewItem lvi in this.listViewScanner_AccessorySelector.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[2].Text = tmpProduct.DescriptionEN;
                }

                //扫码枪供货范围，需要购买
                this.gbScannerDeiverRange.Text = "Deliver Range";
                this.gbUSBNeedtoBuy.Text = "USB Connection need to buy";
                this.gbRS232NeedtoBuy.Text = "RS232 Connection need to buy";
                this.cBScannerDelvier_USBCable.Text = "USB Cable";
                this.cBScannerDelvier_RS232Cable.Text = "RS232 Cable";
                this.cBScannerDelvier_Bluetooth.Text = "Bluetooth Basement";
                this.cBScannerDelvier_Power.Text = "Power Supply";
                this.cBUSBNeedtoBuy_USBCable.Text = "USB Cable";
                this.cBUSBNeedtoBuy_RS232Cable.Text = "RS232 Cable";
                this.cBUSBNeedtoBuy_Bluetooth.Text = "Bluetooth Basement";
                this.cBUSBNeedtoBuy_Power.Text = "Power Supply";
                this.cBRS232NeedtoBuy_USBCable.Text = "USB Cable";
                this.cBRS232NeedtoBuy_RS232Cable.Text = "RS232 Cable";
                this.cBRS232NeedtoBuy_Bluetooth.Text = "Bluetooth Basement";
                this.cBRS232NeedtoBuy_Power.Text = "Power Supply";

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //视觉传感器选型表
                this.labelVisionSensor_Focus.Text = "Focus:";
                this.labelVisionSensor_Function.Text = "Function:";
                this.labelVisionSensor_Light.Text = "Light:";
                this.colHeaderVisionSensor_OrderCode.Text = "Order Code";
                this.colHeaderVisionSensor_LongCode.Text = "Long Code";
                this.colHeaderVisionSensor_Light.Text = "Light";
                this.colHeaderVisionSensor_Function.Text = "Function";
                this.colHeaderVisionSensor_Focus.Text = "Focus";
                this.colHeaderVisionSensor_Description.Text = "Description";
                foreach (ListViewItem lvi in this.listViewVisionSensor.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[5].Text = tmpProduct.DescriptionEN;
                }

                //视觉传感器镜头计算区域
                this.labelVisionSensorLens_Focus.Text = "Focus";
                this.labelVisionSensorLens_FOVHeight.Text = "FOV Height";
                this.labelVisionSensorLens_FOVWidth.Text = "FOV Width";
                this.labelVisionSensorlens_WD.Text = "Work Distance";
                this.labelLensCalculationInfo.Text = "Lens Calculator: \n";
                this.labelLensCalculationInfo.Text = this.labelLensCalculationInfo.Text + "All unit in mm. \n";
                this.labelLensCalculationInfo.Text = this.labelLensCalculationInfo.Text + "One of Focus, WD or FOV \n";
                this.labelLensCalculationInfo.Text = this.labelLensCalculationInfo.Text + "is to be calculated. \n";
                this.btnVisionSensorCalculation.Text = "Calculate";
                this.btnVisionSensorConnection.Text = "Connection Overview";
                this.btnVisionSensorFunctionDetail.Text = "Function Overview";

                //视觉传感器附件区域
                this.labelVisionSensorAccessory.Text = "Accessory:";
                this.colHeaderVisionSensor_AccessoryType.Text = "Type";
                this.colHeaderVisionSensor_AccessoryProduct.Text = "Product";
                this.colHeaderVisionSensor_AccessoryOrderCode.Text = "Order Code";
                this.colHeaderVisionSensor_AccessoryDescription.Text = "Description";
                gbVisionSensorAccessorySelector.Text = "Accessory Selector";
                foreach (ListViewItem lvi in this.listViewVisionSensorAccessory.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[3].Text = tmpProduct.DescriptionEN;
                }


                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //智能相机选型表
                this.labelSmartCameraFunction.Text = "Function:";
                this.labelSmartCameraColor.Text = "Color:";
                this.labelSmartCameraInterface.Text = "Interface:";
                this.colHeaderSmartCamera_OrderCode.Text = "Order Code";
                this.colHeaderSmartCamera_LongCode.Text = "Long Code";
                this.colHeaderSmartCamera_Function.Text = "Function";
                this.colHeaderSmartCamera_Color.Text = "Color";
                this.colHeaderSmartCamera_Interface.Text = "Interface";
                this.colHeaderSmartCamera_Description.Text = "Description";
                foreach (ListViewItem lvi in this.listViewSmartCamera.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[5].Text = tmpProduct.DescriptionEN;
                }


                //智能相机镜头计算区域
                this.labelSmartCameraLens_Focus.Text = "Focus";
                this.labelSmartCameraLens_FOVHeight.Text = "FOV Height";
                this.labelSmartCameraLens_FocusWidth.Text = "FOV Width";
                this.labelSmartCameraLens_WD.Text = "Work Distance";
                this.labelSmartCameraLensINFO.Text = "Lens Calculator: \n";
                this.labelSmartCameraLensINFO.Text = this.labelSmartCameraLensINFO.Text + "All unit in mm. \n";
                this.labelSmartCameraLensINFO.Text = this.labelSmartCameraLensINFO.Text + "One of Focus, WD or FOV \n";
                this.labelSmartCameraLensINFO.Text = this.labelSmartCameraLensINFO.Text + "is to be calculated. \n";
                this.btnSmartCameraLens.Text = "Calculate";
                this.btnSmartCameraConnection.Text = "Connection Overview";
                this.btnSmartCameraFunction.Text = "Function Overview";

                //智能相机附件区域
                this.labelSmartCameraAccessory.Text = "Accessory:";
                this.colHeaderSmartCamera_AccessoryType.Text = "Type";
                this.colHeaderSmartCamera_AccessoryProduct.Text = "Product";
                this.colHeaderSmartCamera_AccessoryOrderCode.Text = "Order Code";
                this.colHeaderSmartCamera_AccessoryDescription.Text = "Description";
                gbSmartCameraAccessory.Text = "Accessory Selector";
                foreach (ListViewItem lvi in this.listViewSmartCameraAccessory.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[3].Text = tmpProduct.DescriptionEN;
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //工业相机选型表
                this.labelCAColor.Text = "Color:";
                this.labelCAResolution.Text = "Resolution:";
                this.labelCAInterface.Text = "Interface:";
                this.colHeaderCA_OrderCode.Text = "Order Code";
                this.colHeaderCA_LongCode.Text = "Long Code";
                this.colHeaderCA_Resolution.Text = "Resolution";
                this.colHeaderCA_ResolutionHeight.Text = "Height";
                this.colHeaderCA_ResolutionWidth.Text = "Width";
                this.colHeaderCA_Color.Text = "Color";
                this.colHeaderCA_Interface.Text = "Interface";
                this.colHeaderCA_Description.Text = "Description";
                foreach (ListViewItem lvi in this.listViewCA.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[7].Text = tmpProduct.DescriptionCN;
                }

                //工业相机镜头计算区域
                this.labelCALens_Focus.Text = "Focus";
                this.labelCALens_FOVHeight.Text = "FOV Height";
                this.labelCALens_FOVWidth.Text = "FOV Width";
                this.labelCALens_WD.Text = "Work Distance";
                this.labelCALens_Resolution.Text = "Resolution";
                this.labelCALensINFO.Text = "Lens Calculator: \n \n";
                this.labelCALensINFO.Text = this.labelCALensINFO.Text + "All unit in mm. \n";
                this.labelCALensINFO.Text = this.labelCALensINFO.Text + "One of Focus, WD or FOV \n";
                this.labelCALensINFO.Text = this.labelCALensINFO.Text + "is to be calculated. \n";
                this.labelCALens_SensorHeight.Text = "Sensor Height";
                this.labelCALens_SensorWidth.Text = "Sensor Width";
                this.btnCA_LensCalculation.Text = "Calculation";
                this.btnSmartCameraConnection.Text = "Connection Overview";


                //工业相机附件区域
                this.labelCAAccessory.Text = "Accessory:";
                this.colHeaderCAAccessory_Type.Text = "Function";
                this.colHeaderCAAccessoryClass.Text = "Class";
                this.colHeaderCAAccessory_Product.Text = "Product";
                this.colHeaderCAAccessory_OrderCode.Text = "Order Code";
                this.colHeaderCAAccessory_Description.Text = "Description";
                gbCAAccessorySelector.Text = "Accessory Selector";
                foreach (ListViewItem lvi in this.listViewCA_Accessory.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[4].Text = tmpProduct.DescriptionEN;
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //镜头选型表
                this.labelLens_Focus.Text = "Focus:";
                this.labelLens_Design.Text = "Design:";
                this.labelLens_ImageSize.Text = "Image Size:";
                this.colHeaderLens_Order.Text = "Order Code";
                this.colHeaderLens_LongCode.Text = "Long Code";
                this.colHeaderLens_Focus.Text = "Focus";
                this.colHeaderLens_ImageSize.Text = "Image Size";
                this.colHeaderLens_Design.Text = "Design";
                this.colHeaderLens_Description.Text = "Description";

                foreach (ListViewItem lvi in this.listViewLens.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[5].Text = tmpProduct.DescriptionEN;
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //线缆选型表
                this.labelCable_Product.Text = "Product:";
                this.labelCable_Interface.Text = "Interface:";
                this.labelCable_Length.Text = "Length:";
                this.colHeaderCable_OrderCode.Text = "Order Code";
                this.colHeaderCA_LongCode.Text = "Long Code";
                this.colHeaderCable_Interface.Text = "Interface";
                this.colHeaderCable_Length.Text = "Length";
                this.colHeaderCable_Description.Text = "Description";

                foreach (ListViewItem lvi in this.listViewCable.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[4].Text = tmpProduct.DescriptionEN;
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //Cockpit选型表
                this.labelCockpit.Text = "Cockpit Software:";
                this.colHeaderCockpit_OrderCode.Text = "Order Code";
                this.colHeaderCockpit_LongCode.Text = "Long Code";
                this.colHeaderCockpit_Function.Text = "Function";
                this.colHeaderCockpit_Description.Text = "Description";
                this.btnCockpitOverview.Text = "Function Overview";
                foreach (ListViewItem lvi in this.listViewCockpit.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[3].Text = tmpProduct.DescriptionEN;
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //Accessory 选型表
                this.labelAccessory_Product.Text = "Product:";
                this.colHeaderAccessory_OrderCode.Text = "Order Code";
                this.colHeaderAccessory_LongCode.Text = "Long Code";
                this.colHeaderAccessory_Product.Text = "Product";
                this.colHeaderAccessory_Description.Text = "Description";

                foreach (ListViewItem lvi in this.listViewAccessory.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[3].Text = tmpProduct.DescriptionEN;
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //Quick start page
                this.buttonQSCA_Cockpit.Text = "Cockpit";
                this.buttonQSCA_Controller.Text = "Controller";
                this.buttonQSCA_GIGE.Text = "GIGE Camera";
                this.buttonQSCA_USB.Text = "USB3 Camera";
                this.buttonQSVisionSensor_Sensor.Text = "Vision Sensor";
                this.buttonQSVisionSensor_Monitor.Text = "Monitor";
                this.buttonQSSmartCamera.Text = "Smart Camera";
                this.buttonQSSmartCamera_Lite.Text = "Smart Camera \nLite";
                this.buttonQSScanner_GreyCableUSB.Text = "Grey\nCabled\nUSB cable";
                this.buttonQSScanner_GreyCable232.Text = "Grey\nCabled\nRS232 cable";
                this.buttonQSScanner_GreyBTUSB.Text = "Grey\nBluetooth\nUSB线缆";
                this.buttonQSScanner_GreyBT232.Text = "Grey\nBluetooth\nRS232线缆";
                this.buttonQSScanner_YellowCableUSBPapier.Text = "Yellow\nCabled\nUSB cable";
                this.buttonQSScanner_YellowCable232Papier.Text = "Yellow\nCabled\nRS232 cable";
                this.buttonQSScanner_YellowBTUSBPapier.Text = "Yellow\nBluetooth\nUSB cable";
                this.buttonQSScanner_YellowBT232Papier.Text = "Yellow\nBluetooth\nRS232 cable";
                this.buttonQSScanner_YellowCableUSBDPM.Text = "Yellow\nCabled\nUSB cable";
                this.buttonQSScanner_YellowCable232DPM.Text = "Yellow\nCabled\nRS232 cable";
                this.buttonQSScanner_YellowBTUSBDPM.Text = "Yellow\nBluetooth\nUSB cable";
                this.buttonQSScanner_YellowBT232DPM.Text = "Yellow\nBluetooth\nRS232 cable";

                this.gbQS_Scanner.Text = "Quick Selection Scanner";
                this.gbQS_VisionSensor.Text = "Quick Selection Vision Sensor";
                this.gbQS_SmartCamera.Text = "Quick Selection Smart Camera";
                this.gbQS_IndustrialCamera.Text = "Quick Selection Industrial Camera";


            }
            else if (SP.Systemlanguage == "中文")
            {
                // 选择表控制按钮
                this.btnAddML.Text = "插入";
                this.btnCLRML.Text = "清空";
                this.btnDelete.Text = "删除";
                this.btnExportML.Text = "导出";

                //选择表
                this.colHeaderPosition.Text = "项";
                this.colHeaderOderCode.Text = "订货号";
                this.colHeaderLongCode.Text = "长号";
                this.colHeaderNumber.Text = "数量";
                this.colHeaderDescription.Text = "描述";

                foreach (ListViewItem lvi in this.listViewMaterial.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[1].Text, PDB.ProductList);
                    lvi.SubItems[4].Text = tmpProduct.DescriptionCN;
                }

                //选项表
                this.tabPageCable.Text = "线缆";
                this.tabPageIndustrialCamera.Text = "工业相机";
                this.tabPageCockpit.Text = "Cockpit";
                this.tabPageLens.Text = "镜头";
                this.tabPageScanner.Text = "扫码枪";
                this.tabPageSmartCamera.Text = "智能相机";
                this.tabPageVisionSensor.Text = "视觉传感器";
                this.tabPageAccessory.Text = "附件";

                //////////////////////////////////////////////////////////////////////////////////////////
                //扫码枪区域
                this.labelScanner_CodeType.Text = "码类型:";
                this.labelScanner_Cable.Text = "线缆";
                this.labelScanner_Communication.Text = "通讯";
                this.colHeaderOrderCode_Scanner.Text = "订货号";
                this.colHeaderLongCode_Scanner.Text = "长号";
                this.colHeaderDescription_Scanner.Text = "描述";
                foreach (ListViewItem lvi in this.listViewScanner_Scanner.Items)
                {
                    Scanner tmpScanner = Scanner.getScanner(lvi.SubItems[0].Text, PDB.ScannerList);
                    lvi.SubItems[2].Text = tmpScanner.DescriptionCN;
                }

                //扫码枪附件选型区域
                this.gBScanner_Accessory.Text = "附件选择区";
                this.colHeaderScanner_AS_ProductFamily.Text = "类型";
                this.colHeaderScanner_AS_OrderCode.Text = "订货号";
                this.colHeaderScanner_AS_Description.Text = "描述";
                foreach (ListViewItem lvi in this.listViewScanner_AccessorySelector.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[2].Text = tmpProduct.DescriptionCN;
                }

                //扫码枪供货范围，需要购买
                this.gbScannerDeiverRange.Text = "供货范围";
                this.gbUSBNeedtoBuy.Text = "USB通讯需要购买";
                this.gbRS232NeedtoBuy.Text = "RS232通讯需要购买";
                this.cBScannerDelvier_USBCable.Text = "USB线缆";
                this.cBScannerDelvier_RS232Cable.Text = "RS232线缆";
                this.cBScannerDelvier_Bluetooth.Text = "蓝牙基站";
                this.cBScannerDelvier_Power.Text = "电源适配器";
                this.cBUSBNeedtoBuy_USBCable.Text = "USB线缆";
                this.cBUSBNeedtoBuy_RS232Cable.Text = "RS232线缆";
                this.cBUSBNeedtoBuy_Bluetooth.Text = "蓝牙基站";
                this.cBUSBNeedtoBuy_Power.Text = "电源适配器";
                this.cBRS232NeedtoBuy_USBCable.Text = "USB线缆";
                this.cBRS232NeedtoBuy_RS232Cable.Text = "RS232线缆";
                this.cBRS232NeedtoBuy_Bluetooth.Text = "蓝牙基站";
                this.cBRS232NeedtoBuy_Power.Text = "电源适配器";

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //视觉传感器选型表
                this.labelVisionSensor_Focus.Text = "焦距:";
                this.labelVisionSensor_Function.Text = "功能:";
                this.labelVisionSensor_Light.Text = "光源:";
                this.colHeaderVisionSensor_OrderCode.Text = "订货号";
                this.colHeaderVisionSensor_LongCode.Text = "长号";
                this.colHeaderVisionSensor_Light.Text = "光源";
                this.colHeaderVisionSensor_Function.Text = "功能";
                this.colHeaderVisionSensor_Focus.Text = "焦距";
                this.colHeaderVisionSensor_Description.Text = "描述";
                foreach (ListViewItem lvi in this.listViewVisionSensor.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[5].Text = tmpProduct.DescriptionCN;
                }


                //视觉传感器镜头计算区域
                this.labelVisionSensorLens_Focus.Text = "焦距";
                this.labelVisionSensorLens_FOVHeight.Text = "视野高";
                this.labelVisionSensorLens_FOVWidth.Text = "视野宽";
                this.labelVisionSensorlens_WD.Text = "工作距离";
                this.labelLensCalculationInfo.Text = "镜头焦距计算: \n \n";
                this.labelLensCalculationInfo.Text = this.labelLensCalculationInfo.Text + "所有单位为mm。 \n";
                this.labelLensCalculationInfo.Text = this.labelLensCalculationInfo.Text + "需要选择焦距，视野 \n";
                this.labelLensCalculationInfo.Text = this.labelLensCalculationInfo.Text + "工作距离之一。 \n";
                this.btnVisionSensorCalculation.Text = "计算";
                this.btnVisionSensorConnection.Text = "连接概览";
                this.btnVisionSensorFunctionDetail.Text = "功能概览";

                //视觉传感器附件区域
                this.labelVisionSensorAccessory.Text = "附件:";
                this.colHeaderVisionSensor_AccessoryType.Text = "功能";
                this.colHeaderVisionSensor_AccessoryProduct.Text = "产品";
                this.colHeaderVisionSensor_AccessoryOrderCode.Text = "订货号";
                this.colHeaderVisionSensor_AccessoryDescription.Text = "描述";
                gbVisionSensorAccessorySelector.Text = "附件选择区域";
                foreach (ListViewItem lvi in this.listViewVisionSensorAccessory.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[3].Text = tmpProduct.DescriptionCN;
                }


                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //智能相机选型表
                this.labelSmartCameraFunction.Text = "功能:";
                this.labelSmartCameraColor.Text = "色彩:";
                this.labelSmartCameraInterface.Text = "接口:";
                this.colHeaderSmartCamera_OrderCode.Text = "订货号";
                this.colHeaderSmartCamera_LongCode.Text = "长号";
                this.colHeaderSmartCamera_Function.Text = "功能";
                this.colHeaderSmartCamera_Color.Text = "色彩";
                this.colHeaderSmartCamera_Interface.Text = "接口";
                this.colHeaderSmartCamera_Description.Text = "描述";
                foreach (ListViewItem lvi in this.listViewSmartCamera.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[5].Text = tmpProduct.DescriptionCN;
                }

                //智能相机镜头计算区域
                this.labelSmartCameraLens_Focus.Text = "焦距";
                this.labelSmartCameraLens_FOVHeight.Text = "视野高";
                this.labelSmartCameraLens_FocusWidth.Text = "视野宽";
                this.labelSmartCameraLens_WD.Text = "工作距离";
                this.labelSmartCameraLensINFO.Text = "镜头焦距计算: \n \n";
                this.labelSmartCameraLensINFO.Text = this.labelSmartCameraLensINFO.Text + "所有单位为mm。 \n";
                this.labelSmartCameraLensINFO.Text = this.labelSmartCameraLensINFO.Text + "需要选择焦距，视野 \n";
                this.labelSmartCameraLensINFO.Text = this.labelSmartCameraLensINFO.Text + "工作距离之一。 \n";
                this.btnSmartCameraLens.Text = "计算";
                this.btnSmartCameraConnection.Text = "连接概览";
                this.btnSmartCameraFunction.Text = "功能概览";

                //智能相机附件区域
                this.labelSmartCameraAccessory.Text = "附件:";
                this.colHeaderSmartCamera_AccessoryType.Text = "功能";
                this.colHeaderSmartCamera_AccessoryProduct.Text = "产品";
                this.colHeaderSmartCamera_AccessoryOrderCode.Text = "订货号";
                this.colHeaderSmartCamera_AccessoryDescription.Text = "描述";
                gbSmartCameraAccessory.Text = "附件选择区域";
                foreach (ListViewItem lvi in this.listViewSmartCameraAccessory.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[3].Text = tmpProduct.DescriptionCN;
                }


                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //工业相机选型表
                this.labelCAColor.Text = "颜色:";
                this.labelCAResolution.Text = "分辨率:";
                this.labelCAInterface.Text = "接口:";
                this.colHeaderCA_OrderCode.Text = "订货号";
                this.colHeaderCA_LongCode.Text = "长号";
                this.colHeaderCA_Resolution.Text = "分辨率";
                this.colHeaderCA_ResolutionHeight.Text = "分辨率高";
                this.colHeaderCA_ResolutionWidth.Text = "分辨率宽";
                this.colHeaderCA_Color.Text = "颜色";
                this.colHeaderCA_Interface.Text = "接口";
                this.colHeaderCA_Description.Text = "描述";
                foreach (ListViewItem lvi in this.listViewCA.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[7].Text = tmpProduct.DescriptionCN;
                }

                //工业相机镜头计算区域
                this.labelCALens_Focus.Text = "焦距";
                this.labelCALens_FOVHeight.Text = "视野高";
                this.labelCALens_FOVWidth.Text = "视野宽";
                this.labelCALens_WD.Text = "工作距离";
                this.labelCALens_Resolution.Text = "分辨率";
                this.labelCALensINFO.Text = "镜头焦距计算: \n \n";
                this.labelCALensINFO.Text = this.labelCALensINFO.Text + "所有单位为mm。 \n";
                this.labelCALensINFO.Text = this.labelCALensINFO.Text + "需要选择焦距，视野 \n";
                this.labelCALensINFO.Text = this.labelCALensINFO.Text + "工作距离之一。 \n";
                this.labelCALens_SensorHeight.Text = "芯片高";
                this.labelCALens_SensorWidth.Text = "芯片宽";
                this.btnCA_LensCalculation.Text = "计算";
                this.btnSmartCameraConnection.Text = "连接概览";


                //工业相机附件区域
                this.labelCAAccessory.Text = "附件:";
                this.colHeaderCAAccessory_Type.Text = "功能";
                this.colHeaderCAAccessoryClass.Text = "参数";
                this.colHeaderCAAccessory_Product.Text = "类别";
                this.colHeaderCAAccessory_OrderCode.Text = "订货号";
                this.colHeaderCAAccessory_Description.Text = "描述";
                gbCAAccessorySelector.Text = "附件选择区域";
                foreach (ListViewItem lvi in this.listViewCA_Accessory.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[4].Text = tmpProduct.DescriptionCN;
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //镜头选型表
                this.labelLens_Focus.Text = "焦距:";
                this.labelLens_Design.Text = "结构:";
                this.labelLens_ImageSize.Text = "成像器大小:";
                this.colHeaderLens_Order.Text = "订货号";
                this.colHeaderLens_LongCode.Text = "长号";
                this.colHeaderLens_Focus.Text = "焦距";
                this.colHeaderLens_ImageSize.Text = "成像器大小";
                this.colHeaderLens_Design.Text = "结构";
                this.colHeaderLens_Description.Text = "描述";

                foreach (ListViewItem lvi in this.listViewLens.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[5].Text = tmpProduct.DescriptionCN;
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //线缆选型表
                this.labelCable_Product.Text = "用于产品:";
                this.labelCable_Interface.Text = "接口:";
                this.labelCable_Length.Text = "长度:";
                this.colHeaderCable_OrderCode.Text = "订货号";
                this.colHeaderCA_LongCode.Text = "长号";
                this.colHeaderCable_Interface.Text = "接口";
                this.colHeaderCable_Length.Text = "长度";
                this.colHeaderCable_Description.Text = "描述";

                foreach (ListViewItem lvi in this.listViewCable.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[4].Text = tmpProduct.DescriptionCN;
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //Cockpit选型表
                this.labelCockpit.Text = "Cockpit 软件:";
                this.colHeaderCockpit_OrderCode.Text = "订货号";
                this.colHeaderCockpit_LongCode.Text = "长号";
                this.colHeaderCockpit_Function.Text = "功能";
                this.colHeaderCockpit_Description.Text = "描述";
                this.btnCockpitOverview.Text = "功能概率";
                foreach (ListViewItem lvi in this.listViewCockpit.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[3].Text = tmpProduct.DescriptionCN;
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //Accessory 选型表
                this.labelAccessory_Product.Text = "用于产品:";
                this.colHeaderAccessory_OrderCode.Text = "订货号";
                this.colHeaderAccessory_LongCode.Text = "长号";
                this.colHeaderAccessory_Product.Text = "功能";
                this.colHeaderAccessory_Description.Text = "描述";

                foreach (ListViewItem lvi in this.listViewAccessory.Items)
                {
                    product tmpProduct = product.getProduct(lvi.SubItems[0].Text, PDB.ProductList);
                    lvi.SubItems[3].Text = tmpProduct.DescriptionCN;
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //Quick start page
                this.buttonQSCA_Cockpit.Text = "Cockpit";
                this.buttonQSCA_Controller.Text = "控制器";
                this.buttonQSCA_GIGE.Text = "GIGE 相机";
                this.buttonQSCA_USB.Text = "USB3 相机";
                this.buttonQSVisionSensor_Sensor.Text = "视觉传感器";
                this.buttonQSVisionSensor_Monitor.Text = "触摸屏";
                this.buttonQSSmartCamera.Text = "智能相机";
                this.buttonQSSmartCamera_Lite.Text = "智能相机 \n精简版";
                this.buttonQSScanner_GreyCableUSB.Text = "灰色\n有线款\nUSB线缆";
                this.buttonQSScanner_GreyCable232.Text = "灰色\n有线款\nRS232线缆";
                this.buttonQSScanner_GreyBTUSB.Text = "灰色\n蓝牙款\nUSB线缆";
                this.buttonQSScanner_GreyBT232.Text = "灰色\n蓝牙款\nRS232线缆";
                this.buttonQSScanner_YellowCableUSBPapier.Text = "黄色\n有线款\nUSB线缆";
                this.buttonQSScanner_YellowCable232Papier.Text = "黄色\n有线款\nRS232线缆";
                this.buttonQSScanner_YellowBTUSBPapier.Text = "黄色\n蓝牙款\nUSB线缆";
                this.buttonQSScanner_YellowBT232Papier.Text = "黄色\n蓝牙款\nRS232线缆";
                this.buttonQSScanner_YellowCableUSBDPM.Text = "黄色\n有线款\nUSB线缆";
                this.buttonQSScanner_YellowCable232DPM.Text = "黄色\n有线款\nRS232线缆";
                this.buttonQSScanner_YellowBTUSBDPM.Text = "黄色\n蓝牙款\nUSB线缆";
                this.buttonQSScanner_YellowBT232DPM.Text = "黄色\n蓝牙款\nRS232线缆";

                this.gbQS_Scanner.Text = "扫码枪快速选型";
                this.gbQS_VisionSensor.Text = "视觉传感器快速选型";
                this.gbQS_SmartCamera.Text = "智能相机快速选型";
                this.gbQS_IndustrialCamera.Text = "工业相机快速选型";

            }
        }

        #endregion


        #region Tab Scanner 控件

        private void LoadScanner_Scanner()
        {
            this.listViewScanner_Scanner.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            this.listViewScanner_Scanner.Items.Clear();

            this.colHeaderDescription_Scanner.Width = this.listViewScanner_Scanner.Size.Width * 100 / 100;
            int PositionIndex = this.listViewScanner_Scanner.Items.Count;


            foreach (Scanner scanner_ in listScanner_local)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = scanner_.OrderCode;
                lvi.SubItems.Add(scanner_.LongCode);

                if (SP.Systemlanguage == "English")
                {
                    lvi.SubItems.Add(scanner_.DescriptionEN);
                }
                else if (SP.Systemlanguage == "中文")
                {
                    lvi.SubItems.Add(scanner_.DescriptionCN);
                }

                this.listViewScanner_Scanner.Items.Add(lvi);

            }

            this.listViewScanner_Scanner.EndUpdate();  //结束数据处理，UI界面一次性绘制。
            bScannerInit = true;
        }
        private void listViewScanner_Scanner_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewScanner_Scanner.SelectedItems.Count > 0)
                this.listViewScanner_AccessorySelector.SelectedItems.Clear();

            if (this.listViewScanner_Scanner.SelectedItems.Count == 1)
            {
                Image img = null;
                Scanner scntmp = Scanner.getScanner(listViewScanner_Scanner.SelectedItems[0].Text, PDB.ScannerList);

                switch (scntmp.ImageIndex)
                {
                    case 1:
                        img = Properties.Resources.Scanner1;
                        break;
                    case 2:
                        img = Properties.Resources.Scanner2;
                        break;
                    case 3:
                        img = Properties.Resources.Scanner3;
                        break;
                    case 4:
                        img = Properties.Resources.Scanner4;
                        break;
                    default:
                        img = null;
                        break;

                }
                if (img != null)
                {
                    Bitmap bmp = new Bitmap(img.Width, img.Height);
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
                    pictureBoxScanner_Scanner.Image = bmp;
                }

                if (scntmp.OrderCode == "BVS001W")
                {

                    this.cBScannerDelvier_USBCable.Checked = true;
                    this.cBScannerDelvier_RS232Cable.Checked = false;
                    this.cBScannerDelvier_Bluetooth.Checked = false;

                    this.cBUSBNeedtoBuy_USBCable.Checked = false;
                    this.cBUSBNeedtoBuy_RS232Cable.Checked = false;
                    this.cBUSBNeedtoBuy_Bluetooth.Checked = false;
                    this.cBUSBNeedtoBuy_Power.Checked = false;

                    this.cBRS232NeedtoBuy_USBCable.Checked = false;
                    this.cBRS232NeedtoBuy_RS232Cable.Checked = true;
                    this.cBRS232NeedtoBuy_Bluetooth.Checked = false;
                    this.cBRS232NeedtoBuy_Power.Checked = true;

                    this.cBRS232NeedtoBuy_USBCable.Visible = true;
                    this.cBRS232NeedtoBuy_RS232Cable.Visible = true;
                    this.cBRS232NeedtoBuy_Bluetooth.Visible = true;
                    this.cBRS232NeedtoBuy_Power.Visible = true;

                    this.cBUSBNeedtoBuy_USBCable.Visible = true;
                    this.cBUSBNeedtoBuy_RS232Cable.Visible = true;
                    this.cBUSBNeedtoBuy_Bluetooth.Visible = true;
                    this.cBUSBNeedtoBuy_Power.Visible = true;

                }
                else if (scntmp.OrderCode == "BVS0020")
                {
                    this.cBScannerDelvier_USBCable.Checked = true;
                    this.cBScannerDelvier_RS232Cable.Checked = false;
                    this.cBScannerDelvier_Bluetooth.Checked = true;

                    this.cBUSBNeedtoBuy_USBCable.Checked = false;
                    this.cBUSBNeedtoBuy_RS232Cable.Checked = false;
                    this.cBUSBNeedtoBuy_Bluetooth.Checked = false;
                    this.cBUSBNeedtoBuy_Power.Checked = true;

                    this.cBRS232NeedtoBuy_USBCable.Visible = false;
                    this.cBRS232NeedtoBuy_RS232Cable.Visible = false;
                    this.cBRS232NeedtoBuy_Bluetooth.Visible = false;
                    this.cBRS232NeedtoBuy_Power.Visible = false;

                    this.cBUSBNeedtoBuy_USBCable.Visible = true;
                    this.cBUSBNeedtoBuy_RS232Cable.Visible = true;
                    this.cBUSBNeedtoBuy_Bluetooth.Visible = true;
                    this.cBUSBNeedtoBuy_Power.Visible = true;
                }
                else if (scntmp.OrderCode == "BVS0021")
                {
                    this.cBScannerDelvier_USBCable.Checked = false;
                    this.cBScannerDelvier_RS232Cable.Checked = true;
                    this.cBScannerDelvier_Bluetooth.Checked = true;

                    this.cBRS232NeedtoBuy_USBCable.Checked = false;
                    this.cBRS232NeedtoBuy_RS232Cable.Checked = false;
                    this.cBRS232NeedtoBuy_Bluetooth.Checked = false;
                    this.cBRS232NeedtoBuy_Power.Checked = true;

                    this.cBRS232NeedtoBuy_USBCable.Visible = true;
                    this.cBRS232NeedtoBuy_RS232Cable.Visible = true;
                    this.cBRS232NeedtoBuy_Bluetooth.Visible = true;
                    this.cBRS232NeedtoBuy_Power.Visible = true;

                    this.cBUSBNeedtoBuy_USBCable.Visible = false;
                    this.cBUSBNeedtoBuy_RS232Cable.Visible = false;
                    this.cBUSBNeedtoBuy_Bluetooth.Visible = false;
                    this.cBUSBNeedtoBuy_Power.Visible = false;
                }
                else if (scntmp.OrderCode == "BVS001U" | scntmp.OrderCode == "BVS001T")
                {
                    this.cBScannerDelvier_USBCable.Checked = false;
                    this.cBScannerDelvier_RS232Cable.Checked = false;
                    this.cBScannerDelvier_Bluetooth.Checked = false;

                    this.cBRS232NeedtoBuy_USBCable.Checked = false;
                    this.cBRS232NeedtoBuy_RS232Cable.Checked = true;
                    this.cBRS232NeedtoBuy_Bluetooth.Checked = false;
                    this.cBRS232NeedtoBuy_Power.Checked = true;

                    this.cBUSBNeedtoBuy_USBCable.Checked = true;
                    this.cBUSBNeedtoBuy_RS232Cable.Checked = false;
                    this.cBUSBNeedtoBuy_Bluetooth.Checked = false;
                    this.cBUSBNeedtoBuy_Power.Checked = false;

                    this.cBRS232NeedtoBuy_USBCable.Visible = true;
                    this.cBRS232NeedtoBuy_RS232Cable.Visible = true;
                    this.cBRS232NeedtoBuy_Bluetooth.Visible = true;
                    this.cBRS232NeedtoBuy_Power.Visible = true;

                    this.cBUSBNeedtoBuy_USBCable.Visible = true;
                    this.cBUSBNeedtoBuy_RS232Cable.Visible = true;
                    this.cBUSBNeedtoBuy_Bluetooth.Visible = true;
                    this.cBUSBNeedtoBuy_Power.Visible = true;

                }
                else if (scntmp.OrderCode == "BVS001Y" | scntmp.OrderCode == "BVS001Z")
                {
                    this.cBScannerDelvier_USBCable.Checked = false;
                    this.cBScannerDelvier_RS232Cable.Checked = false;
                    this.cBScannerDelvier_Bluetooth.Checked = false;

                    this.cBRS232NeedtoBuy_USBCable.Checked = false;
                    this.cBRS232NeedtoBuy_RS232Cable.Checked = true;
                    this.cBRS232NeedtoBuy_Bluetooth.Checked = true;
                    this.cBRS232NeedtoBuy_Power.Checked = true;

                    this.cBUSBNeedtoBuy_USBCable.Checked = true;
                    this.cBUSBNeedtoBuy_RS232Cable.Checked = false;
                    this.cBUSBNeedtoBuy_Bluetooth.Checked = true;
                    this.cBUSBNeedtoBuy_Power.Checked = true;

                    this.cBRS232NeedtoBuy_USBCable.Visible = true;
                    this.cBRS232NeedtoBuy_RS232Cable.Visible = true;
                    this.cBRS232NeedtoBuy_Bluetooth.Visible = true;
                    this.cBRS232NeedtoBuy_Power.Visible = true;

                    this.cBUSBNeedtoBuy_USBCable.Visible = true;
                    this.cBUSBNeedtoBuy_RS232Cable.Visible = true;
                    this.cBUSBNeedtoBuy_Bluetooth.Visible = true;
                    this.cBUSBNeedtoBuy_Power.Visible = true;

                }

            }
        }

        private void cBScanner_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Scanner_Type = cBScanner_Type.Text;
            string Scanner_Communication = cB_Communication.Text;
            string Scanner_Cable = cBScanner_Cable.Text;

            // Select Scanner type
            if (Scanner_Type == "All")
            {
                listScanner_local = (List<Scanner>)PDB.CloneLstScanner(PDB.ScannerList);//做深拷贝
            }
            else
            {
                listScanner_local.Clear();
                foreach (Scanner scanner_ in PDB.ScannerList)
                {
                    if (scanner_.Function.ToString() == Scanner_Type)
                    {
                        listScanner_local.Add(scanner_);
                    }
                }
            }
            // Select Scanner communication
            if (Scanner_Communication == "All")
            {
                PDB.tmpScanList = (List<Scanner>)PDB.CloneLstScanner(listScanner_local);
            }
            else
            {
                PDB.tmpScanList.Clear();
                foreach (Scanner scanner_ in listScanner_local)
                {
                    if (scanner_.Communication.ToString() == Scanner_Communication)
                    {
                        PDB.tmpScanList.Add(scanner_);
                    }
                }
            }

            // Select Scanner cable
            if (Scanner_Cable == "All")
            {
                listScanner_local = (List<Scanner>)PDB.CloneLstScanner(PDB.tmpScanList);//做深拷贝
            }
            else
            {
                listScanner_local.Clear();
                foreach (Scanner scanner_ in PDB.tmpScanList)
                {
                    if (scanner_.CableConnection.ToString() == Scanner_Cable || scanner_.CableConnection.ToString() == "All")
                    {
                        listScanner_local.Add(scanner_);
                    }
                }
            }

            // listScanner_local = (List<Scanner>)PDB.CloneLstScanner(PDB.tmpScanList);



            LoadScanner_Scanner();

        }

        private void getScannerAccessories(ListView.SelectedListViewItemCollection foundItem)
        {
            foreach (ListViewItem lvItem in foundItem)   //添加选中数据
            {

                string productname = lvItem.Text;
                Scanner tmpScanner = Scanner.getScanner(productname, PDB.ScannerList);


                /// <summary>
                /// Cable 选型
                /// </summary>
                if (tmpScanner != null)
                {
                    this.listViewScanner_AccessorySelector.Items.Clear();
                    if (tmpScanner.NeedUSBCable)
                    {
                        foreach (Cable cbl in PDB.CableList)
                        {
                            if (cbl.CableProductFamily1.ToString() == tmpScanner.ScannerFamily.ToString() & cbl.CableInterface == Cable.enumCableInterface.USB2_0)
                            {
                                ListViewItem lvi = new ListViewItem();
                                lvi.Text = cbl.OrderCode;
                                lvi.SubItems.Add(cbl.ProductFamily.ToString());
                                lvi.SubItems.Add(cbl.DescriptionEN);
                                this.listViewScanner_AccessorySelector.Items.Add(lvi);
                            }

                        }
                    }
                    if (tmpScanner.NeedRS232Cable)
                    {
                        foreach (Cable cbl in PDB.CableList)
                        {
                            if (cbl.CableProductFamily1.ToString() == tmpScanner.ScannerFamily.ToString() & cbl.CableInterface == Cable.enumCableInterface.RS232)
                            {
                                ListViewItem lvi = new ListViewItem();
                                lvi.Text = cbl.OrderCode;
                                lvi.SubItems.Add(cbl.ProductFamily.ToString());
                                lvi.SubItems.Add(cbl.DescriptionEN);
                                this.listViewScanner_AccessorySelector.Items.Add(lvi);
                            }
                        }

                        foreach (Accessory Acsy in PDB.AccessoryList)
                        {
                            if (Acsy.Accessoryproduct == Accessory.enumAccessoryproduct.PowerRS232 & tmpScanner.Communication == "Cable")
                            {
                                ListViewItem lvi = new ListViewItem();
                                lvi.Text = Acsy.OrderCode;
                                lvi.SubItems.Add(Acsy.ProductFamily.ToString());
                                lvi.SubItems.Add(Acsy.DescriptionEN);
                                this.listViewScanner_AccessorySelector.Items.Add(lvi);
                            }

                        }
                    }

                    if (tmpScanner.NeedBasement)
                    {
                        foreach (Accessory Acsy in PDB.AccessoryList)
                        {
                            if (tmpScanner.ScannerFamily == Scanner.enumScannerFamily.ScannerHS_P & Acsy.Accessoryproduct == Accessory.enumAccessoryproduct.BluetoothBasement)
                            {
                                ListViewItem lvi = new ListViewItem();
                                lvi.Text = Acsy.OrderCode;
                                lvi.SubItems.Add(Acsy.ProductFamily.ToString());
                                lvi.SubItems.Add(Acsy.DescriptionEN);
                                this.listViewScanner_AccessorySelector.Items.Add(lvi);
                            }

                        }
                    }




                }

            }
        }

        /// <summary>
        /// 选中附件选择区域时
        /// 1.其他区域选中的焦点去除
        /// 2.显示图片
        /// </summary>
        private void listViewScanner_AccessorySelector_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //防止循环两次清除
            if (listViewScanner_AccessorySelector.SelectedItems.Count > 0)
                this.listViewScanner_Scanner.SelectedItems.Clear();

            if (this.listViewScanner_AccessorySelector.SelectedItems.Count == 1)
            {

                product pdtmp = product.getProduct(listViewScanner_AccessorySelector.SelectedItems[0].Text, PDB.ProductList);

                if (pdtmp.ProductFamily == product.enumProductFamily.Cable)
                { pictureBoxScanner_Accessory.Image = PDB.loadCableImage(((Cable)pdtmp)); }

                if (pdtmp.ProductFamily == product.enumProductFamily.Accessory)
                    pictureBoxScanner_Accessory.Image = PDB.loadAccessoryImage(((Accessory)pdtmp));

            }

        }

        #endregion


        #region TabVisionSensor 控件

        // 
        private void cBVisionSensor_Function_SelectedIndexChanged(object sender, EventArgs e)
        {
            string VisionSensorFunction = cBVisionSensor_Function.Text;
            string VisionSensorFocus = cBVisionSensor_Focus.Text;
            string VisionSensorLight = cBVisionSensor_Light.Text;

            // Select Scanner type
            if (VisionSensorFunction == "All")
            {
                listVisionSensor_local = (List<VisionSensor>)PDB.CloneLstVisionSensor(PDB.VisionSensorList);//做深拷贝
            }
            else
            {
                listVisionSensor_local.Clear();
                foreach (VisionSensor visionsensor_ in PDB.VisionSensorList)
                {
                    if (visionsensor_.VisionSensorModel.ToString() == VisionSensorFunction)
                    {
                        listVisionSensor_local.Add(visionsensor_);
                    }
                }
            }
            // Select Scanner communication
            if (VisionSensorFocus == "All")
            {
                PDB.VisionSensorListtmp = (List<VisionSensor>)PDB.CloneLstVisionSensor(listVisionSensor_local);
            }
            else
            {
                PDB.VisionSensorListtmp.Clear();
                foreach (VisionSensor visionsensor_ in listVisionSensor_local)
                {
                    if (visionsensor_.VisionSensorFocus.ToString().Substring(1) == VisionSensorFocus)
                    {
                        PDB.VisionSensorListtmp.Add(visionsensor_);
                    }
                }
            }

            // Select Scanner cable
            if (VisionSensorLight == "All")
            {
                listVisionSensor_local = (List<VisionSensor>)PDB.CloneLstVisionSensor(PDB.VisionSensorListtmp);//做深拷贝
            }
            else
            {
                listVisionSensor_local.Clear();
                foreach (VisionSensor visionsensor_ in PDB.VisionSensorListtmp)
                {
                    if (visionsensor_.VisionSensorLight.ToString() == VisionSensorLight)
                    {
                        listVisionSensor_local.Add(visionsensor_);
                    }
                }
            }

            // listScanner_local = (List<Scanner>)PDB.CloneLstScanner(PDB.tmpScanList);



            LoadVisionSensor();
        }

        private void LoadVisionSensor()
        {
            this.listViewVisionSensor.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            this.listViewVisionSensor.Items.Clear();

            this.colHeaderVisionSensor_Description.Width = this.listViewVisionSensor.Size.Width * 100 / 100;
            int PositionIndex = this.listViewVisionSensor.Items.Count;


            foreach (VisionSensor visionsensor_ in listVisionSensor_local)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = visionsensor_.OrderCode;
                lvi.SubItems.Add(visionsensor_.LongCode);
                lvi.SubItems.Add(visionsensor_.VisionSensorModel.ToString());
                lvi.SubItems.Add(visionsensor_.VisionSensorFocus.ToString().Substring(1));
                lvi.SubItems.Add(visionsensor_.VisionSensorLight.ToString());


                if (SP.Systemlanguage == "English")
                {
                    lvi.SubItems.Add(visionsensor_.DescriptionEN);
                }
                else if (SP.Systemlanguage == "中文")
                {
                    lvi.SubItems.Add(visionsensor_.DescriptionCN);
                }

                this.listViewVisionSensor.Items.Add(lvi);

            }

            this.listViewVisionSensor.EndUpdate();  //结束数据处理，UI界面一次性绘制。
            bVisionSensorInit = true;


            //所有图像都一样，直接init

            Image img1 = Properties.Resources.VisionSensor;

            if (img1 != null)
            {
                Bitmap bmp = new Bitmap(img1.Width, img1.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(img1, new Rectangle(0, 0, img1.Width, img1.Height));
                pbListviewVisionSensor.Image = bmp;
            }




        }

        private void LoadVisionSensorAccessory()
        {
            this.colHeaderVisionSensor_AccessoryDescription.Width = this.listViewVisionSensorAccessory.Size.Width * 150 / 100;
            this.listViewVisionSensorAccessory.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            this.listViewVisionSensorAccessory.Items.Clear();

            if (cbVisionSensorAccessoryChose.Text == "Ethernet Cable" | cbVisionSensorAccessoryChose.Text == "All")
            {
                foreach (Cable cable_ in PDB.CableList)
                {

                    if (cable_.CableProductFamily1 == Cable.enumCableproductfamily.VisionSensor
                        | cable_.CableInterface == Cable.enumCableInterface.Ethernet)
                    {
                        ListViewItem lvi = new ListViewItem();

                        lvi.Text = cable_.OrderCode;
                        lvi.SubItems.Add(cable_.ProductFamily.ToString());
                        lvi.SubItems.Add(cable_.CableInterface.ToString());

                        if (SP.Systemlanguage == "English")
                        {
                            lvi.SubItems.Add(cable_.DescriptionEN);
                        }
                        else if (SP.Systemlanguage == "中文")
                        {
                            lvi.SubItems.Add(cable_.DescriptionCN);
                        }

                        this.listViewVisionSensorAccessory.Items.Add(lvi);

                    }
                }
            }

            if (cbVisionSensorAccessoryChose.Text == "IO Cable" | cbVisionSensorAccessoryChose.Text == "All")
            {
                foreach (Cable cable_ in PDB.CableList)
                {

                    if (cable_.CableProductFamily1 == Cable.enumCableproductfamily.VisionSensor
                        | cable_.CableInterface == Cable.enumCableInterface.IO)
                    {
                        ListViewItem lvi = new ListViewItem();

                        lvi.Text = cable_.OrderCode;
                        lvi.SubItems.Add(cable_.ProductFamily.ToString());
                        lvi.SubItems.Add(cable_.CableInterface.ToString());

                        if (SP.Systemlanguage == "English")
                        {
                            lvi.SubItems.Add(cable_.DescriptionEN);
                        }
                        else if (SP.Systemlanguage == "中文")
                        {
                            lvi.SubItems.Add(cable_.DescriptionCN);
                        }

                        this.listViewVisionSensorAccessory.Items.Add(lvi);

                    }
                }
            }

            if (cbVisionSensorAccessoryChose.Text == "Monitor" | cbVisionSensorAccessoryChose.Text == "All")
            {
                foreach (Cable cable_ in PDB.CableList)
                {

                    if (cable_.CableProductFamily1 == Cable.enumCableproductfamily.Monitor)

                    {
                        ListViewItem lvi = new ListViewItem();

                        lvi.Text = cable_.OrderCode;
                        lvi.SubItems.Add(cable_.ProductFamily.ToString());
                        lvi.SubItems.Add(cable_.CableInterface.ToString());

                        if (SP.Systemlanguage == "English")
                        {
                            lvi.SubItems.Add(cable_.DescriptionEN);
                        }
                        else if (SP.Systemlanguage == "中文")
                        {
                            lvi.SubItems.Add(cable_.DescriptionCN);
                        }

                        this.listViewVisionSensorAccessory.Items.Add(lvi);

                    }
                }

                foreach (Accessory accessory_ in PDB.AccessoryList)
                {

                    if (accessory_.AccessoryProductFamily == Accessory.enumAccessoryproductfamily.VisionSensor)
                    {
                        ListViewItem lvi = new ListViewItem();

                        lvi.Text = accessory_.OrderCode;
                        lvi.SubItems.Add(accessory_.ProductFamily.ToString());
                        lvi.SubItems.Add("");

                        if (SP.Systemlanguage == "English")
                        {
                            lvi.SubItems.Add(accessory_.DescriptionEN);
                        }
                        else if (SP.Systemlanguage == "中文")
                        {
                            lvi.SubItems.Add(accessory_.DescriptionCN);
                        }

                        this.listViewVisionSensorAccessory.Items.Add(lvi);

                    }
                }
            }


            this.listViewVisionSensorAccessory.EndUpdate();  //结束数据处理，UI界面一次性绘制。
        }

        private void btnVisionSensorCalculation_Click(object sender, EventArgs e)
        {
            if (!rBVisionSensorFocus.Checked & !rbVisionSensorFOVWidth.Checked & !rBVisionSensorWD.Checked)
            { MessageBox.Show("Choose one parameter to calculate"); }

            if (rBVisionSensorFocus.Checked)
            {
                tBVisionSensorFocus.Text = (Helper.getFloatFromString(tBVisionSensorWD.Text) * 3.84 / Helper.getFloatFromString(tbVisionSensorFOVWidth.Text)).ToString();
            }

            if (rBVisionSensorWD.Checked)
            {
                tBVisionSensorWD.Text = (Helper.getFloatFromString(tBVisionSensorFocus.Text) / 3.84 * Helper.getFloatFromString(tbVisionSensorFOVWidth.Text)).ToString();

            }

            if (rbVisionSensorFOVWidth.Checked)
            {
                tbVisionSensorFOVWidth.Text = (Helper.getFloatFromString(tBVisionSensorWD.Text) * 3.84 / Helper.getFloatFromString(tBVisionSensorFocus.Text)).ToString();

            }
        }

        private void tbVisionSensorFOVWidth_TextChanged(object sender, EventArgs e)
        {
            tbVisionSensorFOVHeight.Text = (Helper.getFloatFromString(tbVisionSensorFOVWidth.Text) * 0.288 / 0.384).ToString();
        }

        private void btnVisionSensorFunctionDetail_Click(object sender, EventArgs e)
        {
            VisionSensorCompareWindow WindowVisionSensor = new VisionSensorCompareWindow(); //传递参数到参数窗口

            WindowVisionSensor.Show();
        }

        private void btnVisionSensorConnection_Click(object sender, EventArgs e)
        {
            VisionSensorConnectionWindow WindowVisionSensor = new VisionSensorConnectionWindow(); //传递参数到参数窗口

            WindowVisionSensor.Show();
        }

        private void cbVisionSensorAccessoryChose_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadVisionSensorAccessory();
        }

        private void listViewVisionSensorAccessory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //防止循环两次清除
            if (listViewVisionSensor.SelectedItems.Count > 0)
                this.listViewVisionSensor.SelectedItems.Clear();

            if (this.listViewVisionSensorAccessory.SelectedItems.Count == 1)
            {

                product pdtmp = product.getProduct(listViewVisionSensorAccessory.SelectedItems[0].Text, PDB.ProductList);

                if (pdtmp.ProductFamily == product.enumProductFamily.Cable)
                    pBVisionSensorAccessory.Image = PDB.loadCableImage(((Cable)pdtmp));

                if (pdtmp.ProductFamily == product.enumProductFamily.Accessory)
                    pBVisionSensorAccessory.Image = PDB.loadAccessoryImage(((Accessory)pdtmp));

            }



        }


        #endregion


        #region TabSmartCamera 控件

        //加载智能相机到表格中        
        private void LoadSmartCamera()
        {
            this.listViewSmartCamera.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            this.listViewSmartCamera.Items.Clear();

            this.colHeaderSmartCamera_Description.Width = this.listViewSmartCamera.Size.Width * 100 / 100;
            int PositionIndex = this.listViewSmartCamera.Items.Count;


            foreach (SmartCamera smartcamera_ in listSmartCamera_local)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = smartcamera_.OrderCode;
                lvi.SubItems.Add(smartcamera_.LongCode);
                lvi.SubItems.Add(smartcamera_.SmartCameraFunction.ToString());
                lvi.SubItems.Add(smartcamera_.SmartCameraColor.ToString());
                lvi.SubItems.Add(smartcamera_.SmartCameraInterface.ToString());


                if (SP.Systemlanguage == "English")
                {
                    lvi.SubItems.Add(smartcamera_.DescriptionEN);
                }
                else if (SP.Systemlanguage == "中文")
                {
                    lvi.SubItems.Add(smartcamera_.DescriptionCN);
                }

                this.listViewSmartCamera.Items.Add(lvi);

            }

            this.listViewSmartCamera.EndUpdate();  //结束数据处理，UI界面一次性绘制。
            bSmartCameraInit = true;

            /*
            Image img1 = Properties.Resources.SmartCameraLens;

            if (img1 != null)
            {
                Bitmap bmp = new Bitmap(pbVisionSensorLens.Width, pbVisionSensorLens.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(img1, new Rectangle(0, 0, pbVisionSensorLens.Width, pbVisionSensorLens.Height));
                pbVisionSensorLens.Image = bmp;
            }
            */
        }

        //筛选智能相机
        private void cbSmartCameraFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SmartCamerFunction = cbSmartCameraFunction.Text;
            string SmartCamerColor = cbSmartCameraColor.Text;
            string SmartCamerInterface = cbSmartCameraInterface.Text;

            // Select Smartcamer Function
            if (SmartCamerFunction == "All")
            {
                listSmartCamera_local = (List<SmartCamera>)PDB.CloneLstSmartCamera(PDB.SmartCameraList);//做深拷贝
            }
            else
            {
                listSmartCamera_local.Clear();
                foreach (SmartCamera smartcamera_ in PDB.SmartCameraList)
                {
                    if (smartcamera_.SmartCameraFunction.ToString() == SmartCamerFunction)
                    {
                        listSmartCamera_local.Add(smartcamera_);
                    }
                }
            }
            /// Select Smartcamer Color
            if (SmartCamerColor == "All")
            {
                PDB.SmartCameraListtmp = (List<SmartCamera>)PDB.CloneLstSmartCamera(listSmartCamera_local);
            }
            else
            {
                PDB.SmartCameraListtmp.Clear();
                foreach (SmartCamera smartcamera_ in listSmartCamera_local)
                {
                    if (smartcamera_.SmartCameraColor.ToString() == SmartCamerColor)
                    {
                        PDB.SmartCameraListtmp.Add(smartcamera_);
                    }
                }
            }

            /// Select Smartcamer Interface
            if (SmartCamerInterface == "All")
            {
                listSmartCamera_local = (List<SmartCamera>)PDB.CloneLstSmartCamera(PDB.SmartCameraListtmp);//做深拷贝
            }
            else
            {
                listSmartCamera_local.Clear();
                foreach (SmartCamera smartcamera_ in PDB.SmartCameraListtmp)
                {
                    if (smartcamera_.SmartCameraInterface.ToString() == SmartCamerInterface)
                    {
                        listSmartCamera_local.Add(smartcamera_);
                    }
                }
            }

            LoadSmartCamera();
        }

        //切换表格中选项，切换图片
        private void listViewSmartCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSmartCamera.SelectedItems.Count > 0)
                this.listViewSmartCameraAccessory.SelectedItems.Clear();

            if (this.listViewSmartCamera.SelectedItems.Count == 1)
            {
                Image img = null;
                SmartCamera sctmp = SmartCamera.getSmartCamera(listViewSmartCamera.SelectedItems[0].Text, PDB.SmartCameraList);

                switch (sctmp.ImageIndex)
                {
                    case 1:
                        img = Properties.Resources.SmartCameraLite;
                        break;
                    case 2:
                        img = Properties.Resources.SmartCamera;
                        break;
                    default:
                        img = null;
                        break;

                }
                if (img != null)
                {
                    Bitmap bmp = new Bitmap(img.Width, img.Height);
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
                    pbSmartCamera.Image = bmp;
                }
            }
        }

        //计算 lens
        private void btnSmartCameraLens_Click(object sender, EventArgs e)
        {
            if (!rbSmartCameraLens_Focus.Checked & !rbSmartCameraLens_FOV.Checked & !rbSmartCameraLens_WD.Checked)
            { MessageBox.Show("Choose one parameter to calculate"); }

            if (rbSmartCameraLens_Focus.Checked)
            {
                tbSmartCameraLens_Focus.Text = (Helper.getFloatFromString(tbSmartCameraLens_WD.Text) * 6.784 / Helper.getFloatFromString(tbSmartCameraLens_FOVWidth.Text)).ToString();
            }

            if (rbSmartCameraLens_WD.Checked)
            {
                tbSmartCameraLens_WD.Text = (Helper.getFloatFromString(tbSmartCameraLens_Focus.Text) / 6.784 * Helper.getFloatFromString(tbSmartCameraLens_FOVWidth.Text)).ToString();

            }

            if (rbSmartCameraLens_FOV.Checked)
            {
                tbSmartCameraLens_FOVWidth.Text = (Helper.getFloatFromString(tbSmartCameraLens_WD.Text) * 6.784 / Helper.getFloatFromString(tbSmartCameraLens_Focus.Text)).ToString();

            }
        }

        //计算FOV
        private void tbSmartCameraLens_FocusWidth_TextChanged(object sender, EventArgs e)
        {
            tbSmartCameraLens_FocusHeight.Text = (Helper.getFloatFromString(tbSmartCameraLens_FOVWidth.Text) * 1.024 / 1.280).ToString();

        }

        //显示连线图
        private void btnSmartCameraConnection_Click(object sender, EventArgs e)
        {
            SmartCameraConnection WindowSmartCamera = new SmartCameraConnection(); //传递参数到参数窗口

            WindowSmartCamera.Show();
        }

        //显示功能图
        private void btnSmartCameraFunction_Click(object sender, EventArgs e)
        {
            SmartCameraFunction WindowSmartCamera = new SmartCameraFunction(); //传递参数到参数窗口

            WindowSmartCamera.Show();
        }

        //附件切换图片
        private void listViewSmartCameraAccessory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //防止循环两次清除
            if (listViewSmartCameraAccessory.SelectedItems.Count > 0)
                this.listViewSmartCamera.SelectedItems.Clear();

            if (this.listViewSmartCameraAccessory.SelectedItems.Count == 1)
            {

                product pdtmp = product.getProduct(listViewSmartCameraAccessory.SelectedItems[0].Text, PDB.ProductList);

                if (pdtmp.ProductFamily == product.enumProductFamily.Cable)
                { pbSmartCameraAccessory.Image = PDB.loadCableImage(((Cable)pdtmp)); }

                if (pdtmp.ProductFamily == product.enumProductFamily.Accessory)
                    pbSmartCameraAccessory.Image = PDB.loadAccessoryImage(((Accessory)pdtmp));

                if (pdtmp.ProductFamily == product.enumProductFamily.Lens)
                    pbSmartCameraAccessory.Image = PDB.loadLensImage(((Lens)pdtmp));
            }

        }

        //加载智能相机附件
        private void LoadSmartCameraAccessory()
        {
            this.listViewSmartCameraAccessory.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            this.listViewSmartCameraAccessory.Items.Clear();

            colHeaderSmartCamera_AccessoryDescription.Width = listViewSmartCameraAccessory.Width * 150 / 100;

            if (cBSmartCameraAccessory.Text == "Lens" | cBSmartCameraAccessory.Text == "All")
            {
                foreach (Lens lens_ in PDB.LensList)
                {

                    if (lens_.LensImageSize == "2/3\"")
                    {
                        ListViewItem lvi = new ListViewItem();

                        lvi.Text = lens_.OrderCode;
                        lvi.SubItems.Add(lens_.ProductFamily.ToString());
                        lvi.SubItems.Add(lens_.LensFocusLength.ToString().Substring(1));

                        if (SP.Systemlanguage == "English")
                        {
                            lvi.SubItems.Add(lens_.DescriptionEN);
                        }
                        else if (SP.Systemlanguage == "中文")
                        {
                            lvi.SubItems.Add(lens_.DescriptionCN);
                        }

                        this.listViewSmartCameraAccessory.Items.Add(lvi);

                    }
                }
            }

            if (cBSmartCameraAccessory.Text == "Ethernet Cable" | cBSmartCameraAccessory.Text == "All")
            {

                foreach (Cable cable_ in PDB.CableList)
                {
                    if ((cable_.CableProductFamily1 == Cable.enumCableproductfamily.SmartCamera | cable_.CableProductFamily2 == Cable.enumCableproductfamily.SmartCamera
                        | cable_.CableProductFamily3 == Cable.enumCableproductfamily.SmartCamera) & cable_.CableInterface == Cable.enumCableInterface.GIGE)
                    {
                        ListViewItem lvi = new ListViewItem();

                        lvi.Text = cable_.OrderCode;
                        lvi.SubItems.Add(cable_.ProductFamily.ToString());
                        lvi.SubItems.Add(cable_.CableInterface.ToString());

                        if (SP.Systemlanguage == "English")
                        {
                            lvi.SubItems.Add(cable_.DescriptionEN);
                        }
                        else if (SP.Systemlanguage == "中文")
                        {
                            lvi.SubItems.Add(cable_.DescriptionCN);
                        }

                        this.listViewSmartCameraAccessory.Items.Add(lvi);

                    }
                }
            }

            if (cBSmartCameraAccessory.Text == "IO Cable" | cBSmartCameraAccessory.Text == "All")
            {

                foreach (Cable cable_ in PDB.CableList)
                {
                    if (((cable_.CableProductFamily1 == Cable.enumCableproductfamily.SmartCamera | cable_.CableProductFamily2 == Cable.enumCableproductfamily.SmartCamera
                        | cable_.CableProductFamily3 == Cable.enumCableproductfamily.SmartCamera) & cable_.CableInterface == Cable.enumCableInterface.IO) |
                        ((cable_.CableProductFamily1 == Cable.enumCableproductfamily.SmartCameraLite | cable_.CableProductFamily2 == Cable.enumCableproductfamily.SmartCameraLite
                        | cable_.CableProductFamily3 == Cable.enumCableproductfamily.SmartCameraLite) & cable_.CableInterface == Cable.enumCableInterface.IO))
                    {
                        ListViewItem lvi = new ListViewItem();

                        lvi.Text = cable_.OrderCode;
                        lvi.SubItems.Add(cable_.ProductFamily.ToString());
                        lvi.SubItems.Add(cable_.CableInterface.ToString());

                        if (SP.Systemlanguage == "English")
                        {
                            lvi.SubItems.Add(cable_.DescriptionEN);
                        }
                        else if (SP.Systemlanguage == "中文")
                        {
                            lvi.SubItems.Add(cable_.DescriptionCN);
                        }

                        this.listViewSmartCameraAccessory.Items.Add(lvi);

                    }
                }
            }

            if (cBSmartCameraAccessory.Text == "IO-Link Cable" | cBSmartCameraAccessory.Text == "All")
            {

                foreach (Cable cable_ in PDB.CableList)
                {
                    if ((cable_.CableProductFamily1 == Cable.enumCableproductfamily.SmartCamera | cable_.CableProductFamily2 == Cable.enumCableproductfamily.SmartCamera
                        | cable_.CableProductFamily3 == Cable.enumCableproductfamily.SmartCamera) & cable_.CableInterface == Cable.enumCableInterface.IO_Link)
                    {
                        ListViewItem lvi = new ListViewItem();

                        lvi.Text = cable_.OrderCode;
                        lvi.SubItems.Add(cable_.ProductFamily.ToString());
                        lvi.SubItems.Add(cable_.CableInterface.ToString());

                        if (SP.Systemlanguage == "English")
                        {
                            lvi.SubItems.Add(cable_.DescriptionEN);
                        }
                        else if (SP.Systemlanguage == "中文")
                        {
                            lvi.SubItems.Add(cable_.DescriptionCN);
                        }

                        this.listViewSmartCameraAccessory.Items.Add(lvi);

                    }
                }
            }

            if (cBSmartCameraAccessory.Text == "Fieldbus Cable" | cBSmartCameraAccessory.Text == "All")
            {

                foreach (Cable cable_ in PDB.CableList)
                {
                    if ((cable_.CableProductFamily1 == Cable.enumCableproductfamily.SmartCamera | cable_.CableProductFamily2 == Cable.enumCableproductfamily.SmartCamera
                        | cable_.CableProductFamily3 == Cable.enumCableproductfamily.SmartCamera) & cable_.CableInterface == Cable.enumCableInterface.Fieldbus)
                    {
                        ListViewItem lvi = new ListViewItem();

                        lvi.Text = cable_.OrderCode;
                        lvi.SubItems.Add(cable_.ProductFamily.ToString());
                        lvi.SubItems.Add(cable_.CableInterface.ToString());

                        if (SP.Systemlanguage == "English")
                        {
                            lvi.SubItems.Add(cable_.DescriptionEN);
                        }
                        else if (SP.Systemlanguage == "中文")
                        {
                            lvi.SubItems.Add(cable_.DescriptionCN);
                        }

                        this.listViewSmartCameraAccessory.Items.Add(lvi);

                    }
                }
            }

            if (cBSmartCameraAccessory.Text == "Accessory" | cBSmartCameraAccessory.Text == "All")
            {
                foreach (Accessory accessory_ in PDB.AccessoryList)
                {

                    if (accessory_.AccessoryProductFamily == Accessory.enumAccessoryproductfamily.SmartCamera)
                    {
                        ListViewItem lvi = new ListViewItem();

                        lvi.Text = accessory_.OrderCode;
                        lvi.SubItems.Add(accessory_.ProductFamily.ToString());
                        lvi.SubItems.Add("");

                        if (SP.Systemlanguage == "English")
                        {
                            lvi.SubItems.Add(accessory_.DescriptionEN);
                        }
                        else if (SP.Systemlanguage == "中文")
                        {
                            lvi.SubItems.Add(accessory_.DescriptionCN);
                        }

                        this.listViewSmartCameraAccessory.Items.Add(lvi);

                    }
                }
            }


            this.listViewSmartCameraAccessory.EndUpdate();  //结束数据处理，UI界面一次性绘制。
        }

        //智能相机附件筛选
        private void cBSmartCameraAccessory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSmartCameraAccessory();
        }

        #endregion


        #region Tab Industrial Camera 控件

        //加载相机
        private void LoadCA()
        {
            this.listViewCA.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            this.listViewCA.Items.Clear();

            this.colHeaderCA_Description.Width = this.listViewCA.Size.Width * 100 / 100;
            int PositionIndex = this.listViewCA.Items.Count;

            foreach (IndustrialCamera ca_ in listIndustrialCamera_local)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = ca_.OrderCode;
                lvi.SubItems.Add(ca_.LongCode);
                lvi.SubItems.Add(ca_.CAResolution);
                lvi.SubItems.Add(ca_.ImageWidth.ToString());
                lvi.SubItems.Add(ca_.ImageHeight.ToString());
                lvi.SubItems.Add(ca_.CAColor.ToString());
                lvi.SubItems.Add(ca_.CAInterface.ToString());


                if (SP.Systemlanguage == "English")
                {
                    lvi.SubItems.Add(ca_.DescriptionEN);
                }
                else if (SP.Systemlanguage == "中文")
                {
                    lvi.SubItems.Add(ca_.DescriptionCN);
                }

                this.listViewCA.Items.Add(lvi);

            }

            this.listViewCA.EndUpdate();  //结束数据处理，UI界面一次性绘制。
            bIndustrialCameraInit = true;


        }

        //筛选相机
        private void cBCAResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CAResolution = cBCAResolution.Text;
            string CAColor = cBCAColor.Text;
            string CAInterface = cBCAInterface.Text;

            // Select Smartcamer Function
            if (CAResolution == "All")
            {
                listIndustrialCamera_local = (List<IndustrialCamera>)PDB.CloneLstIndustrialCamera(PDB.CAList);//做深拷贝
            }
            else
            {
                listIndustrialCamera_local.Clear();
                foreach (IndustrialCamera ca_ in PDB.CAList)
                {
                    if (ca_.CAResolution.ToString() == CAResolution)
                    {
                        listIndustrialCamera_local.Add(ca_);
                    }
                }
            }
            /// Select Smartcamer Color
            if (CAColor == "All")
            {
                PDB.CAListtmp = (List<IndustrialCamera>)PDB.CloneLstIndustrialCamera(listIndustrialCamera_local);
            }
            else
            {
                PDB.CAListtmp.Clear();
                foreach (IndustrialCamera ca_ in listIndustrialCamera_local)
                {
                    if (ca_.CAColor.ToString() == CAColor)
                    {
                        PDB.CAListtmp.Add(ca_);
                    }
                }
            }

            /// Select Smartcamer Interface
            if (CAInterface == "All")
            {
                listIndustrialCamera_local = (List<IndustrialCamera>)PDB.CloneLstIndustrialCamera(PDB.CAListtmp);//做深拷贝
            }
            else
            {
                listIndustrialCamera_local.Clear();
                foreach (IndustrialCamera ca_ in PDB.CAListtmp)
                {
                    if (ca_.CAInterface.ToString() == CAInterface)
                    {
                        listIndustrialCamera_local.Add(ca_);
                    }
                }
            }

            LoadCA();
        }

        //加载图片
        private void listViewCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCA.SelectedItems.Count > 0)
                this.listViewCA_Accessory.SelectedItems.Clear();

            if (this.listViewCA.SelectedItems.Count == 1)
            {
                Image img = null;
                IndustrialCamera catmp = IndustrialCamera.getIndustrialCamera(listViewCA.SelectedItems[0].Text, PDB.CAList);

                switch (catmp.ImageIndex)
                {
                    case 1:
                        img = Properties.Resources.CAGIGE;
                        break;
                    case 2:
                        img = Properties.Resources.CAUSB3;
                        break;
                    default:
                        img = null;
                        break;

                }
                if (img != null)
                {
                    Bitmap bmp = new Bitmap(img.Width, img.Height);
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
                    pbCA.Image = bmp;
                }
            }

        }

        //计算相机芯片大小
        private void cBCALens_Resolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cBCALens_Resolution.SelectedIndex)
            {
                case 0:
                    tBCALens_SensorWidth.Text = IndustrialCamera.getIndustrialCamera("BVS003A", PDB.CAList).SensorSizeWidth.ToString();
                    tBCALens_SensorHeight.Text = IndustrialCamera.getIndustrialCamera("BVS003A", PDB.CAList).SensorSizeHeight.ToString();
                    break;
                case 1:
                    tBCALens_SensorWidth.Text = IndustrialCamera.getIndustrialCamera("BVS0038", PDB.CAList).SensorSizeWidth.ToString();
                    tBCALens_SensorHeight.Text = IndustrialCamera.getIndustrialCamera("BVS0038", PDB.CAList).SensorSizeHeight.ToString();
                    break;
                case 2:
                    tBCALens_SensorWidth.Text = IndustrialCamera.getIndustrialCamera("BVS0036", PDB.CAList).SensorSizeWidth.ToString();
                    tBCALens_SensorHeight.Text = IndustrialCamera.getIndustrialCamera("BVS0036", PDB.CAList).SensorSizeHeight.ToString();
                    break;
                case 3:
                    tBCALens_SensorWidth.Text = IndustrialCamera.getIndustrialCamera("BVS0034", PDB.CAList).SensorSizeWidth.ToString();
                    tBCALens_SensorHeight.Text = IndustrialCamera.getIndustrialCamera("BVS0034", PDB.CAList).SensorSizeHeight.ToString();
                    break;
                default:
                    tBCALens_SensorWidth.Text = "";
                    tBCALens_SensorHeight.Text = "";
                    break;

            }


        }

        //计算 lens
        private void btnCA_LensCalculation_Click(object sender, EventArgs e)
        {
            if (!rBCALens_Focus.Checked & !rBCALens_FOV.Checked & !rBCALens_WD.Checked)
            { MessageBox.Show("Choose one parameter to calculate"); }

            if (!(cBCALens_Resolution.SelectedIndex >= 0 & cBCALens_Resolution.SelectedIndex <= 4))
            { MessageBox.Show("Please select a camera"); }

            if (rBCALens_Focus.Checked)
            {
                tbCALens_Focus.Text = (Helper.getFloatFromString(tBCALens_WD.Text) * Helper.getFloatFromString(tBCALens_SensorWidth.Text) / Helper.getFloatFromString(tbCALens_FOVWidth.Text)).ToString("0.000");
            }

            if (rBCALens_WD.Checked)
            {
                tBCALens_WD.Text = (Helper.getFloatFromString(tbCALens_Focus.Text) / Helper.getFloatFromString(tBCALens_SensorWidth.Text) * Helper.getFloatFromString(tbCALens_FOVWidth.Text)).ToString("0.000");

            }

            if (rBCALens_FOV.Checked)
            {
                tbCALens_FOVWidth.Text = (Helper.getFloatFromString(tBCALens_WD.Text) * Helper.getFloatFromString(tBCALens_SensorWidth.Text) / Helper.getFloatFromString(tbCALens_Focus.Text)).ToString("0.000");

            }
        }

        //计算 FOV Height
        private void tbCALens_FOVWidth_TextChanged(object sender, EventArgs e)
        {
            if ((cBCALens_Resolution.SelectedIndex >= 0 & cBCALens_Resolution.SelectedIndex <= 4))
            {
                tBCALens_FOVHeight.Text = (Helper.getFloatFromString(tbCALens_FOVWidth.Text) * Helper.getFloatFromString(tBCALens_SensorHeight.Text) / Helper.getFloatFromString(tBCALens_SensorWidth.Text)).ToString("0.000");
            }
        }

        //显示连接图
        private void btnCALens_Connection_Click(object sender, EventArgs e)
        {
            IndustrialCameraConnectionWindow WindowCA = new IndustrialCameraConnectionWindow(); //传递参数到参数窗口

            WindowCA.Show();
        }

        private void LoadCAAccessory()
        {
            this.listViewCA_Accessory.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            this.listViewCA_Accessory.Items.Clear();

            colHeaderCAAccessory_Description.Width = listViewCA_Accessory.Width * 150 / 100;

            if (cBCAAccessory.Text == "Lens" | cBCAAccessory.Text == "All")
            {
                foreach (Lens lens_ in PDB.LensList)
                {
                    ListViewItem lvi = new ListViewItem();

                    lvi.Text = lens_.OrderCode;
                    lvi.SubItems.Add(lens_.ProductFamily.ToString());
                    lvi.SubItems.Add(lens_.LensFocusLength.ToString().Substring(1));
                    lvi.SubItems.Add(lens_.LensImageSize);

                    if (SP.Systemlanguage == "English")
                    {
                        lvi.SubItems.Add(lens_.DescriptionEN);
                    }
                    else if (SP.Systemlanguage == "中文")
                    {
                        lvi.SubItems.Add(lens_.DescriptionCN);
                    }

                    this.listViewCA_Accessory.Items.Add(lvi);


                }
            }

            if (cBCAAccessory.Text == "GigE Cable" | cBCAAccessory.Text == "All")
            {

                foreach (Cable cable_ in PDB.CableList)
                {
                    if ((cable_.CableProductFamily1 == Cable.enumCableproductfamily.GIGE_Camera | cable_.CableProductFamily2 == Cable.enumCableproductfamily.GIGE_Camera
                        | cable_.CableProductFamily3 == Cable.enumCableproductfamily.GIGE_Camera) & cable_.CableInterface == Cable.enumCableInterface.GIGE)
                    {
                        ListViewItem lvi = new ListViewItem();

                        lvi.Text = cable_.OrderCode;
                        lvi.SubItems.Add(cable_.ProductFamily.ToString());
                        lvi.SubItems.Add(cable_.CableInterface.ToString());
                        lvi.SubItems.Add(cable_.CableLength.ToString() + "m");

                        if (SP.Systemlanguage == "English")
                        {
                            lvi.SubItems.Add(cable_.DescriptionEN);
                        }
                        else if (SP.Systemlanguage == "中文")
                        {
                            lvi.SubItems.Add(cable_.DescriptionCN);
                        }

                        this.listViewCA_Accessory.Items.Add(lvi);

                    }
                }
            }

            if (cBCAAccessory.Text == "IO Cable" | cBCAAccessory.Text == "All")
            {

                foreach (Cable cable_ in PDB.CableList)
                {
                    if (((cable_.CableProductFamily1 == Cable.enumCableproductfamily.GIGE_Camera | cable_.CableProductFamily2 == Cable.enumCableproductfamily.GIGE_Camera
                        | cable_.CableProductFamily3 == Cable.enumCableproductfamily.GIGE_Camera) & cable_.CableInterface == Cable.enumCableInterface.IO)
                        |
                        ((cable_.CableProductFamily1 == Cable.enumCableproductfamily.USB3_Camera | cable_.CableProductFamily2 == Cable.enumCableproductfamily.USB3_Camera
                        | cable_.CableProductFamily3 == Cable.enumCableproductfamily.USB3_Camera) & cable_.CableInterface == Cable.enumCableInterface.IO))
                    {
                        ListViewItem lvi = new ListViewItem();

                        lvi.Text = cable_.OrderCode;
                        lvi.SubItems.Add(cable_.ProductFamily.ToString());
                        lvi.SubItems.Add(cable_.CableInterface.ToString());
                        lvi.SubItems.Add(cable_.CableLength.ToString() + "m");

                        if (SP.Systemlanguage == "English")
                        {
                            lvi.SubItems.Add(cable_.DescriptionEN);
                        }
                        else if (SP.Systemlanguage == "中文")
                        {
                            lvi.SubItems.Add(cable_.DescriptionCN);
                        }

                        this.listViewCA_Accessory.Items.Add(lvi);

                    }
                }
            }

            if (cBCAAccessory.Text == "USB3 Cable" | cBCAAccessory.Text == "All")
            {

                foreach (Cable cable_ in PDB.CableList)
                {
                    if ((cable_.CableProductFamily1 == Cable.enumCableproductfamily.USB3_Camera | cable_.CableProductFamily2 == Cable.enumCableproductfamily.USB3_Camera
                        | cable_.CableProductFamily3 == Cable.enumCableproductfamily.USB3_Camera) & cable_.CableInterface == Cable.enumCableInterface.USB3_0)
                    {
                        ListViewItem lvi = new ListViewItem();

                        lvi.Text = cable_.OrderCode;
                        lvi.SubItems.Add(cable_.ProductFamily.ToString());
                        lvi.SubItems.Add(cable_.CableInterface.ToString());
                        lvi.SubItems.Add(cable_.CableLength.ToString() + "m");

                        if (SP.Systemlanguage == "English")
                        {
                            lvi.SubItems.Add(cable_.DescriptionEN);
                        }
                        else if (SP.Systemlanguage == "中文")
                        {
                            lvi.SubItems.Add(cable_.DescriptionCN);
                        }

                        this.listViewCA_Accessory.Items.Add(lvi);

                    }
                }
            }


            this.listViewCA_Accessory.EndUpdate();  //结束数据处理，UI界面一次性绘制。
        }

        private void cBCAAccessory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCAAccessory();
        }

        private void listViewCA_Accessory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //防止循环两次清除
            if (listViewCA_Accessory.SelectedItems.Count > 0)
                this.listViewCA.SelectedItems.Clear();

            if (this.listViewCA_Accessory.SelectedItems.Count == 1)
            {

                product pdtmp = product.getProduct(listViewCA_Accessory.SelectedItems[0].Text, PDB.ProductList);

                if (pdtmp.ProductFamily == product.enumProductFamily.Cable)
                    pbCAAccessory.Image = PDB.loadCableImage(((Cable)pdtmp));

                if (pdtmp.ProductFamily == product.enumProductFamily.Lens)
                    pbCAAccessory.Image = PDB.loadLensImage(((Lens)pdtmp));
            }
        }

        #endregion

        #region 镜头页

        private void LoadLens()
        {
            this.listViewLens.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            this.listViewLens.Items.Clear();

            this.colHeaderLens_Description.Width = this.listViewLens.Size.Width * 100 / 100;
            int PositionIndex = this.listViewLens.Items.Count;

            foreach (Lens lens_ in listLens_local)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = lens_.OrderCode;
                lvi.SubItems.Add(lens_.LongCode);
                lvi.SubItems.Add(lens_.LensFocusLength.ToString().Substring(1));
                lvi.SubItems.Add(lens_.LensImageSize);
                lvi.SubItems.Add(lens_.LensDesign.ToString());

                if (SP.Systemlanguage == "English")
                {
                    lvi.SubItems.Add(lens_.DescriptionEN);
                }
                else if (SP.Systemlanguage == "中文")
                {
                    lvi.SubItems.Add(lens_.DescriptionCN);
                }

                this.listViewLens.Items.Add(lvi);

            }

            this.listViewLens.EndUpdate();  //结束数据处理，UI界面一次性绘制。
            bLensInit = true;


        }

        private void cBLens_Focus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string LensFocus = cBLens_Focus.Text;
            string LensImageSize = cBLens_ImageSize.Text;
            string LensDesign = cBLens_Design.Text;

            // Select Smartcamer Function
            if (LensFocus == "All")
            {
                listLens_local = (List<Lens>)PDB.CloneLstLens(PDB.LensList);//做深拷贝
            }
            else
            {
                listLens_local.Clear();
                foreach (Lens lens_ in PDB.LensList)
                {
                    if (lens_.LensFocusLength.ToString().Substring(1) == LensFocus)
                    {
                        listLens_local.Add(lens_);
                    }
                }
            }
            /// Select Smartcamer Color
            if (LensImageSize == "All")
            {
                PDB.LensListtmp = (List<Lens>)PDB.CloneLstLens(listLens_local);
            }
            else
            {
                PDB.LensListtmp.Clear();
                foreach (Lens lens_ in listLens_local)
                {
                    if (lens_.LensImageSize == LensImageSize)
                    {
                        PDB.LensListtmp.Add(lens_);
                    }
                }
            }

            /// Select Smartcamer Interface
            if (LensDesign == "All")
            {
                listLens_local = (List<Lens>)PDB.CloneLstLens(PDB.LensListtmp);//做深拷贝
            }
            else
            {
                listLens_local.Clear();
                foreach (Lens lens_ in PDB.LensListtmp)
                {
                    if (lens_.LensDesign.ToString() == LensDesign)
                    {
                        listLens_local.Add(lens_);
                    }
                }
            }

            LoadLens();
        }

        private void listViewLens_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewLens.SelectedItems.Count == 1)
            {

                product pdtmp = product.getProduct(listViewLens.SelectedItems[0].Text, PDB.ProductList);

                if (pdtmp.ProductFamily == product.enumProductFamily.Lens)
                    pbLens.Image = PDB.loadLensImage(((Lens)pdtmp));
            }
        }



        #endregion


        #region Cable 页

        private void LoadCable()
        {
            this.listViewCable.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            this.listViewCable.Items.Clear();

            this.colHeaderCable_Description.Width = this.listViewCable.Size.Width * 100 / 100;
            int PositionIndex = this.listViewCable.Items.Count;

            foreach (Cable cable_ in listCable_local)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = cable_.OrderCode;
                lvi.SubItems.Add(cable_.LongCode);
                lvi.SubItems.Add(cable_.CableInterface.ToString());
                lvi.SubItems.Add(cable_.CableLength);


                if (SP.Systemlanguage == "English")
                {
                    lvi.SubItems.Add(cable_.DescriptionEN);
                }
                else if (SP.Systemlanguage == "中文")
                {
                    lvi.SubItems.Add(cable_.DescriptionCN);
                }

                this.listViewCable.Items.Add(lvi);

            }

            this.listViewCable.EndUpdate();  //结束数据处理，UI界面一次性绘制。
            bCableInit = true;


        }

        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CableInterface = cbCable_Interface.Text;
            string CableProduct = cbCable_Product.Text;
            string CableLength = cbCable_Length.Text;

            // Select Smartcamer Function
            if (CableProduct == "All")
            {
                listCable_local = (List<Cable>)PDB.CloneLstCable(PDB.CableList);//做深拷贝
            }
            else
            {
                listCable_local.Clear();
                foreach (Cable cable_ in PDB.CableList)
                {
                    if (cable_.CableProductFamily1.ToString() == CableProduct |
                        cable_.CableProductFamily2.ToString() == CableProduct |
                        cable_.CableProductFamily3.ToString() == CableProduct  )
                    {
                        listCable_local.Add(cable_);
                    }
                }
            }
            /// Select Smartcamer Color
            if (CableInterface == "All")
            {
                PDB.CableListtmp = (List<Cable>)PDB.CloneLstCable(listCable_local);
            }
            else
            {
                PDB.CableListtmp.Clear();
                foreach (Cable cable_ in listCable_local)
                {
                    if (cable_.CableInterface.ToString() == CableInterface)
                    {
                        PDB.CableListtmp.Add(cable_);
                    }
                }
            }

            /// Select Smartcamer Interface
            if (CableLength == "All")
            {
                listCable_local = (List<Cable>)PDB.CloneLstCable(PDB.CableListtmp);//做深拷贝
            }
            else
            {
                listCable_local.Clear();
                foreach (Cable cable_ in PDB.CableListtmp)
                {
                    if (cable_.CableLength == CableLength)
                    {
                        listCable_local.Add(cable_);
                    }
                }
            }

            LoadCable();
        }

        private void listViewCable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewCable.SelectedItems.Count == 1)
            {

                product pdtmp = product.getProduct(listViewCable.SelectedItems[0].Text, PDB.ProductList);

                if (pdtmp.ProductFamily == product.enumProductFamily.Cable)
                    pbCable.Image = PDB.loadCableImage(((Cable)pdtmp));
            }
        }

        private void btnCockpitOverview_Click(object sender, EventArgs e)
        {
            SmartCameraFunction WindowSmartCamera = new SmartCameraFunction(); //传递参数到参数窗口

            WindowSmartCamera.Show();
        }

        #endregion


        #region Cockpit 页

        private void LoadCockpit()
        {
            this.listViewCockpit.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            this.listViewCockpit.Items.Clear();

            this.colHeaderCockpit_Description.Width = this.listViewCockpit.Size.Width * 100 / 100;
            int PositionIndex = this.listViewCockpit.Items.Count;

            foreach (Cockpit cockpit_ in listcockpit_local)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = cockpit_.OrderCode;
                lvi.SubItems.Add(cockpit_.LongCode);
                lvi.SubItems.Add(cockpit_.CockpitProductFamily.ToString());

                if (SP.Systemlanguage == "English")
                {
                    lvi.SubItems.Add(cockpit_.DescriptionEN);
                }
                else if (SP.Systemlanguage == "中文")
                {
                    lvi.SubItems.Add(cockpit_.DescriptionCN);
                }

                this.listViewCockpit.Items.Add(lvi);

            }

            this.listViewCockpit.EndUpdate();  //结束数据处理，UI界面一次性绘制。
            bCockpitInit = true;


        }
        private void listViewCockpit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewCockpit.SelectedItems.Count == 1)
            {

                product pdtmp = product.getProduct(listViewCockpit.SelectedItems[0].Text, PDB.ProductList);

                if (pdtmp.ProductFamily == product.enumProductFamily.Cockpit)
                    pbCockpit.Image = PDB.loadCockpitImage(((Cockpit)pdtmp));
            }
        }

        #endregion

        #region Accessory page

        private void loadAccessory()
        {
            this.listViewAccessory.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            this.listViewAccessory.Items.Clear();

            this.colHeaderAccessory_Description.Width = this.listViewAccessory.Size.Width * 100 / 100;
            int PositionIndex = this.listViewAccessory.Items.Count;

            foreach (Accessory accessory_ in listAccessory_local)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = accessory_.OrderCode;
                lvi.SubItems.Add(accessory_.LongCode);
                lvi.SubItems.Add(accessory_.AccessoryProductFamily.ToString());

                if (SP.Systemlanguage == "English")
                {
                    lvi.SubItems.Add(accessory_.DescriptionEN);
                }
                else if (SP.Systemlanguage == "中文")
                {
                    lvi.SubItems.Add(accessory_.DescriptionCN);
                }

                this.listViewAccessory.Items.Add(lvi);

            }

            this.listViewAccessory.EndUpdate();  //结束数据处理，UI界面一次性绘制。
            bAccessoriesInit = true;

        }
        private void cbAccessory_Product_SelectedIndexChanged(object sender, EventArgs e)
        {
            string AccessoryProduct = cbAccessory_Product.Text;

            // Select Smartcamer Function
            if (AccessoryProduct == "All")
            {
                listAccessory_local = (List<Accessory>)PDB.CloneLstAccessory(PDB.AccessoryList);//做深拷贝
            }
            else
            {
                listAccessory_local.Clear();
                foreach (Accessory accessory_ in PDB.AccessoryList)
                {
                    if (accessory_.AccessoryProductFamily.ToString() == AccessoryProduct)
                    {
                        listAccessory_local.Add(accessory_);
                    }
                }
            }
          
            loadAccessory();
        }

        private void listViewAccessory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewAccessory.SelectedItems.Count == 1)
            {

                product pdtmp = product.getProduct(listViewAccessory.SelectedItems[0].Text, PDB.ProductList);

                if (pdtmp.ProductFamily == product.enumProductFamily.Accessory)
                    pbAccessory.Image = PDB.loadAccessoryImage(((Accessory)pdtmp));
            }
        }

        #endregion

        #region  Quick start page

        //扫码枪， 灰色
        private void buttonQSScanner_GreyCableUSB_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BVS001W", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        private void buttonQSScanner_GreyCable232_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BVS001W", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02J4", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02JJ", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        private void buttonQSScanner_GreyBTUSB_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BVS0020", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02JM", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        private void buttonQSScanner_GreyBT232_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BVS0021", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02JM", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        //扫码枪， 黄色 普通码
        private void buttonQSScanner_YellowCableUSBPapier_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BVS001U", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02J0", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        private void buttonQSScanner_YellowCable232Papier_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BVS001U", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02HY", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02JJ", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        private void buttonQSScanner_YellowBTUSBPapier_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BVS001Y", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02HM", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02J0", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02JM", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        private void buttonQSScanner_YellowBT232Papier_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BVS001Y", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02HM", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02HY", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02JM", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        //扫码枪， 黄色 DPM
        private void buttonQSScanner_YellowCableUSBDPM_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BVS001T", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02J0", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        private void buttonQSScanner_YellowCable232DPM_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BVS001T", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02HY", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02JJ", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        private void buttonQSScanner_YellowBTUSBDPM_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BVS001Z", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02HM", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02J0", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02JM", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        private void buttonQSScanner_YellowBT232DPM_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BVS001Z", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02HM", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02HY", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02JM", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        // 视觉传感器
        private void buttonQSVisionSensor_Sensor_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BVS001L", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BCC0E7T", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BCC0995", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        private void buttonQSVisionSensor_Monitor_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BAE00EH", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BCC0ANC", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BCC032H", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        //智能相机
        private void buttonQSSmartCamera_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BVS0033", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BCC032H", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BCC0HZL", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        private void buttonQSSmartCamera_Lite_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BVS003T", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BCC0JCN", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BCC0HZL", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }


        //工业相机
        private void buttonQSCA_GIGE_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BVS003A", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02FE", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BCC0JCN", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BCC0HZL", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        private void buttonQSCA_USB_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BVS003M", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BAM02FE", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BCC0KLC", PDB.ProductList));
            QS_List_Product.Add(product.getProduct("BCC0KL6", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        private void buttonQSCA_Controller_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BAE0103", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }

        private void buttonQSCA_Cockpit_Click(object sender, EventArgs e)
        {
            QS_List_Product.Clear();
            QS_List_Product.Add(product.getProduct("BAI000Z", PDB.ProductList));
            QuickAddML(QS_List_Product);
        }


        #endregion

        private void tbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbProduct.SelectedIndex == 1 & !bScannerInit)
            { LoadScanner_Scanner(); }
            else if (tbProduct.SelectedIndex == 2 & !bVisionSensorInit)
            { LoadVisionSensor(); LoadVisionSensorAccessory(); }
            else if (tbProduct.SelectedIndex == 3 & !bSmartCameraInit)
            { LoadSmartCamera(); LoadSmartCameraAccessory(); }
            else if (tbProduct.SelectedIndex == 4 & !bIndustrialCameraInit)
            { LoadCA(); LoadCAAccessory(); }
            else if (tbProduct.SelectedIndex == 5 & !bLensInit)
            { LoadLens(); }
            else if (tbProduct.SelectedIndex == 6 & !bCableInit)
            { LoadCable(); }
            else if (tbProduct.SelectedIndex == 7 & !bCockpitInit)
            { LoadCockpit(); }
            else if (tbProduct.SelectedIndex == 8 & !bAccessoriesInit)
            { loadAccessory(); }

        }

        
    }
       
}

