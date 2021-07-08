using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalluffVisionConfigurator
{
    public class product
    {
        /// <summary>
        /// All product class 
        /// </summary>
        public enum enumProductFamily
        {
            All = 0,
            Scanner = 1,
            VisionSensor = 2,
            SmartCamera = 3,
            IndustrialCamera = 4,
            Lens = 5,
            Cable = 6,
            Cockpit = 7,
            Accessory = 8


        }
        public enumProductFamily ProductFamily;
        public string OrderCode;
        public string LongCode;
        public string DescriptionEN;
        public string DescriptionCN;
        public int ImageIndex;
        public static product getProduct(string ordercode, List<product> listproduct)
        {
            product product_ = null;

            foreach (product pdt in listproduct)
            {
                if (pdt.OrderCode == ordercode)
                {
                    product_ = pdt;
                    break;
                }
            }


            return product_;
        }


    }

    public class Cable : product
    {
        public enum enumCableproductfamily
        {
            All = 0,
            None = 99,
            ScannerHS_Q = 1,
            ScannerHS_P = 2,
            VisionSensor = 3,
            Monitor = 4,
            SmartCamera = 5,
            SmartCameraLite = 6,
            GIGE_Camera = 7,
            USB3_Camera = 8,

        }
        public enum enumCableInterface
        {
            All = 0,
            USB2_0 = 1,
            RS232 = 2,
            IO = 3,
            GIGE = 4,
            USB3_0 = 5,
            Fieldbus = 6,
            Ethernet = 7,
            Power = 8,
            IO_Link = 9


        }


        public enumCableproductfamily CableProductFamily1;
        public enumCableproductfamily CableProductFamily2;
        public enumCableproductfamily CableProductFamily3;
        public enumCableInterface CableInterface;
        public string CableLength;


        public Cable()
        {
        }

        public Cable(enumProductFamily productFamily, string ordercode, string longcode, string descriptionEN,
                       string descriptionCN, enumCableproductfamily cableproductfamily1, enumCableproductfamily cableproductfamily2, enumCableproductfamily cableproductfamily3, enumCableInterface cableinterface, string cablelength, int imageIndex)
        {
            this.ProductFamily = productFamily;
            this.OrderCode = ordercode;
            this.LongCode = longcode;
            this.DescriptionEN = descriptionEN;
            this.DescriptionCN = descriptionCN;
            this.CableProductFamily1 = cableproductfamily1;
            this.CableProductFamily2 = cableproductfamily2;
            this.CableProductFamily3 = cableproductfamily3;
            this.CableInterface = cableinterface;
            this.CableLength = cablelength;
            this.ImageIndex = imageIndex;
        }

        public static Cable getCable(string ordercode, List<Cable> listcable)
        {
            Cable cable_ = null;

            foreach (Cable cbl in listcable)
            {
                if (cbl.OrderCode == ordercode)
                {
                    cable_ = cbl;
                    break;
                }
            }


            return cable_;
        }

    }

    public class Lens : product
    {

        public enum enumLensFocusLength
        {
            All = 0,
            F5mm = 1,
            F6mm = 2,
            F8mm = 3,
            F12mm = 4,
            F16mm = 5,
            F25mm = 6,
            F35mm = 7,
            F50mm = 8,
            F75mm = 9,

        }

        public enum enumLensDesign
        {
            All = 0,
            Screw_fix = 1,
            Ruggedized = 2,
            IP67 = 3,
        }


        public string LensImageSize;
        public enumLensFocusLength LensFocusLength;
        public enumLensDesign LensDesign;

        public Lens()
        {
        }

        public Lens(enumProductFamily productFamily, string ordercode, string longcode, string descriptionEN,
                       string descriptionCN, string lensImageSize, enumLensFocusLength lensfocuslength, enumLensDesign lensdesign, int imageIndex)
        {
            this.ProductFamily = productFamily;
            this.OrderCode = ordercode;
            this.LongCode = longcode;
            this.DescriptionEN = descriptionEN;
            this.DescriptionCN = descriptionCN;
            this.LensFocusLength = lensfocuslength;
            this.LensImageSize = lensImageSize;
            this.LensDesign = lensdesign;
            this.ImageIndex = imageIndex;
        }

        public static Lens getlens(string ordercode, List<Lens> listlens)
        {
            Lens lens_ = null;

            foreach (Lens ls in listlens)
            {
                if (ls.OrderCode == ordercode)
                {
                    lens_ = ls;
                    break;
                }
            }


            return lens_;
        }

    }

    public class Accessory : product
    {
        public enum enumAccessoryproductfamily
        {
            All = 0,
            Scanner = 1,
            ScannerHS_P = 3,
            VisionSensor = 4,
            SmartCamera = 5,

        }

        public enum enumAccessoryproduct

        {
            All = 0,
            PowerRS232 = 1,
            BluetoothBasement = 2,
            Lens = 3,
        }

        public enumAccessoryproductfamily AccessoryProductFamily;
        public enumAccessoryproduct Accessoryproduct;



        public Accessory()
        {
        }

        public Accessory(enumProductFamily productFamily, string ordercode, string longcode, string descriptionEN,
                       string descriptionCN, enumAccessoryproductfamily accessoryproductfamily, enumAccessoryproduct accessoryproduct, int imageIndex)
        {
            this.ProductFamily = productFamily;
            this.Accessoryproduct = accessoryproduct;
            this.AccessoryProductFamily = accessoryproductfamily;
            this.OrderCode = ordercode;
            this.LongCode = longcode;
            this.DescriptionEN = descriptionEN;
            this.DescriptionCN = descriptionCN;
            this.ImageIndex = imageIndex;
        }

        public static Accessory getAccessory(string ordercode, List<Accessory> listAccessory)
        {
            Accessory Accessory_ = null;

            foreach (Accessory asy in listAccessory)
            {
                if (asy.OrderCode == ordercode)
                {
                    Accessory_ = asy;
                    break;
                }
            }


            return Accessory_;
        }

    }

    public class Scanner : product
    {
        public enum enumScannerFamily
        {
            ScannerHS_Q = 0,
            ScannerHS_P = 1

        }
        public enum enumCableConnection
        {
            All = 0,
            USB = 1,
            RS232 = 2

        }

        public enum enumCodeFunction
        {
            Papier = 0,
            DPM = 1
        }

        public enumScannerFamily ScannerFamily;
        public enumCableConnection CableConnection;  //线缆类型 1 灰色扫码枪 RJ45，2 黄色扫码枪 RJ50
        public enumCodeFunction Function;
        public string Communication;
        public bool NeedBasement;
        public bool NeedUSBCable;
        public bool NeedRS232Cable;
        public bool NeedPowerSupply;


        public Scanner()
        {
        }

        public Scanner(enumScannerFamily scannerFamily, enumProductFamily productFamily, string ordercode, string longcode, string descriptionEN,
                       string descriptionCN, enumCableConnection cableConnection, enumCodeFunction funtion,
                       string communication, bool needUSBCable, bool needRS232Cable,
                       bool needBasement, bool needPowerSupply, int imageindex)
        {
            this.ScannerFamily = scannerFamily;
            this.ProductFamily = productFamily;
            this.OrderCode = ordercode;
            this.LongCode = longcode;
            this.DescriptionEN = descriptionEN;
            this.DescriptionCN = descriptionCN;
            this.CableConnection = cableConnection;
            this.Function = funtion;
            this.Communication = communication;
            this.NeedBasement = needBasement;
            this.NeedPowerSupply = needPowerSupply;
            this.NeedUSBCable = needUSBCable;
            this.NeedRS232Cable = needRS232Cable;
            this.ImageIndex = imageindex;

        }

        public static Scanner getScanner(string ordercode, List<Scanner> listscaner)
        {
            Scanner scanner_ = null;

            foreach (Scanner scn in listscaner)
            {
                if (scn.OrderCode == ordercode)
                {
                    scanner_ = scn;
                    break;
                }
            }


            return scanner_;
        }

        ~Scanner()  // finalizer
        {
            ;
        }

    }

    public class VisionSensor : product
    {
        public enum enumVisionSensorModel
        {
            All = 0,
            Ident = 1,
            Standard = 2,
            Advanced = 3,
            Universal = 4,


        }
        public enum enumVisionSensorLight
        {
            All = 0,
            Red = 1,
            IR = 2,

        }

        public enum enumVisionSensorFocus
        {
            All = 0,
            F6mm = 1,
            F8mm = 2,
            F12mm = 3,
            F16mm = 4,

        }

        public enumVisionSensorModel VisionSensorModel;
        public enumVisionSensorLight VisionSensorLight;
        public enumVisionSensorFocus VisionSensorFocus;


        public VisionSensor()
        {
        }

        public VisionSensor(enumProductFamily productFamily, string ordercode, string longcode, string descriptionEN,
                       string descriptionCN, enumVisionSensorModel visionSensorModel, enumVisionSensorLight visionSensorLight, enumVisionSensorFocus visionSensorFocus, int imageIndex)
        {
            this.ProductFamily = productFamily;
            this.OrderCode = ordercode;
            this.LongCode = longcode;
            this.DescriptionEN = descriptionEN;
            this.DescriptionCN = descriptionCN;
            this.VisionSensorModel = visionSensorModel;
            this.VisionSensorLight = visionSensorLight;
            this.VisionSensorFocus = visionSensorFocus;
            this.ImageIndex = imageIndex;
        }

        public static VisionSensor getVisionSensor(string ordercode, List<VisionSensor> listvisionsensor)
        {
            VisionSensor visionsensor_ = null;

            foreach (VisionSensor bvse in listvisionsensor)
            {
                if (bvse.OrderCode == ordercode)
                {
                    visionsensor_ = bvse;
                    break;
                }
            }


            return visionsensor_;
        }

    }

    public class SmartCamera : product
    {
        public enum enumSmartCameraFunction
        {
            All = 0,
            Track = 1,
            Ident = 2,
            Standard = 3,
            HalconScript = 4,


        }
        public enum enumSmartCameraColor
        {
            All = 0,
            Mono = 1,
            Color = 2,

        }

        public enum enumSmartCameraInterface
        {
            All = 0,
            Fieldbus = 1,
            RS232 = 2,

        }

        public enumSmartCameraFunction SmartCameraFunction;
        public enumSmartCameraColor SmartCameraColor;
        public enumSmartCameraInterface SmartCameraInterface;


        public SmartCamera()
        {
        }

        public SmartCamera(enumProductFamily productFamily, string ordercode, string longcode, string descriptionEN,
                       string descriptionCN, enumSmartCameraFunction smartCameraFunction, enumSmartCameraColor smartCameraColor, enumSmartCameraInterface smartCameraInterface, int imageIndex)
        {
            this.ProductFamily = productFamily;
            this.OrderCode = ordercode;
            this.LongCode = longcode;
            this.DescriptionEN = descriptionEN;
            this.DescriptionCN = descriptionCN;
            this.SmartCameraFunction = smartCameraFunction;
            this.SmartCameraColor = smartCameraColor;
            this.SmartCameraInterface = smartCameraInterface;
            this.ImageIndex = imageIndex;
        }

        public static SmartCamera getSmartCamera(string ordercode, List<SmartCamera> listsmartcamera)
        {
            SmartCamera smartcamera_ = null;

            foreach (SmartCamera bvs in listsmartcamera)
            {
                if (bvs.OrderCode == ordercode)
                {
                    smartcamera_ = bvs;
                    break;
                }
            }


            return smartcamera_;
        }


    }

    public class Cockpit : product
   {    
        public enum enumCockpitProductFamily
        {
            All = 0,
            Controller = 1,
            Software = 2,
            UpgradePackage =3,
        }

        public enumCockpitProductFamily CockpitProductFamily;

        public Cockpit()
        {
        }

        public Cockpit(enumProductFamily productFamily, string ordercode, string longcode, string descriptionEN,
                       string descriptionCN, enumCockpitProductFamily cockpitproductfamily , int imageIndex)
        {
            this.ProductFamily = productFamily;
            this.OrderCode = ordercode;
            this.LongCode = longcode;
            this.DescriptionEN = descriptionEN;
            this.DescriptionCN = descriptionCN;
            this.CockpitProductFamily = cockpitproductfamily;
            this.ImageIndex = imageIndex;

        }

    }

    public class IndustrialCamera : product
    {
        public enum enumCAResolution
        {
            All = 0,
            P1_6MP = 1,
            P3_2MP = 2,
            P5_1MP = 3,
            P12_3MP = 4,


        }
        public enum enumCAColor
        {
            All = 0,
            Mono = 1,
            Color = 2,

        }

        public enum enumCAInterface
        {
            All = 0,
            GigE = 1,
            USB3 = 2,

        }

        

        public string  CAResolution;
        public enumCAColor CAColor;
        public enumCAInterface CAInterface;
        public double SensorSizeWidth;
        public double SensorSizeHeight;
        public int ImageWidth;
        public int ImageHeight;
        public double FPS;

        public IndustrialCamera()
        {
        }

        public IndustrialCamera(enumProductFamily productFamily, string ordercode, string longcode, string descriptionEN,
                       string descriptionCN, string  caResolution, enumCAColor caColor, enumCAInterface caInterface, double sensorsizewidth,
           double  sensorsizeheight, int imagewidth, int imageheight, double fps, int imageIndex)
        {
            this.ProductFamily = productFamily;
            this.OrderCode = ordercode;
            this.LongCode = longcode;
            this.DescriptionEN = descriptionEN;
            this.DescriptionCN = descriptionCN;
            this.CAResolution = caResolution;
            this.CAColor = caColor;
            this.CAInterface = caInterface;
            this.SensorSizeWidth = sensorsizewidth;
            this.SensorSizeHeight = sensorsizeheight;
            this.ImageWidth = imagewidth;
            this.ImageHeight = imageheight;
            this.ImageIndex = imageIndex;
            this.FPS = fps;
        }

        public static IndustrialCamera getIndustrialCamera(string ordercode, List<IndustrialCamera> listCA)
        {
            IndustrialCamera industrialcamera_ = null;

            foreach (IndustrialCamera ca in listCA)
            {
                if (ca.OrderCode == ordercode)
                {
                    industrialcamera_ = ca;
                    break;
                }
            }


            return industrialcamera_;
        }


    }
}
