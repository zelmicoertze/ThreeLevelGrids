using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuctingGrids.Frontend.GridControl;
using LamedalCore.zPublicClass.GridBlock.GridInterface;

namespace DuctingGrids.Frontend.Forms
{
    public static class DuctingTools
    {
        #region Text File
        private static string AddressConcat(string sX, string sY)
        {
            return sX.Substring(1, sX.Length - 1) + "_" + sY.Substring(0, sY.LastIndexOf('"'));
        }

        public static void ReadGridDataFromFile(GridControls_Create grid, string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                while (sr.Peek() >= 0)
                {
                    string sLine;
                    string[] sArrData;
                    sLine = sr.ReadLine();

                    sArrData = sLine.Split(',');

                    string sMacroX = sArrData[0];
                    string sMacroY = sArrData[1];
                    string sMacro = AddressConcat(sMacroX, sMacroY);

                    string sSubX = sArrData[2];
                    string sSubY = sArrData[3];
                    string sSub = AddressConcat(sSubX, sSubY);

                    string sMicroX = sArrData[4];
                    string sMicroY = sArrData[5];
                    string sMicro = AddressConcat(sMicroX, sMicroY);

                    string sFloatValue = sArrData[6];
                    double dFloatData;

                    if (sFloatValue == "")
                    {
                        dFloatData = 0;
                    }
                    else
                    {
                        dFloatData = Double.Parse(sFloatValue);
                    }

                    string sState = sArrData[7];

                    switch (sState)
                    {
                        case "Scheduled": sState = "1"; break;
                        case "In Progress": sState = "2"; break;
                        case "Complete": sState = "3"; break;
                        case "Cancelled": sState = "4"; break;
                        case "Inspected": sState = "5"; break;
                    }

                    IGridBlock_Base micro = grid.Cuboid.GetChild_MicroGridBlock(sMacro, sSub, sMicro);
                    micro.State_Setup(dFloatData, Int32.Parse(sState));
                }
            }
        }

        public static int[] BlockSizes(string fileName)
        {
            int iMacroXCount = 0;
            int iMacroYCount = 0;
            int iSubXCount = 0;
            int iSubYCount = 0;
            int iMicroXCount = 0;
            int iMicroYCount = 0;

            int[] arrCounts = new int[6];

            using (var sr = new StreamReader(fileName))
            {
                while (sr.Peek() >= 0)
                {
                    string sLine;
                    string[] sArrData;
                    sLine = sr.ReadLine();

                    sArrData = sLine.Split(',');

                    int iMacroX = Int32.Parse(sArrData[0].Substring(1, sArrData[0].Length - 1));
                    int iMacroY = Int32.Parse(sArrData[1].Substring(0, sArrData[1].LastIndexOf('"')));

                    if (iMacroX > iMacroXCount)
                    {
                        iMacroXCount = iMacroX;
                        arrCounts[0] = iMacroXCount;
                    }
                    if (iMacroY > iMacroYCount)
                    {
                        iMacroYCount = iMacroY;
                        arrCounts[1] = iMacroYCount;
                    }

                    int iSubX = Int32.Parse(sArrData[2].Substring(1, sArrData[2].Length - 1));
                    int iSubY = Int32.Parse(sArrData[3].Substring(0, sArrData[3].LastIndexOf('"')));

                    if (iSubX > iSubXCount)
                    {
                        iSubXCount = iSubX;
                        arrCounts[2] = iSubXCount;
                    }
                    if (iSubY > iSubYCount)
                    {
                        iSubYCount = iSubY;
                        arrCounts[3] = iSubYCount;
                    }

                    int iMicroX = Int32.Parse(sArrData[4].Substring(1, sArrData[4].Length - 1));
                    int iMicroY = Int32.Parse(sArrData[5].Substring(0, sArrData[5].LastIndexOf('"')));

                    if (iMicroX > iMicroXCount)
                    {
                        iMicroXCount = iMicroX;
                        arrCounts[4] = iMicroXCount;
                    }
                    if (iMicroY > iMicroYCount)
                    {
                        iMicroYCount = iMicroY;
                        arrCounts[5] = iMicroYCount;
                    }
                }
            }
            return arrCounts;
        }
        #endregion

        #region XML File
        public static void ReadGridDataFromFile(GridControls_Create grid, DataTable gridData)
        {
            foreach (DataRow dr in gridData.Rows)
            {
                double dValue;
                string sMacro = dr["Macro Block Name (Grid One)"].ToString().Replace(',', '_');
                string sSub = dr["Sub Block Name (Grid Two)"].ToString().Replace(',', '_');
                string sMicro = dr["Micro Block Name (Grid Three)"].ToString().Replace(',', '_');
                string sValue = dr["Value"].ToString();
                string sProgressState = dr["FKProgressState"].ToString();

                if (sValue == "")
                     dValue = 0;
                else dValue = Double.Parse(sValue);

                IGridBlock_Base micro = grid.Cuboid.GetChild_MicroGridBlock(sMacro, sSub, sMicro);
                micro.State_Setup(dValue, Int32.Parse(sProgressState));
            }
        }

        public static int[] BlockSizes(DataTable gridData)
        {
            int[] arrCounts = {0, 0, 0, 0, 0, 0};

            foreach (DataRow dr in gridData.Rows)
            {           
                arrCounts[0] = CompareSizes(dr, 0, 0, 1, arrCounts[0], arrCounts, ref arrCounts[1]);

                arrCounts[2] = CompareSizes(dr, 1, 2, 3, arrCounts[2], arrCounts, ref arrCounts[3]);

                arrCounts[4] = CompareSizes(dr, 2, 4, 5, arrCounts[4], arrCounts, ref arrCounts[5]);
            }

            return arrCounts;
        }

        private static int CompareSizes(DataRow dr, int drPos, int arrPosX, int arrPosY, int iXCount, int[] arrCounts, ref int iYCount)
        {
            string sBlock = dr[drPos].ToString();
            string[] sArrData = sBlock.Split(',');

            if (int.Parse(sArrData[0]) > iXCount)
            {
                iXCount = int.Parse(sArrData[0]);
                arrCounts[arrPosX] = iXCount;
            }
            if (int.Parse(sArrData[1]) > iYCount)
            {
                iYCount = int.Parse(sArrData[1]);
                arrCounts[arrPosY] = iYCount;
            }
            return iXCount;
        }

        #endregion

    }
}
