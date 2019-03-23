using System;
using System.IO;

namespace PlastesDe
{
    /// <summary>
    /// Speichert Texte in einer Datei ab. Open Close Automatik.
    /// </summary>
    class TextFile
    {
        ///<summary>
        /// Liefert den Inhalt der Datei zurück.
        ///</summary>
        ///<param name="sFilename">Dateipfad</param>
        public string ReadFile(String sFilename)
        {
            string sContent = "";

            if (File.Exists(sFilename))
            {
                StreamReader sr = null;
                try
                {
                    sr = new StreamReader(sFilename, System.Text.Encoding.Default);
                    sContent = sr.ReadToEnd();
                    sr.Close();
                }
                catch (IOException) { }
                finally
                {
                    if (sr != null)
                    {
                        sr.Close();
                    }
                }
            }
            return sContent;
         } // ReadFile()


        ///<summary>
        /// Schreibt den übergebenen Inhalt in eine Textdatei ohne Zeilenvorschub.
        ///</summary>
        ///<param name="sFilename">Pfad zur Datei</param>
        ///<param name="sLines">zu schreibender Text</param>
        public bool WriteFile(String sFilename, String sLines)
        {
            StreamWriter sw = null;
            bool bReturn = true;

            try
            {
                sw = new StreamWriter(sFilename);
                sw.Write(sLines);
                sw.Close();
            }
            catch (IOException)
            {
                bReturn = false;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }
            }

            return bReturn;
        } // WriteFile()


        /// <summary>
        /// Schreibt den übergebenen Inhalt in eine Textdatei mit Zeilenvorschub.
        /// </summary>
        /// <param name="sFilename"></param>
        /// <param name="sLines"></param>
        /// <returns></returns>
        public bool WriteLine(String sFilename, String sLines)
        {
            StreamWriter sw = null;
            bool bReturn = true;

            try
            {
                sw = new StreamWriter(sFilename);
                sw.Write(sLines);
                sw.Write("\r\n");
                sw.Close();
            }
            catch (IOException)
            {
                bReturn = false;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }
            }

            return bReturn;
        } // WriteLine()


        ///<summary>
        /// Fügt den übergebenen Text an das Ende einer Textdatei an ohne Zeilenvorschub.
        ///</summary>
        ///<param name="sFilename">Pfad zur Datei</param>
        ///<param name="sLines">anzufügender Text</param>
        public bool Append(string sFilename, string sLines)
        {
            StreamWriter sw = null;
            bool bReturn = true;

            try
            {
                sw = new StreamWriter(sFilename, true);
                sw.Write(sLines);
                sw.Close();
            }
            catch (IOException)
            {
                bReturn = false;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }
            }

            return bReturn;
        } // Append()


        /// <summary>
        /// Fügt den übergebenen Text an das Ende einer Textdatei an mit Zeilenvorschub.
        /// </summary>
        /// <param name="sFilename"></param>
        /// <param name="sLines"></param>
        /// <returns></returns>
        public bool AppendLine(string sFilename, string sLines)
        {
            StreamWriter sw = null;
            bool bReturn = true;

            try
            {
                sw = new StreamWriter(sFilename, true);
                sw.Write(sLines);
                sw.Write("\r\n");
                sw.Close();
            }
            catch (IOException)
            {
                bReturn = false;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }
            }

            return bReturn;
        } // AppendLine()


        ///<summary>
        /// Liefert den Inhalt der übergebenen Zeilennummer zurück.
        ///</summary>
        ///<param name="sFilename">Pfad zur Datei</param>
        ///<param name="iLine">Zeilennummer</param>
        public string ReadLine(String sFilename, int iLine)
        {
            StreamReader sr = null;
            string sContent = "";
            float fRow = 0;

            if (File.Exists(sFilename))
            {
                try
                {
                    sr = new StreamReader(sFilename, System.Text.Encoding.Default);
                    while (!sr.EndOfStream && fRow < iLine)
                    {
                        fRow++;
                        sContent = sr.ReadLine();
                    }
                    sr.Close();
                    if (fRow < iLine)
                    {
                        sContent = "";
                    }
                }
                catch (IOException) { }
                finally
                {
                    if (sr != null)
                    {
                        sr.Close();
                    }
                }
            }
            return sContent;
        } // ReadLine()


        /// <summary>
        /// Schreibt den übergebenen Text in eine definierte Zeile.
        ///</summary>
        ///<param name="sFilename">Pfad zur Datei</param>
        ///<param name="iLine">Zeilennummer</param>
        ///<param name="sLines">Text für die übergebene Zeile</param>
        ///<param name="bReplace">Text in dieser Zeile überschreiben (t) oder einfügen (f)</param>
        public bool WriteLine(String sFilename, int iLine, string sLines, bool bReplace)
        {
            StreamReader sr = null;
            string sContent = "";
            string[] delimiterstring = { "\r\n" };
            bool bReturn = true;

            if (File.Exists(sFilename))
            {
                try
                {
                    sr = new StreamReader(sFilename, System.Text.Encoding.Default);
                    sContent = sr.ReadToEnd();
                    sr.Close();
                }
                catch (IOException)
                {
                    bReturn = false;
                }
                finally
                {
                    if (sr != null)
                    {
                        sr.Close();
                    }
                }
            }

            string[] sCols = sContent.Split(delimiterstring, StringSplitOptions.None);

            if (sCols.Length >= iLine)
            {
                if (!bReplace)
                    sCols[iLine - 1] = sLines + "\r\n" + sCols[iLine - 1];
                else
                    sCols[iLine - 1] = sLines;

                sContent = "";
                for (int x = 0; x < sCols.Length - 1; x++)
                {
                    sContent += sCols[x] + "\r\n";
                }
                sContent += sCols[sCols.Length - 1];
            }
            else
            {
                for (int x = 0; x < iLine - sCols.Length; x++)
                {
                    sContent += "\r\n";
                }
                sContent += sLines;
            }

            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(sFilename);
                sw.Write(sContent);
                sw.Close();
            }
            catch (IOException)
            {
                bReturn = false;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }
            }

            return bReturn;
        } // WriteLine()

    } // class TextFile
}
