using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BalluffVisionConfigurator
{
    class ProductDataBase : ICloneable
    {
        public List<product> ProductList = new List<product>();

        public List<Scanner> ScannerList = new List<Scanner>();
        public List<Scanner> tmpScanList = new List<Scanner>();

        public List<Accessory> AccessoryList = new List<Accessory>();
        public List<Accessory> AccessoryListtmp = new List<Accessory>();

        public List<Cable> CableList = new List<Cable>();
        public List<Cable> CableListtmp = new List<Cable>();

        public List<VisionSensor> VisionSensorList = new List<VisionSensor>();
        public List<VisionSensor> VisionSensorListtmp = new List<VisionSensor>();

        public List<SmartCamera> SmartCameraList = new List<SmartCamera>();
        public List<SmartCamera> SmartCameraListtmp = new List<SmartCamera>();

        public List<Lens> LensList = new List<Lens>();
        public List<Lens> LensListtmp = new List<Lens>();

        public List<IndustrialCamera> CAList = new List<IndustrialCamera>();
        public List<IndustrialCamera> CAListtmp = new List<IndustrialCamera>();

        public List<Cockpit> CockpitList = new List<Cockpit>();



        public ProductDataBase()
        {
            InitScanner();
            ProductList.AddRange(ScannerList);
            InitCable();
            ProductList.AddRange(CableList);
            InitAccessory();
            ProductList.AddRange(AccessoryList);
            InitVisionSensor();
            ProductList.AddRange(VisionSensorList);
            InitSmartCamera();
            ProductList.AddRange(SmartCameraList);
            InitLens();
            ProductList.AddRange(LensList);
            InitIndustrialCamera();
            ProductList.AddRange(CAList);
            InitCockpit();
            ProductList.AddRange(CockpitList);
        }

        public void InitAccessory()
        {
            //Scanner Powersupply 
            Accessory BAM02JJ = new Accessory(product.enumProductFamily.Accessory, "BAM02JJ", "BAE PS-VS-1W-05-015-704-CX-22", "5V Power supply for RS232 cable, EU standard",
                "5V电源, 用于RS232线缆, 欧标", Accessory.enumAccessoryproductfamily.Scanner, Accessory.enumAccessoryproduct.PowerRS232, 100);

            Accessory BAM02JM = new Accessory(product.enumProductFamily.Accessory, "BAM02JM", "BAE PS-VS-1W-12-010-704-CX-22", "12V Power supply for Bluetooth basement, EU standard",
                "12V电源, 用于蓝牙基站, 欧标", Accessory.enumAccessoryproductfamily.Scanner, Accessory.enumAccessoryproduct.BluetoothBasement, 101);

            Accessory BAM02HM = new Accessory(product.enumProductFamily.Accessory, "BAM02HM", "BAM MD-VS-001-0002", "Bluetooth basement for HS-P",
                "蓝牙基站, 用于HS-P扫码枪", Accessory.enumAccessoryproductfamily.ScannerHS_P, Accessory.enumAccessoryproduct.BluetoothBasement, 102);

            Accessory BAM02HN = new Accessory(product.enumProductFamily.Accessory, "BAM02HN", "BAM MD-VS-001-0003", "Bluetooth basement for HS-P, with additional Battrie charger",
                "蓝牙基站, 用于HS-P扫码枪, 带附加电池充电位", Accessory.enumAccessoryproductfamily.ScannerHS_P, Accessory.enumAccessoryproduct.BluetoothBasement, 102);
            
            AccessoryList.Add(BAM02JJ);
            AccessoryList.Add(BAM02JM);
            AccessoryList.Add(BAM02HM);
            AccessoryList.Add(BAM02HN);

            //Vision Sensor Monitor
            Accessory BAE00EH = new Accessory(product.enumProductFamily.Accessory, "BAE00EH", "BAE PD-VS-002-E", "Vision sensor monitor",
                "视觉传感器显示器", Accessory.enumAccessoryproductfamily.VisionSensor, Accessory.enumAccessoryproduct.All, 103);

            Accessory BAM01A8 = new Accessory(product.enumProductFamily.Accessory, "BAM01A8", "BAM PC-AE-002-1", "Vision sensor monitor protection",
                "视觉传感器显示器保护罩", Accessory.enumAccessoryproductfamily.VisionSensor, Accessory.enumAccessoryproduct.All, 104);

            AccessoryList.Add(BAE00EH);
            AccessoryList.Add(BAM01A8);

            //Smart Camera Accessory
            Accessory BAM02NA = new Accessory(product.enumProductFamily.Accessory, "BAM02NA", "BAM PC-VS-023-1", "C mount lens protection tupe, D=40mm, L=40mm",
                "C口镜头保护套, 直径40mm, 长度40mm", Accessory.enumAccessoryproductfamily.SmartCamera, Accessory.enumAccessoryproduct.Lens, 105);

            Accessory BAM02W0 = new Accessory(product.enumProductFamily.Accessory, "BAM02W0", "BAM PC-VS-023-1-01", "C mount lens protection tupe, D=40mm, L=71mm",
               "C口镜头保护套, 直径40mm, 长度71mm", Accessory.enumAccessoryproductfamily.SmartCamera, Accessory.enumAccessoryproduct.Lens, 105);

            AccessoryList.Add(BAM02NA);
            AccessoryList.Add(BAM02W0);


        }

        public void InitCable()
        {   
            //Scanner HS-Q
            Cable BAM02J6 = new Cable(product.enumProductFamily.Cable, "BAM02J6", "BAM MD-VS-005-0005-02", "Cable, RJ45 to USB, 2.0m, straight", "线缆, RJ45-USB, 2.0米，直线",
                Cable.enumCableproductfamily.ScannerHS_Q, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.USB2_0, "2",1);

            Cable BAM02J7 = new Cable(product.enumProductFamily.Cable, "BAM02J7", "BAM MD-VS-005-0005-02C", "Cable, RJ45 to USB, 2.0m, spiral", "线缆, RJ45-USB, 2.0米，螺旋线",
                Cable.enumCableproductfamily.ScannerHS_Q, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.USB2_0, "2",2);
            
            Cable BAM02J4 = new Cable(product.enumProductFamily.Cable, "BAM02J4", "BAM MD-VS-005-0004-02", "Cable, RJ45 to RS232, 2.0m, straight", "线缆, RJ45-RS232, 2.0米，直线",
                Cable.enumCableproductfamily.ScannerHS_Q, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.RS232, "2", 3);

            Cable BAM02J5 = new Cable(product.enumProductFamily.Cable, "BAM02J5", "BAM MD-VS-005-0004-02C", "Cable, RJ45 to RS232, 2.0m, spiral", "线缆, RJ45-RS232, 2.0米，螺旋线",
                Cable.enumCableproductfamily.ScannerHS_Q, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.RS232, "2", 4);

            //Scanner HS-P
            Cable BAM02J0 = new Cable(product.enumProductFamily.Cable, "BAM02J0", "BAM MD-VS-005-0002-02", "Cable, RJ50 to USB, 2.0m, straight", "线缆, RJ50-USB, 2.0米，直线",
                Cable.enumCableproductfamily.ScannerHS_P, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.USB2_0, "2", 5);

            Cable BAM02J1 = new Cable(product.enumProductFamily.Cable, "BAM02J1", "BAM MD-VS-005-0002-03.6C", "Cable, RJ50 to USB, 3.6m, spiral", "线缆, RJ50-USB, 3.6米，螺旋线",
                Cable.enumCableproductfamily.ScannerHS_P, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.USB2_0, "3", 2);

            Cable BAM02J2 = new Cable(product.enumProductFamily.Cable, "BAM02J2", "BAM MD-VS-005-0003-03.6", "Cable, RJ50 to USB, 3.6m, straight", "线缆, RJ50-USB, 3.6米，直线",
                Cable.enumCableproductfamily.ScannerHS_P, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.USB2_0, "3", 5);

            Cable BAM02J3 = new Cable(product.enumProductFamily.Cable, "BAM02J3", "BAM MD-VS-005-0003-02.4C", "Cable, RJ50 to USB, 2.4m, spiral", "线缆, RJ50-USB, 2.4米，螺旋线",
                Cable.enumCableproductfamily.ScannerHS_P, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.USB2_0, "2", 2);

            Cable BAM02HY = new Cable(product.enumProductFamily.Cable, "BAM02HY", "BAM MD-VS-005-0001-01.8", "Cable, RJ50 to RS232, 1.8m, straight", "线缆, RJ50-RS232, 1.8米，直线",
                Cable.enumCableproductfamily.ScannerHS_P, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.RS232, "2", 6);

            Cable BAM02HZ = new Cable(product.enumProductFamily.Cable, "BAM02HZ", "BAM MD-VS-005-0001-02.4C", "Cable, RJ50 to RS232, 2.4m, spiral", "线缆, RJ50-RS232, 2.4米，螺旋线",
                Cable.enumCableproductfamily.ScannerHS_P, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.RS232, "2", 4);

            CableList.Add(BAM02J6);
            CableList.Add(BAM02J7);
            CableList.Add(BAM02J4);
            CableList.Add(BAM02J5);
            CableList.Add(BAM02J0);
            CableList.Add(BAM02J1);
            CableList.Add(BAM02J2);
            CableList.Add(BAM02J3);
            CableList.Add(BAM02HY);
            CableList.Add(BAM02HZ);

            //Vision Sensor Ethernet cable 

            Cable BCC0E7R = new Cable(product.enumProductFamily.Cable, "BCC0E7R", "BCC M415-E834-AG-672-ES64N8-030", "Vision Sensor Ethernet Cable, RJ45-Male 4-pin to M12x1-Female, 5-pin, 3m ", "视觉传感器以太网线缆, RJ45-公头, 4-针 转 M12x1-插口, 直头, 5-针, 3米",
                Cable.enumCableproductfamily.VisionSensor, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.Ethernet, "3", 7);

            Cable BCC0E7T = new Cable(product.enumProductFamily.Cable, "BCC0E7T", "BCC M415-E834-AG-672-ES64N8-050", "Vision Sensor Ethernet Cable, RJ45-Male 4-pin to M12x1-Female, 5-pin, 5m ", "视觉传感器以太网线缆, RJ45-公头, 4-针 转 M12x1-插口, 直头, 5-针, 5米",
                Cable.enumCableproductfamily.VisionSensor, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.Ethernet, "5", 7);

            Cable BCC0E7U = new Cable(product.enumProductFamily.Cable, "BCC0E7U", "BCC M415-E834-AG-672-ES64N8-100", "Vision Sensor Ethernet Cable, RJ45-Male 4-pin to M12x1-Female, 5-pin, 10m", "视觉传感器以太网线缆, RJ45-公头, 4-针 转 M12x1-插口, 直头, 5-针, 10米",
                Cable.enumCableproductfamily.VisionSensor, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.Ethernet, "10", 7);

            Cable BCC0E7W = new Cable(product.enumProductFamily.Cable, "BCC0E7W", "BCC M415-E834-AG-672-ES64N8-150", "Vision Sensor Ethernet Cable, RJ45-Male 4-pin to M12x1-Female, 5-pin, 15m", "视觉传感器以太网线缆, RJ45-公头, 4-针 转 M12x1-插口, 直头, 5-针, 15米",
                Cable.enumCableproductfamily.VisionSensor, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.Ethernet, "15", 7);

            Cable BCC0E7Y = new Cable(product.enumProductFamily.Cable, "BCC0E7Y", "BCC M415-E834-AG-672-ES64N8-200", "Vision Sensor Ethernet Cable, RJ45-Male 4-pin to M12x1-Female, 5-pin, 20m", "视觉传感器以太网线缆, RJ45-公头, 4-针 转 M12x1-插口, 直头, 5-针, 20米",
                Cable.enumCableproductfamily.VisionSensor, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.Ethernet, "20", 7);

            //Vision sensor IO Cable 
            Cable BCC0994 = new Cable(product.enumProductFamily.Cable, "BCC0994", "BCC M418-0000-1A-046-PS0825-020", "Vision Sensor IO cable, M12-Female, 8pin, A coded, 2m ", "视觉传感器IO线缆, M12母头, 8-针, A编码, 2米",
               Cable.enumCableproductfamily.VisionSensor, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO, "2", 8);

            Cable BCC0995 = new Cable(product.enumProductFamily.Cable, "BCC0995", "BCC M418-0000-1A-046-PS0825-050", "Vision Sensor IO cable, M12-Female, 8pin, A coded, 5m ", "视觉传感器IO线缆, M12母头, 8-针, A编码, 5米",
               Cable.enumCableproductfamily.VisionSensor, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO, "5", 8);

            Cable BCC0996 = new Cable(product.enumProductFamily.Cable, "BCC0996", "BCC M418-0000-1A-046-PS0825-100", "Vision Sensor IO cable, M12-Female, 8pin, A coded, 10m ", "视觉传感器IO线缆, M12母头, 8-针, A编码, 10米",
               Cable.enumCableproductfamily.VisionSensor, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO, "10", 8);

            Cable BCC09HL = new Cable(product.enumProductFamily.Cable, "BCC09HL", "BCC M418-0000-1A-046-PS0825-200", "Vision Sensor IO cable, M12-Female, 8pin, A coded, 20m ", "视觉传感器IO线缆, M12母头, 8-针, A编码, 20米",
               Cable.enumCableproductfamily.VisionSensor, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO, "20", 8);

            //Vision sensor Monitor 
            Cable BCC0ANA = new Cable(product.enumProductFamily.Cable, "BCC0ANA", "BCC M415-M415-5D-687-ES64N8-020", "Vision Sensor Monitor ethernet cable, 2m ", "视觉传感器显示器网线, 2米",
               Cable.enumCableproductfamily.Monitor, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.Ethernet, "2", 9);

            Cable BCC0ANC = new Cable(product.enumProductFamily.Cable, "BCC0ANC", "BCC M415-M415-5D-687-ES64N8-050", "Vision Sensor Monitor ethernet cable, 5m ", "视觉传感器显示器网线, 5米",
               Cable.enumCableproductfamily.Monitor, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.Ethernet, "5", 9);

            Cable BCC0E6M = new Cable(product.enumProductFamily.Cable, "BCC0E6M", "BCC M415-0000-1A-003-PX0434-010", "Power cable M12 4-pin connector, open wire cable, 1m, for smart camera power/vision sensor monitor", "电源线缆 M12, 4芯接口, 线缆, 1米, 用于智能相机/视觉传感器显示器",
               Cable.enumCableproductfamily.Monitor, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO, "1", 8);

            Cable BCC032F = new Cable(product.enumProductFamily.Cable, "BCC032F", "BCC M415-0000-1A-003-PX0434-020", "Power cable M12 4-pin connector, open wire cable, 2m, for smart camera power/vision sensor monitor", "电源线缆 M12, 4芯接口, 线缆, 2米, 用于智能相机/视觉传感器显示器",
               Cable.enumCableproductfamily.Monitor, Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO, "2", 8);

            Cable BCC032H = new Cable(product.enumProductFamily.Cable, "BCC032H", "BCC M415-0000-1A-003-PX0434-050", "Power cable M12 4-pin connector, open wire cable, 5m, for smart camera power/vision sensor monitor", "电源线缆 M12, 4芯接口, 线缆, 5米, 用于智能相机/视觉传感器显示器",
               Cable.enumCableproductfamily.Monitor, Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO, "5", 8);

            CableList.Add(BCC0E7R);
            CableList.Add(BCC0E7T);
            CableList.Add(BCC0E7U);
            CableList.Add(BCC0E7W);
            CableList.Add(BCC0E7Y);
            CableList.Add(BCC0994);
            CableList.Add(BCC0995);
            CableList.Add(BCC0996);
            CableList.Add(BCC09HL);
            CableList.Add(BCC0ANA);
            CableList.Add(BCC0ANC);
            CableList.Add(BCC0E6M);
            CableList.Add(BCC032F);
            CableList.Add(BCC032H);

            // Smart Camera Cable 
            
            //Power
            Cable BCC032J = new Cable(product.enumProductFamily.Cable, "BCC032J", "BCC M415-0000-1A-003-PX0434-100", "Power cable M12 4-pin connector, open wire cable, 10m, for smart camera power/vision sensor monitor", "电源线缆 M12, 4芯接口, 线缆, 10米, 用于智能相机/视觉传感器显示器",
               Cable.enumCableproductfamily.Monitor, Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO, "10", 8);

            Cable BCC06TR = new Cable(product.enumProductFamily.Cable, "BCC06TR", "BCC M415-0000-1A-003-PX0434-200", "Power cable M12 4-pin connector, open wire cable, 20m, for smart camera power/vision sensor monitor", "电源线缆 M12, 4芯接口, 线缆, 20米, 用于智能相机/视觉传感器显示器",
               Cable.enumCableproductfamily.Monitor, Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO, "20", 8);
            
            //ETHERNET
            Cable BCC0HZK = new Cable(product.enumProductFamily.Cable, "BCC0HZK", "BCC M418-E818-8X0-723-PS58N9-020", "Ethernet cable M12 8-pin X-coded to RJ45, 2m, for smart camera/smart camera lite/Gige industrial camera", "以太网线缆M12, 8芯, X编码转RJ45接口, 2米, 用于智能相机/智能相机精简版/GIGE相机",
               Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.SmartCameraLite, Cable.enumCableproductfamily.GIGE_Camera, Cable.enumCableInterface.GIGE, "2", 10);

            Cable BCC0HZL = new Cable(product.enumProductFamily.Cable, "BCC0HZL", "BCC M418-E818-8X0-723-PS58N9-050", "Ethernet cable M12 8-pin X-coded to RJ45, 5m, for smart camera/smart camera lite/Gige industrial camera", "以太网线缆M12, 8芯, X编码转RJ45接口, 5米, 用于智能相机/智能相机精简版/GIGE相机",
              Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.SmartCameraLite, Cable.enumCableproductfamily.GIGE_Camera, Cable.enumCableInterface.GIGE, "5", 10);

            Cable BCC0HZM = new Cable(product.enumProductFamily.Cable, "BCC0HZM", "BCC M418-E818-8X0-723-PS58N9-100", "Ethernet cable M12 8-pin X-coded to RJ45, 10m, for smart camera/smart camera lite/Gige industrial camera", "以太网线缆M12, 8芯, X编码转RJ45接口, 10米, 用于智能相机/智能相机精简版/GIGE相机",
              Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.SmartCameraLite, Cable.enumCableproductfamily.GIGE_Camera, Cable.enumCableInterface.GIGE, "10", 10);

            Cable BCC0JAE = new Cable(product.enumProductFamily.Cable, "BCC0JAE", "BCC M418-E818-8X0-723-PS58N9-200", "Ethernet cable M12 8-pin X-coded to RJ45, 20m, for smart camera/smart camera lite/Gige industrial camera", "以太网线缆M12, 8芯, X编码转RJ45接口, 10米, 用于智能相机/智能相机精简版/GIGE相机",
              Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.SmartCameraLite, Cable.enumCableproductfamily.GIGE_Camera, Cable.enumCableInterface.GIGE, "20", 10);

            //Profinet
            Cable BCC0JF0 = new Cable(product.enumProductFamily.Cable, "BCC0JF0", "BCC M414-E834-8G-668-PS54N2-020", "Profinet cable M12 4-pin D-coded to RJ45, 2m, for smart camera", "Profinet 线缆 M12, 4芯, D编码转RJ45接口, 2米, 用于智能相机",
             Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.Fieldbus, "2", 11);

            Cable BCC0JF2 = new Cable(product.enumProductFamily.Cable, "BCC0JF2", "BCC M414-E834-8G-668-PS54N2-050", "Profinet cable M12 4-pin D-coded to RJ45, 5m, for smart camera", "Profinet 线缆 M12, 4芯, D编码转RJ45接口, 5米, 用于智能相机",
             Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.Fieldbus, "5", 11);

            Cable BCC0JF3 = new Cable(product.enumProductFamily.Cable, "BCC0JF3", "BCC M414-E834-8G-668-PS54N2-100", "Profinet cable M12 4-pin D-coded to RJ45, 10m, for smart camera", "Profinet 线缆 M12, 4芯, D编码转RJ45接口, 10米, 用于智能相机",
             Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.Fieldbus, "10", 11);

            Cable BCC0JF5 = new Cable(product.enumProductFamily.Cable, "BCC0JF5", "BCC M414-E834-8G-668-PS54N2-200", "Profinet cable M12 4-pin D-coded to RJ45, 20m, for smart camera", "Profinet 线缆 M12, 4芯, D编码转RJ45接口, 20米, 用于智能相机",
             Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.Fieldbus, "20", 11);

            Cable BCC0E90 = new Cable(product.enumProductFamily.Cable, "BCC0E90", "BCC M414-E894-8G-672-ES64N9-020", "EtherNet/IP cable M12 4-pin D-coded to RJ45, 2m, for smart camera", "EtherNet/IP 线缆 M12, 4芯, D编码转RJ45接口, 2米, 用于智能相机",
            Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.Fieldbus, "2", 13);

            Cable BCC0E8Z = new Cable(product.enumProductFamily.Cable, "BCC0E8Z", "BCC M414-E894-8G-672-ES64N9-050", "EtherNet/IP cable M12 4-pin D-coded to RJ45, 5m, for smart camera", "EtherNet/IP 线缆 M12, 4芯, D编码转RJ45接口, 5米, 用于智能相机",
           Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.Fieldbus, "5", 13);

            Cable BCC0E8P = new Cable(product.enumProductFamily.Cable, "BCC0E8P", "BCC M414-E894-8G-672-ES64N9-100", "EtherNet/IP cable M12 4-pin D-coded to RJ45, 10m, for smart camera", "EtherNet/IP 线缆 M12, 4芯, D编码转RJ45接口, 10米, 用于智能相机",
           Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.Fieldbus, "10", 13);

            Cable BCC0E8U = new Cable(product.enumProductFamily.Cable, "BCC0E8U", "BCC M414-E894-8G-672-ES64N9-200", "EtherNet/IP cable M12 4-pin D-coded to RJ45, 20m, for smart camera", "EtherNet/IP 线缆 M12, 4芯, D编码转RJ45接口, 20米, 用于智能相机",
           Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.Fieldbus, "20", 13);



            //IO-LINK

            Cable BCC039K = new Cable(product.enumProductFamily.Cable, "BCC039K", "BCC M415-M414-3A-304-PX0434-010", "IO-Link cable M12x1-Female 5-pin to M12x1-Male 5-pin, 1m, for smart camera", "IO-Link线缆 M12公头5芯转M12母头5芯, 1米, 用于智能相机",
             Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO_Link, "1", 12);

            Cable BCC039M = new Cable(product.enumProductFamily.Cable, "BCC039M", "BCC M415-M414-3A-304-PX0434-020", "IO-Link cable M12x1-Female 5-pin to M12x1-Male 5-pin, 2m, for smart camera", "IO-Link线缆 M12公头5芯转M12母头5芯, 2米, 用于智能相机",
             Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO_Link, "2", 12);

            Cable BCC039P = new Cable(product.enumProductFamily.Cable, "BCC039P", "BCC M415-M414-3A-304-PX0434-050", "IO-Link cable M12x1-Female 5-pin to M12x1-Male 5-pin, 5m, for smart camera", "IO-Link线缆 M12公头5芯转M12母头5芯, 5米, 用于智能相机",
            Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO_Link, "5", 12);

            Cable BCC06WR = new Cable(product.enumProductFamily.Cable, "BCC06WR", "BCC M415-M414-3A-304-PX0434-100", "IO-Link cable M12x1-Female 5-pin to M12x1-Male 5-pin, 10m, for smart camera", "IO-Link线缆 M12公头5芯转M12母头5芯, 10米, 用于智能相机",
            Cable.enumCableproductfamily.SmartCamera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO_Link, "10", 12);

            CableList.Add(BCC032J);
            CableList.Add(BCC06TR);
            CableList.Add(BCC0HZK);
            CableList.Add(BCC0HZL);
            CableList.Add(BCC0HZM);
            CableList.Add(BCC0JAE);
            CableList.Add(BCC0JF0);
            CableList.Add(BCC0JF2);
            CableList.Add(BCC0JF3);
            CableList.Add(BCC0JF5);
            CableList.Add(BCC039K);
            CableList.Add(BCC039M);
            CableList.Add(BCC039P);
            CableList.Add(BCC06WR);
            CableList.Add(BCC0E90);
            CableList.Add(BCC0E8Z);
            CableList.Add(BCC0E8P);
            CableList.Add(BCC0E8U);


            //Smartcamera Lite 

            //IO
            Cable BCC0KE5 = new Cable(product.enumProductFamily.Cable, "BCC0KE5", "BCC M41C-0000-1A-169-PS0C25-010-C009", "IO cable M12x1-Female, 12-pin, open wire cable, 1m, for smart camera lite IO/GIGE industrial camera IO", "IO线缆 M12母头, 12芯接口, 线缆, 1米, 用于智能相机精简版/GIGE工业相机",
               Cable.enumCableproductfamily.SmartCameraLite, Cable.enumCableproductfamily.GIGE_Camera, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO, "1", 8);

            Cable BCC0KE6 = new Cable(product.enumProductFamily.Cable, "BCC0KE6", "BCC M41C-0000-1A-169-PS0C25-020-C009", "IO cable M12x1-Female, 12-pin, open wire cable, 2m, for smart camera lite IO/GIGE industrial camera IO", "IO线缆 M12母头, 12芯接口, 线缆, 2米, 用于智能相机精简版/GIGE工业相机",
              Cable.enumCableproductfamily.SmartCameraLite, Cable.enumCableproductfamily.GIGE_Camera, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO, "2", 8);

            Cable BCC0JCN = new Cable(product.enumProductFamily.Cable, "BCC0JCN", "BCC M41C-0000-1A-169-PS0C25-050-C009", "IO cable M12x1-Female, 12-pin, open wire cable, 5m, for smart camera lite IO/GIGE industrial camera IO", "IO线缆 M12母头, 12芯接口, 线缆, 5米, 用于智能相机精简版/GIGE工业相机",
              Cable.enumCableproductfamily.SmartCameraLite, Cable.enumCableproductfamily.GIGE_Camera, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO, "5", 8);

            Cable BCC0JCP = new Cable(product.enumProductFamily.Cable, "BCC0JCP", "BCC M41C-0000-1A-169-PS0C25-100-C009", "IO cable M12x1-Female, 12-pin, open wire cable, 10m, for smart camera lite IO/GIGE industrial camera IO", "IO线缆 M12母头, 12芯接口, 线缆, 10米, 用于智能相机精简版/GIGE工业相机",
             Cable.enumCableproductfamily.SmartCameraLite, Cable.enumCableproductfamily.GIGE_Camera, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO, "10", 8);

            CableList.Add(BCC0KE5);
            CableList.Add(BCC0KE6);
            CableList.Add(BCC0JCN);
            CableList.Add(BCC0JCP);


            //USB3 Industrial Camera

            //USB3 cable 
            Cable BCC0KL9 = new Cable(product.enumProductFamily.Cable, "BCC0KL9", "BCC U0AA-U019-90-736-Z19004-010", "USB 3.0 Micro-B to USB3.0 A, 1m, for USB3.0 industrial camera", "USB3.0线缆, MicroB接口转USB A, 1米, 用于USB3.0工业相机",
               Cable.enumCableproductfamily.USB3_Camera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.USB3_0, "1", 14);

            Cable BCC0KLA = new Cable(product.enumProductFamily.Cable, "BCC0KLA", "BCC U0AA-U019-90-736-Z19004-030", "USB 3.0 Micro-B to USB3.0 A, 3m, for USB3.0 industrial camera", "USB3.0线缆, MicroB接口转USB A, 3米, 用于USB3.0工业相机",
              Cable.enumCableproductfamily.USB3_Camera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.USB3_0, "3", 14);

            Cable BCC0KLC = new Cable(product.enumProductFamily.Cable, "BCC0KLC", "BCC U0AA-U019-90-736-Z19004-050", "USB 3.0 Micro-B to USB3.0 A, 5m, for USB3.0 industrial camera", "USB3.0线缆, MicroB接口转USB A, 5米, 用于USB3.0工业相机",
              Cable.enumCableproductfamily.USB3_Camera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.USB3_0, "5", 14);

            //IO cable
            Cable BCC0KL6 = new Cable(product.enumProductFamily.Cable, "BCC0KL6", "BCC Z032-0000-10-148-VS0CT4-050", "IO cable Hirose Connector, 12-pin, open wire cable, 5m, for USB3.0 industrial camera", "IO线缆, 广濑连接器, 12芯, 5米, 用于USB3.0工业相机",
              Cable.enumCableproductfamily.USB3_Camera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO, "5", 15);

            Cable BCC0KL7 = new Cable(product.enumProductFamily.Cable, "BCC0KL7", "BCC Z032-0000-10-148-VS0CT4-100", "IO cable Hirose Connector, 12-pin, open wire cable, 10m, for USB3.0 industrial camera", "IO线缆, 广濑连接器, 12芯, 10米, 用于USB3.0工业相机",
              Cable.enumCableproductfamily.USB3_Camera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO, "10", 15);

            Cable BCC0KL8 = new Cable(product.enumProductFamily.Cable, "BCC0KL8", "BCC Z032-0000-10-148-VS0CT4-200", "IO cable Hirose Connector, 12-pin, open wire cable, 20m, for USB3.0 industrial camera", "IO线缆, 广濑连接器, 12芯, 20米, 用于USB3.0工业相机",
              Cable.enumCableproductfamily.USB3_Camera, Cable.enumCableproductfamily.None, Cable.enumCableproductfamily.None, Cable.enumCableInterface.IO, "20", 15);

            CableList.Add(BCC0KL9);
            CableList.Add(BCC0KLA);
            CableList.Add(BCC0KLC);
            CableList.Add(BCC0KL6);
            CableList.Add(BCC0KL7);
            CableList.Add(BCC0KL8);


        }

        public void InitScanner()
        {
            Scanner BVS001W = new Scanner(Scanner.enumScannerFamily.ScannerHS_Q, product.enumProductFamily.Scanner, "BVS001W", "BVS HS-QC-SDR-MA-01-01",
            "BVS HS-Q cabled handheld readers read all common 1D, 2D code, red LED illuminant lighting, blue LED illuminant aimer IP40",
            "BVS HS-Q 有线手持阅读器读取所有常见的1D、2D代码，红色LED光源照明，蓝色LED光源标靶", Scanner.enumCableConnection.All, Scanner.enumCodeFunction.Papier,
                                           "Cable", false,true,false,false,1);
            Scanner BVS0020 = new Scanner(Scanner.enumScannerFamily.ScannerHS_Q, product.enumProductFamily.Scanner,"BVS0020", "BVS HS-QB-SDR-MA-01-02",
                "BVS HS-Q bluetooth handheld readers read all common 1D, 2D code, red LED illuminant lighting, blue LED illuminant aimer, with USB cable",
                "BVS HS-Q 无线蓝牙手持阅读器读取所有常见的1D、2D代码，红色LED光源照明，蓝色LED光源标靶，带USB线缆", Scanner.enumCableConnection.USB, Scanner.enumCodeFunction.Papier,
                                            "Bluetooth", false, false, false, true,  2);
            Scanner BVS0021 = new Scanner(Scanner.enumScannerFamily.ScannerHS_Q, product.enumProductFamily.Scanner,"BVS0021", "BVS HS-QB-SDR-MA-01-03",
                "BVS HS-Q bluetooth handheld readers read all common 1D, 2D code, red LED illuminant lighting, blue LED illuminant aimer, with RS232 cable",
                "BVS HS-Q 无线蓝牙手持阅读器读取所有常见的1D、2D代码，红色LED光源照明，蓝色LED光源标靶，带RS232线缆", Scanner.enumCableConnection.RS232, Scanner.enumCodeFunction.Papier,
                                            "Bluetooth", false, false, false, true,  2);
            Scanner BVS001U = new Scanner(Scanner.enumScannerFamily.ScannerHS_P, product.enumProductFamily.Scanner,"BVS001U", "BVS HS-PC-HDW-MA-01",
                "BVS HS-P cabled papier code handheld barcode readers read all 2D, 1D and stacked barcodes fast and reliably, white LED, red laser class 2, IP65 ",
                "BVS HS-P有线纸码手持条形码阅读器能快速和可靠的读取所有常见的2D、1D和堆叠条形码，白色LED光源照明，红色激光标靶，IP65", Scanner.enumCableConnection.All, Scanner.enumCodeFunction.Papier,
                                            "Cable", true, true, false, false,  3);
            Scanner BVS001T = new Scanner(Scanner.enumScannerFamily.ScannerHS_P, product.enumProductFamily.Scanner,"BVS001T", "BVS HS-PC-DPW-MA-01",
                "BVS HS-P cabled DPM code handheld barcode readers read all 2D, 1D and stacked barcodes fast and reliably, white LED, red laser class 2, IP65",
                "BVS HS-P有线DPM码手持条形码阅读器能快速和可靠的读取所有常见的2D、1D和堆叠条形码，白色LED光源照明，红色激光标靶，IP65", Scanner.enumCableConnection.All, Scanner.enumCodeFunction.DPM,
                                            "Cable", true, true, false, false,  3);
            Scanner BVS001Y = new Scanner(Scanner.enumScannerFamily.ScannerHS_P, product.enumProductFamily.Scanner,"BVS001Y", "BVS HS-PB-HDW-MZ-01",
                "BVS HS-P bluetooth papier code handheld barcode readers read all 2D, 1D and stacked barcodes fast and reliably, white LED, red laser class 2, IP65",
                "BVS HS-P蓝牙纸码手持条形码阅读器能快速和可靠的读取所有常见的2D、1D和堆叠条形码，白色LED光源照明，红色激光标靶，IP65", Scanner.enumCableConnection.All, Scanner.enumCodeFunction.Papier,
                                            "Bluetooth", true, true, true, true,  4);
            Scanner BVS001Z = new Scanner(Scanner.enumScannerFamily.ScannerHS_P, product.enumProductFamily.Scanner,"BVS001Z", "BVS HS-PB-DPW-MZ-01",
                "BVS HS-P bluetooth DPM code handheld barcode readers read all 2D, 1D and stacked barcodes fast and reliably, white LED, red laser class 2, IP65",
                "BVS HS-P蓝牙DPM码手持条形码阅读器能快速和可靠的读取所有常见的2D、1D和堆叠条形码，白色LED光源照明，红色激光标靶，IP65", Scanner.enumCableConnection.All, Scanner.enumCodeFunction.DPM,
                                            "Bluetooth", true, true, true, true,  4);
            

            ScannerList.Add(BVS001W);
            ScannerList.Add(BVS0020);
            ScannerList.Add(BVS0021);
            ScannerList.Add(BVS001U);
            ScannerList.Add(BVS001T);
            ScannerList.Add(BVS001Y);
            ScannerList.Add(BVS001Z);
        
        }

        public void InitVisionSensor()
        {
            //Vision Sensor Identification
            VisionSensor BVS001R = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS001R", "BVS ID-3-005-E", "Vision sensor Identification, red light, focus 6mm", "视觉传感器识别型, 红光，6mm焦距",
                VisionSensor.enumVisionSensorModel.Ident, VisionSensor.enumVisionSensorLight.Red, VisionSensor.enumVisionSensorFocus.F6mm, 1);

            VisionSensor BVS0001 = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS0001", "BVS ID-3-001-E", "Vision sensor Identification, red light, focus 8mm", "视觉传感器识别型, 红光，8mm焦距",
                VisionSensor.enumVisionSensorModel.Ident, VisionSensor.enumVisionSensorLight.Red, VisionSensor.enumVisionSensorFocus.F8mm, 1);

            VisionSensor BVS000T = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS000T", "BVS ID-3-003-E", "Vision sensor Identification, red light, focus 12mm", "视觉传感器识别型, 红光，12mm焦距",
               VisionSensor.enumVisionSensorModel.Ident, VisionSensor.enumVisionSensorLight.Red, VisionSensor.enumVisionSensorFocus.F12mm, 1);

            VisionSensor BVS000Y = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS000Y", "BVS ID-3-007-E", "Vision sensor Identification, red light, focus 16mm", "视觉传感器识别型, 红光，16mm焦距",
              VisionSensor.enumVisionSensorModel.Ident, VisionSensor.enumVisionSensorLight.Red, VisionSensor.enumVisionSensorFocus.F16mm, 1);

            VisionSensor BVS001C = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS001C", "BVS ID-3-105-E", "Vision sensor Identification, IR light, focus 6mm", "视觉传感器识别型, 红外光，6mm焦距",
              VisionSensor.enumVisionSensorModel.Ident, VisionSensor.enumVisionSensorLight.IR, VisionSensor.enumVisionSensorFocus.F6mm, 1);

            VisionSensor BVS0019 = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS0019", "BVS ID-3-101-E", "Vision sensor Identification, IR light, focus 8mm", "视觉传感器识别型, 红外光，8mm焦距",
             VisionSensor.enumVisionSensorModel.Ident, VisionSensor.enumVisionSensorLight.IR, VisionSensor.enumVisionSensorFocus.F8mm, 1);

            VisionSensor BVS001A = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS001A", "BVS ID-3-103-E", "Vision sensor Identification, IR light, focus 12mm", "视觉传感器识别型, 红外光，12mm焦距",
             VisionSensor.enumVisionSensorModel.Ident, VisionSensor.enumVisionSensorLight.IR, VisionSensor.enumVisionSensorFocus.F12mm, 1);

            VisionSensor BVS001E = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS001E", "BVS ID-3-107-E", "Vision sensor Identification, IR light, focus 16mm", "视觉传感器识别型, 红外光，16mm焦距",
            VisionSensor.enumVisionSensorModel.Ident, VisionSensor.enumVisionSensorLight.IR, VisionSensor.enumVisionSensorFocus.F16mm, 1);

            VisionSensorList.Add(BVS001R);
            VisionSensorList.Add(BVS0001);
            VisionSensorList.Add(BVS000T);
            VisionSensorList.Add(BVS000Y);
            VisionSensorList.Add(BVS001C);
            VisionSensorList.Add(BVS0019);
            VisionSensorList.Add(BVS001A);
            VisionSensorList.Add(BVS001E);

            //Vision Sensor Standard
            VisionSensor BVS000E = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS000E", "BVS OI-3-005-E", "Vision sensor Standard, red light, focus 6mm", "视觉传感器标准型, 红光，6mm焦距",
                VisionSensor.enumVisionSensorModel.Standard, VisionSensor.enumVisionSensorLight.Red, VisionSensor.enumVisionSensorFocus.F6mm, 1);

            VisionSensor BVS0003 = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS0003", "BVS OI-3-001-E", "Vision sensor Standard, red light, focus 8mm", "视觉传感器标准型, 红光，8mm焦距",
                VisionSensor.enumVisionSensorModel.Standard, VisionSensor.enumVisionSensorLight.Red, VisionSensor.enumVisionSensorFocus.F8mm, 1);

            VisionSensor BVS0005 = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS0005", "BVS OI-3-003-E", "Vision sensor Standard, red light, focus 12mm", "视觉传感器标准型, 红光，12mm焦距",
               VisionSensor.enumVisionSensorModel.Standard, VisionSensor.enumVisionSensorLight.Red, VisionSensor.enumVisionSensorFocus.F12mm, 1);
 
            VisionSensor BVS0013 = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS0013", "BVS OI-3-105-E", "Vision sensor Standard, IR light, focus 6mm", "视觉传感器标准型, 红外光，6mm焦距",
              VisionSensor.enumVisionSensorModel.Standard, VisionSensor.enumVisionSensorLight.IR, VisionSensor.enumVisionSensorFocus.F6mm, 1);

            VisionSensor BVS0014 = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS0014", "BVS OI-3-101-E", "Vision sensor Standard, IR light, focus 8mm", "视觉传感器标准型, 红外光，8mm焦距",
             VisionSensor.enumVisionSensorModel.Standard, VisionSensor.enumVisionSensorLight.IR, VisionSensor.enumVisionSensorFocus.F8mm, 1);

            VisionSensor BVS0012 = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS0012", "BVS OI-3-103-E", "Vision sensor Standard, IR light, focus 12mm", "视觉传感器标准型, 红外光，12mm焦距",
             VisionSensor.enumVisionSensorModel.Standard, VisionSensor.enumVisionSensorLight.IR, VisionSensor.enumVisionSensorFocus.F12mm, 1);

            VisionSensorList.Add(BVS000E);
            VisionSensorList.Add(BVS0003);
            VisionSensorList.Add(BVS0005);
            VisionSensorList.Add(BVS0013);
            VisionSensorList.Add(BVS0014);
            VisionSensorList.Add(BVS0012);

            //Vision Sensor Advanced
            VisionSensor BVS000L = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS000L", "BVS OI-3-055-E", "Vision sensor Advanced, red light, focus 6mm", "视觉传感器增强型, 红光，6mm焦距",
                VisionSensor.enumVisionSensorModel.Advanced, VisionSensor.enumVisionSensorLight.Red, VisionSensor.enumVisionSensorFocus.F6mm, 1);

            VisionSensor BVS000J = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS000J", "BVS OI-3-051-E", "Vision sensor Advanced, red light, focus 8mm, 360°pattern match", "视觉传感器增强型, 红光，8mm焦距, 360°模板匹配",
                VisionSensor.enumVisionSensorModel.Advanced, VisionSensor.enumVisionSensorLight.Red, VisionSensor.enumVisionSensorFocus.F8mm, 1);

            VisionSensor BVS000F = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS000F", "BVS OI-3-091-E", "Vision sensor Advanced, red light, focus 8mm,", "视觉传感器增强型, 红光，8mm焦距",
               VisionSensor.enumVisionSensorModel.Advanced, VisionSensor.enumVisionSensorLight.Red, VisionSensor.enumVisionSensorFocus.F8mm, 1);

            VisionSensor BVS000K = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS000K", "BVS OI-3-053-E", "Vision sensor Advanced, red light, focus 12mm，360°pattern match", "视觉传感器增强型, 红光，6mm焦距，360°模板匹配",
                VisionSensor.enumVisionSensorModel.Advanced, VisionSensor.enumVisionSensorLight.Red, VisionSensor.enumVisionSensorFocus.F12mm, 1);

            VisionSensor BVS000H = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS000H", "BVS OI-3-093-E", "Vision sensor Advanced, red light, focus 12mm", "视觉传感器增强型, 红光，12mm焦距",
                VisionSensor.enumVisionSensorModel.Advanced, VisionSensor.enumVisionSensorLight.Red, VisionSensor.enumVisionSensorFocus.F12mm, 1);

            VisionSensor BVS000W = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS000W", "BVS OI-3-057-E", "Vision sensor Advanced, red light, focus 16mm, 360°pattern match", "视觉传感器增强型, 红光，8mm焦距，360°模板匹配",
               VisionSensor.enumVisionSensorModel.Advanced, VisionSensor.enumVisionSensorLight.Red, VisionSensor.enumVisionSensorFocus.F16mm, 1);

            VisionSensor BVS0016 = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS0016", "BVS OI-3-155-E", "Vision sensor Advanced, IR light, focus 6mm, 360°pattern match", "视觉传感器增强型, 红外光，6mm焦距，360°模板匹配",
              VisionSensor.enumVisionSensorModel.Advanced, VisionSensor.enumVisionSensorLight.IR, VisionSensor.enumVisionSensorFocus.F6mm, 1);

            VisionSensor BVS0015 = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS0015", "BVS OI-3-151-E", "Vision sensor Advanced, IR light, focus 8mm, 360°pattern match", "视觉传感器增强型, 红外光，8mm焦距，360°模板匹配",
             VisionSensor.enumVisionSensorModel.Advanced, VisionSensor.enumVisionSensorLight.IR, VisionSensor.enumVisionSensorFocus.F8mm, 1);

            VisionSensor BVS0017 = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS0017", "BVS OI-3-153-E", "Vision sensor Advanced, IR light, focus 12mm, 360°pattern match", "视觉传感器增强型, 红外光，12mm焦距，360°模板匹配",
             VisionSensor.enumVisionSensorModel.Advanced, VisionSensor.enumVisionSensorLight.IR, VisionSensor.enumVisionSensorFocus.F12mm, 1);

            VisionSensor BVS0018 = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS0018", "BVS OI-3-157-E", "Vision sensor Advanced, IR light, focus 16mm, 360°pattern match", "视觉传感器增强型, 红外光，16mm焦距，360°模板匹配",
             VisionSensor.enumVisionSensorModel.Advanced, VisionSensor.enumVisionSensorLight.IR, VisionSensor.enumVisionSensorFocus.F16mm, 1);

            VisionSensorList.Add(BVS000L);
            VisionSensorList.Add(BVS000J);
            VisionSensorList.Add(BVS000F);
            VisionSensorList.Add(BVS000K);
            VisionSensorList.Add(BVS000H);
            VisionSensorList.Add(BVS000W);
            VisionSensorList.Add(BVS0016);
            VisionSensorList.Add(BVS0015);
            VisionSensorList.Add(BVS0017);
            VisionSensorList.Add(BVS0018);

            //Vision Sensor Universal
            VisionSensor BVS001L = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS001L", "BVS UR-3-005-E", "Vision sensor Universal, red light, focus 6mm", "视觉传感器通用型, 红光，6mm焦距",
                VisionSensor.enumVisionSensorModel.Universal, VisionSensor.enumVisionSensorLight.Red, VisionSensor.enumVisionSensorFocus.F6mm, 1);

            VisionSensor BVS001M = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS001M", "BVS UR-3-001-E", "Vision sensor Universal, red light, focus 8mm", "视觉传感器通用型, 红光，8mm焦距",
               VisionSensor.enumVisionSensorModel.Universal, VisionSensor.enumVisionSensorLight.Red, VisionSensor.enumVisionSensorFocus.F8mm, 1);

            VisionSensor BVS001N = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS001N", "BVS UR-3-003-E", "Vision sensor Universal, red light, focus 12mm", "视觉传感器通用型, 红光，12mm焦距",
               VisionSensor.enumVisionSensorModel.Universal, VisionSensor.enumVisionSensorLight.Red, VisionSensor.enumVisionSensorFocus.F12mm, 1);

            VisionSensor BVS001P = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS001P", "BVS UR-3-007-E", "Vision sensor Universal, red light, focus 16mm", "视觉传感器通用型, 红光，16mm焦距",
              VisionSensor.enumVisionSensorModel.Universal, VisionSensor.enumVisionSensorLight.Red, VisionSensor.enumVisionSensorFocus.F16mm, 1);

            VisionSensor BVS001F = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS001F", "BVS UR-3-105-E", "Vision sensor Universal, IR light, focus 6mm", "视觉传感器通用型, 红外光，6mm焦距",
              VisionSensor.enumVisionSensorModel.Universal, VisionSensor.enumVisionSensorLight.IR, VisionSensor.enumVisionSensorFocus.F6mm, 1);

            VisionSensor BVS001H = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS001H", "BVS UR-3-101-E", "Vision sensor Universal, IR light, focus 8mm", "视觉传感器通用型, 红外光，8mm焦距",
             VisionSensor.enumVisionSensorModel.Universal, VisionSensor.enumVisionSensorLight.IR, VisionSensor.enumVisionSensorFocus.F8mm, 1);

            VisionSensor BVS001J = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS001J", "BVS UR-3-103-E", "Vision sensor Universal, IR light, focus 12mm", "视觉传感器通用型, 红外光，12mm焦距",
             VisionSensor.enumVisionSensorModel.Universal, VisionSensor.enumVisionSensorLight.IR, VisionSensor.enumVisionSensorFocus.F12mm, 1);

            VisionSensor BVS001K = new VisionSensor(product.enumProductFamily.VisionSensor, "BVS001K", "BVS UR-3-107-E", "Vision sensor Universal, IR light, focus 16mm", "视觉传感器通用型, 红外光，16mm焦距",
            VisionSensor.enumVisionSensorModel.Universal, VisionSensor.enumVisionSensorLight.IR, VisionSensor.enumVisionSensorFocus.F16mm, 1);

            VisionSensorList.Add(BVS001L);
            VisionSensorList.Add(BVS001M);
            VisionSensorList.Add(BVS001N);
            VisionSensorList.Add(BVS001P);
            VisionSensorList.Add(BVS001F);
            VisionSensorList.Add(BVS001H);
            VisionSensorList.Add(BVS001J);
            VisionSensorList.Add(BVS001K);


        }

        public void InitSmartCamera()
        {
            //Smart camera lite
            SmartCamera BVS003U = new SmartCamera(product.enumProductFamily.SmartCamera, "BVS003U", "BVS SL-M1280Z00-07-001", "Smart camera lite, track funtion, monochrome, 1.3MP, TCP, RS232 and digital IO",
                "智能相机精简版，追溯功能，130万像素，黑白，RS232，TCP，IO接口", SmartCamera.enumSmartCameraFunction.Track,SmartCamera.enumSmartCameraColor.Mono,SmartCamera.enumSmartCameraInterface.RS232, 1);

            SmartCamera BVS003R = new SmartCamera(product.enumProductFamily.SmartCamera, "BVS003R", "BVS SL-C1280Z00-30-001", "Smart camera lite, track funtion, color, 1.3MP, TCP, RS232 and digital IO",
                "智能相机精简版，追溯功能，130万像素，彩色，RS232，TCP，IO接口", SmartCamera.enumSmartCameraFunction.Track, SmartCamera.enumSmartCameraColor.Color, SmartCamera.enumSmartCameraInterface.RS232, 1);

            SmartCamera BVS003W = new SmartCamera(product.enumProductFamily.SmartCamera, "BVS003W", "BVS SL-M1280Z00-07-010", "Smart camera lite, identification funtion, monochrome, 1.3MP, TCP, RS232 and digital IO",
               "智能相机精简版，识别功能，130万像素，黑白，RS232，TCP，IO接口", SmartCamera.enumSmartCameraFunction.Ident, SmartCamera.enumSmartCameraColor.Mono, SmartCamera.enumSmartCameraInterface.RS232, 1);

            SmartCamera BVS003T = new SmartCamera(product.enumProductFamily.SmartCamera, "BVS003T", "BVS SL-M1280Z00-07-000", "Smart camera lite, standard funtion, monochrome, 1.3MP, TCP, RS232 and digital IO",
               "智能相机精简版，标准功能，130万像素，黑白，RS232，TCP，IO接口", SmartCamera.enumSmartCameraFunction.Standard, SmartCamera.enumSmartCameraColor.Mono, SmartCamera.enumSmartCameraInterface.RS232, 1);

            SmartCamera BVS003P = new SmartCamera(product.enumProductFamily.SmartCamera, "BVS003P", "BVS SL-C1280Z00-07-000", "Smart camera lite, standard funtion, color, 1.3MP, TCP, RS232 and digital IO",
               "智能相机精简版，标准功能，130万像素，彩色，RS232，TCP，IO接口", SmartCamera.enumSmartCameraFunction.Standard, SmartCamera.enumSmartCameraColor.Color, SmartCamera.enumSmartCameraInterface.RS232, 1);

            SmartCameraList.Add(BVS003U);
            SmartCameraList.Add(BVS003R);
            SmartCameraList.Add(BVS003W);
            SmartCameraList.Add(BVS003T);
            SmartCameraList.Add(BVS003P);

            //Smart camera full

            SmartCamera BVS002A = new SmartCamera(product.enumProductFamily.SmartCamera, "BVS002A", "BVS SC-M1280Z00-30-000", "Smart camera, standard funtion, monochrome, 1.3MP, TCP, Fieldbus, digital IO and IO-Link",
                "智能相机，标准功能，130万像素，黑白，总线Profinet，EthernetIP，TCP，IO和IO-Link接口", SmartCamera.enumSmartCameraFunction.Standard, SmartCamera.enumSmartCameraColor.Mono, SmartCamera.enumSmartCameraInterface.Fieldbus, 2);

            SmartCamera BVS0029 = new SmartCamera(product.enumProductFamily.SmartCamera, "BVS0029", "BVS SC-M1280Z00-30-010", "Smart camera, identification funtion, monochrome, 1.3MP, TCP, Fieldbus, digital IO and IO-Link",
                "智能相机，识别功能，130万像素，黑白，总线Profinet，EthernetIP，TCP，IO和IO-Link接口", SmartCamera.enumSmartCameraFunction.Ident, SmartCamera.enumSmartCameraColor.Mono, SmartCamera.enumSmartCameraInterface.Fieldbus, 2);

            SmartCamera BVS002F= new SmartCamera(product.enumProductFamily.SmartCamera, "BVS002F", "BVS SC-C1280Z00-30-000", "Smart camera, identification funtion, color, 1.3MP, TCP, Fieldbus, digital IO and IO-Link",
                "智能相机，识别功能，130万像素，彩色，总线Profinet，EthernetIP，TCP，IO和IO-Link接口", SmartCamera.enumSmartCameraFunction.Standard, SmartCamera.enumSmartCameraColor.Color, SmartCamera.enumSmartCameraInterface.Fieldbus, 2);

            SmartCamera BVS0033 = new SmartCamera(product.enumProductFamily.SmartCamera, "BVS0033", "BVS SC-M1280Z00-30-020", "Smart camera, Halcon Script funtion, monochrome, 1.3MP, TCP, Fieldbus, digital IO and IO-Link",
               "智能相机，附带Halcon脚本功能，130万像素，黑白，总线Profinet，EthernetIP，TCP，IO和IO-Link接口", SmartCamera.enumSmartCameraFunction.HalconScript, SmartCamera.enumSmartCameraColor.Mono, SmartCamera.enumSmartCameraInterface.Fieldbus, 2);

            SmartCameraList.Add(BVS002A);
            SmartCameraList.Add(BVS0029);
            SmartCameraList.Add(BVS002F);
            SmartCameraList.Add(BVS0033);

        }

        public void InitLens()
        {
            
            //////////////////////////////////////////////////////
            ///理光镜头
            ///

            Lens BAM029R = new Lens(product.enumProductFamily.Lens, "BAM029R", "BAM LS-VS-004-C2/3-0614-2", "RICOH lens: C-Mount, 6mm focal length, 2/3 inch, Thread=30mm, L=37.5mm",
               "理光镜头：C口, 6mm焦距, 2/3英寸, 螺纹30mm, 长度37.5mm", "2/3\"", Lens.enumLensFocusLength.F6mm,Lens.enumLensDesign.Screw_fix, 200);

            Lens BAM02FA = new Lens(product.enumProductFamily.Lens, "BAM02FA", "BAM LS-VS-004-C2/3-0814-2", "RICOH lens: C-Mount, 8mm focal length, 2/3 inch, Thread=40mm, L=36.7mm",
              "理光镜头：C口, 8mm焦距, 2/3英寸, 螺纹40mm, 长度36.7mm", "2/3\"", Lens.enumLensFocusLength.F8mm, Lens.enumLensDesign.Screw_fix, 200);

            Lens BAM02FC = new Lens(product.enumProductFamily.Lens, "BAM02FC", "BAM LS-VS-004-C2/3-1214-2", "RICOH lens: C-Mount, 12mm focal length, 2/3 inch, Thread=27mm, L=45.7mm",
              "理光镜头：C口, 12mm焦距, 2/3英寸, 螺纹27mm, 长度45.7mm", "2/3\"", Lens.enumLensFocusLength.F12mm, Lens.enumLensDesign.Screw_fix, 200);

            Lens BAM02FE = new Lens(product.enumProductFamily.Lens, "BAM02FE", "BAM LS-VS-004-C2/3-1614-2", "RICOH lens: C-Mount, 16mm focal length, 2/3 inch, Thread=27mm, L=32.2mm",
              "理光镜头：C口, 16mm焦距, 2/3英寸, 螺纹27mm, 长度32.2mm", "2/3\"", Lens.enumLensFocusLength.F16mm, Lens.enumLensDesign.Screw_fix, 200);

            Lens BAM02FF = new Lens(product.enumProductFamily.Lens, "BAM02FF", "BAM LS-VS-004-C2/3-2514-2", "RICOH lens: C-Mount, 25mm focal length, 2/3 inch, Thread=30mm, L=38mm",
             "理光镜头：C口, 25mm焦距, 2/3英寸, 螺纹30mm, 长度38mm", "2/3\"", Lens.enumLensFocusLength.F25mm, Lens.enumLensDesign.Screw_fix, 200);

            Lens BAM02FH = new Lens(product.enumProductFamily.Lens, "BAM02FH", "BAM LS-VS-004-C2/3-3514-2", "RICOH lens: C-Mount, 35mm focal length, 2/3 inch, Thread=30mm, L=35.4mm",
             "理光镜头：C口, 35mm焦距, 2/3英寸, 螺纹30mm, 长度35.4mm", "2/3\"", Lens.enumLensFocusLength.F35mm, Lens.enumLensDesign.Screw_fix, 200);

            Lens BAM02FJ = new Lens(product.enumProductFamily.Lens, "BAM02FJ", "BAM LS-VS-004-C2/3-5014-2", "RICOH lens: C-Mount, 50mm focal length, 2/3 inch, Thread=30mm, L=46.5mm",
            "理光镜头：C口, 50mm焦距, 2/3英寸, 螺纹30mm, 长度46.5mm", "2/3\"", Lens.enumLensFocusLength.F50mm, Lens.enumLensDesign.Screw_fix, 200);

            Lens BAM02Y3 = new Lens(product.enumProductFamily.Lens, "BAM02Y3", "BAM LS-VS-004-C2/3-7532-2", "RICOH lens: C-Mount, 75mm focal length, 2/3 inch, Thread=30mm, L=70.1mm",
           "理光镜头：C口, 75mm焦距, 2/3英寸, 螺纹30mm, 长度70.1mm", "2/3\"", Lens.enumLensFocusLength.F75mm, Lens.enumLensDesign.Screw_fix, 200);

            LensList.Add(BAM029R);
            LensList.Add(BAM02FA);
            LensList.Add(BAM02FC);
            LensList.Add(BAM02FE);
            LensList.Add(BAM02FF);
            LensList.Add(BAM02FH);
            LensList.Add(BAM02FJ);
            LensList.Add(BAM02Y3);

            //////////////////////////////////////////////////////
            ///Kowa 防抖
            ///

            Lens BAM0364 = new Lens(product.enumProductFamily.Lens, "BAM0364", "BAM LS-VS-006-C2/3-0814-5", "Kowa lens: C-Mount,8mm focal length, 2/3 inch, Thread=30mm, L= 42.2mm",
           "科华镜头：C口, 8mm焦距, 2/3英寸, 螺纹30mm, 长度42.2mm", "2/3\"",  Lens.enumLensFocusLength.F8mm, Lens.enumLensDesign.Ruggedized, 201);

            Lens BAM0365 = new Lens(product.enumProductFamily.Lens, "BAM0365", "BAM LS-VS-006-C2/3-1214-5", "Kowa lens: C-Mount,12mm focal length, 2/3 inch, Thread=30mm, L= 42.2mm",
           "科华镜头：C口, 12mm焦距, 2/3英寸,螺纹30mm, 长度42.2mm", "2/3\"", Lens.enumLensFocusLength.F12mm, Lens.enumLensDesign.Ruggedized, 201);

            Lens BAM0366 = new Lens(product.enumProductFamily.Lens, "BAM0366", "BAM LS-VS-006-C2/3-1614-5", "Kowa lens: C-Mount,16mm focal length, 2/3 inch, Thread=30mm, L= 38.6mm",
           "科华镜头：C口, 16mm焦距, 2/3英寸, 螺纹30mm, 长度38.6mm", "2/3\"", Lens.enumLensFocusLength.F16mm, Lens.enumLensDesign.Ruggedized, 201);

            Lens BAM0367 = new Lens(product.enumProductFamily.Lens, "BAM0367", "BAM LS-VS-006-C2/3-2514-5", "Kowa lens: C-Mount,25mm focal length, 2/3 inch, Thread=30mm, L= 44mm",
          "科华镜头：C口, 25mm焦距, 2/3英寸, 螺纹30mm, 长度44mm", "2/3\"", Lens.enumLensFocusLength.F25mm, Lens.enumLensDesign.Ruggedized, 201);

            Lens BAM0368 = new Lens(product.enumProductFamily.Lens, "BAM0368", "BAM LS-VS-006-C2/3-3514-5", "Kowa lens: C-Mount,35mm focal length, 2/3 inch, Thread=30mm, L= 44.3mm",
          "科华镜头：C口, 35mm焦距, 2/3英寸, 螺纹30mm, 长度44.3mm", "2/3\"", Lens.enumLensFocusLength.F35mm, Lens.enumLensDesign.Ruggedized, 201);

            Lens BAM0369 = new Lens(product.enumProductFamily.Lens, "BAM0369", "BAM LS-VS-006-C2/3-5014-5", "Kowa lens: C-Mount,50mm focal length, 2/3 inch, Thread=30mm, L= 72mm",
         "科华镜头：C口, 12mm焦距, 2/3英寸, 螺纹30mm, 长度72mm", "2/3\"", Lens.enumLensFocusLength.F50mm, Lens.enumLensDesign.Ruggedized, 201);

            
            LensList.Add(BAM0364);
            LensList.Add(BAM0365);
            LensList.Add(BAM0366);
            LensList.Add(BAM0367);
            LensList.Add(BAM0368);
            LensList.Add(BAM0369);

            //////////////////////////////////////////////////////
            ///Tarmon 1.1 inch
            ///

            Lens BAM035R = new Lens(product.enumProductFamily.Lens, "BAM035R", "BAM LS-VS-007-C1/1-0818-C", "Tarmon lens: C-Mount, 8mm focal length, 1.1 inch, Thread= 80mm, L= 101.9mm",
           "腾龙镜头：C口, 8mm焦距, 1.1英寸, 螺纹80mm, 长度101.9mm", "1.1\"", Lens.enumLensFocusLength.F8mm, Lens.enumLensDesign.Screw_fix, 202);

            Lens BAM035T = new Lens(product.enumProductFamily.Lens, "BAM035T", "BAM LS-VS-007-C1/1-1618-C", "Tarmon lens: C-Mount, 16mm focal length, 1.1 inch, Thread= 57mm, L= 98.9mm",
          "腾龙镜头：C口, 16mm焦距, 1.1英寸, 螺纹57mm, 长度98.9mm", "1.1\"", Lens.enumLensFocusLength.F16mm, Lens.enumLensDesign.Screw_fix, 202);

            Lens BAM035U = new Lens(product.enumProductFamily.Lens, "BAM035U", "BAM LS-VS-007-C1/1-2518-C", "Tarmon lens: C-Mount, 25mm focal length, 1.1 inch, Thread= 57mm, L= 101.3mm",
         "腾龙镜头：C口, 25mm焦距, 1.1英寸, 螺纹57mm, 长度101.3mm", "1.1\"", Lens.enumLensFocusLength.F25mm, Lens.enumLensDesign.Screw_fix, 202);

            Lens BAM035W = new Lens(product.enumProductFamily.Lens, "BAM035W", "BAM LS-VS-007-C1/1-2518-C", "Tarmon lens: C-Mount, 25mm focal length, 1.1 inch, Thread= 57mm, L= 101.3mm",
         "腾龙镜头：C口,50mm焦距, 1.1英寸, 螺纹53mm, 长度98.7mm", "1.1\"", Lens.enumLensFocusLength.F50mm, Lens.enumLensDesign.Screw_fix, 202);

            LensList.Add(BAM035R);
            LensList.Add(BAM035T);
            LensList.Add(BAM035U);
            LensList.Add(BAM035W);

            //////////////////////////////////////////////////////
            ///Kowa 1.1 inch 
            ///

            Lens BAM03MN = new Lens(product.enumProductFamily.Lens, "BAM03MN", "BAM LS-VS-009-C1/1-0625-O", "Kowa lens: C-Mount, 6.5mm focal length, 1.1 inch, Thread= 84mm, L= 79.1mm",
           "科华镜头：C口, 6.5mm焦距, 1.1英寸, 螺纹84mm, 长度79.1mm", "1.1\"", Lens.enumLensFocusLength.F6mm, Lens.enumLensDesign.Screw_fix, 203);

            Lens BAM03MP = new Lens(product.enumProductFamily.Lens, "BAM03MP", "BAM LS-VS-009-C1/1-0825-O", "Kowa lens: C-Mount, 8.5mm focal length, 1.1 inch, Thread= 64mm, L= 73.3mm",
          "科华镜头：C口, 8.5mm焦距, 1.1英寸, 螺纹64mm, 长度73.3mm", "1.1\"", Lens.enumLensFocusLength.F8mm, Lens.enumLensDesign.Screw_fix, 203);

            Lens BAM03MR = new Lens(product.enumProductFamily.Lens, "BAM03MR", "BAM LS-VS-009-C1/1-1218-O", "Kowa lens: C-Mount, 12mm focal length, 1.1 inch, Thread= 51mm, L= 73.8mm",
          "科华镜头：C口, 12mm焦距, 1.1英寸, 螺纹51mm, 长度73.8mm", "1.1\"", Lens.enumLensFocusLength.F12mm, Lens.enumLensDesign.Screw_fix, 203);

            Lens BAM03MT = new Lens(product.enumProductFamily.Lens, "BAM03MT", "BAM LS-VS-009-C1/1-1618-O", "Kowa lens: C-Mount, 16mm focal length, 1.1 inch, Thread=43mm, L= 65.7mm",
         "科华镜头：C口, 16mm焦距, 1.1英寸, 螺纹43mm, 长度65.7mm", "1.1\"", Lens.enumLensFocusLength.F16mm, Lens.enumLensDesign.Screw_fix, 203);

            Lens BAM03MU = new Lens(product.enumProductFamily.Lens, "BAM03MU", "BAM LS-VS-009-C1/1-2518-O", "Kowa lens: C-Mount, 25mm focal length, 1.1 inch, Thread=43mm, L= 69.4mm",
        "科华镜头：C口, 25mm焦距, 1.1英寸, 螺纹43mm, 长度69.4mm", "1.1\"", Lens.enumLensFocusLength.F25mm, Lens.enumLensDesign.Screw_fix, 203);

            Lens BAM03MW = new Lens(product.enumProductFamily.Lens, "BAM03MW", "BAM LS-VS-009-C1/1-3518-O", "Kowa lens: C-Mount, 35mm focal length, 1.1 inch, Thread=43mm, L= 66mm",
        "科华镜头：C口, 35mm焦距, 1.1英寸, 螺纹43mm, 长度66mm", "1.1\"", Lens.enumLensFocusLength.F35mm, Lens.enumLensDesign.Screw_fix, 203);

            Lens BAM03MY = new Lens(product.enumProductFamily.Lens, "BAM03MY", "BAM LS-VS-009-C1/1-5018-O", "Kowa lens: C-Mount, 50mm focal length, 1.1 inch, Thread=45mm, L= 74.5mm",
        "科华镜头：C口, 50mm焦距, 1.1英寸, 螺纹45mm, 长度74.5mm", "1.1\"", Lens.enumLensFocusLength.F50mm, Lens.enumLensDesign.Screw_fix, 203);
                      

            LensList.Add(BAM03MN);
            LensList.Add(BAM03MP);
            LensList.Add(BAM03MR);
            LensList.Add(BAM03MT);
            LensList.Add(BAM03MU);
            LensList.Add(BAM03MW);
            LensList.Add(BAM03MY);

            //////////////////////////////////////////////////////
            ///Kowa IP67 2/3 inch 
            ///

            Lens BAM03H1 = new Lens(product.enumProductFamily.Lens, "BAM03H1", "BAM LS-VS-008-C2/3-0528-5", "Kowa IP67 lens: C-Mount, 5mm focal length, 2/3 inch, Thread=43mm, L= 45.8mm",
          "科华防水镜头：C口, 5mm焦距, 2/3英寸, 螺纹43mm, 长度45.8mm", "2/3\"", Lens.enumLensFocusLength.F5mm, Lens.enumLensDesign.IP67, 204);

            Lens BAM03H2 = new Lens(product.enumProductFamily.Lens, "BAM03H2", "BAM LS-VS-008-C2/3-0814-5", "Kowa IP67 lens: C-Mount, 8mm focal length, 2/3 inch, Thread=33mm, L= 50.1mm",
          "科华防水镜头：C口, 8mm焦距, 2/3英寸, 螺纹33mm, 长度50.1mm", "2/3\"", Lens.enumLensFocusLength.F8mm, Lens.enumLensDesign.IP67, 204);

            Lens BAM03H3 = new Lens(product.enumProductFamily.Lens, "BAM03H3", "BAM LS-VS-008-C2/3-1214-5", "Kowa IP67 lens: C-Mount, 12mm focal length, 2/3 inch, Thread=33mm, L= 42.7mm",
          "科华防水镜头：C口, 12mm焦距, 2/3英寸, 螺纹33mm, 长度42.7mm", "2/3\"", Lens.enumLensFocusLength.F12mm, Lens.enumLensDesign.IP67, 204);

            Lens BAM03H4 = new Lens(product.enumProductFamily.Lens, "BAM03H4", "BAM LS-VS-008-C2/3-1614-5", "Kowa IP67 lens: C-Mount, 16mm focal length, 2/3 inch, Thread=33mm, L= 41.4mm",
          "科华防水镜头：C口, 16mm焦距, 2/3英寸, 螺纹33mm, 长度41.4mm", "2/3\"", Lens.enumLensFocusLength.F16mm, Lens.enumLensDesign.IP67, 204);

            Lens BAM03H5 = new Lens(product.enumProductFamily.Lens, "BAM03H5", "BAM LS-VS-008-C2/3-2514-5", "Kowa IP67 lens: C-Mount, 25mm focal length, 2/3 inch, Thread=33mm, L= 47mm",
          "科华防水镜头：C口, 25mm焦距, 2/3英寸, 螺纹33mm, 长度47mm", "2/3\"", Lens.enumLensFocusLength.F25mm, Lens.enumLensDesign.IP67, 204);

            Lens BAM03H6 = new Lens(product.enumProductFamily.Lens, "BAM03H6", "BAM LS-VS-008-C2/3-3520-5", "Kowa IP67 lens: C-Mount, 35mm focal length, 2/3 inch, Thread=33mm, L= 42.8mm",
          "科华防水镜头：C口, 35mm焦距, 2/3英寸, 螺纹33mm, 长度42.8mm", "2/3\"", Lens.enumLensFocusLength.F35mm, Lens.enumLensDesign.IP67, 204);

            Lens BAM03H7 = new Lens(product.enumProductFamily.Lens, "BAM03H7", "BAM LS-VS-008-C2/3-5028-5", "Kowa IP67 lens: C-Mount, 50mm focal length, 2/3 inch, Thread=33mm, L= 60.2mm",
          "科华防水镜头：C口, 50mm焦距, 2/3英寸, 螺纹33mm, 长度60.2mm", "2/3\"", Lens.enumLensFocusLength.F50mm, Lens.enumLensDesign.IP67, 204);

            

            LensList.Add(BAM03H1);
            LensList.Add(BAM03H2);
            LensList.Add(BAM03H3);
            LensList.Add(BAM03H4);
            LensList.Add(BAM03H5);
            LensList.Add(BAM03H6);
            LensList.Add(BAM03H7);
        }

        public void InitIndustrialCamera()
        {
            IndustrialCamera BVS003A = new IndustrialCamera(product.enumProductFamily.IndustrialCamera, "BVS003A", "BVS CA-GX0-0016ZG-112C41-XAS2", "GIGE Industrial Camera, 1.6MP, Monochrome, 75fps ",
         "网口GIGE工业相机, 160万分辨率, 黑白，75帧", "1.6MP", IndustrialCamera.enumCAColor.Mono, IndustrialCamera.enumCAInterface.GigE,  5.02, 3.75, 1456, 1088, 75 , 1);

            IndustrialCamera BVS003C = new IndustrialCamera(product.enumProductFamily.IndustrialCamera, "BVS003C", "BVS CA-GX0-0016ZC-111C41-XAS2", "GIGE Industrial Camera, 1.6MP, Color, 75fps ",
         "网口GIGE工业相机, 160万分辨率, 彩色，75帧", "1.6MP", IndustrialCamera.enumCAColor.Color, IndustrialCamera.enumCAInterface.GigE, 5.02, 3.75, 1456, 1088, 75, 1);

            IndustrialCamera BVS0038 = new IndustrialCamera(product.enumProductFamily.IndustrialCamera, "BVS0038", "BVS CA-GX0-0032AG-112C41-XAS2", "GIGE Industrial Camera, 3.2MP, Monochrome, 37.2fps ",
         "网口GIGE工业相机, 320万分辨率, 黑白，37.2帧", "3.2MP", IndustrialCamera.enumCAColor.Mono, IndustrialCamera.enumCAInterface.GigE, 7.12, 5.33, 2064, 1544, 37.2, 1);

            IndustrialCamera BVS0039 = new IndustrialCamera(product.enumProductFamily.IndustrialCamera, "BVS0038", "BVS CA-GX0-0032AC-111C41-XAS2", "GIGE Industrial Camera, 3.2MP, Color, 37.2fps ",
         "网口GIGE工业相机, 320万分辨率, 彩色，37.2帧", "3.2MP", IndustrialCamera.enumCAColor.Color, IndustrialCamera.enumCAInterface.GigE, 7.12, 5.33, 2064, 1544, 37.2, 1);

            IndustrialCamera BVS0036 = new IndustrialCamera(product.enumProductFamily.IndustrialCamera, "BVS0036", "BVS CA-GX0-0051AG-112C41-XAS2", "GIGE Industrial Camera, 5.1MP, Monochrome, 23.4fps ",
        "网口GIGE工业相机, 510万分辨率, 黑白，23.4帧", "5.1MP", IndustrialCamera.enumCAColor.Mono, IndustrialCamera.enumCAInterface.GigE,   8.5,  7.09, 2464, 2056, 23.4, 1);

            IndustrialCamera BVS0037 = new IndustrialCamera(product.enumProductFamily.IndustrialCamera, "BVS0037", "BVS CA-GX0-0051AC-111C41-XAS2", "GIGE Industrial Camera, 5.1MP, Color, 23.4fps ",
        "网口GIGE工业相机, 510万分辨率, 彩色，23.4帧", "5.1MP", IndustrialCamera.enumCAColor.Color, IndustrialCamera.enumCAInterface.GigE, 8.5, 7.09, 2464, 2056, 23.4, 1);

            IndustrialCamera BVS0034 = new IndustrialCamera(product.enumProductFamily.IndustrialCamera, "BVS0034", "BVS CA-GX0-0124AG-112C41-XAS2", "GIGE Industrial Camera, 12.4MP, Monochrome, 9.6fps ",
       "网口GIGE工业相机, 1230万分辨率, 黑白，9.6帧", "12.3MP", IndustrialCamera.enumCAColor.Mono, IndustrialCamera.enumCAInterface.GigE, 14.13, 10.38, 4112, 3008, 9.6, 1);

            IndustrialCamera BVS0035 = new IndustrialCamera(product.enumProductFamily.IndustrialCamera, "BVS0035", "BVS CA-GX0-0124AC-111C41-XAS2", "GIGE Industrial Camera, 12.4MP, Color, 9.6fps ",
       "网口GIGE工业相机, 1230万分辨率, 彩色，9.6帧", "12.3MP", IndustrialCamera.enumCAColor.Color, IndustrialCamera.enumCAInterface.GigE, 14.13, 10.38, 4112, 3008, 9.6, 1);


            CAList.Add(BVS003A);
            CAList.Add(BVS003C);
            CAList.Add(BVS0038);
            CAList.Add(BVS0039);
            CAList.Add(BVS0036);
            CAList.Add(BVS0037);
            CAList.Add(BVS0034);
            CAList.Add(BVS0035);


            IndustrialCamera BVS003M = new IndustrialCamera(product.enumProductFamily.IndustrialCamera, "BVS003M", "BVS CA-SF2-0016ZG-112121-XAS2", "USB3.0 Industrial Camera, 1.6MP, Monochrome, 226.5fps ",
         "USB3.0工业相机, 160万分辨率, 黑白，226.5帧", "1.6MP", IndustrialCamera.enumCAColor.Mono, IndustrialCamera.enumCAInterface.USB3, 5.02, 3.75, 1456, 1088, 226.5, 2);

            IndustrialCamera BVS003N = new IndustrialCamera(product.enumProductFamily.IndustrialCamera, "BVS003N", "BVS CA-SF2-0016ZC-111121-XAS2", "USB3.0 Industrial Camera, 1.6MP, Color, 226.5fps ",
         "USB3.0工业相机, 160万分辨率, 彩色，226.5帧", "1.6MP", IndustrialCamera.enumCAColor.Color, IndustrialCamera.enumCAInterface.USB3, 5.02, 3.75, 1456, 1088, 226.5, 2);

            IndustrialCamera BVS003K = new IndustrialCamera(product.enumProductFamily.IndustrialCamera, "BVS003K", "BVS CA-SF2-0032AG-112121-XAS2", "USB3.0 Industrial Camera, 3.2MP, Monochrome, 55fps ",
         "USB3.0工业相机, 320万分辨率, 黑白，55帧", "3.2MP", IndustrialCamera.enumCAColor.Mono, IndustrialCamera.enumCAInterface.USB3, 7.12, 5.33, 2064, 1544, 55, 2);

            IndustrialCamera BVS003L = new IndustrialCamera(product.enumProductFamily.IndustrialCamera, "BVS0038", "BVS CA-SF2-0032AC-111121-XAS2", "USB3.0 Industrial Camera, 3.2MP, Color, 55fps ",
         "USB3.0工业相机, 320万分辨率, 彩色，55帧", "3.2MP", IndustrialCamera.enumCAColor.Color, IndustrialCamera.enumCAInterface.USB3, 7.12, 5.33, 2064, 1544, 55, 2);

            IndustrialCamera BVS003H = new IndustrialCamera(product.enumProductFamily.IndustrialCamera, "BVS003H", "BVS CA-SF2-0051AG-112121-XAS2", "USB3.0 Industrial Camera, 5.1MP, Monochrome, 35fps ",
         "USB3.0工业相机, 510万分辨率, 黑白，35帧", "5.1MP", IndustrialCamera.enumCAColor.Mono, IndustrialCamera.enumCAInterface.USB3, 8.5, 7.09, 2464, 2056, 35, 2);

            IndustrialCamera BVS003J = new IndustrialCamera(product.enumProductFamily.IndustrialCamera, "BVS003J", "BVS CA-SF2-0051AC-111121-XAS2", "USB3.0 Industrial Camera, 5.1MP, Color, 35fps ",
        "USB3.0工业相机, 510万分辨率, 彩色，35帧", "5.1MP", IndustrialCamera.enumCAColor.Color, IndustrialCamera.enumCAInterface.USB3, 8.5, 7.09, 2464, 2056, 35, 2);

            IndustrialCamera BVS003E = new IndustrialCamera(product.enumProductFamily.IndustrialCamera, "BVS003E", "BVS CA-SF2-0124AG-112121-XAS2", "USB3.0 Industrial Camera, 12.3MP, Monochrome, 23fps ",
         "USB3.0工业相机, 1230万分辨率, 黑白，23帧", "12.3MP", IndustrialCamera.enumCAColor.Mono, IndustrialCamera.enumCAInterface.USB3, 14.13, 10.38, 4112, 3008, 23, 2);

            IndustrialCamera BVS003F = new IndustrialCamera(product.enumProductFamily.IndustrialCamera, "BVS003F", "BVS CA-SF2-0124AC-111121-XAS2", "USB3.0 Industrial Camera, 12.3MP, Color, 23fps ",
        "USB3.0工业相机, 1230万分辨率, 彩色，23帧", "12.3MP", IndustrialCamera.enumCAColor.Color, IndustrialCamera.enumCAInterface.USB3, 14.13, 10.38, 4112, 3008, 23, 2);


            CAList.Add(BVS003M);
            CAList.Add(BVS003N);
            CAList.Add(BVS003K);
            CAList.Add(BVS003L);
            CAList.Add(BVS003H);
            CAList.Add(BVS003J);
            CAList.Add(BVS003E);
            CAList.Add(BVS003F);


        }

        public void InitCockpit()
        {
            //Cockpit 
            Cockpit BAE0103 = new Cockpit(product.enumProductFamily.Cockpit, "BAE0103", "BAE PD-VS-014-05", "Controller for industrial cameras, Linux, BVS-Cockpit, Processor i7–6700TE, 16 GB DDR4 RAM, 256 GB SSD, 2x LAN,  4x GIGE - LAN, 4x USB3, 4x USB2, 2x Profinet ",
                "用于工业相机的控制器，Linux系统，i7–6700TE 处理器，16 GB 内存，256 GB SSD，2x LAN,  4x GIGE - LAN, 4x USB3, 4x USB2, 2x Profinet", Cockpit.enumCockpitProductFamily.Controller, 300);

            Cockpit BAI000Z = new Cockpit(product.enumProductFamily.Cockpit, "BAI000Z", "BAI BVS-CA-EPC-001", "Cockpit Window 64Bit Software for Industrial camera, USB license dongle ",
                "Cockpit Windows 64位系统软件，用于工业相机", Cockpit.enumCockpitProductFamily.Software, 301);

            Cockpit BAI_Ident = new Cockpit(product.enumProductFamily.Cockpit, "BAI_Ident ", "BAI BVS-P99N-UGY-0001-1DZ-IDZZ", "Cockpit upgrade package for Identification version",
                "Cockpit 升级包，升级软件到识别版", Cockpit.enumCockpitProductFamily.UpgradePackage, 302);

            Cockpit BAI_Std = new Cockpit(product.enumProductFamily.Cockpit, "BAI_Std", "BAI BVS-P99N-UGY-0001-1DZ-STZZ", "Cockpit upgrade package for Standard version",
                "Cockpit 升级包，升级软件到标准版", Cockpit.enumCockpitProductFamily.UpgradePackage, 302);

            Cockpit BAI_HDev = new Cockpit(product.enumProductFamily.Cockpit, "BAI_HDev", "BAI BVS-P99N-UGY-0001-1DZ-HAZZ", "Cockpit upgrade package for Halcon version",
                "Cockpit 升级包，升级软件到Halcon版", Cockpit.enumCockpitProductFamily.UpgradePackage, 302);

            Cockpit BAI_8Instance = new Cockpit(product.enumProductFamily.Cockpit, "BAI_8Instance", "BAI BVS-P99N-UGY-0001-1DZ-IAZZ", "Cockpit upgrade package for 8 cameras",
                "Cockpit 升级包，升级软件到能使用8个相机", Cockpit.enumCockpitProductFamily.UpgradePackage, 302);

            CockpitList.Add(BAE0103);
            CockpitList.Add(BAI000Z);
            CockpitList.Add(BAI_Ident);
            CockpitList.Add(BAI_Std);
            CockpitList.Add(BAI_HDev);
            CockpitList.Add(BAI_8Instance);

        }

        public Bitmap loadCableImage(Cable cable)
        {
            Bitmap bmp = null;
            Image img = null;

            switch (cable.ImageIndex)
            {

                case 1:
                    img = Properties.Resources.CableScannerRJ45USB;
                    break;
                case 2:
                    img = Properties.Resources.CableScannerSpireUSB;
                    break;
                case 3:
                    img = Properties.Resources.CableScannerRJ45RS232;
                    break;
                case 4:
                    img = Properties.Resources.CableScannerSpireRS232;
                    break;
                case 5:
                    img = Properties.Resources.CableScannerRJ50USB;
                    break;
                case 6:
                    img = Properties.Resources.CableScannerRJ50RS232;
                    break;

                case 7:
                    img = Properties.Resources.VisionSensorETHCable;
                    break;
                case 8:
                    img = Properties.Resources.VisionSensorIOCable;
                    break;
                case 9:
                    img = Properties.Resources.VisionSensorMonitorCable;
                    break;
                case 10:
                    img = Properties.Resources.CableEthertnetM12;
                    break;
                case 11:
                    img = Properties.Resources.CableProfinetM12;
                    break;
                case 12:
                    img = Properties.Resources.CableIO_Link;
                    break;
                case 13:
                    img = Properties.Resources.CableEIPM12;
                    break;
                case 14:
                    img = Properties.Resources.CableU3;
                     break;
                case 15:
                    img = Properties.Resources.CableHirose;
                    break;


                default:
                    img = null;
                    break;

            }
            if (img != null)
            {
                bmp = new Bitmap(img.Width, img.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));

            }

            return bmp;

        }

        public Bitmap loadCockpitImage(Cockpit cockpit)
        {
            Bitmap bmp = null;
            Image img = null;

            switch (cockpit.ImageIndex)
            {

                case 300:
                    img = Properties.Resources.Controller;
                    break;
                case 301:
                    img = Properties.Resources.Cockpit;
                    break;
                case 302:
                    img = Properties.Resources.CockpitUpgrade
;
                    break;
               
                default:
                    img = null;
                    break;

            }
            if (img != null)
            {
                bmp = new Bitmap(img.Width, img.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));

            }

            return bmp;

        }

        public Bitmap loadAccessoryImage(Accessory accessory)
        {

            Bitmap bmp = null;
            Image img = null;

            switch (accessory.ImageIndex)
            {
                                
               case 100:
                   img = Properties.Resources.Accessory5VPower;
                   break;
               case 101:
                   img = Properties.Resources.Accessory12VPower;
                   break;
               case 102:
                   img = Properties.Resources.AccessoryBluetoothBase;
                   break;

               case 103:
                    img = Properties.Resources.VisionSensorMonitor;
                    break;

               case 104:
                    img = Properties.Resources.VisionSensorMonitorProtection;
                    break;

               case 105:
                    img = Properties.Resources.LensProtection;
                    break;

                default:
                    img = null;
                    break;

            }
            if (img != null)
            {
                bmp = new Bitmap(img.Width, img.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));

            }

            return bmp;

        }

        public Bitmap loadLensImage(Lens lens)
        {
            Bitmap bmp = null;
            Image img = null;

            switch (lens.ImageIndex)
            {

                case 200:
                    img = Properties.Resources.LensRichon;
                    break;
                case 201:
                    img = Properties.Resources.LensKowa;
                    break;
                case 202:
                    img = Properties.Resources.LensTarmon;
                    break;
                case 203:
                    img = Properties.Resources.LensKowa11;
                    break;
                case 204:
                    img = Properties.Resources.LensKowaIP67;
                    break;
                default:
                    img = null;
                    break;

            }
            if (img != null)
            {
                bmp = new Bitmap(img.Width, img.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));

            }

            return bmp;

        }

        public Bitmap loadCAImage(IndustrialCamera industrialcamera)
        {
            Bitmap bmp = null;
            Image img = null;

            switch (industrialcamera.ImageIndex)
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
                bmp = new Bitmap(img.Width, img.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));

            }

            return bmp;

        }

        public Object Clone()
        {

            return this.MemberwiseClone();
        }

        public object CloneLstScanner(List<Scanner> listscanner)
        {
            List<Scanner> newlistScanner = new List<Scanner>();

            foreach(Scanner scntmp in listscanner)
            {
                newlistScanner.Add(scntmp);
                
            }
            return newlistScanner;
        }

        public object CloneLstVisionSensor(List<VisionSensor> listvisionsensor)
        {
            List<VisionSensor> newlistVisionSensor = new List<VisionSensor>();

            foreach (VisionSensor vstmp in listvisionsensor)
            {
                newlistVisionSensor.Add(vstmp);

            }
            return newlistVisionSensor;
        }

        public object CloneLstSmartCamera(List<SmartCamera> listsmartcamera)
        {
            List<SmartCamera> newlistSmartCamera = new List<SmartCamera>();

            foreach (SmartCamera SCtmp in listsmartcamera)
            {
                newlistSmartCamera.Add(SCtmp);

            }
            return newlistSmartCamera;
        }

        public object CloneLstIndustrialCamera(List<IndustrialCamera> listindustrialcamera)
        {
            List<IndustrialCamera> newlistIndustrialCamera = new List<IndustrialCamera>();

            foreach (IndustrialCamera CAtmp in listindustrialcamera)
            {
                newlistIndustrialCamera.Add(CAtmp);

            }
            return newlistIndustrialCamera;
        }

        public object CloneLstLens(List<Lens> listLens)
        {
            List<Lens> newlistLens = new List<Lens>();

            foreach (Lens Lenstmp in listLens)
            {
                newlistLens.Add(Lenstmp);

            }
            return newlistLens;
        }

        public object CloneLstCable(List<Cable> listCable)
        {
            List<Cable> newlistCable = new List<Cable>();

            foreach (Cable Cabletmp in listCable)
            {
                newlistCable.Add(Cabletmp);

            }
            return newlistCable;
        }

        public object CloneLstAccessory(List<Accessory> listAccessory)
        {
            List<Accessory> newlistAccessory = new List<Accessory>();

            foreach (Accessory accessorytmp in listAccessory)
            {
                newlistAccessory.Add(accessorytmp);

            }
            return newlistAccessory;
        }

        public object CloneLstCockpit(List<Cockpit> listCockpit)
        {
            List<Cockpit> newlistCockpit = new List<Cockpit>();

            foreach (Cockpit Cockpittmp in listCockpit)
            {
                newlistCockpit.Add(Cockpittmp);

            }
            return newlistCockpit;
        }
    }
}
