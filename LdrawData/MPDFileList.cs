using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace LdrawData
{
    class MPDSubPart
    {
        public String filename { get; set; }
        public String data { get; set; }
        public StreamReader getDataStreamReader()
        {
            String a = new String(data.ToCharArray());// make new copy
            MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(a));
            return new StreamReader(stream);
        }
    }

    public class MPDFileList
    {
        private MPDSubPart firstPart = null;
        private List<MPDSubPart> subparts = new List<MPDSubPart>();

        // If filename is null, its root file.
        // Gets streams of subpart if not null.
        // returns null if failed.
        public StreamReader getMPDSubpart(String file)
        {
            if (file == null)
            {
                return firstPart.getDataStreamReader();
            }
            else
            {
                foreach (MPDSubPart sub in subparts)
                {
                    if (sub.filename.ToLower().CompareTo(file.ToLower()) == 0)
                    {
                        // found MPD subpart.
                        return sub.getDataStreamReader();
                    }
                }
            }
            // Not found. Probably real file somewhere.
            return null;
        }

        public MPDFileList(String mpdfile)
        {
            String line = "";
            String[] lines;
            String[] space = { " " };// Used for split line
            bool first = true;

            // Open file, read all of it, making firstpart and rest of other parts
            if (!File.Exists(mpdfile))
            {
                Debug.WriteLine("No file found!");
                return;
            }
            StreamReader mpdRead = new StreamReader(mpdfile);
            if (mpdRead == null)
            {
                Debug.WriteLine("failed on streamline");
                return;
            }
            // Now create mpdsubpart
            MPDSubPart sub = new MPDSubPart();
            firstPart = sub;
            sub.data = "";
            line = mpdRead.ReadLine();
            while (line != null)
            {
                lines = line.Split(space, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length > 2 && lines[0].CompareTo("0") == 0 && lines[1].CompareTo("FILE") == 0)
                {
                    // if its not first subpart, make next one. if it is, just keep adding parts
                    // Because MPD format specify that main part also has a filename parameter.

                    String ff = lines[2];

                    // In rare cases, there are spaces in filename!
                    if (lines.Length > 3)
                    {
                        for (int q = 3; q < lines.Length; q++)
                            ff = ff + " " + lines[q];
                    }

                    if (!first)
                    {
                        Debug.WriteLine("subpart! name is " + ff);

                        subparts.Add(sub);
                        //Now make new subpart and set it.
                        sub = new MPDSubPart();
                        sub.data = "";
                    }
                    sub.filename = ff; // Set filename (always third parameter after 0 FILE).
                    first = false;           // Now that we got first filename (root one), set to false so new filename line means ts a submodel.
                }
                else
                {
                    // Add current line to current subfile.
                    sub.data = sub.data + "\n" + line;
                }
                line = mpdRead.ReadLine();
            }
            //Now close the final subpart, only if its NOT same as firstpart.
            if (firstPart != sub)
            {
                subparts.Add(sub);
            }

            // okay now check whats in the data files...
            //Debug.WriteLine("contents of firstfile:##########################################################");
            //Debug.WriteLine(firstPart.data);
            //foreach (MPDSubPart ssub in subparts)
            //{
            //    Debug.WriteLine("contents of aubpart " + ssub.filename + ":##########################################################");
            //    Debug.WriteLine(ssub.data);
            //}
        }
    }
}
