namespace HerkesYazarOlsun.BLL.Helper
{
    public class FileUploadHelper
    {
        public static string MimTypeGetir(string uzanti)
        {
            string mimtype = "";
            switch (uzanti)
            {
                case "dwg": { mimtype = "application/acad"; break; }
                case "ncz": { mimtype = "application/ncz"; break; }
                case "yde": { mimtype = "application/yde"; break; }
                case "rw5": { mimtype = "application/rw5"; break; }
                case "ncn": { mimtype = "application/ncn"; break; }
                case "gsi": { mimtype = "application/gsi"; break; }
                case "ham": { mimtype = "application/ham"; break; }
                case "raw": { mimtype = "application/raw"; break; }
                case "mjf": { mimtype = "application/mjf"; break; }
                case "pdf": { mimtype = "application/pdf"; break; }
                case "xls": { mimtype = "application/excel"; break; }
                case "txt": { mimtype = "text/plain"; break; }
                case "xlsx": { mimtype = "application/vnd.ms-excel"; break; }
                case "jpg": { mimtype = "image/jpeg"; break; }
                case "jpeg": { mimtype = "image/jpeg"; break; }
                case "png": { mimtype = "image/png"; break; }
                case "dxf": { mimtype = "application/dxf"; break; }
                case "dgn": { mimtype = "application/dgn"; break; }
                case "csv": { mimtype = "application/csv"; break; }
                case "tab": { mimtype = "application/tab"; break; }
                case "shp": { mimtype = "application/shp"; break; }
                case "shx": { mimtype = "application/shx"; break; }
                case "prj": { mimtype = "application/prj"; break; }
                case "map": { mimtype = "application/map"; break; }
                case "id": { mimtype = "application/id"; break; }
                case "dat": { mimtype = "application/dat"; break; }
                case "dtm": { mimtype = "application/dtm"; break; }
                case "ktm": { mimtype = "application/ktm"; break; }
                case "3dm": { mimtype = "application/3dm"; break; }
                case "koo": { mimtype = "application/koo"; break; }
                case "xyz": { mimtype = "application/xyz"; break; }
                case "tbl": { mimtype = "application/tbl"; break; }
                case "axy": { mimtype = "application/axy"; break; }
                case "pol": { mimtype = "application/pol"; break; }
                case "sem": { mimtype = "application/sem"; break; }
                case "nno": { mimtype = "application/nno"; break; }
                case "tracyjob": { mimtype = "application/tracyjob"; break; }
                case "nmea": { mimtype = "application/nmea"; break; }
                case "rte": { mimtype = "application/rte"; break; }
                case "upt": { mimtype = "application/upt"; break; }
                case "log": { mimtype = "application/log"; break; }
                case "ymk": { mimtype = "application/ymk"; break; }
                case "gps": { mimtype = "application/gps"; break; }
                case "yyt": { mimtype = "application/yyt"; break; }
                case "01o": { mimtype = "application/01o"; break; }
                case "mfj": { mimtype = "application/mfj"; break; }
                case "tsj": { mimtype = "application/tsj"; break; }
                case "job": { mimtype = "application/job"; break; }
                case "dbx": { mimtype = "application/dbx"; break; }
                case "jxl": { mimtype = "application/jxl"; break; }
                case "ssf": { mimtype = "application/ssf"; break; }
                case "kml": { mimtype = "application/kml"; break; }
                case "kmz": { mimtype = "application/kmz"; break; }
                case "str": { mimtype = "application/str"; break; }
                case "adf": { mimtype = "application/adf"; break; }
                case "mif": { mimtype = "application/mif"; break; }
                case "gst": { mimtype = "application/gst"; break; }
                case "imd": { mimtype = "application/imd"; break; }
                case "lpk": { mimtype = "application/lpk"; break; }
                case "pmf": { mimtype = "application/pmf"; break; }
                case "pos": { mimtype = "application/pos"; break; }
                case "rinex": { mimtype = "application/rinex"; break; }
                case "rtk": { mimtype = "application/rtk"; break; }
                case "geo": { mimtype = "application/geo"; break; }
                case "asc": { mimtype = "application/asc"; break; }
                case "xml": { mimtype = "application/xml"; break; }
                case "gts": { mimtype = "application/gts"; break; }
                case "sdr": { mimtype = "application/sdr"; break; }
                case "gts6": { mimtype = "application/gts6"; break; }
                case "gts7": { mimtype = "application/gts7"; break; }
                case "gt7": { mimtype = "application/gt7"; break; }
                case "rpb": { mimtype = "application/rpb"; break; }
                case "bse": { mimtype = "application/bse"; break; }
                case "pun": { mimtype = "application/pun"; break; }
                case "eyp": { mimtype = "application/eyp"; break; }
                case "doc": { mimtype = "application/msword"; break; }
                case "rar": { mimtype = "application/rar"; break; }
                case "docx": { mimtype = "application/vnd.openxmlformats-officedocument.wordprocessingml.document"; break; }
                default:
                    mimtype = "application/" + uzanti;
                    break;
            }
            return mimtype;
        }
    }
}
